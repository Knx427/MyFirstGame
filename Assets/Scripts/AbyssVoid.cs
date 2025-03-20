using UnityEngine;
using System;
public class AbyssVoid : MonoBehaviour
{
    public static event Action fellIntoAbyss;
  void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fellIntoAbyss?.Invoke();
        }
    }
}
