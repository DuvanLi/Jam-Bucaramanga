using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove1 : MonoBehaviour
{

    public float time;
    
    public float velocity;
    public float amplitude;
    public Rigidbody2D rb;

    public bool invert;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Kill", 5f);
    }

    // Update is called once per frame
    void Update()
    {

        time *= Mathf.Rad2Deg;

        if (time >= 360)
            time = 0;

        time += Time.deltaTime * velocity;

        time *= Mathf.Deg2Rad;

        if (!invert)
            rb.velocity = new Vector2(-velocity , Mathf.Sin(time) * amplitude);
        else
            rb.velocity = new Vector2(-velocity, -Mathf.Sin(time ) * amplitude);
    }


    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
