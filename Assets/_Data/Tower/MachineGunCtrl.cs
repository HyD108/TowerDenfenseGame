using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunCtrl : TowerCtrl
{
    //[SerializeField] protected MachineGunShooting towerShooting;
    //public MachineGunShooting TowerShooting => towerShooting;
    public override string GetName()
    {
        return "MachineGun";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadTowerShootings();
    }

    //protected virtual void LoadTowerShootings()
    //{
    //    if (this.towerShooting != null) return;
    //    this.towerShooting = GetComponentInChildren<MachineGunShooting>();
    //    Debug.Log(transform.name + ": LoadTowerShootings", gameObject);
    //}
}
