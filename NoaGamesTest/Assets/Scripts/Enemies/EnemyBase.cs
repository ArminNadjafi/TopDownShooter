using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float speed;
    public float damage;
    public float health;
    public ParticleSystem ps;
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)  StartCoroutine(DestroyEnemy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            
            StartCoroutine(DestroyEnemy());
        }
    }
    IEnumerator DestroyEnemy()
    {
        ps.Play();
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
  
}