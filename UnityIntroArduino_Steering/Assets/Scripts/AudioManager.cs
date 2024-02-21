using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioID
    {
        EXPLOSION = 0,
    }

    private static AudioManager instance;//singleTon Member variable

    public static AudioManager Instance//singleTon access property
    {
        get { return instance; }
    }

    private void Awake()//singleton instance creation on awake (when object is first created)
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject); //optional if it needs to exist across different scenes
    }

    public AudioSource[] setPredefClips;
    private static AudioSource[] predefinedClips;

    // Start is called before the first frame update
    void Start()
    {
        predefinedClips = setPredefClips;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayClipOnce(AudioSource audioS)
    {
        audioS.Play();
    }

    public void StartClipLoop(AudioSource audioS)
    {
        audioS.loop = true;
        audioS.Play();
    }
    public void StopClipLoop(AudioSource audioS)
    {
        audioS.Stop();
    }
    public void PlayClipOnce(AudioID id)
    {
        predefinedClips[(int)id].Play();
    }

    public void StartClipLoop(AudioID id)
    {
        predefinedClips[(int)id].loop = true;
        predefinedClips[(int)id].Play();
    }
    public void StopClipLoop(AudioID id)
    {
        predefinedClips[(int)id].Stop();
    }


}
