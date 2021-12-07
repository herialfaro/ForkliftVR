using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour
{
   
    public Transform[] Targets;
    Transform NextPos;
    public int nextPosIndex;
    public float speed;
  //  public float destroyObjTime;

    void Start()
    {
       // StartCoroutine(DestroyObj());
        NextPos = Targets[0];
    }

    // Update is called once per frame
    void Update()
    {
        FollowPosition();
    }

    public void FollowPosition()
    {
        if(transform.position == NextPos.position)
        {
            nextPosIndex++;
            if (nextPosIndex >= Targets.Length)
            {
                nextPosIndex = 0;
                Destroy(this.gameObject);
            }
            NextPos = Targets[nextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }

   
}
