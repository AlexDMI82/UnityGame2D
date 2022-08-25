using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool movingRight = true;
    public float distance;
    public Transform groundDetection;
    public Animator anim;


    public bool enemyInSight = true;

  


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {

        if (enemyInSight)
        {
            Patroll();
        }

    }



    private void Patroll()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        anim.SetBool("Running", true);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }






}
