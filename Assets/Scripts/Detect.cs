using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.Equals("SwitchObject"))
                {
            if (GameObject.Find("DoorObject").GetComponent<Door>().door_state == 0)
            {
                GameObject.Find("DoorObject").GetComponent<Door>().door_state = 1;
            }
            else if (GameObject.Find("DoorObject").GetComponent<Door>().door_state == 1)
            {
                GameObject.Find("DoorObject").GetComponent<Door>().door_state = 2;
            }
            else if (GameObject.Find("DoorObject").GetComponent<Door>().door_state == 2)
            {
                GameObject.Find("DoorObject").GetComponent<Door>().door_state = 1;
            }
        }
    }
}
