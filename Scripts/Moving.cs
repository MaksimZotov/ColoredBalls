using System.Collections;
using UnityEngine;

public class Moving : MonoBehaviour
{ 
    float speed;
    float forSpeed;
    float forSpeedKoef = 0.9f;
    bool fistGame;

    void Start()
    {
        fistGame = true;
        ClickPlayManager.ClickPlay += StartMove;
        ClickPlayManager.ClickPlay += GoToOriginPoint;
        ClickPlayManager.ClickPlay += SetSpeed;
        TriggerManager.TriggerEnterFalse += StopMove;
        TriggerManager.TriggerEnterFalse += ZeroForSpeed;
        TriggerManager.TriggerEnterTrue += GoToOriginPoint;
        TriggerManager.TriggerEnterTrue += SetSpeed;
    }

    public void StartMove()
    {
        StartCoroutine("Move");
    }

    public void StopMove()
    {
        StopCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            yield return null;
        }
    }

    void GoToOriginPoint()
    {
        if (!fistGame)
            transform.position = new Vector3(0, 7.37f, 10);
        fistGame = false;
    }

    void SetSpeed()
    {
        if (forSpeed < 10)
            speed = 14 * forSpeedKoef;
        else if (forSpeed < 20)
            speed = 17 * forSpeedKoef;
        else if (forSpeed < 30)
            speed = 20 * forSpeedKoef;
        else
            speed = 23 * forSpeedKoef;
        forSpeed++;
        if (forSpeed >= 40)
        {
            forSpeed = 0;
            forSpeedKoef *= 1.024f;
        }
        if (forSpeedKoef > 1.08f)
            forSpeedKoef = 0.95f;
    }

    void ZeroForSpeed()
    {
        forSpeed = 0;
    }
}
