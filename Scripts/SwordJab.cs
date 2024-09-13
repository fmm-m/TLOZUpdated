using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordJab : MonoBehaviour
{
    public GameObject player;
    Vector3 mousePosition;
    bool stabbing = false;
    int stabbingCount = 0;
    public float speed = 0.0001f;
    float startAngle;

    void Start()
    {

    }

    void Update()
    {
        

        Vector3 mousePosition = Input.mousePosition + transform.position;
        
        
        
        Vector3 direction = mousePosition - Camera.main.transform.position;
        direction.z = 0; 

        // Calculate the angle in degrees between the player's forward direction and the mouse position
        Debug.Log(mousePosition);
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Apply the rotation to the player object
        transform.rotation = new Quaternion(0, 0, 0, 0);
        Vector3 rotateVector = new Vector3(0, 0, angle);
        
        Debug.DrawLine(transform.position, mousePosition);

        if (Input.GetMouseButtonDown(0) && !stabbing)
        {
            stabbing = true;
            startAngle = angle;

        }
        else if (stabbing) {
            stabbingCount++;
            float xComponent = Mathf.Cos(startAngle) * speed;
            float yComponent = Mathf.Sin(startAngle) * speed;
            Vector3 stabMovement = new Vector3(xComponent, yComponent, 0);
            this.transform.position = player.transform.position + stabMovement * stabbingCount;
            if (stabbingCount == 40)
            {
                stabbingCount = 0;
                stabbing = false;
            }
        } else {
            this.transform.position = player.transform.position;
        }

    }
}
