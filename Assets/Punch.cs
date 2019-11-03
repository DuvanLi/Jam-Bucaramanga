using UnityEngine;

public class Punch :MonoBehaviour
{
    public AudioSource punchAudio;
   public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<iA>() != null)
        {
            if(movementController.atacking)
            {
            other.GetComponent<iA>().life -= movementController.atkDamage;
                punchAudio.Play();
            }
        }
    }
}