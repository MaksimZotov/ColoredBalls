using UnityEngine;

public class UISetterActive : MonoBehaviour
{
    [SerializeField] GameObject TouchIcon;
    [SerializeField] GameObject TextRecord;
    [SerializeField] GameObject CurrentScore;
    [SerializeField] GameObject MenuRegistration;

    void Start()
    {
        TriggerManager.TriggerEnterFalse += ShowButtonStart;
        TriggerManager.TriggerEnterFalse += ShowTextRecord;
        TriggerManager.TriggerEnterFalse += ShowMenuRegistration;
        ClickPlayManager.ClickPlay += ShowCurrentScore;
        ClickPlayManager.ClickPlay += HideButtonStart;
        ClickPlayManager.ClickPlay += HideTextRecord;
        ClickPlayManager.ClickPlay += HideMenuRegistration;
    }

    void HideButtonStart()
    {
        TouchIcon.SetActive(false);
    }

    void ShowButtonStart()
    {
        TouchIcon.SetActive(true);
    }

    void HideTextRecord()
    {
        TextRecord.SetActive(false);
    }

    void ShowTextRecord()
    {
        TextRecord.SetActive(true);
    }

    void ShowCurrentScore()
    {
        CurrentScore.SetActive(true);
    }

    void HideMenuRegistration()
    {
        MenuRegistration.SetActive(false);
    }

    void ShowMenuRegistration()
    {
        MenuRegistration.SetActive(true);
    }
}
