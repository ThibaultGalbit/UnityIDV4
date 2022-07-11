using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setStateOfGem();

    }

    void setStateOfGem()
    {
        Vector3 vecDist = player.position - transform.position;
        float playerDistance = Mathf.Abs(vecDist.x) + Mathf.Abs(vecDist.y);

        if(playerDistance < 0.8)
        {
            gameObject.SetActive(false);
        }
    }
}
