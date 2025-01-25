using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource musicSource;

    [SerializeField]
    public AudioSource SFXSource;

    public AudioClip music;
    public AudioClip onHover;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void HoverSound()
    {
        SFXSource.PlayOneShot(onHover);
    }

    public void ClickSound()
    {
        SFXSource.PlayOneShot(click);
    }
}
