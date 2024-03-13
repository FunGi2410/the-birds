using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWaves> enemyWaves;
    private int indexEnemy;
    private int ranPosSpawner;

    private const int maxAmountSpawnerPoint = 5;

    [SerializeField] float nextSpawnTime = 0.5f;
    float timer = 0f;
    [SerializeField] float startSpawnTime;

    [SerializeField] int aliveAmountEnemyCurrent;
    private LevelManager levelManager;
    private int indexWave = 0; // increse 1 

    public int AliveAmountEnemyCurrent { 
        get => aliveAmountEnemyCurrent; 
        set
        {
            if(value >= 0) aliveAmountEnemyCurrent = value;
        }
    }

    private void Start()
    {
        this.levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        EnemyCtrl.OnEnemyDead += EnemyDead;
    }

    private void Update()
    {
        if (GameManager.instance.CurTimerGame < this.startSpawnTime) return;
        this.timer += Time.deltaTime;
        if (this.timer >= this.nextSpawnTime)
        {
            this.Spawn();
            this.timer = 0f;
        }
    }

    public void EnemyDead()
    {
        this.AliveAmountEnemyCurrent--;
    }

    protected virtual void Spawn()
    {
        if (this.AliveAmountEnemyCurrent <= 0 && this.enemyWaves[indexWave].Enemies.Count <= 0)
        {
            this.levelManager.WinLevel();
            GameManager.instance.PauseGame();
            return;
        }
        if (this.enemyWaves[indexWave].Enemies.Count > 0)
        {
            this.indexEnemy = Random.Range(0, this.enemyWaves[indexWave].Enemies.Count - 1);
            //this.indexEnemy = Random.Range(0, this.enemies.Count);
        }
        else return;

        this.ranPosSpawner = Random.Range(0, maxAmountSpawnerPoint);
        if (this.enemyWaves[indexWave].Enemies[indexEnemy].amount == 0)
        {
            this.enemyWaves[indexWave].Enemies.RemoveAt(indexEnemy);
            if (this.enemyWaves[indexWave].Enemies.Count <= 0 && indexWave < this.enemyWaves.Count - 1) indexWave++;

            return;
        }
        GameObject enemyObj = Instantiate(this.enemyWaves[indexWave].Enemies[this.indexEnemy].enemyPrefabs, transform.GetChild(this.ranPosSpawner).transform);
        this.AliveAmountEnemyCurrent++;
        this.enemyWaves[indexWave].Enemies[indexEnemy].amount--;
    }
}
