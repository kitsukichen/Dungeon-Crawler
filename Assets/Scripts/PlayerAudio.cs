using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackAudio;
    public AudioClip footstepAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        audioSource.clip = attackAudio;
        audioSource.Play();
    }

    public void PlayWalkAudio()
    {
        audioSource.clip = footstepAudio;
        audioSource.Play();
    }
}
