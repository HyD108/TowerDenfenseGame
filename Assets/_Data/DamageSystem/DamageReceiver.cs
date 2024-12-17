using UnityEngine;

public abstract class DamageReceiver : HyDBehaviour
{
    [SerializeField] protected float currentHP = 10;
    [SerializeField] public float CurrentMP => currentHP;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    protected abstract void OnDead();
    protected abstract void OnHurt();

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Receive(int damage, DamageSender damageSender)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        if (this.currentHP < 0) this.currentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }
    public virtual void Receive(float damage)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        if (this.currentHP < 0) this.currentHP = 0;

        if (this.IsDead()) this.OnDead();
        else this.OnHurt();
    }

    public virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected virtual void Reborn()
    {
        this.currentHP = this.maxHP;
    }

}
