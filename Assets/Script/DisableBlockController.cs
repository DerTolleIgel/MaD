using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisableBlockController : MonoBehaviour
{

    GameObject player1;
    GameObject player2;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player1 = GameObject.Find("Controllers").GetComponent<PlayerMovement>().player1;
        player2 = GameObject.Find("Controllers").GetComponent<PlayerMovement>().player2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        

        // higher danger level
        BlockController mainBc = gameObject.GetComponent<BlockController>();
        if (mainBc.scriptValueA > 0)
        {
            if (collision.gameObject == player1 || collision.gameObject == player2 )
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
                foreach(GameObject go in blocks)
                {
                    BlockController bc = go.GetComponent<BlockController>();
                    if(bc.scriptValueA > 0 && bc.scriptValueA < mainBc.scriptValueA)
                    {
                        bc.changeStatusTo(false) ;
                    }
                }
            }
        }

        // reset block
        if (mainBc.scriptValueA == -1)
        {
            bool a = GetComponent<BoxCollider2D>().IsTouching(player1.GetComponent<BoxCollider2D>());
            bool b = GetComponent<BoxCollider2D>().IsTouching(player2.GetComponent<BoxCollider2D>());
            if (a && b)
            {
                GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
                foreach (GameObject go in blocks)
                {
                    BlockController bc = go.GetComponent<BlockController>();
                    if (bc.scriptValueA > 0)
                    {
                        bc.changeStatusTo(true);
                    }
                }
            }
        }

        

    }

}
