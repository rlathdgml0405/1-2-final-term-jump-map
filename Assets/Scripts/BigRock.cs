using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRock : MonoBehaviour
{
    public float delta = 0.1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newXPosition = transform.position.x + delta;
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        if (transform.position.x < 20)
        {
            delta *= -1;
        }
        else if (transform.position.x > 23)
        {
            delta *= -1;
        }


    }
}
