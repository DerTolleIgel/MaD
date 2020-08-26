using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;


public class StarSpawner : MonoBehaviour
{

    public GameObject spawnObject;
    public float interval = 5f;
    private GameObject refcamera;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnStar", 0, interval);
        refcamera = GameObject.Find("Main Camera");
    }

   private void spawnStar()
    {
     
        GameObject newGO = Instantiate(spawnObject);        
        newGO.transform.position = new Vector3(refcamera.transform.position.x+Range(-10,10), refcamera.transform.position.y+6f, 0);     
        Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Range(-0.1f, 0.1f), -0.1f);
        
    }
    
}
