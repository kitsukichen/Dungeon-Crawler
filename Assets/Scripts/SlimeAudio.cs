using UnityEngine;

public class SlimeAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip idleAudio;
    public AudioClip walkAudio;
    public AudioClip attackAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayIdleAudio()
    {
        audioSource.clip = idleAudio;
        audioSource.Play();
    }

    public void PlayAttackSound()
    {
        audioSource.clip = attackAudio;
        audioSource.Play();
    }
    public void PlayWalkSound()
    {
        audioSource.clip = walkAudio;
        audioSource.Play();
    }
}
