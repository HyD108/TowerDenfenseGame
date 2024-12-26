using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BuildManager : HyDSingleton<BuildManager>
{
    [SerializeField] protected TowerSpawnCtrl ctrl;
    [SerializeField] protected TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }

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
    public virtual void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        InventoryCtrl currencyInventory = InventoriesManager.Instance.Currency();
        ItemInventory item = currencyInventory.FindItem(ItemCode.Gold);
        int money = item.itemCount;
        item.Deduct(turretToBuild.cost);
        if (money < turretToBuild.cost) return;
        TowerCtrl newPrefabs = this.turretToBuild.prefab;
        Collider platformCollider = node.GetComponent<Collider>();
        if (platformCollider != null)
        {
            platformCollider.enabled = false;
        }
        TowerCtrl prefab = this.ctrl.Spawner.Spawn(newPrefabs, node.transform.position + node.offset, Quaternion.identity);
        prefab.gameObject.SetActive(true);
        if (platformCollider != null)
        {
            platformCollider.enabled = true;
        }
        node.prefab = prefab;
        Debug.Log(money);
    }

}
