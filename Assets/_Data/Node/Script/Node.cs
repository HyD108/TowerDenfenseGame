using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : NodeBase
{
    [SerializeField] protected TowerSpawnCtrl ctrl;
    public Vector3 offset;
    [SerializeField] public TowerCtrl prefab;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTower();
    }

    private void LoadTower()
    {
        if (this.ctrl != null) return;
        this.ctrl = FindAnyObjectByType<TowerSpawnCtrl>();
    }

    private void OnMouseDown()
    {
        if (!BuildManager.Instance.CanBuild) return;
        BuildManager.Instance.BuildTurretOn(this);
    }
}
