using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_FireBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool isFiring;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int index;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //No lives left cannot fire
        if (!P_MoveForward.livesRemaining)
        {
            return;
        }
        //Player hit, cannot fire while resetting
        else if (!P_MoveForward.playerNotHit)
        {
            return;
        }
        //Player alive and has not been hit
        else if (P_MoveForward.playerNotHit)
        {
            isFiring = Input.GetKeyUp(KeyCode.Space);
            if (!isFiring)
            {
                return;
            }
            else
            {
                FireBullet();
            }
        }
    }
    void FireBullet()
    {
        //Cycles through object pool, places bullet in scene, activates bullet movement
        if (index >= ObjectPool.bulletObjectPool.Count)
        {
            index = 0;
        }
        bullet = ObjectPool.bulletObjectPool[index];
        bullet.transform.position = transform.position;
        bullet.GetComponent<B_Movement>().ActivateBulletMovement(transform.up);
        index++;
        SoundManager.Instance.PlayShootingSounds();
    }
}
