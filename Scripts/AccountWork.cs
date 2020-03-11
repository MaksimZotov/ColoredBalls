using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System;
using TMPro;

public class AccountWork : MonoBehaviour
{
    [SerializeField] GameObject ClickPlayTouchPad;
    [SerializeField] GameObject UIRegistration;
    [SerializeField] GameObject ButtonGoPlay;
    [SerializeField] CalculatedScore DataScore;
    [SerializeField] ShowScore ShowScoreUI;
    [SerializeField] TMP_InputField UserName;
    [SerializeField] TMP_InputField Password;
    [SerializeField] TextMeshProUGUI Notification;

    int score;
    int action;
    string userName;
    string password;
    string serverReply;

    IEnumerator SendInfoToServer()
    {
        userName = UserName.text;
        password = Password.text;

        WWWForm form = new WWWForm();
        form.AddField("Name", userName);
        form.AddField("Pass", password);
        form.AddField("Score", score);
        form.AddField("Action", action);
        var download = UnityWebRequest.Post("https://coloredballs.000webhostapp.com/db-test/", form);    
        
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
            serverReply = download.error;
        else
            serverReply = download.downloadHandler.text;

        if (action == 0 && serverReply.Equals("Пользователь " + userName + " зарегистрирован"))
            ButtonGoPlay.SetActive(true);

        if (action == 1)
        {
            try
            {
                int maxScore = Convert.ToInt32(serverReply);
                DataScore.MaxScore = maxScore;
                ShowScoreUI.UpdateMaxScore();
                ButtonGoPlay.SetActive(true);
                serverReply = "Вход в аккаунт выполнен успешно, ваш рекорд: " + serverReply;
            }
            catch (FormatException e) { }
        }

        Notification.text = serverReply;
    }

    public void LogIn()
    {
        action = 0;
        ButtonGoPlay.SetActive(false);
        StartCoroutine(SendInfoToServer());
    }

    public void SignIn()
    {
        action = 1;
        ButtonGoPlay.SetActive(false);
        StartCoroutine(SendInfoToServer());
    }

    public void SaveScore()
    {
        action = 2;
        score = DataScore.MaxScore;
        StartCoroutine(SendInfoToServer());
    }

    public void GoPlay()
    {
        ClickPlayTouchPad.SetActive(true);
        UIRegistration.SetActive(false);
        DataScore.CurrentScore = 0;
        ShowScoreUI.UpdateCurrentScore();
        ShowScoreUI.UpdateMaxScore();
    }

    public void GoToMenuRegistration()
    {
        ClickPlayTouchPad.SetActive(false);
        UIRegistration.SetActive(true);
        ButtonGoPlay.SetActive(false);
        Notification.text = "";
    }
}
