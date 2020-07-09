using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMasks : MonoBehaviour 
{
	public CameraBoundaries[] clearAreas;
	PlayerController player;
	SpriteRenderer rend;

    public bool oneTime;
    public int oneTimeID;

	void Start () 
	{
        if(oneTime && BreakableWallManager.wallsAreHidden[oneTimeID])
        {
            Destroy(this.gameObject);
        }

		player = FindObjectOfType<PlayerController>();
		rend = GetComponent<SpriteRenderer>();

		if(IsPlayerInBounds())
		{
			rend.color = Color.clear;
		}
		else
		{
			rend.color = Color.white;
		}
	}

	void Update () 
	{
		if(IsPlayerInBounds())
		{
			rend.color = Color.Lerp(rend.color, Color.clear, Time.deltaTime * 7);

            if(rend.color == Color.clear && oneTime)
            {
                BreakableWallManager.wallsAreHidden[oneTimeID] = true;
                Destroy(this.gameObject);
            }
		}
		else
		{
			rend.color = Color.Lerp(rend.color, Color.white, Time.deltaTime * 7);
		}
	}

	bool IsPlayerInBounds()
	{
		for (int i = 0; i < clearAreas.Length; i++)
		{
			if (clearAreas[i].transform.position.x + (clearAreas[i].size.x / 2) > player.transform.position.x &&
				clearAreas[i].transform.position.x - (clearAreas[i].size.x / 2) < player.transform.position.x &&
				clearAreas[i].transform.position.y + (clearAreas[i].size.y / 2) > player.transform.position.y &&
				clearAreas[i].transform.position.y - (clearAreas[i].size.y / 2) < player.transform.position.y)
			{
				return true;
			}
		}
		return false;
	}
}
