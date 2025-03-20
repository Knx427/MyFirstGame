using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Object to spawn
    public GameObject LightSource;
    public Transform spawnLocation; 
    public Transform LightspawnLocation;  // Location to spawn the object
    public CountdownTimer CountdownTimer;
    private bool isObjectSpawned = false;
    GameObject Clone;
    GameObject LightClone;

    void Start()
    {
        SpawnObject();
    }
    void OnEnable() =>  CalledEnamble();
    void OnDisable() => CollectibleCount.allCollected -= SpawnObject;    
    public void SpawnObject()
    {
        if (!isObjectSpawned && objectToSpawn != null && spawnLocation != null)
        {
            Clone = Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
            LightClone = Instantiate(LightSource, LightspawnLocation.position, LightspawnLocation.rotation);
            isObjectSpawned = true;
            Debug.Log($"Object spawned at: {spawnLocation.position}");
        }
        else
        {
            Debug.LogError("Object to spawn or spawn location is not set, or object is already spawned.");
        }
    }
    void CalledEnamble()
    {
        CountdownTimer.timeUp += DespawnObject;

    }
    public void DespawnObject()
    {
        if (isObjectSpawned==true && CountdownTimer.totalTime <= 0)
        {
            Destroy(Clone);
            Destroy(LightClone);
            isObjectSpawned = false;
            Debug.Log("Object despawned.");
        }
    }
}
