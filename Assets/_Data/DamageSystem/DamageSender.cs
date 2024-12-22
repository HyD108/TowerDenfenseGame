using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : HyDBehaviour
{
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected Collider _collider;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.Send(collider);
    }

    protected abstract void Send(Collider collider);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadTriggerCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }
}
