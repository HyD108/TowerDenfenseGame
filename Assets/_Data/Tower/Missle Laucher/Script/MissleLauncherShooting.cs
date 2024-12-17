using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncherShooting : TowerShootingAbstract
{
    [SerializeField] protected EffectCode bulletCode = EffectCode.Missle;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 2f;

    protected override void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;
        FirePoint firePoint = this.GetFirePoint();
        this.SpawnBullet(firePoint);
    }

    protected override EffectCtrl SpawnBullet(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.bulletCode.ToString());
        EffectCtrl newEfffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEfffect.gameObject.SetActive(true);

        return prefab;
    }
}
