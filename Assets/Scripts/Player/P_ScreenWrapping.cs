using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ScreenWrapping : MonoBehaviour
{
    public TrailRenderer leftWingTrail;
    public TrailRenderer rightWingTrail;
    public static MeshRenderer shipRenderer;
    public static bool isWrapping;
    [SerializeField] private Camera cam;
    [SerializeField] private bool onScreen, wrappingX, wrappingY;
    private Vector2 screenPos, newPos;

    // Start is called before the first frame update
    void Awake()
    {
        onScreen = true;
        shipRenderer = GameObject.FindWithTag("PlayerMeshRenderer").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!P_MoveForward.playerNotHit)
        {
            return;
        }
        //If player is alive check for onScreen
        else
        {
            //Returns true if the camera can see the ship
            onScreen = shipRenderer.isVisible;

            if (onScreen)
            {
                wrappingX = false;
                wrappingY = false;
                isWrapping = false;
                return;
            }
            //Camera cannot see the ship, use screen wrap
            else
            {
                ScreenWrap();
                isWrapping = true;
            }
        }
    }

    void ScreenWrap()
    {
        //Grab the ships position values in relation to the camera view port
        screenPos = cam.WorldToScreenPoint(transform.position);
        //NewPos holds the current position then gets inverted based upon the screenPos values
        newPos = transform.position;
        if (!wrappingX && screenPos.x > 1 || !wrappingX && screenPos.x < 0)
        {
            newPos.x = -newPos.x;
            wrappingX = true;
        }
        if (!wrappingY && screenPos.y > 1 || !wrappingY && screenPos.y < 0)
        {
            newPos.y = -newPos.y;
            wrappingY = true;
        }
        //Ships position now set to the inverted newPos
        transform.position = newPos;
    }

    //Turns mesh renderer on/off
    public static void ToggleRenderer(bool toggle)
    {
        if (toggle)
        {
            shipRenderer.enabled = true;
        }
        else
        {
            shipRenderer.enabled = false;
        }
    }
}
