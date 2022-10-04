using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Rotate : MonoBehaviour
{
    [SerializeField] private bool rotateLeft, rotateRight;
    [SerializeField] private float rotateSpeed;
    private Vector3 currentEularAngle;

    // Start is called before the first frame update
    void Awake()
    {
        rotateLeft = false;
        rotateRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets bool states based on input
        rotateLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        rotateRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    }
    private void FixedUpdate()
    {
        //return if player is not moving left or right
        if (!rotateLeft && !rotateRight)
        {
            return;
        }
        //return if player is trying to turn left and right
        else if (rotateLeft && rotateRight)
        {
            return;
        }
        else
        {
            //rotating left
            if (rotateLeft && !rotateRight)
            {
                currentEularAngle += new Vector3(transform.rotation.x, transform.rotation.y, rotateSpeed) * Time.fixedDeltaTime;
                gameObject.transform.eulerAngles = currentEularAngle;
            }
            //rotating right
            else if (rotateRight && !rotateLeft)
            {
                currentEularAngle -= new Vector3(transform.rotation.x, transform.rotation.y, rotateSpeed) * Time.fixedDeltaTime;
                gameObject.transform.eulerAngles = currentEularAngle;
            }
        }
    }
}
