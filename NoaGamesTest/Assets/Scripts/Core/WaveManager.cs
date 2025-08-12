using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WaveManager : MonoBehaviour
{
    public WaveData[] waves;
    [SerializeField] private EnemyFactory enemyFactory;
    public Transform[] spawnPoints;
    public float spawnDelay = 0.5f;
    public float WaveDelayTime = 5f;
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(LoadWaves());
    }
    
    IEnumerator LoadWaves()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://www.profc.ir/users/shooterWaves");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error loading waves: " + www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            RootData root = JsonUtility.FromJson<RootData>(json);

            if (root != null && root.ok == 1 && root.data != null && root.data.waves != null)
            {
                waves = root.data.waves;
                Debug.Log("Loaded waves: " + waves.Length);
                StartCoroutine(SpawnWaveRoutine());
            }
            else
            {
                Debug.LogError("Invalid JSON structure or empty waves list");
            }
        }
    }

    IEnumerator SpawnWaveRoutine()
    {
        while (currentWave < waves.Length)
        {
            WaveData wave = waves[currentWave];

            foreach (EnemyData enemyInfo in wave.enemy)
            {
                for (int i = 0; i < enemyInfo.count; i++)
                {
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                    string enemyTag = $"EnemyType{enemyInfo.type}";
                    GameObject enemy = ObjectPool.Instance.GetEnemyFromPool(enemyTag);
                    enemy.transform.position = spawnPoint.position;
                    enemy.transform.rotation = Quaternion.identity;

                    yield return new WaitForSeconds(spawnDelay);
                }
            }

            currentWave++;
            UIManager.Instance.ShowWaveText("Wave"+currentWave+"Finished");
            yield return new WaitForSeconds(WaveDelayTime);
          
        }
        UIManager.Instance.winPanel.SetActive(true);
    }
}