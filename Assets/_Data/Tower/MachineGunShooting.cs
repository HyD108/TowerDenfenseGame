using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShooting : TowerShootingAbstract
{
    [SerializeField] protected EffectCode bulletCode = EffectCode.Projectile1;
    [SerializeField] protected SoundName shootSfxName = SoundName.LaserKickDrum;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 0.5f;
    protected override void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;
        FirePoint firePoint = this.GetFirePoint();
        this.SpawnBullet(firePoint);
        this.SpawnMuzzle(firePoint);
        this.SpawnSound(firePoint.transform.position);
    }
    protected override EffectCtrl SpawnBullet(FirePoint firePoint)
    {
        EffectCtrl prefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(this.bulletCode.ToString());
        EffectCtrl newEfffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(prefab, firePoint.transform.position, firePoint.transform.rotation);
        newEfffect.gameObject.SetActive(true);

        return prefab;
    }

    protected virtual EffectCtrl SpawnMuzzle(FirePoint firePoint)
    {
        EffectCtrl hitPrefab = EffectSpawnerCtrl.Instance.Prefabs.GetByName(EffectCode.Hit1.ToString());
        EffectCtrl newHitEfffect = EffectSpawnerCtrl.Instance.Spawner.Spawn(hitPrefab, firePoint.transform.position, firePoint.transform.rotation);
        newHitEfffect.gameObject.SetActive(true);

        return hitPrefab;
    }
    protected virtual void SpawnSound(Vector3 position)
    {

        SoundManager.Instance.CreateSfx(this.shootSfxName, position);
    }
}
