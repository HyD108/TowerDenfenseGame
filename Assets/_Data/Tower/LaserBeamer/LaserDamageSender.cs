using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageSender : HyDBehaviour
{
    [SerializeField] protected LaserBeamerCtrl ctrl;
    public LayerMask hitLayer;
    [SerializeField] protected float laserDamage = 0.8f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    private void LoadCtrl()
    {
        if (ctrl != null) return;
        this.ctrl = GetComponentInParent<LaserBeamerCtrl>();
    }

    void Update()
    {
        this.Send();
    }

    protected virtual void Send()
    {
        RaycastHit hit;
        Vector3 startPoint = this.ctrl.lineRenderer.GetPosition(0); 
        Vector3 endPoint = this.ctrl.lineRenderer.GetPosition(1);
        float Dis = Vector3.Distance(startPoint, endPoint);
        
        if (Physics.Raycast(startPoint, endPoint - startPoint,
            out hit, Dis, hitLayer))
        {
            this.ctrl.lineRenderer.SetPosition(1, hit.point); 
            DamageReceiver enemy = hit.collider.GetComponentInChildren<DamageReceiver>();
            if(enemy ==  null) return;
            enemy.Receive(laserDamage * Time.deltaTime);

        }

    }
}
   


