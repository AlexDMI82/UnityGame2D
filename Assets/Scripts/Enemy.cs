
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;    
    public int currentHealth;
    public Animator anim;
    public GameObject blood;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Start()
    {
        currentHealth = maxHealth;
    }



    public void TakeDamage(int damage)
     {
        PlayBloodAnimation();
         currentHealth -= damage;        
        // play hurt animation
        anim.SetTrigger("EnemyHurt");   

        if (currentHealth <= 0)
            {
              Die();          
            }
     }

    void Die()
    {
        // die animation     
        anim.SetBool("isDead", true);

        // disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 

        // stop enemy from patrolling
        this.GetComponent<EnemyPatrol>().enabled = false;     

        Debug.Log("Enemy Died!");
    }


    void PlayBloodAnimation()
    {
        // blood particles
        blood.SetActive(true);
        Instantiate(blood, transform.position, Quaternion.identity);
        blood.SetActive(false);
        
    }


}
