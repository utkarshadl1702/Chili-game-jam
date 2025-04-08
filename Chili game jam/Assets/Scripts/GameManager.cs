using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Make it accesable throughout
    public static GameManager instance;
    //Make it a singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Make a variable that stores number of flower and flowertype of it
    public Dictionary<FlowerType.FlowerTypeEnum, int> flowerData = new Dictionary<FlowerType.FlowerTypeEnum, int>();

    
}
