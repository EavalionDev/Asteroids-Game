using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Singlton instance
    public static ObjectPool Instance;
    //Keep position
    private Vector2 startingPos;
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
        }
    }
    private void Start()
    {
        startingPos = new Vector2(0,-10f);
    }
    private void Update()
    {
        transform.position = startingPos;
    }

    //Game object pool lists
    public static List<GameObject> bulletObjectPool = new List<GameObject>();
    public static List<GameObject> bigAsteroidObjectPool = new List<GameObject>(); 
    public static List<GameObject> mediumAsteroidObjectPool = new List<GameObject>(); 
    public static List<GameObject> smallAsteroidObjectPool = new List<GameObject>();

    //Particle pool lists
    public static List<ParticleSystem> bigAsteroidParticles = new List<ParticleSystem>();
    public static List<ParticleSystem> mediumAsteroidParticles = new List<ParticleSystem>();
    public static List<ParticleSystem> smallAsteroidParticles = new List<ParticleSystem>();
    public static ParticleSystem playerDeathParticles;
}
