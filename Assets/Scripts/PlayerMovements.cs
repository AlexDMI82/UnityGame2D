
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private float horizontalInput;
    private Animator anim;
    [SerializeField]private int jumpPower;
    //[SerializeField] private LayerMask groundLayer;
    private bool grounded;
    [SerializeField] private float launchVelocity;
    public ParticleSystem dust;

  
    [SerializeField] protected AudioSource source;
    public AudioClip jumpClip;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       

    }

   

    protected virtual void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        source = audioSources[0];
        jumpClip = audioSources[0].clip;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");       
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // flip player when moving left and rigth
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one / 2;
            CreateDust();
        }   

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1) / 2;
            CreateDust();
        }       
 
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //if (Input.GetMouseButtonDown(1) && !grounded)
        //{
        //    Fly();
        //    Debug.Log("Flying");
        //}

        anim.SetBool("run", horizontalInput != 0);

    }

   private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        grounded = false;
        CreateDust();

        source.PlayOneShot(jumpClip);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }


    void CreateDust()
    {
        dust.Play();
    }


    //private void Fly()
    //{
    //    //body.velocity = launchVelocity * transform.forward;
    //    body.AddForce(transform.forward * Time.deltaTime * 1000);
  
    //}








}
