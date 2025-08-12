using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public abstract void Fire();
    public virtual float GetCooldownPercent()
    {
        return 0f;
    }
}