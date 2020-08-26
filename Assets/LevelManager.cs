using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    static private LevelManager instance;
    public float transitionTime = 1.1f;
    public Level[] levels;
    public Animator transition;



    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            //instance.transition.SetTrigger("End");
            return;
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string levelName)
    {
        int buildIndex = -1;
        foreach (Level level in levels)
        {
            if (level.name == levelName)
            {

                buildIndex = level.buildIndex;
                break;
            }
        }
        if(buildIndex != -1)
        StartCoroutine(LoadLevelCo(buildIndex));
    }
    private IEnumerator LoadLevelCo(int buildIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(buildIndex);        

    }


    static public LevelManager get()
    {
        return instance;
    }
        

   
}
