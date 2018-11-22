using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour {

    AudioSource a;

    public static int frameSize = 512;
    public static float[] spectrum;
    public static float[] bands;

    public float binWidth;
    public float sampleRate;

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
    }

    // Use this for initialization
    void Start () {
        
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;

        int last = 0;
        for (int i = 0; i < bands.Length; i++)
        {
            int current = (int) Mathf.Pow(2, i + 1);
            Debug.Log(i + "\t" + current + "\t" + last + "\t" + last * binWidth + "\t" + current * binWidth);
            last = current;
        }
    }

    void GetFrequencyBands()
    {        
        int last = 0;
        for (int i = 0; i < bands.Length; i++)
        {
            int current = (int)Mathf.Pow(2, i + 1);
            float average = 0;
            for (int j = last; j < current; j++)
            {
                average += spectrum[j] * (j + 1);
            }
            int count = current;
            average /= (float) count;
            bands[i] = average;
            last = current;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        a.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        GetFrequencyBands();
    }
}
