using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed_factor = 2.0f;
    public int door_state = 0;




    void Start()
    {
        
    }

  
  void Update()
    {
        DoorMove();
    }

    void DoorMove()
    {
        if(door_state == 1)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(9.262f, 11.19599f, 11.874f), Time.deltaTime * speed_factor);
        }
        else if (door_state ==2)
        {
            transform.position =
                Vector3.Lerp(transform.position, new Vector3(11.17f, 11.19599f, 9.966f), Time.deltaTime * speed_factor);
        }
    }
}
