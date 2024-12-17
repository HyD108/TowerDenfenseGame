using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDamageSender : DamageSender
{
    public float explosionRadius = 5f;
    public float damage = 50f;
    [SerializeField] protected EffectDespawn despawn;
    [SerializeField] protected MissleCtrl ctrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponentInParent<MissleCtrl>();
    }


    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<EffectDespawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected override void Send(Collider collider)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            DamageReceiver target = nearbyObject.GetComponent<DamageReceiver>();

            if (target == null) return;
            float distance = Vector3.Distance(transform.position, nearbyObject.transform.position);
                float damageAmount = Mathf.Max(0, damage * (1 - (distance / explosionRadius)));
                target.Receive(damageAmount);
        }
        this.despawn.DoDespawn();

    }
}
