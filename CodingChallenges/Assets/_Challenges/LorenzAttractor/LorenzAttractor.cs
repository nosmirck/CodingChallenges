using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorenzAttractor : MonoBehaviour
{
	public float speed = 0.5f;
	Vector3 currentPosition;
	Vector3 constants;
	Vector3 deltaPosition;
	// Use this for initialization
	void Start ()
	{
		currentPosition = Vector3.right * 0.1f;
		constants = new Vector3 (10f, 28f, 8f / 3f);
		deltaPosition = Vector3.zero;
	}

	// Update is called once per frame
	void Update ()
	{
		deltaPosition.x = (constants.x * (currentPosition.y - currentPosition.x)) * Time.deltaTime * speed;
		deltaPosition.y = (currentPosition.x * (constants.y - currentPosition.z) - currentPosition.y) * Time.deltaTime * speed;
		deltaPosition.z = ((currentPosition.x * currentPosition.y) - (constants.z * currentPosition.z)) * Time.deltaTime * speed;

		currentPosition = currentPosition + deltaPosition;

		transform.localPosition = currentPosition;

	}
}