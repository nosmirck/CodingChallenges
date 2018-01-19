using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixSymbolStream : MonoBehaviour
{
	public GameObject SymbolPrefab;
	void Start ()
	{
		int Width = Mathf.FloorToInt (Camera.main.orthographicSize * Camera.main.aspect);
		for (int x = -Width; x < Width + 1; x++)
		{
			int StreamSize = Random.Range (5, 35);
			bool HasFirstChange = Random.Range (0, 5) == 0;
			float StreamSpeed = Random.Range (0.05f, 0.66f);
			int posY = Random.Range (0, StreamSize);
			for (int y = 0; y < StreamSize; y++)
			{
				GameObject symbolPref = Instantiate (SymbolPrefab, this.transform.position, Quaternion.identity);
				MatrixSymbol symbol = symbolPref.GetComponent<MatrixSymbol> ();
				symbol.First = HasFirstChange && y == 0;
				symbol.SymbolPosition = new Vector3 (x, y + posY, 0);
				symbol.Speed = StreamSpeed;
				symbol.Opacity = Remap (y, 0, StreamSize, 1f, 0.1f);
			}
		}
	}
	public float Remap (float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}