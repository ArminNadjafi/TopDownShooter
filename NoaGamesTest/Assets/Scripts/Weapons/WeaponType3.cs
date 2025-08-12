using System;
using UnityEngine;

public class WeaponType3 : WeaponBase
{
    public float cooldown = 30f;
    private float nextFireTime;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (nextFireTime > 0)
            nextFireTime -= Time.deltaTime;
    }

    public override void Fire()
    {
        if (currentAmmo  > 0 && Time.time >= nextFireTime)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject("ExplosiveBullet");
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }

            currentAmmo --;
            nextFireTime = Time.time + cooldown;
        }
    }
    public override float GetCooldownPercent()
    {
        return Mathf.Clamp01(nextFireTime / cooldown);
    }
}