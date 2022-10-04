using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Rotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canRotate;
    private Vector3 currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = Vector3.zero;
    }

    private void FixedUpdate()
    {
        //Reset rotation when off screen
        if (!canRotate)
        {
            currentRotation = Vector3.zero;
            return;
        }
        //Rotate continously when on screen
        else
        {
            currentRotation += new Vector3(1, 1, 1) * Time.fixedDeltaTime * speed;
            transform.eulerAngles = currentRotation;
        }
        
    }
    //Activates rotation when asteroid is placed in scene
    public void ToggleCanRotate(bool rotate)
    {
        canRotate = rotate;
        speed = Random.Range(8f, 25f);
    }
}
