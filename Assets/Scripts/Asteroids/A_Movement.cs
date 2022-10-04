using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Movement : MonoBehaviour
{
    public MeshRenderer asteroidRenderer;
    public A_Rotate rotateClass;

    [SerializeField] private float speed;
    [SerializeField] private bool onScreen, isActive;
    private Vector2 startingPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        transform.position = startingPosition;
        isActive = false;
        onScreen = false;
        rb = GetComponent<Rigidbody2D>();
    }
    //If scene changes and asteroid is active send it back to the object pool
    private void Update()
    {
        //send back to object pool if scene changes and asteroid is on screen
        if (ScoreManager.sceneChange && isActive)
        {
            SendBackToPool();
        }
    }
    private void FixedUpdate()
    {
        //If asteroid is active on screen, move forwards
        if (isActive)
        {
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
    }
    //Activates movement and rotation
    public void AcitvateAsteroidMovement()
    {
        isActive = true;
        rotateClass.ToggleCanRotate(true);
    }

    //Called when asteroid leaves screen or is hit by a bullet, resets aseroids movement and position values
    public void SendBackToPool()
    {
        rb.velocity = Vector2.zero;
        transform.position = startingPosition;
        rotateClass.ToggleCanRotate(false);
        isActive = false;
    }
}
