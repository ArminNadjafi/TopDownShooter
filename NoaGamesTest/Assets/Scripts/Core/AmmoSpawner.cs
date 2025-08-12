using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public string ammoTag = "AmmoBox"; 
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;  

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAmmo), spawnInterval, spawnInterval);
    }

    void SpawnAmmo()
    {
        GameObject ammoBox = ObjectPool.Instance.GetPooledObject(ammoTag);
        if (ammoBox != null)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            ammoBox.transform.position = spawnPoint.position;
            ammoBox.SetActive(true);
        }
    }
}