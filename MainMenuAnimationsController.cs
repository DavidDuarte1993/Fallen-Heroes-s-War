using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuAnimationsController : MonoBehaviour {

    public static MainMenuAnimationsController instance;

    private AudioSource heroes_Appear_Sound;

    public GameObject[] thunderFX;

    public Animator[] hero_Animators;
    public Animator ground_Animator;

    public float appear_Heroes_Time = 2f;
    public float shakeTime = 0.9f;

    public CinemachineVirtualCamera cinemachineCam;
    private CinemachineBasicMultiChannelPerlin shakeFX;

    void Awake() {
        MakeInstance();

        heroes_Appear_Sound = GetComponent<AudioSource>();
    }

    void Start () {
        StartCoroutine(ActivateAnimations());

        shakeFX = cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

	}
	
    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    public void GroundSlideIn() {
        ground_Animator.Play(AnimationTags.SLIDE_IN_ANIMATION);
    }

    public void PlayHeroAppearSound() {
        heroes_Appear_Sound.Play();
    }

    public void ActivateThunderFX() {

        for (int i = 0; i < thunderFX.Length; i++) {
            thunderFX[i].SetActive(true);
        }

        StartCoroutine(ShakeTheCamera());

    }

    IEnumerator ActivateAnimations() {
        yield return new WaitForSeconds(appear_Heroes_Time);

        for (int i = 0; i < hero_Animators.Length; i++) {
            hero_Animators[i].Play(AnimationTags.SLIDE_IN_ANIMATION);
        }

    }
	
    IEnumerator ShakeTheCamera() {
        shakeFX.m_AmplitudeGain = 10;
        shakeFX.m_FrequencyGain = 3f;

        yield return new WaitForSeconds(shakeTime);

        shakeFX.m_AmplitudeGain = 0;
        shakeFX.m_FrequencyGain = 0f;

    }

} 




































