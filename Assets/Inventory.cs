using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int gemsCount;
    public Text gemsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instace d'inventaire");
            return;
        }

        instance = this;
    }

    public void addGems(int count)
    {
        gemsCount += count;
        gemsCountText.text = gemsCount.ToString();
    }
}
