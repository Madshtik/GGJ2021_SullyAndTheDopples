using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct AudioDict
{
    public AudioClip clip;
    public string key;

    [TextArea(5, 10)]
    public string subtitles;
}

public class AudioFetcher : MonoBehaviour
{
    public List<AudioDict> audioDicts;

    public AudioSource source;

    public Text subtitles;

    static AudioFetcher _instance;

    public static AudioFetcher Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioFetcher>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Fetch(string key)
    {
        for (int i = 0; i < audioDicts.Count; i++)
        {
            if (audioDicts[i].key == key)
            {
                source.clip = audioDicts[i].clip;
                subtitles.text = audioDicts[i].subtitles;
            }
        }
        source.Play();
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }
}
