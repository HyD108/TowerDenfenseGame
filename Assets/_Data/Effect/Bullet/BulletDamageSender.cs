using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectDespawn despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<EffectDespawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected override void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._collider;
        this.sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }

    protected override void Send(Collider collider)
    {
        DamageReceiver damageReceiver = GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.Receive(this.damage, this);
        this.despawn.DoDespawn();
    }
}
