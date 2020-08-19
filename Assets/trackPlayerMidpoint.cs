using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPlayerMidpoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (player1.transform.position + player2.transform.position) / 2;
    }
}
