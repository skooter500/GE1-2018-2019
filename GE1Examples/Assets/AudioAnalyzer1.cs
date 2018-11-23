using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer1 : MonoBehaviour {
    AudioSource audioSource;
    public static int frameSize = 512;
    public static float[] spectrum;
    public static float[] bands;

    public bool useMic = false;
    public AudioClip clip;
    public string deviceName;

    public AudioMixerGroup amgMain;
    public AudioMixerGroup amgMic;


    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize, 2)];

        if (useMic)
        {
            if (Microphone.devices.Length > 0)
            {
                deviceName = Microphone.devices[0].ToString();
                audioSource.clip = Microphone.Start(deviceName, true, 10, AudioSettings.outputSampleRate);
                audioSource.outputAudioMixerGroup = amgMic;
            }
        }
        else
        {
            audioSource.clip = clip;
            audioSource.outputAudioMixerGroup = amgMain;
        }
        audioSource.Play();
	}

    void GetBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            int start = (int) Mathf.Pow(2, i) - 1;
            int width = (int) Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for (int j = start; j < end; j++)
            {
                average += spectrum[j] * (j + 1); 
            }
            average /= width;
            bands[i] = average;
        }
    }
	
	// Update is called once per frame
	void Update () {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        GetBands();
	}
}
