using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private bool active = true;

    public Sprite spriteActive;
    public Sprite spriteInactive; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // test code
        //if (Time.time % 5 == 0) changeStatus();
    }

    public void changeStatus()
    {
        active = !active;

        if(active)
        {
            GetComponent<SpriteRenderer>().sprite = spriteActive;
            gameObject.layer = LayerMask.NameToLayer("Walkable");
        } else
        {
            GetComponent<SpriteRenderer>().sprite = spriteInactive;
            gameObject.layer = LayerMask.NameToLayer("Empty");
        }
    }
}
