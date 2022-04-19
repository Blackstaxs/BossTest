using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
	public float FloatWidth = 10f;
	public float FloatHeight = 10f;
	public float randomMin = .7f;

	public GameObject WallObject;
	public NavMeshSurface MeshSurface;

	private int IntRange = 4;

	// Use this for initialization
	void Start()
	{
		GenerateLevel();
		MeshSurface.BuildNavMesh();
	}

	// Create a grid based level
	void GenerateLevel()
	{
		// Loop over grid
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

	// Spawn wall
	void SpawnWall(int x, int y)
    {
		Vector3 pos = new Vector3(x - FloatWidth / 2f, 1f, y - FloatHeight / 2f);
		GameObject wall = (GameObject)Instantiate(WallObject, pos, Quaternion.identity);
		wall.transform.Translate(new Vector3(0.0f, wall.transform.localScale.y / 2.0f, 0.0f));
	}
}
