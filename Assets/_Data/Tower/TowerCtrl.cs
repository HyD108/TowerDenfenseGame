using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerCtrl : PoolObj
{
    [SerializeField] protected TowerRadar radar;
    public TowerRadar Radar => radar;

    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;


    [SerializeField] protected LevelAbstract level;
    public LevelAbstract Level => level;

    [SerializeField] protected TowerShootingAbstract shooting;
    public TowerShootingAbstract Shooting => shooting;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRadar();
        this.LoadRotator();
        this.LoadLevel();
        this.LoadShootingAbstract();
    }

    private void LoadShootingAbstract()
    {
        if (shooting != null) return;
        this.shooting = GetComponentInChildren<TowerShootingAbstract>();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<LevelAbstract>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadRadar()
    {
        if (this.radar != null) return;
        this.radar = GetComponentInChildren<TowerRadar>();
        Debug.Log(transform.name + ": LoadRadar", gameObject);
    }

    protected virtual void LoadRotator()
    {
        if (this.rotator != null) return;
        this.rotator = transform.Find("Model").Find("Rotator");
        Debug.Log(transform.name + ": LoadRotator", gameObject);
    }

   
}
