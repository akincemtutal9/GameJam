using UnityEngine;

public class SFXPlaying : MonoBehaviour  
{
    public static AudioSource attack1;
    public static AudioSource attack2;
    public static AudioSource enemydie;
    public static AudioSource characterdie;
    public static AudioSource menumusic;

    public static void PlayAttack1()
    {
        attack1.Play();
    }

    public static void PlayAttack2()
    {
        attack2.Play();
    }

    public static void PlayEnemyDie()
    {
        enemydie.Play();
    }

    public static void PlayCharacterDie()
    {
        characterdie.Play();
    }

    public static void PlayMenuMusic()
    {
        menumusic.Play();
    }
}
