using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]protected float damage;

    //private Animator anim;




    //private void Awake()
    //{
    //    anim = GetComponent<Animator>();
    
    //}



    protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player") {  
            
            collision.GetComponent<Health>().TakeDamage(damage);
           // anim.SetTrigger("EnemyAttack");
           // Debug.Log("Enemy Attacking");

        }


    }

 




}
