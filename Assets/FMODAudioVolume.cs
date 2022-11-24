//using System.Collections; 
//using System.Collections.Generic; 

using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMODAudioVolume : MonoBehaviour
{
	public StudioEventEmitter emitter;
	public EventInstance instance;
	public float volume;

	//public AudioSource audioSource; // FMOD audio source?
	public float updateStep = 0.1f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;

	//public float clipLoudness;
	private float[] clipSampleData;

	public GameObject cube;
	public float sizeFactor = 1;

	public float minSize = 0;
	public float maxSize = 500;

	// Use this for initialization
	private void Awake()
	{
		instance = emitter.EventInstance;
		clipSampleData = new float[sampleDataLength];
	}

	// Update is called once per frame
	private void Update()
	{
		currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep)
		{
			//currentUpdateTime = 0f;
			//audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			//clipLoudness = 0f;

			//currentUpdateTime = 0f;
			//instance.clip.GetData(clipSampleData, instance.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			//volume = 0f;

			instance.getVolume(out float volume);
			foreach (var sample in clipSampleData)
			{
				//clipLoudness += Mathf.Abs(sample);
				volume += Mathf.Abs(sample);
			}
			//clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for // Replace with FMOD equivalence

			//clipLoudness *= sizeFactor;
			//clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
			//cube.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);

			volume /= sampleDataLength; //clipLoudness is what you are looking for // Replace with FMOD equivalence

			volume *= sizeFactor;
			volume = Mathf.Clamp(volume, minSize, maxSize);
			cube.transform.localScale = new Vector3(volume, volume, volume);
		}
	}
}