using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamerCtrl : TowerCtrl
{

    [SerializeField] public LineRenderer lineRenderer;
    [SerializeField] public ParticleSystem impactEffect;
    [SerializeField] public Light lightImpact;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRenderer();
        this.LoadImpactEffect();
        this.LoadLightImpact();

    }

    private void LoadLightImpact()
    {
        if(lightImpact != null) return;
        this.lightImpact = GetComponentInChildren<Light>();
    }

    private void LoadImpactEffect()
    {
        if(impactEffect != null) return;
        this.impactEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void LoadRenderer()
    {
        if (this.lineRenderer != null) return;
        this.lineRenderer = GetComponent<LineRenderer>();
    }

    public override string GetName()
    {
        return "LaserBeamer";
    }


}
