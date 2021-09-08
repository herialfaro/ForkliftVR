using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerVRPointer : MonoBehaviour
{
    [SerializeField] private float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    //public VRInputModule 
    private LineRenderer m_LineRender = null;

    private void Awake()
    {
        m_LineRender = GetComponent<LineRenderer>();
    }
    void Update()
    {
        updateLine();
    }

    public void updateLine()
    {
        float targetLength = m_DefaultLength;

        RaycastHit hit = CreateRaycast(targetLength);

        Vector3 endPositon = transform.position + (transform.forward * targetLength);

        if(hit.collider != null)
        {
            endPositon = hit.point;
        }

        m_Dot.transform.position = endPositon;

        m_LineRender.SetPosition(0, transform.position);
        m_LineRender.SetPosition(1, endPositon);
    }

    private RaycastHit CreateRaycast(float length)
    {

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
