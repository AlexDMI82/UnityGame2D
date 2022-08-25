
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
   
    public Animator anim;
    private EnemyPatrol enemyPatrol;

    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }


    private void Update()
    {
        if (PlayerInSight())
        {
            enemyPatrol.enemyInSight = false;
            anim.SetBool("EnemyAttacking", true);
        }
        else
        {
            enemyPatrol.enemyInSight = true;
            anim.SetBool("EnemyAttacking", false);
        }
    }



    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColider.bounds.size.x * range, boxColider.bounds.size.y, boxColider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

       // if (hit.collider != null)
            // can do damge here 
           // Debug.Log("Target Detected!");

        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxColider.bounds.size.x * range, boxColider.bounds.size.y, boxColider.bounds.size.z));

    }
}
