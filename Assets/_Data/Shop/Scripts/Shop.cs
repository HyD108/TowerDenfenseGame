using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : HyDBehaviour
{

    protected virtual void CheckCurrency()
    {
        ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold);
        if(item != null) return;
        if(item.itemCount <= 8) return;
        item.itemCount -= 8;
    }
    public void PurchaseStandardTurret()
    {
        this.CheckCurrency();

        Debug.Log("StandardTurretPurchased");
        BuildManager.Instance.SetTurretToBuild(TowerSpawnCtrl.Instance.Prefabs.GetByName("MachineGun"));
    }
}
