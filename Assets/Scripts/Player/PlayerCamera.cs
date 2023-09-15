using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCamera : MonoBehaviour
{

    public float sensX, sensY;

    public Transform orientation;

    float xRot, yRot;

    float deltaTime;

    public TextMeshProUGUI fpsText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString();

        // Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
    }

	private void FixedUpdate()
	{
		
	}
	private void LateUpdate()
    {

        // Update Camera Rotation 
        Quaternion target = Quaternion.Euler(xRot, yRot, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 15);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

        // Update Camera Position 

        GameObject parent = this.gameObject.transform.parent.gameObject;
        parent.transform.position = orientation.position;
    }
}
