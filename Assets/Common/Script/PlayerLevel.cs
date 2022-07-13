using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    public int currentLevel = 1;
    
    public int nbGems = 0;

    public bool playerCanLevelUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(nbGems == minGemsForlevel(currentLevel))
        {
            playerCanLevelUp = true;
        }
    }


    int minGemsForlevel(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                return 1;
            case 2:
                return 3;
            case 3:
                return 6;
            case 4:
                return 10;
            case 5:
                return 13;
        }

        return 0;

    }
}
