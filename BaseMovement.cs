using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {

    [HideInInspector]
    public Vector3 movementDirection;

    private Rigidbody myBody;

    public float walk_Speed = 5f;
    public float walking_Force = 50f;
    public float turning_Smoothing = 0.1f;

	void Awake () {
        myBody = GetComponent<Rigidbody>();
	}

    void FixedUpdate () {
        HangleMovement();
    }

    void HangleMovement() {

        Vector3 targetVelocity = movementDirection * walk_Speed;

        Vector3 deltaVelocity = targetVelocity - myBody.velocity;

        if(myBody.useGravity) {
            deltaVelocity.y = 0f;
        }

        myBody.AddForce(deltaVelocity * walking_Force, 
       ForceMode.Acceleration);

        Vector3 face_Direction = movementDirection;

        if(face_Direction == Vector3.zero) {

            myBody.angularVelocity = Vector3.zero;

        } else {

            float rotationAngle = AngleAroundAxis(transform.forward,
            face_Direction, Vector3.up);

            myBody.angularVelocity = (Vector3.up * rotationAngle * turning_Smoothing);

        }

    }

    float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis) {

        float angle = Vector3.Angle(dirA, dirB);

        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) > 0 ? 1 : -1);
    }

} 




































