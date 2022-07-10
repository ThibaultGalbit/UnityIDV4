using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 7f;
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
        float angle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;
        rb.rotation = angle;
        Debug.Log(direction);
        direction.Normalize();
        movement = direction;
   
    }



    private void FixedUpdate()
    {
        moveCharacter(movement);
        setMovementAnimation(movement);
    }
    private void setMovementAnimation(Vector2 direction)
    {
        Debug.Log(direction.x < 0);

        if (direction.x < 0)
        {
            animator.Play("Godlin_left");
        } else if (direction.x > 0)
        { 
            animator.Play("Godlin_right");
        }else if (direction.y < 0)
        {
            animator.Play("Godlin_down");
        }
        else if (direction.y > 0)
        {
            animator.Play("Godlin_up");
        }

    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
