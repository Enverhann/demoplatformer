using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkScenes : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLEvel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Link scenes to each other with trigger 
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;

        if (otherGameObject.name == "Boy")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (useIntegerToLoadLEvel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
