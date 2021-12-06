using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR; 

public class PausemenuController : MonoBehaviour
{
    [SerializeField] private SteamVR_Input_Sources m_source;
    [SerializeField] private SteamVR_Action_Boolean m_clickButton;

   [SerializeField] private GameObject m_pausePanel;
   [SerializeField] private GameObject pointer;
   public GameObject m_input;
   private bool isPaused = false;

void Awake (){
    Continue();
}
    // Update is called once per frame
    void Update()
    {
        if(m_clickButton.GetStateDown(m_source))
        {
            if(isPaused)
            {
                Continue();
            }
            else{
                PauseGame();
            }
        }


    }

    void PauseGame()
    {
        m_pausePanel.SetActive(true);
        m_input.SetActive(false) ;
        pointer.SetActive(true);
        isPaused = true;
    }


    void Continue()
    {
        m_pausePanel.SetActive(false);
        pointer.SetActive(false);
         m_input.SetActive(true);
        isPaused = false;
    }
}
