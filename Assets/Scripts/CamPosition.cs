using UnityEngine;

public class CamPosition : MonoBehaviour
{
    public Transform cameraPosition;


    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
