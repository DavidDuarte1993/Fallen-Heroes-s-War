using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour {

    public LayerMask layerMask;
    public float radius = 1f;
    public float damage = 1f;

    public bool deal_Multiple_Damage;

    public bool disable_Script;

    public bool detectCollisionAfterDelay;
    private bool canDetectCollision = true;
    public float delayTime = 1f;

	void Start () {
        if(detectCollisionAfterDelay) {
            canDetectCollision = false;
            StartCoroutine(CollisionAfterDelay());
        }
	}
	
	void Update () {
        if(canDetectCollision) {
            DetectCollision();
        }	
	}

    void DetectCollision() {

        Collider[] hit = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hit.Length > 0) {

            if(deal_Multiple_Damage) {

                for (int i = 0; i < hit.Length; i++) {

                    hit[i].GetComponent<HealthScript>().ApplyDamage(damage);

                }

            } else {

                hit[0].GetComponent<HealthScript>().ApplyDamage(damage);

            }

            if(disable_Script) {

                enabled = false;

            } else {

                gameObject.SetActive(false);
            }

        } 

    } 

    IEnumerator CollisionAfterDelay() {
        yield return new WaitForSeconds(delayTime);
        canDetectCollision = true;
    }

} 










































