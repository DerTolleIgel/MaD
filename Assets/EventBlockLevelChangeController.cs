using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBlockLevelChangeController : MonoBehaviour
{

    public string levelName;

    private GameObject player1;
    private GameObject player2;

    // Start is called before the first frame update
    private bool p1entered = false;
    private bool p2entered = false;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        controllers.GetComponent<PlayerMovement>();
        player1 = controllers.GetComponent<PlayerMovement>().player1;
        player2 = controllers.GetComponent<PlayerMovement>().player2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player1) p1entered = true;
        if (collision.gameObject == player1) p2entered = true;

        if (p1entered && p2entered)
        {
            LevelManager.get().LoadLevel(levelName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player1) p1entered = false;
        if (collision.gameObject == player1) p2entered = false;
    }
}
