using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWave : HyDBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl ctrl;
    [SerializeField] protected int waveIndex = 0;
    public int WaveIndex => waveIndex;
    [SerializeField] protected float spawnSpeed;
    [SerializeField] protected float timeBetweenWaves = 5.5f;
    [SerializeField] protected float countDown = 2f;
    [SerializeField] protected int enemySpawnCount = 1;
    [SerializeField] protected float maxSpeed = 10f;
    public float CountDown => countDown;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void Start()
    {
        base.Start();
        this.spawnSpeed = Mathf.Max(1f - 0.05f * waveIndex, 0.5f);
    }

    private void Update()
    {
        this.TimeToSpawnWave();
    }
    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<EnemySpawnerCtrl>();
        Debug.Log(transform.name + ": LoadEnemySpawnerCtrl", gameObject);
    }

    protected  virtual IEnumerator SpawnWave()
    {
        for(int i = 0; i < enemySpawnCount; i++)
        {
            this.Spawning();
            yield return new WaitForSeconds(spawnSpeed);
        }
        this.waveIndex++;

        if(this.waveIndex % 5 == 0)
        {
            this.IncreaseEnemyStats();
        }
    }

    protected virtual void IncreaseEnemyStats()
    {
        this.enemySpawnCount = Mathf.Clamp(this.enemySpawnCount + 1, 0, maxSpawn);

        foreach (EnemyCtrl enemy in this.spawnedEnemies)
        {
            if (!enemy.EnemyDamageReceiver.IsDead())
            {
                enemy.EnemyDamageReceiver.MaxHp += 6;
                enemy.Agent.speed = Mathf.Clamp(enemy.Agent.speed + 0.8f, 0, maxSpeed);
            }
        }

        Debug.Log($"Wave {waveIndex}: Increased enemy stats - SpawnCount: {enemySpawnCount}, HP +10, Speed +0.5");
    }

    protected virtual void TimeToSpawnWave()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
    }

    protected virtual void Spawning()
    {
        //Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedEnemies.Count >= this.maxSpawn) return;

        EnemyCtrl prefab = this.ctrl.Prefabs.GetRandom();
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
