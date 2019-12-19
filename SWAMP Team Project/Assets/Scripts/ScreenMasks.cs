using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMasks : MonoBehaviour 
{
	public CameraBoundaries[] clearAreas;
	PlayerController player;
	SpriteRenderer rend;

	void Start () 
	{
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
