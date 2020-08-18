using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;


public class StarSpawner : MonoBehaviour
{

    public GameObject spawnObject;
    public int interval = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnStar", 0, interval);
    }

   private void spawnStar()
    {        
        GameObject newGO = Instantiate(spawnObject);
        newGO.transform.SetParent(gameObject.transform);
        newGO.transform.position = new Vector3(Range(-10,10), newGO.transform.parent.transform.position.y, 0);
        Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Range(-0.1f, 0.1f), -0.1f);
        
    }
    
}
