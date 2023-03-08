using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    public GameObject fish;

    void Awake()
    {
        StartCoroutine(UpdateFish());
    }

    void Update()
    {
        MouseAiming();
        KeyboardMovement();
    }

    void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    IEnumerator UpdateFish()
    {
        float rot = 90.0f;  //rotation starts at 90 so we have to go with that
        float d_rot = 1.0f;
        bool dir_right = true;
        
        while (true) {
            while (dir_right)
            {
                d_rot = 1.0f;
                rot += d_rot;
                if (rot >= 110.0f)
                {
                    dir_right = false;
                }
                fish.transform.Rotate(0.0f, d_rot, 0.0f, Space.Self);  //Rotate right
                yield return new WaitForSeconds(0.1f);              
            }
        
        
            while (!dir_right)
            {
                d_rot = -1.0f;
                rot += d_rot;
                if (rot < 70.0f)
                {
                    dir_right = true;
                }
                fish.transform.Rotate(0.0f, d_rot, 0.0f, Space.Self);    //Rotate left 
                yield return new WaitForSeconds(0.1f);               
            }
        }
    }
}