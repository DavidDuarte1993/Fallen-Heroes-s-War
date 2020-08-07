using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownController : MonoBehaviour {

    private AudioSource audioSource;
    private Animator anim;

    public GameObject countdown_3, countdown_2, countdown_1;

    public GMCameraAnimationsController cameraAnimationsController;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
    public void StartCountdown() {

        anim.enabled = true;

        Countdown3();

    }

    void Countdown3 () {
        countdown_3.SetActive(true);
    }

    void Countdown2() {

        countdown_3.SetActive(false);
        countdown_2.SetActive(true);

        anim.Play(AnimationTags.COUNTDOWN_2_ANIMATION);

    }

    void Countdown1() {

        countdown_2.SetActive(false);
        countdown_1.SetActive(true);

        anim.Play(AnimationTags.COUNTDOWN_1_ANIMATION);

    }

    void ActivateMainCamera() {
        countdown_1.SetActive(false);
        cameraAnimationsController.TurnOnMainCamera();
    }

    void PlayCountdownSound() {
        audioSource.Play();
    }

} 




























