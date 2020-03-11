using UnityEngine;

public class CalculatedScore : MonoBehaviour
{
    public int CurrentScore { get; set; }
    public int MaxScore { get; set; }

    void Start()
    {
        TriggerManager.TriggerEnterTrue += PlusOneScore;
        TriggerManager.TriggerEnterFalse += SetMaxScore;
        ClickPlayManager.ClickPlay += CurrentScoreEqualZero;
    }

    void SetMaxScore()
    {
        if (CurrentScore > MaxScore)
            MaxScore = CurrentScore;
    }

    void PlusOneScore()
    {
        CurrentScore++;
    }
   
    void CurrentScoreEqualZero()
    {
        CurrentScore = 0;
    }
}
