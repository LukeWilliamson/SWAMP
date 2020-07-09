using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpawnPoint
{
	public Vector2 spawnPointPosition;
	public Vector2 triggerZonePosition;
	public Vector2 triggerZoneSize = Vector2.one;
}

public class RespawnManager : MonoBehaviour 
{
	[SerializeField]
	public SpawnPoint[] spawnPoints;
	int current = 0;
	PlayerController player;

	Image blackScreen;
	bool dying = false;
	float fadeTime = 1;

	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
	}
	
	void Update () 
	{
		blackScreen = FindObjectOfType<CameraController>().blackScreen.GetComponent<Image>();
		IsPlayerInBounds();

		if(dying)
		{
			Respawn();
		}
	}

	void IsPlayerInBounds()
	{
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (spawnPoints[i].triggerZonePosition.x + (spawnPoints[i].triggerZoneSize.x / 2) > player.transform.position.x &&
				spawnPoints[i].triggerZonePosition.x - (spawnPoints[i].triggerZoneSize.x / 2) < player.transform.position.x &&
				spawnPoints[i].triggerZonePosition.y + (spawnPoints[i].triggerZoneSize.y / 2) > player.transform.position.y &&
				spawnPoints[i].triggerZonePosition.y - (spawnPoints[i].triggerZoneSize.y / 2) < player.transform.position.y)
			{
				current = i;
			}
		}
	}

	public void Respawn ()
	{
		dying = true;
		fadeTime -= Time.deltaTime;
		player.rigBod.velocity = Vector2.zero;

        if (fadeTime > 0)
		{
			blackScreen.color = Color.Lerp(blackScreen.color, Color.black, Time.deltaTime * 6);
		}

		if (fadeTime < 0)
		{
			blackScreen.color = Color.Lerp(blackScreen.color, Color.clear, Time.deltaTime * 6);
			player.transform.position = spawnPoints[current].spawnPointPosition;

			if(fadeTime < -1)
			{
				dying = false;
				fadeTime = 1;
			}
		}

	}

	#if UNITY_EDITOR
	void OnDrawGizmosSelected()
	{
		for(int i = 0; i < spawnPoints.Length; i++)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(spawnPoints[i].spawnPointPosition, 0.1f);
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube(spawnPoints[i].triggerZonePosition, spawnPoints[i].triggerZoneSize);
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(spawnPoints[current].spawnPointPosition, 0.1f);
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(spawnPoints[current].triggerZonePosition, spawnPoints[current].triggerZoneSize);
	}
	#endif
}
