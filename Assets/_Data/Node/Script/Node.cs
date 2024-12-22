using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : NodeBase
{
    [SerializeField] protected TowerSpawnCtrl ctrl;
    [SerializeField] protected string towerName = "MachineGun";
    [SerializeField] protected Vector3 offSet;
    //[SerializeField] protected Dictionary<Vector3, TowerCtrl> spawnedTowers = new Dictionary<Vector3, TowerCtrl>();


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
        if (InputManager.Instance.IsAim) return;

        if(BuildManager.Instance.GetTurretToBuild() == null) return;

        Vector3 spawnPosition = this.transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 0.5f);
        foreach (var hit in hitColliders)
        {
            if (hit.gameObject.CompareTag(this.towerName))
            {
                Debug.Log("A tower already exists here!");
                return;
            }
        }

        TowerCtrl prefab = BuildManager.Instance.GetTurretToBuild();
        TowerCtrl newPrefabs = this.ctrl.Spawner.Spawn(prefab, spawnPosition);
        newPrefabs.transform.position += offSet;
        newPrefabs.gameObject.SetActive(true);
    }
}
