using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : HyDBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserBeamer;
    public void PurchaseStandardTurret()
    {

        Debug.Log("StandardTurretPurchased");
        BuildManager.Instance.SelectTurretToBuild(standardTurret);
    }
    public void PurchaseMissleTurret()
    {

        Debug.Log("MissleLaucherPurchased");
        BuildManager.Instance.SelectTurretToBuild(missleLauncher);
    }

    public void PurchaseLaserTurret()
    {

        Debug.Log("LaserBeamerPurchased");
        BuildManager.Instance.SelectTurretToBuild(laserBeamer);
    }



}
