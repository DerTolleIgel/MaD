using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DisableBlockController : MonoBehaviour
{

    GameObject player1;
    GameObject player2;

    private bool player1touches = false;
    private bool player2touches = false;

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
            if (collision.gameObject == player1) player1touches = true;
            if (collision.gameObject == player2) player2touches = true;

            if(player1touches && player2touches)
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

        Debug.Log("Enter: player1 = " + player1touches + " / player2 = " + player2touches);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        BlockController mainBc = gameObject.GetComponent<BlockController>();
        if (mainBc.scriptValueA == -1)
        {
            if (collision.gameObject == player1) player1touches = false;
            if (collision.gameObject == player2) player2touches = false;
        }

        Debug.Log("Exit: player1 = " + player1touches + " / player2 = " + player2touches);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
