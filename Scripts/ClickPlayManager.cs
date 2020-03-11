using UnityEngine;

public class ClickPlayManager : MonoBehaviour
{
    public static EventVoid ClickPlay;

    bool clickPlayIsAble = true;

    void Start()
    {
        TriggerManager.TriggerEnterFalse += SetClickPlayAble;
    }

    public void OnClickPlay()
    {
        if (ClickPlay != null && clickPlayIsAble)
            ClickPlay();
        clickPlayIsAble = false;
    }

    void SetClickPlayAble()
    {
        clickPlayIsAble = true;
    }
}
