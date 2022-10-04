using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Singleton Instance
    public static SoundManager Instance { get; private set; }

    //Player moving sounds
    public AudioSource[] playerMoving;
    private bool initialThrust;
    //Player shooting sounds
    public AudioSource playerShoot;
    //Player death sounds
    public AudioSource playerExplosion1;
    public AudioSource playerExplosion2;  
    //Asteroid explosion sounds
    public AudioSource asteroidExplosion1;
    public AudioSource asteroidExplosion2;
    //Music sounds
    public AudioSource music;
    public AudioSource ambience;
    

    //Destroy if more than 1 instance exists
    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            music.Play();
            ambience.Play();
        }
    }
    private void Start()
    {
        initialThrust = false;

    }

    public void PlayMovingSounds()
    {
        //Play intial boost sound and continous moving sound
        if (playerMoving[1].isPlaying && initialThrust)
        {
            return;
        }
        else
        {
            //Randomises pitch values and plays sounds
            if (!initialThrust)
            {
                float randomPitch1 = Random.Range(0.6f, 1.7f);
                playerMoving[0].pitch = randomPitch1;
                playerMoving[0].Play();
                initialThrust = true;
            }
            float randomPitch2 = Random.Range(0.6f, 1.7f);
            playerMoving[1].pitch = randomPitch2;
            playerMoving[1].Play();
        }
    }
    public void StopMovingSounds()
    {
        initialThrust = false;
        //Stop sounds if playing when player is not moving
        if (!playerMoving[1].isPlaying)
        {
            return;
        }
        else
        {
            playerMoving[0].Stop();
            playerMoving[1].Stop();
        }
    }
    public void PlayShootingSounds()
    {
        //Randomises pitch and plays shooting sound
        float randomPitch = Random.Range(.6f, 1.7f);
        playerShoot.pitch = randomPitch;
        playerShoot.Play();
    }
    public void PlayPlayerDeathSound()
    {
        //Plays standard death sounds if lives remain
        if (P_Lives.livesRemaining >= 1)
        {
            if (playerExplosion1.isPlaying)
            {
                return;
            }
            else
            {
                playerExplosion1.Play();
            }
        }
        //Plays final death sound upon dying with no lioves left
        else
        {
            if (playerExplosion2.isPlaying)
            {
                return;
            }
            else
            {
                playerExplosion2.Play();
            }
        }
    }

    public void PlayAsteroidDestroySound()
    {
        //Randomly chooses between 2 sounds to play when asteroid is destroyed
        int soundChoice = Random.Range(1, 3);
        if (soundChoice == 1)
        {
            asteroidExplosion1.Play();
        }
        else
        {
            asteroidExplosion2.Play();
        }
    }

}
