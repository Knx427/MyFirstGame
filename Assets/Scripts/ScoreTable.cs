using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    private Transform scorePanel; //container ScorePanel
    private Transform playerData; //template PlayerData
    void Awake()
    {
        scorePanel = transform.Find("ScorePanel");
        Debug.Log(transform.Find("ScorePanel")); 
        playerData = scorePanel.Find("PlayerData");

        playerData.gameObject.SetActive(false);

        float templateHeight = -20f;
        for(int i=0;i<10; i++)
        {
            Transform entryTransform = Instantiate(playerData, scorePanel);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
