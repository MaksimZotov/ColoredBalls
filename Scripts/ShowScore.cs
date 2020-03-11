using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{ 
    [SerializeField] Text MaxScore;
    [SerializeField] Text CurrentScore;
    [SerializeField] CalculatedScore DataScore;

    void Start()
    {
        TriggerManager.TriggerEnterTrue += UpdateCurrentScore;
        TriggerManager.TriggerEnterFalse += UpdateMaxScore;
        ClickPlayManager.ClickPlay += UpdateCurrentScore;
    }

    public void UpdateCurrentScore()
    {
        CurrentScore.text = "" + DataScore.CurrentScore;
    }

    public void UpdateMaxScore()
    {
        MaxScore.text = "Best score:\n" + DataScore.MaxScore;
    }
}
