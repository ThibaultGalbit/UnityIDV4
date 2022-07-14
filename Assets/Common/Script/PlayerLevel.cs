using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    public bool playerCanLevelUp(string levelName, int nbGems)
    {
        if (nbGems >= minGemsForlevel(levelName)){
            return true;
        }
        else{
            return false;
        }
    }


    int minGemsForlevel(string levelName)
    {
        switch (levelName)
        {
            case "Level01":
                return 1;
            case "Level02":
                return 2;
            case "Level03":
                return 4;
            case "Level04":
                return 6;
            case "Level05":
                return 10;
            case "Level06":
                return 13;
        }

        return 0;

    }
}
