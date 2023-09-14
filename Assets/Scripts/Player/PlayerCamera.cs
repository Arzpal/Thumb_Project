using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float sensX, sensY;

    public Transform orientation;

    float xRot, yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        Quaternion target = Quaternion.Euler(xRot, yRot, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 15);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
    private void LateUpdate()
    {
        // Update Camera Position and Rotation

        GameObject parent = this.gameObject.transform.parent.gameObject;
        parent.transform.position = orientation.position;
    }
}
