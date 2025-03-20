using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMPro.TMP_Text Text;
    [SerializeField]
    public FloatSO scoreSO;
    public CollectibleCount collectibleCount;
    void Awake()
    {
        Text = GetComponent<TMPro.TMP_Text>();
    }
    void OnEnable() =>  exec();
    void OnDisable() => Disabler();
    void exec()
    {
        Collectible.onCollected += OnCollectibleCollected;
        SuperCollectible.Collected += OnSuperCollectibleCollected;
        ResetGame.Reseted += Reset;
        Play.resetScore += Reset;
        MainMenu.resetScore += Reset;
        FinishExit.Finish += SetHighScore;
       
    }
    void Disabler()
    {
        Collectible.onCollected -= OnCollectibleCollected;
        SuperCollectible.Collected -= OnSuperCollectibleCollected;
    }
    void OnSuperCollectibleCollected()
    {
        scoreSO.Value+= +50;
        Debug.Log("Collected 1Supergem "+scoreSO.Value);
        UpdateScore();  
        Debug.Log(PlayerPrefs.GetFloat("HighScore",0));
    }

    void OnCollectibleCollected()
    {
        scoreSO.Value+= +10;
        Debug.Log("Collected 1gem "+scoreSO.Value);
        UpdateScore();  
        Debug.Log(PlayerPrefs.GetFloat("HighScore",0));
    }
    void UpdateScore()
    {
        if(scoreSO.Value <= PlayerPrefs.GetFloat("HighScore", 0))
            Text.text = $"Score:<br>{scoreSO.Value}";

        else if(scoreSO.Value > PlayerPrefs.GetFloat("HighScore", 0))
        {  
            Text.text =  $"High Score:<br>{scoreSO.Value}";
        }
    }
    void SetHighScore()
    {
        if(scoreSO.Value > PlayerPrefs.GetFloat("HighScore", 0))
            PlayerPrefs.SetFloat("HighScore", scoreSO.Value);
    }
    void Reset()
    {
        scoreSO.Value=0;
    }

}
