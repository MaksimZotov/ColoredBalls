using UnityEngine;

public class ShowBackSpheres : MonoBehaviour
{
    [SerializeField] GameObject ParentOfSpheres;

    void Start()
    {
        TriggerManager.TriggerEnterTrue += Show;
        TriggerManager.TriggerEnterFalse += Hide;
    }

    void Show()
    {
        ParentOfSpheres.SetActive(true);
    }

    void Hide()
    {
        ParentOfSpheres.SetActive(false);
    }
}
