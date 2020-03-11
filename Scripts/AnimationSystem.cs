using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    [SerializeField] Animation Camera;
    [SerializeField] Animation Player;
    [SerializeField] Animation TouchIcon;

    void Start()
    {
        TriggerManager.TriggerEnterFalse += PlayCamera;
        ClickPlayManager.ClickPlay += StopTutorial;
    }

    void PlayCamera()
    {
        Camera.Play();
    }

    void StopTutorial()
    {
        Player.Stop();
        TouchIcon.Stop();
    }
}
