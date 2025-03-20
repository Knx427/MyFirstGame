using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class FinishExit : MonoBehaviour
{
    public static event Action Finish;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Finish?.Invoke();
            SceneManager.LoadScene("Exited Scene");
        }
    }
}
