using System.Collections;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 20;
    public ParticleSystem ps;
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) 
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                if (  player.currentWeapon.currentAmmo+ammoAmount<= player.currentWeapon.maxAmmo)
                {
                    player.currentWeapon.currentAmmo += ammoAmount;
                }
                else
                {
                    player.currentWeapon.currentAmmo = player.currentWeapon.maxAmmo;
                }
                UIManager.Instance.UpdateAmmo( player.currentWeapon.currentAmmo, player.currentWeapon.maxAmmo);
            }

            StartCoroutine(DestroyAmmoBox());
        }

        if (collision.CompareTag("Player")) 
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                if (  player.currentWeapon.currentAmmo+ammoAmount<= player.currentWeapon.maxAmmo)
                {
                    player.currentWeapon.currentAmmo += ammoAmount;
                }
                else
                {
                    player.currentWeapon.currentAmmo = player.currentWeapon.maxAmmo;
                }
                UIManager.Instance.UpdateAmmo( player.currentWeapon.currentAmmo, player.currentWeapon.maxAmmo);
            }
            StartCoroutine(DestroyAmmoBox());
        }
    }

    IEnumerator DestroyAmmoBox()
    {
        ps.Play();
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
}