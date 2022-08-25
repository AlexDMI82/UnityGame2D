using UnityEngine;

public class Crystals : MonoBehaviour
{

    public AudioClip crystalSound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {          
            DestroyCrystal();
            Debug.Log("Crystal Destroyed!");
            AudioSource.PlayClipAtPoint(crystalSound, transform.position, 2f);
            
        }
    }


    void DestroyCrystal()
    {
        StatsManager.instance.AddPoint();
        Destroy(gameObject);
       
        
    }


}
