using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : TowerShootingAbstract
{
    [SerializeField] protected Vector3 offset = new Vector3(0, 1, 0);
    [SerializeField]protected LaserBeamerCtrl laserBeamerCtrl;
    [SerializeField] protected float damage = 5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBeamerCtrl();
        this.LoadDamageReceiver();

    }

    private void LoadDamageReceiver()
    {
        //if(this.damageReceiver != null) return;
        //this.damageReceiver = 
    }

    private void LoadBeamerCtrl()
    {
        if(this.laserBeamerCtrl != null) return;
        this.laserBeamerCtrl = GetComponentInParent<LaserBeamerCtrl>();
    }

    protected override void Shooting()
    {
        if (target == null) 
        {
            if (this.laserBeamerCtrl.lineRenderer.enabled)
            {
                this.laserBeamerCtrl.impactEffect.Stop();
                this.laserBeamerCtrl.lineRenderer.enabled = false;
                this.laserBeamerCtrl.lightImpact.enabled = false;
            }
                
            return;
        }
             
        this.Laser();
    }

    protected virtual void Laser()
    {
        this.target.EnemyDamageReceiver.Receive(this.damage * Time.deltaTime);
        if (!this.laserBeamerCtrl.lineRenderer.enabled)
        {
            this.laserBeamerCtrl.lineRenderer.enabled = true;
            this.laserBeamerCtrl.impactEffect.Play();
            this.laserBeamerCtrl.lightImpact.enabled = true;
        }

        FirePoint firePoint = this.GetFirePoint();
        this.laserBeamerCtrl.lineRenderer.SetPosition(0, firePoint.transform.position);
        this.laserBeamerCtrl.lineRenderer.SetPosition(1, target.transform.position + this.offset);

        this.laserBeamerCtrl.impactEffect.transform.position = this.target.transform.position + this.offset;
    }

    protected override EffectCtrl SpawnBullet(FirePoint firePoint)
    {
        throw new NotImplementedException();
    }
}
