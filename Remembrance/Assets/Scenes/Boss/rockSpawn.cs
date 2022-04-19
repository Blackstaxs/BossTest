using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawn : MonoBehaviour
{
	public float FloatWidth = 20f;
	public float FloatHeight = 20f;
	public float randomMin = .7f;
	public float halfLength = 2.0f;

	public GameObject WallObject;

	private int IntRange = 4;

	public void GenerateWall()
	{
		for (int i = 0; i < 8; i++)
		{
			GenerateLevel();
		}
	}

	public void GenerateLevel()
	{
		for (int x = 0; x <= FloatWidth; x += IntRange)
		{
			for (int y = 0; y <= FloatHeight; y += IntRange)
			{
				if (Random.value > randomMin)
				{
					SpawnWall(x, y);
				}
			}
		}
	}

	void SpawnWall(int x, int y)
	{
		Vector3 pos = new Vector3(x - FloatWidth / halfLength, FloatHeight, y - FloatHeight / halfLength);
		GameObject wall = (GameObject)Instantiate(WallObject, pos, Quaternion.identity);
		wall.transform.Translate(new Vector3(0.0f, wall.transform.localScale.y / halfLength, 0.0f));
	}
}
