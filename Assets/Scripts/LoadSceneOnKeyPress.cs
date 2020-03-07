using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeyPress : MonoBehaviour
{
    public int sceneToLoadIndex;
    public KeyCode keyPress;


    void Update()
    {
        if (Input.GetKey(keyPress))
            SceneManager.LoadScene(sceneToLoadIndex);
    }
}
