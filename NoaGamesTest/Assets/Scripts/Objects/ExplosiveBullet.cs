using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public float speed = 6f;
    public float explosionRadius = 2f;
    public float damage = 5f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyBase>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
      
    }
}