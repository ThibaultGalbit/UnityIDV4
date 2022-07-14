using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage;

    GameObject player;

    private float lastAttackedAt = -9999f;
    private float cooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        verifyPlayerDistance();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Player")
        {
            damageToPlayer();
        }
    }



    void verifyPlayerDistance()
    {
        BoxCollider2D bx = gameObject.GetComponent<BoxCollider2D>();
        BoxCollider2D bxPlayer = gameObject.GetComponent<BoxCollider2D>();


        if (bx.IsTouching(bxPlayer))
        {
            damageToPlayer();
        }
    }

    void damageToPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (Time.time > lastAttackedAt + cooldown)
        {
            playerHealth.TakeDamage(damage);
            lastAttackedAt = Time.time;
        }

    }

}
