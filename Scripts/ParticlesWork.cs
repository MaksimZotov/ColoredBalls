using UnityEngine;

public class ParticlesWork : MonoBehaviour
{
    [SerializeField] GameObject ParticleWhenMoving;
    [SerializeField] ParticleSystem ParticleFalseTrigger;
    [SerializeField] MeshRenderer Player;
    [SerializeField] CalculatedScore ScoreData;

	void Start ()
    {
        TriggerManager.TriggerEnterTrue += UpateParticle;
        TriggerManager.TriggerEnterTrue += PlayOver40;
        TriggerManager.TriggerEnterFalse += OnDeath;
        ClickPlayManager.ClickPlay += UpateParticle;
    }
	
	void UpateParticle()
    {
        ParticleWhenMoving.SetActive(false);
        ParticleWhenMoving.SetActive(true);
        Player.enabled = true;
    }
 
    void OnDeath()
    {
        ParticleWhenMoving.SetActive(false);
        ParticleFalseTrigger.Play();
        Player.enabled = false;
    }

    void PlayOver40()
    {
        if (ScoreData.CurrentScore % 40 == 0)
            ParticleFalseTrigger.Play();
    }
}
