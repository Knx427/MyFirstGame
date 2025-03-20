using UnityEngine;

public class HiScoreReset : MonoBehaviour
{
    public void ResetingScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
    }
}
