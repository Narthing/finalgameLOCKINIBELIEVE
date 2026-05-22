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

    public Transform rocketlauncher;

    public Transform maincamera;

    void Start()
    {
        // Lock the cursor in the center and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping

        Vector3 rocketstuff = new Vector3(maincamera.eulerAngles.x - 90, playerBody.eulerAngles.y, 0f);
        rocketlauncher.rotation = Quaternion.Euler(rocketstuff);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body horizontally
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
