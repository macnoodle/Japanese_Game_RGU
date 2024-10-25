using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHat : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string W;
    public string S;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        { RotateTowardsMouse(); 
        }

        void RotateTowardsMouse()
        {
            // Get mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;  // Ignore z-axis for 2D

            // Calculate the angle and apply rotation to face the mouse
            float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}