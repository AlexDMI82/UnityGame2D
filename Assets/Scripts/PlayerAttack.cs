
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    private Animator anim; 
    private float cooldownTimer = Mathf.Infinity;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 20;

    // audio
    [SerializeField]protected AudioSource source;
    public AudioClip attackClip;


    private void Awake()
    {
        anim = GetComponent<Animator>();    

    }

    protected virtual void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        source = audioSources[1];
        attackClip = audioSources[1].clip;     
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            Attack();            
        }            
        cooldownTimer += Time.deltaTime;
    }


    private void Attack()
    {                      
        anim.SetTrigger("attack");
        cooldownTimer = 0;        

        // detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            // play attack sound
            source.PlayOneShot(attackClip);
        }
       
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
