using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GateLevelUp : MonoBehaviour
{

    GameObject player;

    PlayerLevel playerLevel;

    Inventory inventory;

    public string sceneName;

    GameObject gateNotice;


    void Start()
    {
        player = GameObject.Find("Player");
        playerLevel = player.GetComponent<PlayerLevel>();
        inventory = Inventory.instance;
        gateNotice = GameObject.Find("GateNotice");
        gateNotice.SetActive(false);


    }

    //Detect collisions between the GameObjects with Colliders attached

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int nbGems = inventory.getGemsCount();

        if (collision.gameObject.name == "Player")
        {
            if(playerLevel.playerCanLevelUp(SceneManager.GetActiveScene().name, nbGems))
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
        player.GetComponent<PlayerHealth>().resetHealth();
        inventory.resetGems();
        SceneManager.LoadScene(sceneName);
    }

    void cannotLevelUp()
    {
        gateNotice.SetActive(true);
    }
}
