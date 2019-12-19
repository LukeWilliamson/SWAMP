using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum zoneType
{
	water,
	scalableBackground
}

public class WaterZone : MonoBehaviour 
{
	[SerializeField]
	public zoneType typeOfZone;

	void OnTriggerStay2D (Collider2D other)
	{
		if(other.gameObject.GetComponent<PlayerController>())
		{
			if(typeOfZone == zoneType.water)
			{
				other.gameObject.GetComponent<PlayerController>().inWater = true;
			}
			else if(typeOfZone == zoneType.scalableBackground)
			{
				other.gameObject.GetComponent<PlayerController>().scalingBackground = true;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.GetComponent<PlayerController>())
		{
			if(typeOfZone == zoneType.water)
			{
				other.gameObject.GetComponent<PlayerController>().inWater = false;
			}
			else if(typeOfZone == zoneType.scalableBackground)
			{
				other.gameObject.GetComponent<PlayerController>().scalingBackground = false;
			}
		}
	}
}
