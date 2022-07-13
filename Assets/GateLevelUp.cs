using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLevelUp : MonoBehaviour
{

    public Transform player;

    PlayerLevel playerLevel;

    void Start()
    {
        playerLevel = player.GetComponent<PlayerLevel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Detect collisions between the GameObjects with Colliders attached

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(playerLevel.playerCanLevelUp)
            {
                levelUp();
            }
            else
            {
                cannotLevelUp();
            }
        }
    }

    void levelUp()
    {
        Debug.Log("Level uuuuuuuuuuuuuuuuuuppp");
    }

    void cannotLevelUp()
    {
        Debug.Log("Not level uuuppp :(");
    }
}
