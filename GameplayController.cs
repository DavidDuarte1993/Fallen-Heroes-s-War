using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public GameObject[] heroes;

    public GameObject player_Spawn_FX;

    public Transform player_Spawn_Point;

    private EnemySpawner enemySpawner;

    [HideInInspector]
    public int enemy_Count;

    private bool second_Wave;

    private BossSpawnController bossSpawnController;

    void Awake () {
        MakeInstance();

        enemySpawner = GetComponent<EnemySpawner>();

        bossSpawnController = GameObject.Find("Boss Spawn Controller")
                                        .GetComponent<BossSpawnController>();

    }

    void Start() {
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    public void SpawnPlayer() {
        StartCoroutine(SpawnPlayerAfterDelay());
    }

    IEnumerator SpawnPlayerAfterDelay() {
        player_Spawn_FX.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Instantiate(heroes[GameManager.instance.selected_Hero_Index],
                    player_Spawn_Point.position, Quaternion.Euler(0f, 180f, 0f));
    }

    public void SpawnEnemy(int enemyCount) {

        enemy_Count = enemyCount;

        enemySpawner.SpawnEnemy(enemyCount);
    }

    public void EnemyDied() {

        enemy_Count--;

        if(enemy_Count <= 0) {

            bossSpawnController.StartBossSpawn();

        }
    }

    IEnumerator SpawnSecondWaveOfEnemies() {
        yield return new WaitForSeconds(3f);

        SpawnEnemy(3);

    }

} 































