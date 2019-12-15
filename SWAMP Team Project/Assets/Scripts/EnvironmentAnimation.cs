using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAnimation : MonoBehaviour 
{
	public AnimationClip fromLeftAnimation;
	public AnimationClip fromRightAnimation;
	public bool destroyAfterPlay = false;

	PlayerController player;
	BoxCollider2D col;
	Animation anim;
	bool isPlaying;

	void Start ()
	{
		player = FindObjectOfType<PlayerController>();
		col = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animation>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.GetComponent<PlayerController>() && !isPlaying)
		{
			if(player.transform.position.x < col.bounds.center.x)
			{
				anim.clip = fromLeftAnimation;
				anim.Play();

				StartCoroutine(WaitForAnim(true));
			}
			else if(player.transform.position.x > col.bounds.center.x)
			{
				anim.clip = fromRightAnimation;
				anim.Play();

				StartCoroutine(WaitForAnim(false));
			}
		}
	}

	IEnumerator WaitForAnim(bool left)
	{			
		isPlaying = true;
		if(left)
		{
			yield return new WaitForSeconds(fromLeftAnimation.length);
		}
		else
		{
			yield return new WaitForSeconds(fromRightAnimation.length);
		}

		if(destroyAfterPlay)
		{
			Destroy(this.gameObject);
		}
		else
		{
			isPlaying = false;
		}
	}
}
