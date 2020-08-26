using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TriggerLightning : MonoBehaviour
{

    public Light2D globalLight;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("doLightning", 0.9f, 1);
    }

    void doLightning()
    {
        globalLight.GetComponent<Animator>().SetTrigger("Play");
        int i = Random.Range(1, 3);
        
        AudioManager.get().Play("thunder" + i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
