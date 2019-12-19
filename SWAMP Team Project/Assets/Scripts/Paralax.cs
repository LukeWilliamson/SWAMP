using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour 
{
	[System.Serializable]
	public struct paralaxLayer
	{
		public Transform layer;
		public float moveSpeed;
	}

	[SerializeField]
	public paralaxLayer[] layers;
	Vector3 camPos;

	void Start ()
	{
		camPos = transform.position;
	}

	void LateUpdate () 
	{
		for(int i = 0; i < layers.Length; i++)
		{
			Vector3 paralax = (camPos - transform.position) * layers[i].moveSpeed;
			layers[i].layer.position = new Vector3(layers[i].layer.position.x + paralax.x, layers[i].layer.position.y + paralax.y, layers[i].layer.position.z);
		}

		camPos = transform.position;
	}
}
