using UnityEngine;

public class EnemyProjectile : EnemyDamage // will damage the player every time it touches
{

    [SerializeField] private float speed;  

    private Transform player;
    private Vector2 target; 
    public float lifeTime;

    public AudioClip explosionClip;

    


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
       

    }


    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            DestroyProjectile();
            other.GetComponent<Health>().TakeDamage(damage);
            AudioSource.PlayClipAtPoint(explosionClip, transform.position, 2f);
           
        }
    }


    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }






}
