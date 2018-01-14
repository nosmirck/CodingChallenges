using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MengerSponge : MonoBehaviour
{
	public GameObject CubePrefab;
	public int Depth;
	public float Size;

	void Awake ()
	{
		//If you have a powerful computer, go ahead and try to get a maximum depth
		//for me, 5 is the top, 4 is ok.
		if (Depth > 5) Depth = 5;
		CreateMengerSponge (transform.position, Size, Depth);
	}

	// Update is called once per frame
	private void CreateMengerSponge (Vector3 center, float size, int depth)
	{
		if (depth == 1)
		{
			DrawCube (center, size);
		}
		else
		{
			float newSize = size / 3f;
			for (int ix = -1; ix < 2; ix++)
			{
				for (int iy = -1; iy < 2; iy++)
				{
					if (ix == 0 && iy == 0)
					{
						continue;
					}
					for (int iz = -1; iz < 2; iz++)
					{
						if ((iz == 0) && ((ix == 0) || (iy == 0)))
						{
							continue;
						}
						Vector3 newCenter = center + (new Vector3 (ix, iy, iz) * newSize);
						CreateMengerSponge (newCenter, newSize, depth - 1);
					}
				}
			}
		}
	}

	private void DrawCube (Vector3 center, float size)
	{
		GameObject cube = Instantiate (CubePrefab);
		cube.transform.parent = transform;
		cube.transform.localPosition = center;
		cube.transform.localRotation = Quaternion.identity;
		cube.transform.localScale = Vector3.one * size;
	}
}