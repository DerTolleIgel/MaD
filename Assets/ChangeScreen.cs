using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject nextScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
 * taken from here: https://answers.unity.com/questions/1368545/how-do-i-create-a-scene-variable.html
 public string levelName;
  
      void OnTriggerEnter2D(Collider2D coll) {
  
          if(coll.gameObject.name == "Player") {
              // Loading the scene from it's name
              SceneManager.LoadScene(levelName);
          }
      }
*/