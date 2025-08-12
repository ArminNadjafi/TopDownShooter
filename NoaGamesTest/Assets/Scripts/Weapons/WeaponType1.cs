using UnityEngine;

public class WeaponType1 : WeaponBase
{
    public float fireRate = 0.2f;
    private float fireTimer;
    void Start()
    {
        currentAmmo = maxAmmo;
    }
    public override void Fire()
    {
        if (currentAmmo  > 0 && Time.time >= fireTimer)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject("Bullet");
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }

            currentAmmo --;
            fireTimer = Time.time + fireRate;
        }
    }
}