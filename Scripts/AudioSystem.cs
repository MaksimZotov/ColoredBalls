using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] AudioSource ASourceTrue;
    [SerializeField] AudioSource ASourceFalse;

    void Start()
    {
        TriggerManager.TriggerEnterTrue += PlayTrueSphere;
        TriggerManager.TriggerEnterFalse += PlayFalseSphere;
    }

    void PlayTrueSphere()
    {
        ASourceTrue.Play();
    }

    void PlayFalseSphere()
    {
        ASourceFalse.Play();
    }
}
