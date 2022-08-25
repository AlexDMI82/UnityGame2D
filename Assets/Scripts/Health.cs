using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    public float currentHealth;
    private bool dead;
    private Animator anim;


    public AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    public void TakeDamage(float _damage)
    {
        
        // to handle the range of damage and that it does not goes below 0
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        AudioSource.PlayClipAtPoint(hurtSound, transform.position, 2f);
        //currentHealth -= _damage;

        if (currentHealth > 0)
        {            
            Debug.Log("Hurt, but still alive");
            
        }
        else 
            if (!dead)
        {

            Debug.Log("Dead");
            GetComponent<PlayerMovements>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            anim.SetTrigger("die");
            dead = true;
        }




    }

}
