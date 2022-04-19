using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool EnemyPool;
    public int MaxEnemyCount;
    public int ZPos = 20;
    public int EnemyCount = 1;

    private const int MinXPos = -20;
    private const int MaxXPos = 21;
    private const float YOffset = 1.0f;
    
    private List<GameObject> Enemies;
    private bool SpawnWave;

    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<GameObject>();
        SpawnWave = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpawnWave)
        {
            InstantiateEnemies();
            SpawnEnemies();
            SpawnWave = false;
            EnemyCount = Mathf.Min(++EnemyCount, MaxEnemyCount);
        }
        CleanUp();
    }

    private void InstantiateEnemies()
    {
        GameObject enemy;
        for(int index = 0; index < EnemyCount && SpawnWave; index++)
        {
            enemy = EnemyPool.GetPooledObject();
            if (enemy != null)
            {
                Enemies.Add(enemy);
                enemy.SetActive(true);
            }
            else
            {
                SpawnWave = false;
                Debug.Log("Ending after " + index + " spawned enemies");
            }
        }
    }

    private void SpawnEnemies()
    {
        int xPos;
        Vector3 pos;
        Debug.Log("Spawning " + EnemyCount + " enemies");
        foreach(GameObject enemy in Enemies)
        {
            xPos = Random.Range(MinXPos, MaxXPos);
            //Transform and activate enemy
            pos = new Vector3(xPos, YOffset, ZPos);
            enemy.transform.position = pos;
           
            Debug.Log("Enemy spawned @" + enemy.transform.position);
            Debug.Log("Enemy enabled: " + enemy.activeInHierarchy);
        }
        foreach (GameObject enemy in Enemies)
            Debug.Log("Enemy @" + enemy.transform.position);
        Debug.Log("Spawned " + Enemies.Count + " enemies");
    }

    private void CleanUp()
    {
        Stack<int> indicies = new Stack<int>();
        //Maintain only active enemies in Enemies
        for(int index = 0; index < Enemies.Count; index++)
        {
            if(!Enemies[index].activeInHierarchy)
            {
                Debug.Log("Cleaning enemy");
                indicies.Push(index);
            }
        }
        while(indicies.Count > 0)
        {
            Enemies.RemoveAt(indicies.Pop());
            Debug.Log(Enemies.Count + " enemies remaining");
        }
        SpawnWave = (Enemies.Count <= 0);
    }
}