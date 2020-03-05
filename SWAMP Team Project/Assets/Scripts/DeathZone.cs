using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeathZone : MonoBehaviour 
{
	BoxCollider2D col;
	RespawnManager respawn;

	public bool forcedRespawn = true;
	public int damage = 1;

	void Start () 
	{
		col = GetComponent<BoxCollider2D>();
		respawn = FindObjectOfType<RespawnManager>();

		col.isTrigger = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.GetComponent<PlayerController>())
		{
			Stats.playerHealth -= damage;

			if(Stats.playerHealth > 0)
			{
				if(forcedRespawn)
				{
					respawn.Respawn();
				}
			}
			else
			{
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
		}
	}
}
