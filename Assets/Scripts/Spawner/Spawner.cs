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

        set
        {
            spawned = value;
        }
    }

    public void Spawn()
    {
        if (!spawned)
        {
            spawned = true;
            Instantiate(obj, transform.position, Quaternion.identity).GetComponent<Coin>().Callback = this;
        }
    }
}