using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ScreenWrapping : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private MeshRenderer asteroidRenderer;
    [SerializeField] private bool onScreen, inPlay, wrappingX, wrappingY, resetUponSceneChange;
    private Vector2 screenPos, newPos;

    // Start is called before the first frame update
    void Start()
    {
        resetUponSceneChange = false;
        inPlay = false;
        onScreen = true;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Returns true if the camera can see the ship
        onScreen = asteroidRenderer.isVisible;

        //Asteroid has just entered the screen and is not in play
        if (onScreen && !inPlay)
        {
            inPlay = true;
        }
        //Asteroid has entered the screen and is now in play, do not screen wrap
        else if (onScreen && inPlay)
        {
            wrappingX = false;
            wrappingY = false;
            return;
        }
        //Asteroid has left the screen and is in play, use screen wrap
        else if (!onScreen && inPlay)
        {
            ScreenWrap();
        }
    }

    void ScreenWrap()
    {
        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
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
}
