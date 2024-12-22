using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BuildManager : HyDSingleton<BuildManager>
{
    //[SerializeField] public TowerCtrl LaserTurretPrefab;
    //[SerializeField] public TowerCtrl MissleTurretPrefab;
    [SerializeField] public TowerCtrl turretToBuild;



    public TowerCtrl GetTurretToBuild()
    {
        return this.turretToBuild;
    }

    public void SetTurretToBuild(TowerCtrl turret)
    {
        turretToBuild = turret; 
    }
}
