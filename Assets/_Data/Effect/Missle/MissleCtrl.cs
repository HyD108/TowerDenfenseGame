using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleCtrl : EffectCtrl
{
    [SerializeField] public ParticleSystem explosionEffect;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExplosionEffect();
    }
    private void LoadExplosionEffect()
    {
        if (this.explosionEffect != null) return;
        this.explosionEffect = transform.GetComponentInChildren<ParticleSystem>();
    }
    public override string GetName()
    {
        return "Missle";
    }

}
