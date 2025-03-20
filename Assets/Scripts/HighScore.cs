using UnityEngine;
using TMPro;
using System.Security.Cryptography;
public class HighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    void Update()
    {
        scoreText.text ="High Score:<br>" + PlayerPrefs.GetFloat("HighScore", 0);
    }
}
