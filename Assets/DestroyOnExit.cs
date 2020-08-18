using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    // Start is called before the first frame update
    public float minY = -5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (transform.position.y < minY)
        {
        
            Destroy(gameObject);
        }
    }
}
