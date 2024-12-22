using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

        bool hasExploded = false;
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            DamageReceiver target = nearbyObject.GetComponentInChildren<DamageReceiver>();
            if (target == null) continue;
            float distance = Vector3.Distance(transform.position, nearbyObject.transform.position);
            float damageAmount = Mathf.Max(0, damage * (1 - (distance / explosionRadius)));
            target.Receive(damageAmount);
            hasExploded = true;
        }
        if (hasExploded)
        {
            this.despawn.DoDespawn();
            SpawnExplosion();          
        }
        
    }
        protected virtual EffectCtrl SpawnExplosion()
    {
        EffectCtrl hitPrefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Explosion.ToString());
        EffectCtrl newHitEfffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(hitPrefab, this.transform.position, Quaternion.identity);
        newHitEfffect.gameObject.SetActive(true);
        return hitPrefab;
    }
   

}

