using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : GameManager
{
    [Serializable]
    public struct KeyValuePair
    {
        public string musicName;
        public AudioClip audioClip;
    }

    public List<KeyValuePair> soundList = new List<KeyValuePair>();
    public List<KeyValuePair> trackList = new List<KeyValuePair>();
    public List<KeyValuePair> dialogueList = new List<KeyValuePair>();

    [SerializeField] private Dictionary<string, AudioClip> allSounds = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> allTracks = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> allDialogue = new Dictionary<string, AudioClip>();


    //Initialize Dictionaries
    private void Awake()
    {
        foreach (KeyValuePair SMD in soundList)
        {
            allSounds[SMD.musicName] = SMD.audioClip;
        }
        foreach (KeyValuePair SMD in trackList)
        {
            allTracks[SMD.musicName] = SMD.audioClip;
        }
        foreach (KeyValuePair SMD in dialogueList)
        {
            allDialogue[SMD.musicName] = SMD.audioClip;
        }
    }

    //Find needed audio clip
    public AudioClip getAudioClip(string musicType, string musicName)
    {
        AudioClip clip = null;
        switch (musicType)
        {
            case "Sound": clip = allSounds[musicName]; break;
            case "Track": clip = allTracks[musicName]; break;
            case "Dialogue": clip = allDialogue[musicName]; break;
        }

        return clip;
    }
}
