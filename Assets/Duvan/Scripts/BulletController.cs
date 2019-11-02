using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float SleepTime;
    public float activationRate;
    public List<GameObject> bullets;

    void Start()
    {
        StartCoroutine("Activate");
    }

    IEnumerator Activate()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].SetActive(true);
            yield return new WaitForSeconds(activationRate);
        }

        yield return new WaitForSeconds(SleepTime);

        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].SetActive(false);
            yield return new WaitForSeconds(activationRate);
        }
    }
}
