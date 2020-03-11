using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int width;
    int height;
    float posX;
    float posEnd;
    float TouchPad;
    bool distBetweenFingersTapsIsOk;

    private void Start()
    {
        ClickPlayManager.ClickPlay += StartMove;
        TriggerManager.TriggerEnterFalse += StopMove;
        width = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;
        TouchPad = 0.7f;
    }

    void StartMove()
    {
        StartCoroutine("Move");
        distBetweenFingersTapsIsOk = true;
        posEnd = Input.GetTouch(0).position.x;
        TouchPad = 1;
    }

    void StopMove()
    {
        StopCoroutine("Move");
        TouchPad = 0.7f;
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && distBetweenFingersTapsIsOk && Input.mousePosition.y / height < TouchPad)
            {
                posX = (Input.mousePosition.x / width - 0.5f) * 6.5f;
                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
                if (transform.localPosition.x < -2.5f)
                    transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                if (transform.localPosition.x > 2.5f)
                    transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
            }
            
            if (Input.touchCount == 1 && distBetweenFingersTapsIsOk && Input.GetTouch(0).position.y / height < TouchPad)
            {
                posX = (Input.GetTouch(0).position.x / width - 0.5f) * 6.5f;
                transform.position = new Vector3(posX, transform.position.y, transform.position.z);
                if (transform.localPosition.x < -2.5f)
                    transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                if (transform.localPosition.x > 2.5f)
                    transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
            }
            yield return null;
        }
    }

    public void SetBeginPos()
    {
        if (Mathf.Abs(Input.GetTouch(0).position.x / width - posEnd / width) < 0.2f)
            distBetweenFingersTapsIsOk = true;
        else
            distBetweenFingersTapsIsOk = false;
    }

    public void SetEndPos()
    {
        if (distBetweenFingersTapsIsOk)
            posEnd = Input.GetTouch(0).position.x;
        distBetweenFingersTapsIsOk = false;
    }
}
