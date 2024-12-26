using UnityEngine;

public abstract class DamageReceiver : EnemyAbstract
{
    [SerializeField] protected float currentHP = 10;
    public float CurrentHP
    {
        get { return currentHP; }
        set { currentHP = Mathf.Max(value, 0); }
    }
    [SerializeField] public float CurrentMP => currentHP;
    [SerializeField] protected int maxHP;
    public int MaxHp => maxHP;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    protected abstract void OnDead();
    protected abstract void OnHurt();

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Receive(float damage, DamageSender damageSender)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        this.ctrl.UpdateHealthBar();
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
