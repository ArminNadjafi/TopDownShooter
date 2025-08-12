using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

  public PlayerController player;
    [SerializeField] private WaveManager waveManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

   
}