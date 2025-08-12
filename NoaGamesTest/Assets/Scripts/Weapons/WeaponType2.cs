using UnityEngine;

public class WeaponType2 : WeaponBase
{
   
    public float fireRate = 0.05f;
    private float fireTimer;
    public float heat;
    public  float heatIncrease = 0.05f;
    public  float heatCooldown = 0.025f;
    void Start()
    {
        currentAmmo = maxAmmo;
    }
 

    void Update()
    {
        if (heat > 0)
            heat -= heatCooldown * Time.deltaTime;
        heat = Mathf.Clamp01(heat);
    }

    public override void Fire()
    {
        if (currentAmmo  > 0 && Time.time >= fireTimer && heat < 1)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject("Bullet");
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }

            currentAmmo --;
            heat += heatIncrease;
            fireTimer = Time.time + fireRate;
        }
    }
    public override float GetCooldownPercent()
    {
        return heat; 
    }
}