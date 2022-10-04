using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePopulateIObjectPool : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        //Get the particle system attached to this gameobject
        ps = GetComponent<ParticleSystem>();
        //Assign it to the correct object pool
        if (gameObject.tag == "playerDeathParticle")
        {
            ObjectPool.playerDeathParticles = ps;
        }
        else if (gameObject.tag == "bigAsteroidParticle")
        {
            ObjectPool.bigAsteroidParticles.Add(ps);
        }
        else if (gameObject.tag == "mediumAsteroidParticle")
        {
            ObjectPool.mediumAsteroidParticles.Add(ps);
        }
        else 
        {
            ObjectPool.smallAsteroidParticles.Add(ps);
        }
        //Destroy script
        Destroy(GetComponent<ParticlePopulateIObjectPool>());
    }
}
