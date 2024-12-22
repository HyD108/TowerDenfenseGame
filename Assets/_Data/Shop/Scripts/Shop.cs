using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : HyDBehaviour
{
    ItemInventory item;
    protected virtual void CheckGold()
    {
        item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold);
        if (item == null) return;
    }
    public void PurchaseStandardTurret()
    {
        this.CheckGold();
        //if (item.itemCount <= 8) return;
        //item.itemCount -= 8;

        Debug.Log("StandardTurretPurchased");
        BuildManager.Instance.SetTurretToBuild(TowerSpawnCtrl.Instance.Prefabs.GetByName("StandardTurret"));
    }
    public void PurchaseMissleTurret()
    {
        this.CheckGold() ;
        if (item.itemCount <= 10) return;
        item.itemCount -= 10;

        Debug.Log("MissleLaucherPurchased");
        BuildManager.Instance.SetTurretToBuild(TowerSpawnCtrl.Instance.Prefabs.GetByName("Missile Launcher"));
    }

    public void PurchaseLaserTurret()
    {
        this.CheckGold() ;
        if (item.itemCount <= 12) return;
        item.itemCount -= 12;

        Debug.Log("LaserBeamerPurchased");
        BuildManager.Instance.SetTurretToBuild(TowerSpawnCtrl.Instance.Prefabs.GetByName("Laser Beamer"));
    }



}
