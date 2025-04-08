using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Assign 4 prefabs in Inspector
    public Terrain terrain; // Assign your terrain in Inspector
    public int spawnCount = 10; // How many objects to spawn

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainSize = terrainData.size;

        for (int i = 0; i < spawnCount; i++)
        {
            // Pick a random prefab
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            // Generate a random position on the terrain
            float randomX = Random.Range(0, terrainSize.x);
            float randomZ = Random.Range(0, terrainSize.z);
            float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            Vector3 spawnPosition = new Vector3(randomX, y, randomZ);

            // Instantiate and preserve the script/components
            Instantiate(prefabToSpawn, new Vector3(spawnPosition.x, spawnPosition.y - 0.368f, spawnPosition.z), Quaternion.Euler(-90, 0, 0));

        }
    }
}