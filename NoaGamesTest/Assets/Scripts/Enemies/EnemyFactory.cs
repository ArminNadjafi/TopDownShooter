using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public EnemyBase SpawnEnemy(int type, Vector3 position)
    {
        GameObject obj = null;

        switch (type)
        {
            case 1:
                obj = ObjectPool.Instance.GetPooledObject("GreenEnemy");
                break;
            case 2:
                obj = ObjectPool.Instance.GetPooledObject("YellowEnemy");
                break;
            case 3:
                obj = ObjectPool.Instance.GetPooledObject("RedEnemy");
                break;
        }

        if (obj != null)
        {
            obj.transform.position = position;
            obj.SetActive(true);
        }

        return obj?.GetComponent<EnemyBase>();
    }
}