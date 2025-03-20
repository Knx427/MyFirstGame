using UnityEngine;

public class SpawnLoc : MonoBehaviour
{
    public Transform spawnPosition;
    void Update()
    {
        transform.position = spawnPosition.position;
    }
}
