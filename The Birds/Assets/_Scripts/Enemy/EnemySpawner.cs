using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemies;
    private int indexEnemy;
    private int ranPosSpawner;

    private const int maxAmountSpawnerPoint = 5;

    float nextSpawnTime = 0.5f;
    float timer = 0f;
    [SerializeField] float startSpawnTime;

    [SerializeField] int aliveAmountEnemyCurrent;
    private LevelManager levelManager;

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
        if(this.AliveAmountEnemyCurrent <= 0 && this.enemies.Count <= 0)
        {
            this.levelManager.WinLevel();
            GameManager.instance.PauseGame();
            return;
        }
        if (this.enemies.Count > 0)
        {
            /*this.indexEnemy = Random.Range(0, this.enemies.Count - 1);*/
            this.indexEnemy = Random.Range(0, this.enemies.Count);
        }
        else return;
        
        this.ranPosSpawner = Random.Range(0, maxAmountSpawnerPoint);
        if (this.enemies[indexEnemy].amount == 0)
        {
            this.enemies.RemoveAt(indexEnemy);
            return;
        }
        GameObject enemyObj = Instantiate(this.enemies[this.indexEnemy].enemyPrefabs, transform.GetChild(this.ranPosSpawner).transform);
        this.AliveAmountEnemyCurrent++;
        this.enemies[indexEnemy].amount--;
    }
}
