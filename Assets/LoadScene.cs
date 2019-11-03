using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string NextScene;

    void OnTriggerEnter2D(Collider2D col)
    {
        print("-----------------------------------------------------------------");
        if (col.gameObject.GetComponent<movementController>() != null)
            SceneManager.LoadScene(NextScene);
    }
}
