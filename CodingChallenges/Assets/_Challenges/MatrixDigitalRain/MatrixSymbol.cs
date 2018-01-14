using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixSymbol : MonoBehaviour
{
	TextMesh Text;
	float LastSwitch;
	float SwtichInterval;
	float CamSize;
	public Vector3 SymbolPosition;
	public float Speed;
	public bool First;
	public float Opacity;
	void Start ()
	{
		CamSize = Camera.main.orthographicSize;
		transform.position = SymbolPosition;
		Text = GetComponent<TextMesh> ();
		LastSwitch = Time.time;
		SwtichInterval = Random.Range (0.035f, 0.9f);
		if (First)
		{
			Text.color = new Color (0.55f, 1f, 0.66f, Opacity);
		}
		else
		{
			Text.color = new Color (0f, 1f, 0.27f, Opacity);
		}
		Text.text = "" + (char) (0x30A0 + Random.Range (0, 97));
	}
	void FixedUpdate ()
	{
		if (Time.time > LastSwitch + SwtichInterval)
		{
			var charType = Random.Range (0, 6);
			if (charType > 1)
			{
				Text.text = "" + (char) (0x30A0 + Random.Range (0, 97));
			}
			else
			{
				Text.text = Random.Range (0, 10).ToString ();
			}
			LastSwitch = Time.time;
		}
		SymbolPosition.y = transform.position.y - Speed;
		if (SymbolPosition.y <= -CamSize)
		{
			SymbolPosition.y += CamSize*2f;
		}
		transform.position = SymbolPosition;
	}
}