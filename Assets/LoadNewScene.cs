using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
    public string nameScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nameScene);
    }
}
