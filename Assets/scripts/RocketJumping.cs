using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketJumping : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivity = 300f;

    [Header("References")]
    public Transform playerBody; // Assign your player GameObject here

    private float xRotation = 0f;
    private float yRotation = 0f;

    public Transform rocketlauncher;

    public Transform maincamera;

    void Start()
    {
        // Lock the cursor in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;

        Physics.gravity = new Vector3(0, -19f, 0);
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // horizontally

        yRotation += mouseX;

        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        //rotate rocket launcher
        Vector3 rocketstuff = new Vector3(maincamera.eulerAngles.x - 90, maincamera.eulerAngles.y, 0f);
        rocketlauncher.rotation = Quaternion.Euler(rocketstuff);

    }
}
