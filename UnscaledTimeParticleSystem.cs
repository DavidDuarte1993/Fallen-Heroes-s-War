using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscaledTimeParticleSystem : MonoBehaviour {

    private ParticleSystem particleFX;

	void Awake () {
        particleFX = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        if(Time.timeScale < 0.01f) {
            particleFX.Simulate(Time.unscaledDeltaTime, true, false);
        }
	}
}
