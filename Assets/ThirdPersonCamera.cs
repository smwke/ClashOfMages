using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    public bool lockCursor = true;
    public float mouseSensitivity = 4f;
    public Transform target;
    public float offset = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    
    /*public float rotationSmoothTime = 1.2f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;*/

    float yaw, pitch;
	// Use this for initialization
	void Start () {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {

    
        
            RotateAroundTarget();
        
        
	}
    void RotateAroundTarget()
    {
        yaw += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;


       

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;
        transform.position = target.position - transform.forward * offset;
        //currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
    }
}
