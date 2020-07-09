using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    money,
    swordItem
}

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    public itemType typeOfItem;
    public int value = 0;
    public int iD;
    public bool waitToAnimate = false;

    bool animating = true;
    void Start()
    {
        if (waitToAnimate)
        {
            StartCoroutine(Animate());
        }
        else
        {
            animating = false;
        }

        if(typeOfItem == itemType.money && Stats.moneyCollected[iD])
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(1.5f);
        animating = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() && !animating)
        {
            if(typeOfItem == itemType.money)
            {
                Stats.playerMoney += value;
                Stats.moneyCollected[iD] = true;
                Destroy(this.gameObject);
            }

            if (typeOfItem == itemType.swordItem)
            {
                Stats.hasSword = true;
                Destroy(this.gameObject);
            }
        }
    }
}
