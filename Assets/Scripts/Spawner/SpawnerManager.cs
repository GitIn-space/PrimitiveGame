using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 0;

    private List<Spawner> spawners = new List<Spawner>();

    private void Awake()
    {
        spawners.AddRange(GetComponentsInChildren<Spawner>());

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            if(spawners.Any(each => !each.Spawned))
                spawners.Where(each => !each.Spawned).OrderBy(each => Random.value).First().Spawn();
        }
    }
}
