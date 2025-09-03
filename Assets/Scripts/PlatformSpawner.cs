using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject platformPrefab;
    public Transform player;

    [Header("Settings")]
    public float levelWidth = 3.0f;         // horizontal range
    public float minY = 0.5f;               // minimum vertical gap
    public float maxY = 2.0f;               // maximum vertical gap
    public int initialPlatforms = 10;       // how many to spawn at start
    public float despawnDistance = 10f;     // how far below player platforms get destroyed

    private float highestY;                 // track highest platform Y
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        highestY = player.position.y;

        // spawn some platforms at the start
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // keep spawning above player
        while (highestY < player.position.y + Camera.main.orthographicSize * 2)
        {
            SpawnPlatform();
        }

        // clean up old platforms
        for (int i = platforms.Count - 1; i >= 0; i--)
        {
            if (platforms[i].transform.position.y < player.position.y - despawnDistance)
            {
                Destroy(platforms[i]);
                platforms.RemoveAt(i);
            }
        }
    }

    void SpawnPlatform()
    {
        float y = highestY + Random.Range(minY, maxY);
        float x = Random.Range(-levelWidth, levelWidth);

        Vector3 pos = new Vector3(x, y, 0f);
        GameObject newPlat = Instantiate(platformPrefab, pos, Quaternion.identity);
        platforms.Add(newPlat);

        highestY = y;
    }
}

