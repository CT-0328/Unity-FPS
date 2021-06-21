using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {

    public float mouseSensitivety = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    /*void Start() {
      Cursor.lockState = CursorLockMode.Locked;
    }*/

    void Update() {
      Cursor.lockState = CursorLockMode.Locked;
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivety * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivety * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
