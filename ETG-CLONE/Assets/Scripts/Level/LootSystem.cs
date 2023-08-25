using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SpawnItem 
{
    public GameObject item;
    public float spawnRate;
    [HideInInspector] public float minSpawnProb, maxSpawnProb;
}

public class LootSystem : MonoBehaviour
{
    public SpawnItem[] spawnItem;
    bool isClosed = true;


    private void Start()
    {
        for (int i = 0; i < spawnItem.Length; i++)
        {
            if(i == 0)
            {
                spawnItem[i].minSpawnProb = 0;
                spawnItem[i].maxSpawnProb = spawnItem[i].spawnRate - 1;
            }
            else
            {
                spawnItem[i].minSpawnProb = spawnItem[i-1].maxSpawnProb +1;
                spawnItem[i].maxSpawnProb = spawnItem[i].minSpawnProb + spawnItem[i].spawnRate - 1;

            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Spawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Spawn();
        }
    }
    void Spawn()
    {
        float randomNum = Random.Range(0, 100);

        for (int i = 0; i < spawnItem.Length; i++)
        {
            if(randomNum>= spawnItem[i].minSpawnProb && randomNum <= spawnItem[i].maxSpawnProb && isClosed)
            {
                Instantiate(spawnItem[i].item, transform.position, Quaternion.identity);
                isClosed = false;
                break;
            }

        }
    }
}
