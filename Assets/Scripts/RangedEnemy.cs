using System.Collections;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxColider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerLayer;


    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        if (timeBtwShots <= 0 && PlayerInSight())
        {
            SpawnProjectile();
            
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }



    private void SpawnProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);        
    }



    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColider.bounds.size.x * range, boxColider.bounds.size.y, boxColider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        //if (hit.collider != null)
        // can do damge here 
        //Debug.Log("Target Detected!");

        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxColider.bounds.size.x * range, boxColider.bounds.size.y, boxColider.bounds.size.z));

    }



}
