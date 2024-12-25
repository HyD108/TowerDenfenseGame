using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : HyDBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl ctrl;
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected float timeBetweenWaves = 5.5f;
    [SerializeField] protected float countDown = 2f;
    public float CountDown => countDown;
    [SerializeField] protected int waveIndex = 0;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();


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
        for(int i = 0; i <= waveIndex; i++)
        {
            this.Spawning();
            yield return new WaitForSeconds(0.3f);
        }
        this.waveIndex++;
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
