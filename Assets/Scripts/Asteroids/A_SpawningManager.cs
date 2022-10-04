using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SpawningManager : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float timeUntilSpawn;
    [SerializeField] private int spawnAmount;
    [SerializeField] private int spawnGoal;
    [SerializeField] private int bigAsteroidIndex;
    private static int mediumAsteroidIndex;
    private static int smallAsteroidIndex;
    private static GameObject bigAsteroid, mediumAsteroid1, mediumAsteroid2, smallAsteroid1, smallAsteroid2;

    // Start is called before the first frame update
    void Start()
    {
        mediumAsteroidIndex = 0;
        smallAsteroidIndex = 0;
        bigAsteroidIndex = 0;
        timer = 0;
        spawnAmount = 0;
        spawnGoal = spawnAmount + 5;
        SpawnBigAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawns asteroid when timer reaches the time until spawn
        timer += Time.deltaTime;
        if (timer >= timeUntilSpawn)
        {
            SpawnBigAsteroid();
            timer = 0;
        }
        //Decreasese the time between spawning every 5 asteroids
        if (spawnAmount >= spawnGoal)
        {
            DecreaseTimeUntilSpawn();
        }
    }

    //Cycles through object pool, places asteroid in scene, activates asteroid movement heading towards an offset position
    void SpawnBigAsteroid()
    {
        spawnAmount++;
        if (bigAsteroidIndex >= ObjectPool.bigAsteroidObjectPool.Count)
        {
            bigAsteroidIndex = 0;
        }
        if (bigAsteroid == null)
        {
            bigAsteroid = ObjectPool.bigAsteroidObjectPool[bigAsteroidIndex];
        }
        bigAsteroid = ObjectPool.bigAsteroidObjectPool[bigAsteroidIndex];
        if (bigAsteroid == null)
        {
            bigAsteroid = ObjectPool.bigAsteroidObjectPool[bigAsteroidIndex];
        }
        bigAsteroid.transform.position = Random.insideUnitCircle.normalized * 10f;
        Vector2 offsetPosition = gameObject.transform.position + Random.insideUnitSphere * 6f;
        bigAsteroid.transform.LookAt(offsetPosition);
        bigAsteroid.GetComponent<A_Movement>().AcitvateAsteroidMovement();
        bigAsteroidIndex++;
    }

    //Cycles through object pool, places small asteroids in scene, activates asteroid movement heading towards a randomised direction
    public static void SpawnMediumAsteroids(GameObject hitAsteroid)
    {
        //Object assigning from pool
        if (mediumAsteroidIndex >= ObjectPool.mediumAsteroidObjectPool.Count)
        {
            mediumAsteroidIndex = 0;
        }
        mediumAsteroid1 = ObjectPool.mediumAsteroidObjectPool[mediumAsteroidIndex];
        mediumAsteroidIndex++;
        mediumAsteroid2 = ObjectPool.mediumAsteroidObjectPool[mediumAsteroidIndex];
        //Object positioning and offset
        Vector2 offsetPosition1 = hitAsteroid.transform.position + Random.insideUnitSphere;
        Vector2 offsetPosition2 = hitAsteroid.transform.position + Random.insideUnitSphere;
        mediumAsteroid1.transform.position = offsetPosition1;
        mediumAsteroid2.transform.position = offsetPosition2;
        //Object facing direction
        mediumAsteroid1.transform.LookAt(Random.insideUnitSphere * 6f);
        mediumAsteroid2.transform.LookAt(Random.insideUnitSphere * 6f);
        //Activate objects movement
        mediumAsteroid1.GetComponent<A_Movement>().AcitvateAsteroidMovement();
        mediumAsteroid2.GetComponent<A_Movement>().AcitvateAsteroidMovement();
        mediumAsteroidIndex++;
    }

    //Cycles through object pool, places small asteroids in scene, activates asteroid movement heading towards a randomised direction
    public static void SpawnSmallAsteroids( GameObject hitAsteroid)
    {
        //Object assigning from pool
        if (smallAsteroidIndex >= ObjectPool.smallAsteroidObjectPool.Count)
        {
            smallAsteroidIndex = 0;
        }
        smallAsteroid1 = ObjectPool.smallAsteroidObjectPool[smallAsteroidIndex];
        smallAsteroidIndex++;
        smallAsteroid2 = ObjectPool.smallAsteroidObjectPool[smallAsteroidIndex];
        //Object positioning and offset
        Vector2 offsetPosition1 = hitAsteroid.transform.position + Random.insideUnitSphere;
        Vector2 offsetPosition2 = hitAsteroid.transform.position + Random.insideUnitSphere;
        smallAsteroid1.transform.position = offsetPosition1;
        smallAsteroid2.transform.position = offsetPosition2;
        //Object facing direction
        smallAsteroid1.transform.LookAt(Random.insideUnitSphere * 6f);
        smallAsteroid2.transform.LookAt(Random.insideUnitSphere * 6f);
        //Activate objects movement
        smallAsteroid1.GetComponent<A_Movement>().AcitvateAsteroidMovement();
        smallAsteroid2.GetComponent<A_Movement>().AcitvateAsteroidMovement();
        smallAsteroidIndex++;
    }

    //Reduce time in between spawning by 1 until it reaches every 2 seconds
    void DecreaseTimeUntilSpawn()
    {
        spawnGoal = spawnAmount + 5;
        if (timeUntilSpawn <= 2)
        {
            return;
        }
        else
        {
            timeUntilSpawn--;
        }
    }
}
