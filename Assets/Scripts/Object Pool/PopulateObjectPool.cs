using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateObjectPool : MonoBehaviour
{
    //Game objects
    private GameObject[] bullets;
    private GameObject[] bigAsteroids;
    private GameObject[] mediumAsteroids;
    private GameObject[] smallAsteroids;

    void Start()
    {
        if (ObjectPool.bulletObjectPool.Count <= 0)
        {
            //Fill object pool with all bullets in the scene
            bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                ObjectPool.bulletObjectPool.Add(bullet);
            }
        }
        if (ObjectPool.bigAsteroidObjectPool.Count <= 0)
        {
            //Fill object pool with all big asteroids in the scene
            bigAsteroids = GameObject.FindGameObjectsWithTag("bigAsteroid");
            foreach (GameObject asteroid in bigAsteroids)
            {
                ObjectPool.bigAsteroidObjectPool.Add(asteroid);
            }
        }
        if (ObjectPool.mediumAsteroidObjectPool.Count <= 0)
        {
            //Fill object pool with all medium asteroids in the scene
            mediumAsteroids = GameObject.FindGameObjectsWithTag("mediumAsteroid");
            foreach (GameObject asteroid in mediumAsteroids)
            {
                ObjectPool.mediumAsteroidObjectPool.Add(asteroid);
            }
        }
        if (ObjectPool.smallAsteroidObjectPool.Count <= 0)
        {
            //Fill object pool with all small asteroids in the scene
            smallAsteroids = GameObject.FindGameObjectsWithTag("smallAsteroid");
            foreach (GameObject asteroid in smallAsteroids)
            {
                ObjectPool.smallAsteroidObjectPool.Add(asteroid);
            }
        }
       
    }
}
