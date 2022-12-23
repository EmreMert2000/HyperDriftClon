using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;
    Vector3 moveVec;
    Vector3 rotVec;
    float dragamount=0.99f;
    [SerializeField] float steerangle;
    [SerializeField] float tracktion;
    public Joystick mycontrol;
    public Transform rw, lw;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVec += transform.forward * carSpeed * Time.deltaTime;
       transform.position += moveVec * Time.deltaTime;
        rotVec += new Vector3(0, SimpleInput.GetAxis("Horizontal"), 0);
        transform.Rotate(Vector3.up * SimpleInput.GetAxis("Horizontal") *steerangle*Time.deltaTime*moveVec.magnitude);

        moveVec = dragamount * moveVec;
        moveVec = Vector3.ClampMagnitude(moveVec, maxSpeed);
        rotVec = Vector3.ClampMagnitude(rotVec, steerangle);
        moveVec = Vector3.Lerp(moveVec.normalized, transform.forward, tracktion * Time.deltaTime) * moveVec.magnitude;
        lw.localRotation = Quaternion.Euler(rotVec);
        rw.localRotation = Quaternion.Euler(rotVec);
    }
}
