[System.Serializable]
public class WaveData
{
    public EnemyData[] enemy;
}
[System.Serializable]
public class EnemyData
{
    public int type;
    public int count;
}
[System.Serializable]
public class DataWrapper
{
    public WaveData[] waves;
}

[System.Serializable]
public class RootData
{
    public int ok;
    public DataWrapper data;
}