using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovePlatform : MonoBehaviour
{
    public float speed;
    public GameObject Player;
    public int StartPoint;
    public Transform[] points;
    private int i;   
    void Start()
    {
        transform.position = points[StartPoint].position;
    }
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,points[i].position ) < 0.02f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        Player.transform.parent = transform;
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        Player.transform.parent = null;
    }
}
