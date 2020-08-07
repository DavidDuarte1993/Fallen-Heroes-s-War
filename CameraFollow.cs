using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform myTranform;
    private Transform target;

    public Vector3 offset = new Vector3(7.5f, 11f, 4.2f);

	void Start () {
        target = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        myTranform = transform;
	}

    void LateUpdate () {
		
        if(target) {
            myTranform.position = target.position + offset;
        }

	}
} 
