using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim, anim2, anim3, anim4, anim5;
    [SerializeField] float jumpForce;

    bool grounded;
    bool gameOver = false;
    private string playerJump = "Jump";
    private string debugDelete = "DeleteMe";
    private string ground = "Ground";
    private string obstacle = "Obstacle";
    private string playerDeath = "SantaDeath";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver)
        {
            if (grounded == true)
            {
                jump();
            }
        }
    }

    void jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger(playerJump);

        GameManager.instance.IncrementScore();
        Debug.Log(debugDelete);
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   {
        if(collision.gameObject.tag == ground)
        {
            grounded = true;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == obstacle){
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play(playerDeath);
            gameOver = SetGameOverTrue();
        }
    }
}
