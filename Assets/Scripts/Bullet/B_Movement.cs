using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool onScreen, inPlay, isActive;
    private SpriteRenderer bulletRenderer;
    private Vector2 direction, startingPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        isActive = false;
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        bulletRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //If the bullet leaves the screen, send back to object pool
        onScreen = bulletRenderer.isVisible;
        if (onScreen)
        {
            inPlay = true;
        }
        if (!onScreen && inPlay)
        {
            SendBackToPool();
            inPlay = false;
        }
    }
    private void FixedUpdate()
    {
        //If bullet is active on screen, move towards the ships forward facing direction
        if (isActive)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }
    //Takes in the player ships forward facing direction
    public void ActivateBulletMovement(Vector2 _direction)
    {
        direction = _direction;
        isActive = true;
    }
    //Called when Bullet leaves screen or hits an asteroid
    public void SendBackToPool()
    {
        rb.velocity = Vector2.zero;
        transform.position = startingPosition;
        isActive = false;
    }
}
