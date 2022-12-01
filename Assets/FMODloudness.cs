using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODloudness : MonoBehaviour
{

    [SerializeField] float volumeCoefficient; 

    float animationLerpTimer = 0;

    float animationLerpStartValue;

    float animationLerpCurrentValue;

    public float[] volumeLevel;

    FMOD.ChannelGroup masterChannelGroup;
    FMOD.DSP dsp;
    FMOD.DSP_METERING_INFO dspInfo;

    public GameObject speaker;

    // Start is called before the first frame update
    void Start()
    {
        RuntimeManager.CoreSystem.getMasterChannelGroup(out masterChannelGroup);
        masterChannelGroup.getDSP(0, out dsp);
        dsp.setMeteringEnabled(true, true);
    }

    // Update is called once per frame
    void Update()
    {
        dsp.getMeteringInfo(System.IntPtr.Zero, out dspInfo);
        volumeLevel = dspInfo.peaklevel;
        AnimateSpeaker(volumeLevel);
    }

    void AnimateSpeaker(float[] volumeLevel)
    {
        //get avg of channel levels 
        float avgLevel = volumeCoefficient * (volumeLevel[0] + volumeLevel[1]) / 2;
        float maxLevel = 1.3f;
        float minLevel = 0.7f;

        if (animationLerpCurrentValue > avgLevel)
        {
            //Keep lerping
            
            speaker.transform.localScale = Vector3.one * animationLerpCurrentValue;
            animationLerpTimer += Time.deltaTime * 2f;
            animationLerpCurrentValue = Mathf.Lerp(animationLerpStartValue, minLevel, animationLerpTimer);


        } else
        {
            float clampedVolume = Mathf.Clamp(avgLevel, minLevel, maxLevel);
            speaker.transform.localScale = Vector3.one * clampedVolume;

            animationLerpStartValue = clampedVolume;
            animationLerpCurrentValue = clampedVolume;
            animationLerpTimer = 0;
        }

        
    }

}
