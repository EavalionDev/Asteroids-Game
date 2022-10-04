using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_CollisionDetection : MonoBehaviour
{
    private P_MoveForward playerMovementClass;

    private void Start()
    {
        playerMovementClass = GetComponent<P_MoveForward>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player hit by asteroid, play particles, looses a life and gets reset
        if (collision.CompareTag("bigAsteroid") || collision.CompareTag("mediumAsteroid") || collision.CompareTag("smallAsteroid"))
        {
            ObjectPool.playerDeathParticles.transform.position = transform.position;
            ObjectPool.playerDeathParticles.Play();
            P_Lives.MinusLife();
            P_MoveForward.playerNotHit = false;
            SoundManager.Instance.PlayPlayerDeathSound();
        }
    }
}
