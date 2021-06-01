using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    private void Update()
    {
        
    }

    public GameObject obstaclePrefab;
    public GameObject alternateobstaclePrefab;

    void SpawnObstacle () 
    {
        //CHoose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(4, 7);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        float randomChance = Random.Range(0.0f, 1.0f);

        //Spawn the obstacle at that position
        if(randomChance < 0.4f){
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
        else{
        Instantiate(alternateobstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }
}
