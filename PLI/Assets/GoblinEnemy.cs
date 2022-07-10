using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : MonoBehaviour
{
    public float moveSpeed = 1f ;
    public int damage = 10;
    public int distanceForFollow = 10;
    private string enemyDirection;
    
    // Attack attrs
    private float lastAttackedAt = -9999f;
    public float cooldown = 1f; //seconds


    public Transform player;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        rb.rotation = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
   
    }

    private void FixedUpdate()
    {
        //setDirection();
        setStateOfEnemy();
    }

    void setDirection()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) { 

        Vector3 vecRotation = player.position - transform.position;
        float rotation = Mathf.Atan2(vecRotation.y, vecRotation.x) * Mathf.Rad2Deg;

            if (rotation < -135 || rotation > 135)
            {
                enemyDirection = "left";
                animator.Play("Godlin_left");
            }
            else if (rotation < 45 && rotation > -45)
            {
                enemyDirection = "right";
                animator.Play("Godlin_right");
            }
            else if (rotation > -135 && rotation < -45)
            {
                enemyDirection = "down";
                animator.Play("Goblin_Down");
            }
            else
            {
                enemyDirection = "up";
                animator.Play("Godlin_Up");
            }
        }
    }

    void moveCharacter()
    {
        rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
    }

    void setStateOfEnemy()
    {
        Vector3 vecDist = player.position - transform.position;
        float playerDistance = Mathf.Abs(vecDist.x) + Mathf.Abs(vecDist.y);

        Debug.Log(playerDistance);

        if (playerDistance > 1.5 && playerDistance < distanceForFollow) {
           setDirection();
           moveCharacter();
        } else if (playerDistance <= 1.5) { 
            attack();
        }else {
            animator.Rebind();
        }

    }

    void attack()
    {

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                switch(enemyDirection)
                {
                    case "left":
                        animator.Play("Goblin_attack_left");
                        break;
                    case "right":
                        animator.Play("Goblin_attack_right");
                        break;
                    case "up":
                        animator.Play("Goblin_attack_up");
                        break;
                    case "down":
                        animator.Play("Goblin_attack_down");
                        break;
                }

                playerHealth.TakeDamage(damage);
                lastAttackedAt = Time.time;
            }
        }
        
    }

}
