using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_MoveForward : MonoBehaviour
{
    public static bool playerNotHit;
    public static bool clearWingTrails;
    public static bool livesRemaining;
    public TrailRenderer leftWingTrail;
    public TrailRenderer rightWingTrail;

    private Rigidbody2D rb;
    private CircleCollider2D col;
    [SerializeField] private bool moveForward;
    [SerializeField] private float thrust, drag;
    private Vector2 startingPosition;
    private bool playerReset;

    // Start is called before the first frame update
    void Awake()
    {
        clearWingTrails = false;
        livesRemaining = true;
        startingPosition = transform.position;
        playerNotHit = true;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        moveForward = false;
        playerReset = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Turn wing trails on and off
        if (P_ScreenWrapping.isWrapping)
        {
            TurnOffWingsTrails();
        }
        else
        {
            if (moveForward && !clearWingTrails)
            {
                TurnOnWingTrails();
            }
            else
            {
                TurnOffWingsTrails();
            }
        }

        //No lives remaining and has been reset
        if (!livesRemaining && playerReset)
        {
            return;
        }
        //No lives remaining but has not been reset
        else if (!livesRemaining && !playerReset)
        {
            playerReset = true;
            PlayerDied();
        }
        //Player has lives and has been hit
        else if (livesRemaining && !playerNotHit)
        { 
            //Reset player movement if not already done
            if (playerReset)
            {
                return;
            }
            else
            {
                playerReset = true;
                StartCoroutine(PlayerHitResetMovement());
                return;
            }
        }
        //Player has lives and has not been hit
        else if (livesRemaining && playerNotHit)
        {
            //Sets bool states based on input
            moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        } 

    }
    private void FixedUpdate()
    {
        //Use of gaurd clauses to control movement 
        if (!moveForward)
        {
            //Turn off moving sounds
            SoundManager.Instance.StopMovingSounds();
            rb.drag = 0.5f;
            return;
        }
        else
        {
            //Turn on moving sounds
            SoundManager.Instance.PlayMovingSounds();
            //Apply thrust to the ship
            rb.AddForce(transform.up * thrust * Time.fixedDeltaTime, ForceMode2D.Impulse);
            //Apply drag to the ship
            rb.drag = drag;
        }
    }

    //Turns on wing trails
    void TurnOnWingTrails()
    {
        if (leftWingTrail.emitting)
        {
            return;
        }
        else
        {
            leftWingTrail.emitting = true;
            rightWingTrail.emitting = true;
        }
    }
    //Turns wing trails off
    void TurnOffWingsTrails()
    {
        if (!leftWingTrail.emitting)
        {
            return;
        }
        else if (P_ScreenWrapping.isWrapping || clearWingTrails)
        {
            leftWingTrail.Clear();
            rightWingTrail.Clear();
        }
        else
        {
            leftWingTrail.emitting = false;
            rightWingTrail.emitting = false;
        }
    }
    //Player has been hit by an asteroid, toggle renderer and collider, reset position
    IEnumerator PlayerHitResetMovement()
    {
        moveForward = false;
        col.enabled = false;
        rb.velocity = Vector2.zero;
        P_ScreenWrapping.ToggleRenderer(false);
        transform.position = startingPosition;
        yield return new WaitForSeconds(2f);
        P_ScreenWrapping.ToggleRenderer(true);
        playerNotHit = true;
        playerReset = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
        clearWingTrails = false;
    }
    //Player has 0 lives left, stop moving, turn off renderer and disable collider
    void PlayerDied()
    {
        moveForward = false;
        col.enabled = false;
        rb.velocity = Vector2.zero;
        P_ScreenWrapping.ToggleRenderer(false);
    }
}
