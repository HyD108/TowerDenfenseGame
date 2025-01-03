using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyAbstract
{
    [SerializeField] protected PathMoving path;
    [SerializeField] protected int currentPointIndex = 0;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float pointDistanceLimit = 1f;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool isMoving = false;

    void FixedUpdate()
    {
        this.Moving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathMoving();
    }

    protected virtual void LoadPathMoving()
    {
        if (this.path != null) return;
        this.path = GameObject.Find("PathMoving_0").GetComponent<PathMoving>();
        Debug.Log(transform.name + ": LoadAgent", gameObject);
    }

    protected virtual void Moving()
    {
        this.LoadMovingStatus();
        if (this.isFinish || !this.canMove || this.IsDead() || !this.ctrl.Agent.enabled || !this.ctrl.Agent.isOnNavMesh)
        {
            if (this.ctrl.Agent != null && this.ctrl.Agent.enabled && this.ctrl.Agent.isOnNavMesh)
            {
                this.ctrl.Agent.isStopped = true;
            }
            return;
        }

        this.GetNextPoint();
        if (this.ctrl.Agent.isOnNavMesh)
        {
            this.ctrl.Agent.SetDestination(this.currentPoint.transform.position);
        }
    }

    protected virtual bool IsDead()
    {
        return this.ctrl.EnemyDamageReceiver.IsDead();
    }

    protected virtual void GetNextPoint()
    {
        this.currentPoint = this.path.GetPoint(this.currentPointIndex);
        this.pointDistance = Vector3.Distance(this.currentPoint.transform.position, transform.position);
        if (this.pointDistance < this.pointDistanceLimit) this.currentPointIndex++;
        if (this.currentPointIndex > this.path.Points.Count - 1)
        {
            this.isFinish = true;
            PlayerStats.Lives--;
            this.ctrl.EnemyDamageReceiver.CurrentHP = 0;
            this.IsDead();
            this.ctrl.Despawn.DoDespawn();
            this.OnRespawn();
        }

    }

    protected virtual void LoadMovingStatus()
    {
        if (this.ctrl.Agent != null && this.ctrl.Agent.enabled && this.ctrl.Agent.isOnNavMesh)
        {
            this.isMoving = !this.ctrl.Agent.isStopped;
            this.ctrl.Animator.SetBool("isMoving", this.isMoving);
        }
    }
    public void OnRespawn()
    {
        this.currentPointIndex = 0;  
        this.currentPoint = this.path.GetPoint(this.currentPointIndex);  
        this.isFinish = false;  
    }
}
