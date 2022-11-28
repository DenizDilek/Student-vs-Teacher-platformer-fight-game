using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public float speed;
    private bool m_FacingRight = true;
    private Transform target;
    private Rigidbody2D m_Rigidbody2D;
    private float move;
    private Vector3 m_Velocity = Vector3.zero;
    public GameObject Bullet2;
    private float timebtwshots;
    public float startshottime;
    public Transform Firepoint1;
    public Animator animator;
    public bool isCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = target.position.x - transform.position.x;
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        
        if (timebtwshots <= 0 && QuestionAsking.Question == false)
        {
            
            StartCoroutine(Charges());
            
            
            Score.ScoreValue += 1;
            timebtwshots = startshottime;
        }
        else
        {
            timebtwshots -= Time.fixedDeltaTime;
        }
        if (Vector2.Distance(transform.position, target.position) > 3 && isCharging != true && QuestionAsking.Question == false )
        {
            Vector3 targetVelocity = new Vector2(speed *move * Time.fixedDeltaTime , m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            animator.SetFloat("Speed", Mathf.Abs(move));
        }
        
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        transform.Rotate(0f, 180f, 0f);
    }
    IEnumerator Charges()
    {
        isCharging = true;
        animator.SetBool("isCharging", isCharging);
        
        yield return new WaitForSeconds(1);
        isCharging = false;
        animator.SetBool("isCharging", isCharging);
        Instantiate(Bullet2, Firepoint1.position, Firepoint1.rotation);
    }
}

