using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    private float screenBound = 10;
    private float roadBound = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < roadBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > screenBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -screenBound)
        {
            Destroy(gameObject);
        }
    }
}
