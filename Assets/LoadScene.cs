using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string NextScene;
    public bool lastScene;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (lastScene)
            movementController.atkDamage = 100;
        print("-----------------------------------------------------------------");
        if (col.gameObject.GetComponent<movementController>() != null)
            SceneManager.LoadScene(NextScene);
    }
}
