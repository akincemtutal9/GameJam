using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip attack1Clip;  // audio clip for first attack
    public AudioClip attack2Clip;  // audio clip for second attack
    public AudioClip characterDieClip;  // audio clip for character death
    public AudioClip enemyDieClip;  // audio clip for enemy death

    private AudioSource audioSource;

    private void Start()
    {
        // get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttack1()
    {
        // play the audio clip for first attack
        audioSource.clip = attack1Clip;
        audioSource.Play();
    }

    public void PlayAttack2()
    {
        // play the audio clip for second attack
        audioSource.clip = attack2Clip;
        audioSource.Play();
    }

    public void PlayCharacterDie()
    {
        // play the audio clip for character death
        audioSource.clip = characterDieClip;
        audioSource.Play();
    }

    public void PlayEnemyDie()
    {
        // play the audio clip for enemy death
        audioSource.clip = enemyDieClip;
        audioSource.Play();
    }
}
