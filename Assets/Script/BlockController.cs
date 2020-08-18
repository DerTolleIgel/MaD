using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlockController : MonoBehaviour
{
    private bool active = true;

    public Sprite spriteActive;
    public Sprite spriteInactive; 

    public int scriptValueA = 0;
    public int changeInterval = 0;
    public int changeIntervalDelay = 0;

    void Start()
    {
        if (changeInterval != 0)
            InvokeRepeating("changeStatus", changeIntervalDelay, changeInterval);
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


    public void changeStatusTo(bool bactive)
    {
        if (bactive != active)
        {
            changeStatus();
        }
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
