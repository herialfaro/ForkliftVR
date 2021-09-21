using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField] private float nextSpawn;
    [SerializeField] private float spawnRate;
    public GameObject trailRenderObj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ToSpawnObj();
    }

    public void ToSpawnObj()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(trailRenderObj);
            Debug.Log("spawn");
        }
    }
}
