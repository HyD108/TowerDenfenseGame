using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerRadar : HyDBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;
    [SerializeField] protected List<EnemyCtrl> enemies;
    [SerializeField] private float detectionRadius = 12f; 
    [SerializeField] private LayerMask enemyLayer; 

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadEnemy();
        this.FindNearest();
        this.DetectEnemies();
    }

    private void DetectEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        enemies.Clear();
        foreach (Collider hit in hits)
        {
            EnemyCtrl enemy = hit.GetComponentInParent<EnemyCtrl>();
            if (enemy != null && !enemies.Contains(enemy))
            {
                enemies.Add(enemy);
            }
        }


        FindNearest();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 12;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void AddEnemy(EnemyCtrl enemyCtrl)
    {
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(EnemyCtrl enemyCtrl)
    {
        if (this.nearest == enemyCtrl) this.nearest = null;
        this.enemies.Remove(enemyCtrl);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }

    }

    public virtual EnemyCtrl GetTarget()
    {
        return this.nearest;
    }

    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                if (enemyCtrl == this.nearest) this.nearest = null;
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
