using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody rb;
    private Vector3 rotation;
    private float cameraRotationX;
    [SerializeField] Camera cam;
    private float currentCameraRotation = 0;
    [SerializeField] float cameraRotationLimit = 85f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    private void FixedUpdate()
    {
        PerfromMovement();
        PerfromRotation();

    }

    void PerfromMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerfromRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotation -= cameraRotationX;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
			
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0, 0);
        }
    }

    public void Jump(float jumpHeight)
    {
        rb.AddForce(0, jumpHeight, 0, ForceMode.Force);
    }

}
