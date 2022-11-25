using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODloudness : MonoBehaviour
{



    public float[] volumeLevel;

    FMOD.ChannelGroup masterChannelGroup;
    FMOD.DSP dsp;
    FMOD.DSP_METERING_INFO dspInfo;

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
    }
}
