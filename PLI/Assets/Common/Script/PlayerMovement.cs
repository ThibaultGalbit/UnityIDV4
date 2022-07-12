using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject arrowPrefab;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y =  Input.GetAxisRaw("Vertical");


        /*if (Input.GetKeyDown(KeyCode.M))
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(18.0f, 0.0f);
        }*/

        if (Input.GetButtonDown("attack"))
        {
            StartCoroutine(AttackCo());
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    } 

    private IEnumerator AttackCo()
    {
        animator.SetBool("AttackWeapon", true);
        yield return null;
        animator.SetBool("AttackWeapon", false);
        yield return new WaitForSeconds(.1f);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
