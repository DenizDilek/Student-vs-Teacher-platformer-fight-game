using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Transform Enemy;
    public Rigidbody2D rb;
    private Vector2 target;
    public float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector2(player.position.x - Enemy.position.x , player.position.y - Enemy.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        while (target.x < 5 && target.x > -5 && target.x != 0)
        {
            target = target * 3;
        }
        rb.velocity = target * speed * Time.fixedDeltaTime;
        

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D info)
    {
        
        PlayerMove playermove = info.GetComponent<PlayerMove>();
        if(playermove != null)
        {


            
            GameManager.isHit = true;
            DestroyBullet();
            
        }
    }
}
