using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField] private float nextSpawn;
    [SerializeField] private float spawnRate;

    public bool startTime;
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
        if (startTime)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                Instantiate(trailRenderObj);
               // Debug.Log("spawn");
            }
        }
    }

    public void NewTimeToTrail()
    {
        startTime = true;
    }
}
