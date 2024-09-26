using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private bool spawned = false;
    public bool Spawned
    {
        get
        {
            return spawned;
        }

        private set
        {
            spawned = value;
        }
    }

    public GameObject Spawn()
    {
        if (!spawned)
        {
            spawned = true;
            return Instantiate(obj, transform.position, Quaternion.identity);
        }

        return null;
    }
}