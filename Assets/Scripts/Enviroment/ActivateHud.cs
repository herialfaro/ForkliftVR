using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHud : MonoBehaviour
{
    public GameObject txtCarryBox;
    public GameObject pnlLose;
    public GameObject pnlFinish;
    [Header("InterfazUser")]
    public GameObject[] UIElements;
    public GameObject ObjectToDesapear;
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
            ActivateUIInteractable();
        }
        if (other.CompareTag("Finish"))//Victory
        {
            pnlFinish.SetActive(true);
            ActivateUIInteractable();
        }
    }

    void ActivateUIInteractable()
    {
        for (int i = 0; i <= UIElements.Length-1; i++)
        {
            UIElements[i].SetActive(true);
        }
            ObjectToDesapear.SetActive(false);
    }
}
