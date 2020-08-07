using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour {

    public AudioSource playerAttackSound;

    void Play_PlayerAttackSound() {
        playerAttackSound.Play();
    }

}
