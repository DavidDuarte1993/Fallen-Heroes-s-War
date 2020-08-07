using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMainMenu : MonoBehaviour {

    private Animator myAnim;

	void Awake () {
        myAnim = GetComponent<Animator>();
	}
	
    void TurnOnRootMotion() {
        myAnim.applyRootMotion = true;
    }

    void AppearGround() {
        MainMenuAnimationsController.instance.GroundSlideIn();
    }

    void ThunderEffect() {
        MainMenuAnimationsController.instance.ActivateThunderFX();
    }

    void HeroAppearSound() {
        MainMenuAnimationsController.instance.PlayHeroAppearSound();
    }
} 






























