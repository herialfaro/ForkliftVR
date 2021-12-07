using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private SteamVR_Input_Sources m_targetSource;

    [SerializeField] private SteamVR_Action_Boolean m_clickAction;
    private GameObject m_currentObject = null;
    private PointerEventData m_data = null;
  
  protected override void Awake()
  {
    base.Awake();

    m_data = new PointerEventData(eventSystem);
  }

// this function like an Update
  public override void Process()
  {
        //Reset Data, set camera
    m_data.Reset();
    m_data.position = new Vector2(m_camera.pixelWidth / 2, m_camera.pixelHeight / 2 );

        //Raycast
    eventSystem.RaycastAll(m_data,m_RaycastResultCache);
    m_data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
    m_currentObject = m_data.pointerCurrentRaycast.gameObject;
     
        //clear raycast
    m_RaycastResultCache.Clear();
        
        // Hover
    HandlePointerExitAndEnter(m_data,m_currentObject);
        
        //Press
    if(m_clickAction.GetStateDown(m_targetSource))
        ProcessPress(m_data);
        
        //Release

    if(m_clickAction.GetStateUp(m_targetSource))
        PorcessRelease(m_data);

  }

  public PointerEventData GetData()
  {
    return m_data;
  }

  private void ProcessPress(PointerEventData _data)
  {
        // set a raycast
    _data.pointerPressRaycast = _data.pointerCurrentRaycast;

        // Check for object hit, get down handler, call
    GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_currentObject,_data,ExecuteEvents.pointerDownHandler);

        // If no down handler, try adn get click handler
    if(newPointerPress == null)
        newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_currentObject);

        //set data
    _data.pressPosition = _data.position;
    _data.pointerPress = newPointerPress;
    _data.rawPointerPress = m_currentObject;

  }

  private void PorcessRelease(PointerEventData _data)
  {
        //Execute pointer up
    ExecuteEvents.Execute(_data.pointerPress,_data, ExecuteEvents.pointerUpHandler);

        //Check for click Handler
    GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_currentObject);

        //Check if actual 
    if(_data.pointerPress == pointerUpHandler)
    {
        ExecuteEvents.Execute(_data.pointerPress,_data,ExecuteEvents.pointerClickHandler);
    }

        //Clear selected gameobject
    eventSystem.SetSelectedGameObject(null);

        //reset data
    _data.pressPosition = Vector2.zero;
    _data.pointerPress =null;
    _data.rawPointerPress = null;

  }
}
