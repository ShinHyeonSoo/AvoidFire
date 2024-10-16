using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Sound
{
    Bgm,
    Sfx,
    Max,
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [SerializeField] private Slider _sliderBgm;
    [SerializeField] private Slider _sliderSfx;

    private AudioSource[] _audioSources = new AudioSource[(int)Sound.Max];
    private Dictionary<string, AudioClip> _audioClipDic = new Dictionary<string, AudioClip>();

    public float BgmVolume {  get; set; }
    public float SfxVolume {  get; set; }

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Init();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        Setup();
        RemoveDuplicates();
    }

    private static void Init()
    {
        if (_instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(SoundManager).Name;
            _instance = gameObj.AddComponent<SoundManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

    private void Setup()
    {
        string[] soundNames = System.Enum.GetNames(typeof(Sound)); // "Bgm", "Sfx"
        for (int i = 0; i < soundNames.Length - 1; i++)
        {
            GameObject go = new GameObject { name = soundNames[i] };
            _audioSources[i] = go.AddComponent<AudioSource>();
            go.transform.parent = transform;
        }

        BgmVolume = 0.5f;
        SfxVolume = 0.5f;
        _audioSources[(int)Sound.Bgm].loop = true; // bgm 재생기는 무한 반복 재생

        LoadSounds();
    }

    private void LoadSounds()
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Sounds/Bgm");
        
        for(int i = 0; i < audioClips.Length; ++i)
        {
            _audioClipDic.Add(audioClips[i].name, audioClips[i]);
        }

        audioClips = Resources.LoadAll<AudioClip>("Sounds/Sfx");

        for (int i = 0; i < audioClips.Length; ++i)
        {
            _audioClipDic.Add(audioClips[i].name, audioClips[i]);
        }
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Clear()
    {
        // 재생기 전부 재생 스탑, 음반 빼기
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // 효과음 Dictionary 비우기
        _audioClipDic.Clear();
    }

    public void Play(AudioClip audioClip, Sound type)
    {
        if (audioClip == null)
            return;

        if (type == Sound.Bgm) // BGM 배경음악 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.volume = BgmVolume;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else // Sfx 효과음 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.Sfx];
            audioSource.volume = SfxVolume;
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Play(string audioName, Sound type)
    {
        if (_audioClipDic[audioName] == null)
            return;

        if (type == Sound.Bgm) // BGM 배경음악 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.volume = BgmVolume;
            audioSource.clip = _audioClipDic[audioName];
            audioSource.Play();
        }
        else // Sfx 효과음 재생
        {
            AudioSource audioSource = _audioSources[(int)Sound.Sfx];
            audioSource.volume = SfxVolume;
            audioSource.PlayOneShot(_audioClipDic[audioName]);
        }
    }

    public AudioClip GetAudioClip(string name)
    {
        return _audioClipDic[name];
    }

    public void TestPlaySFX(string name)
    {
        AudioSource audioSource = _audioSources[(int)Sound.Sfx];
        audioSource.volume = SfxVolume;
        audioSource.PlayOneShot(_audioClipDic[name]);
    }

    public void SetVolume()
    {
        BgmVolume = _sliderBgm.value;
        SfxVolume = _sliderSfx.value;

        _audioSources[(int)Sound.Bgm].volume = BgmVolume;
        _audioSources[(int)Sound.Sfx].volume = SfxVolume;
    }
}
