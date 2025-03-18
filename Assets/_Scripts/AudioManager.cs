using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]

    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Audio Clips")]

    public AudioClip breakClip;
    public AudioClip bounceClip;
    public AudioClip wallBounceClip;
    public AudioClip deathClip;
    public AudioClip musicClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        PlayMusic();
    }

   public void PlayMusic()
    {
        if (musicSource != null && musicSource != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }



    public void PlaySound(AudioClip clip)
    {
        if(clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }


}
