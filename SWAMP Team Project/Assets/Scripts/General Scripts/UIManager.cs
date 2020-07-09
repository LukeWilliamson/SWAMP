using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healthIndicator;
    public Text moneyCounter;
    public Sprite[] healthIndicatorLevels;

    void Start()
    {
        
    }

    void Update()
    {
        healthIndicator.sprite = healthIndicatorLevels[Stats.playerHealth];
        moneyCounter.text = "" + Stats.playerMoney;
    }
}
