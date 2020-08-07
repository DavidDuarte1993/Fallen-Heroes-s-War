
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

    private CharacterAnimation playerAnimation;

    private BaseMovement baseMovement;

    private Quaternion screenMovement_Space;
    private Vector3 screenMovement_Forward;
    private Vector3 screenMovement_Right;

	void Awake () {
        baseMovement = GetComponent<BaseMovement>();
        baseMovement.movementDirection = Vector3.zero;

        playerAnimation = GetComponent<CharacterAnimation>();

    }

    void Start() {

    }

    void OnEnable() {
        GMCameraAnimationsController.screenMovement += SetScreenMovement;
    }

    void OnDisable() {
        GMCameraAnimationsController.screenMovement -= SetScreenMovement;
    }

    void Update () {
        MovementInput();
    }

    void MovementInput() {

        baseMovement.movementDirection = Input.GetAxis(AxisManger.HORIZONTAL_AXIS)
            * screenMovement_Right + Input.GetAxis(AxisManger.VERTICAL_AXIS) 
            * screenMovement_Forward;

        if(Input.GetAxis(AxisManger.HORIZONTAL_AXIS) != 0 ||
        Input.GetAxis(AxisManger.VERTICAL_AXIS) != 0) {

            playerAnimation.Walk(true);

            } else {

            playerAnimation.Walk(false);

        }

        if (baseMovement.movementDirection.sqrMagnitude > 1) {
            baseMovement.movementDirection.Normalize();
        }

    }

    void SetScreenMovement() {
        screenMovement_Space = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        screenMovement_Forward = screenMovement_Space * Vector3.forward;
        screenMovement_Right = screenMovement_Space * Vector3.right;
    }

    void PlayerDied() {

        EndGameManager.instance.GameOver(false);

        GetComponent<PlayerAttackInput>().enabled = false;

        enabled = false;

    }
} 


































