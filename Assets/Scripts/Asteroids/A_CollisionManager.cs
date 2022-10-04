using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CollisionManager : MonoBehaviour
{
    private ScoreManager scoreClass;
    private A_Movement movementClass;
    private ParticleSystem bigAsteroidParticle;
    private ParticleSystem mediumAsteroidParticle;
    private ParticleSystem smallAsteroidParticle;
    private int bigIndex;
    private int mediumIndex;
    private int smallIndex;

    private void Start()
    {
        scoreClass = GameObject.FindWithTag("ScoreObject").GetComponent<ScoreManager>();
        movementClass = GetComponent<A_Movement>();
        bigIndex = 0;
        mediumIndex = 0;
        smallIndex = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Asteroids hit by bullets are sent back to object pools, big asteroids spawn 2 medium ones
        if (collision.CompareTag("Bullet"))
        {
            if (gameObject.tag == "bigAsteroid")
            {
                if (bigIndex >= ObjectPool.bigAsteroidParticles.Count)
                {
                    bigIndex = 0;
                }
                bigAsteroidParticle = ObjectPool.bigAsteroidParticles[bigIndex];
                bigAsteroidParticle.transform.position = transform.position;
                bigAsteroidParticle.Play();
                bigIndex++;
                A_SpawningManager.SpawnMediumAsteroids(gameObject);
                scoreClass.AddLargeScore();
            }
            //Asteroids hit by bullets are sent back to object pools, medium asteroids spawn 2 small ones
            else if (gameObject.tag == "mediumAsteroid")
            {
                if (mediumIndex >= ObjectPool.mediumAsteroidParticles.Count)
                {
                    mediumIndex = 0;
                }
                mediumAsteroidParticle = ObjectPool.mediumAsteroidParticles[mediumIndex];
                mediumAsteroidParticle.transform.position = transform.position;
                mediumAsteroidParticle.Play();
                mediumIndex++;
                A_SpawningManager.SpawnSmallAsteroids(gameObject);
                scoreClass.AddMediumScore();
            }
            //Asteroids hit by bullets are sent back to object pools
            else if (gameObject.tag == "smallAsteroid")
            {
                if (smallIndex >= ObjectPool.smallAsteroidParticles.Count)
                {
                    smallIndex = 0;
                }
                smallAsteroidParticle = ObjectPool.smallAsteroidParticles[smallIndex];
                smallAsteroidParticle.transform.position = transform.position;
                smallAsteroidParticle.Play();
                smallIndex++;
                scoreClass.AddSmallScore();
            }
            collision.GetComponent<B_Movement>().SendBackToPool();
            movementClass.SendBackToPool();
            SoundManager.Instance.PlayAsteroidDestroySound();
        }
    }
}
