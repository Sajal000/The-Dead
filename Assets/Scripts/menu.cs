using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public string nextScene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
