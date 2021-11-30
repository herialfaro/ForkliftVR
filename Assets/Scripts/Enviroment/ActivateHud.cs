using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHud : MonoBehaviour
{
    public GameObject txtCarryBox;
    public GameObject pnlLose;
    public GameObject pnlFinish;
    SpawnObj spawnObj;

    void Start()
    {
        spawnObj = GetComponent<SpawnObj>();
        spawnObj = FindObjectOfType<SpawnObj>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerStart"))//Start
        {
            txtCarryBox.SetActive(true);
            spawnObj.NewTimeToTrail();
        }
        if (other.CompareTag("Floor"))//Lose
        {
            pnlLose.SetActive(true);
        }
        if (other.CompareTag("Finish"))//Victory
        {
            pnlFinish.SetActive(true);
        }
    }
}
