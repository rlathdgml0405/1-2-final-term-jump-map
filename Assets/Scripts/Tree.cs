using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
  
    private float angle_factor = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 10.0f+transform.eulerAngles.y, Time.deltaTime * angle_factor);


        transform.eulerAngles = Vector3.up *angle;
    }
}
