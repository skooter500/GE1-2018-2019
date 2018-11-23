using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour {

    public bool useMic = false;
    public AudioClip clip;
    AudioSource a;
    public AudioMixerGroup amgMic;
    public AudioMixerGroup amgMaster;

    public string selectedDevice;

    public static int frameSize = 512;
    public static float[] spectrum;
    public static float[] bands;

    public static float[] bandBuffer;
    float[] bufferDecrease;

    public float binWidth;
    public float sampleRate;

    float[] bandHighest;
    public static float[] normalisedBands;
    
    /*
     * 20-60 - Subbase
     * 60-250 - Bass
     * 250-500 - Low midrange
     * 500 - 2Khz - Midrange
     * 2Khz - 4Khz - Upper midrange
     * 4Khz - 6Khz - Presence
     * 6Khz - 20Khz - Brilliance
     */

    private void Awake()
    {
        a = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        bands = new float[(int) Mathf.Log(frameSize, 2)];
        //bands = new float[8];
        
        bandBuffer = new float[bands.Length];
        bufferDecrease = new float[bands.Length];

        bandHighest = new float[bands.Length];
        normalisedBands = new float[bands.Length];

        if (useMic)
        {
            if (Microphone.devices.Length > 0)
            {
                selectedDevice = Microphone.devices[0].ToString();
                a.clip = Microphone.Start(selectedDevice, true, 1, AudioSettings.outputSampleRate);
                a.outputAudioMixerGroup = amgMic;
            }
        }
        else
        {
            a.clip = clip;
            a.outputAudioMixerGroup = amgMaster;
        }
        a.Play();
    }

    // Use this for initialization
    void Start () {
        
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;
        int last = 0;
    }

    // See:
    // https://www.youtube.com/watch?v=mHk3ZiKNH48

    void GetBandBuffer()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            if (bands[i] > bandBuffer[i])
            {
                bandBuffer[i] = bands[i];
                bufferDecrease[i] = 0.005f;
            }
            else if (bands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void GetNormalizedBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            if (bands[i] > bandHighest[i])
            {
                bandHighest[i] = bands[i];
            }
            if (bandHighest[i] != 0)
            {
                normalisedBands[i] = bands[i] / bandHighest[i];
            }
        }
    }

    
    /*
        void GetFrequencyBands()
        {
            int count = 0;

            // 22050 / 512 = 43Hz per sample?
            float binWidth = 43;
            for (int i = 0; i < 8; i++)
            {
                float average = 0;
                int sampleCount = (int)Mathf.Pow(2, i) * 2;
                if (i == 7)
                {
                    sampleCount += 2;
                }
                int nextCount = count + (sampleCount);
                //Debug.Log(i + "\t" + count + "\t" + nextCount + "\t" + (count * binWidth) + "\t" + nextCount * binWidth);

                for (int j = 0; j < sampleCount; j++)
                {
                average += spectrum[count] * (count + 1);
                    count++;
                }
                average /= count;
                bands[i] = average;
            }
        }
        */

    
        void GetFrequencyBands()
    {        
        for (int i = 0; i < bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for (int j = start; j < end; j++)
            {
                average += spectrum[j];
            }
            average /= (float) width;
            bands[i] = average;
            //Debug.Log(i + "\t" + start + "\t" + end + "\t" + start * binWidth + "\t" + (end * binWidth));
        }

    }
    
    
    // Update is called once per frame
    void Update () {
        a.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        GetFrequencyBands();
        GetBandBuffer();
        GetNormalizedBands();
    }
}
