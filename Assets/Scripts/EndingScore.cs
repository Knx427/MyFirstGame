using TMPro;
using UnityEngine;

public class EndingScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private FloatSO scoreSO;
    private void Start()
    {
        scoreText.text ="Score:<br>" + scoreSO.Value;
    }
}
