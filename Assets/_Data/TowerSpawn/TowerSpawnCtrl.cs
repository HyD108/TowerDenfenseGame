using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnCtrl : HyDSingleton<TowerSpawnCtrl>
{
    [SerializeField] protected TowerSpawner spawner;
    public TowerSpawner Spawner => spawner;

    [SerializeField] protected TowerPrefabs prefabs;
    public TowerPrefabs Prefabs => prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadPrefabs();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<TowerSpawner>();
        //Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs != null) return;
        this.prefabs = GetComponentInChildren<TowerPrefabs>();
        //Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
}
