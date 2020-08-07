using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnController : MonoBehaviour {

    private Animator anim;

    public GameObject bossSpawnCamera;

    public EnemySpawner enemySpawner;

    public float delayBefore_SpawningBoss = 2f;
    public float delayBefore_BossFightStarts = 4f;

    private ShakeCamera shakeCamera;

    public float shakeTime = 0.1f;

    void Awake() {
        anim = GetComponent<Animator>();
        shakeCamera = GetComponent<ShakeCamera>();
    }

    public void StartBossSpawn() {
        StartCoroutine(BossSpawnWithDelay());
    }

    IEnumerator BossSpawnWithDelay() {
        yield return new WaitForSecondsRealtime(delayBefore_SpawningBoss);

        Time.timeScale = 0f;

        bossSpawnCamera.SetActive(true);

        anim.Play(AnimationTags.SLIDE_IN_ANIMATION);

    }

    void ShakeAndSpawn() {
        StartCoroutine(ShakTheCameraAndSpawnTheBoss());
    }

    IEnumerator ShakTheCameraAndSpawnTheBoss() {

        shakeCamera.InitializeValues(shakeTime);

        enemySpawner.SpawnBoss(0);

        yield return new WaitForSecondsRealtime(shakeTime + delayBefore_BossFightStarts);

        Time.timeScale = 1f;

        bossSpawnCamera.SetActive(false);

    }
} 


























