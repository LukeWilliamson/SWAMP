using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    Image healthSprite;

    public Sprite healthSprite0;
    public Sprite healthSprite1;
    public Sprite healthSprite2;
    public Sprite healthSprite3;

    void Start()
    {
        healthSprite = GetComponent<Image>();
    }

    void Update()
    {
        SetHealthSprite();
    }

    void SetHealthSprite ()
    {
        if(Stats.playerHealth <= 0)
        {
            healthSprite.sprite = healthSprite0;
        }

        else if (Stats.playerHealth == 1)
        {
            healthSprite.sprite = healthSprite1;
        }

        else if (Stats.playerHealth == 2)
        {
            healthSprite.sprite = healthSprite2;
        }

        else if (Stats.playerHealth == 3)
        {
            healthSprite.sprite = healthSprite3;
        }
    }
}
