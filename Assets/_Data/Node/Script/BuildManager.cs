using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BuildManager : HyDSingleton<BuildManager>
{
    //[SerializeField] protected TowerCtrl standardTurretPrefab;
    //[SerializeField] protected TowerCtrl anotherTurretPrefab;
    [SerializeField] protected TowerCtrl turretToBuild;



    public TowerCtrl GetTurretToBuild()
    {
        return this.turretToBuild;
    }

    public void SetTurretToBuild(TowerCtrl turret)
    {
        turretToBuild = turret; 
    }
}
