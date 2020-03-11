using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] CalculatedScore ScoreData;
    [SerializeField] AccountWork Account;

    void Start()
    {
        TriggerManager.TriggerEnterFalse += CheckSave;
    }

    void CheckSave()
    {
        if (ScoreData.CurrentScore >= ScoreData.MaxScore)
            Account.SaveScore();
    }
}
