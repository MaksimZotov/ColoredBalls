using UnityEngine;

public class SpheresManager : MonoBehaviour
{
    [SerializeField] Material PlayerMatComp;
    [SerializeField] Sphere[] Spheres;
    [SerializeField] Material[] Materials;

    bool firstGame = true;

    void Awake()
    {
        ClickPlayManager.ClickPlay += SetColorSpheres;
    }

    void Start()
    {
        TriggerManager.TriggerEnterTrue += SetColorSpheres;
        TriggerManager.TriggerEnterFalse += SetTrue;
        SetRandomTarget();
    }

    void SetColorSpheres()
    {
        if (!firstGame)
        {
            for (int i = 0; i < 5; i++)
            {
                Spheres[i].IsTarget = false;
                int index = Random.Range(0, 5);
                Color tempColor = Materials[index].color;
                Materials[index].color = Materials[i].color;
                Materials[i].color = tempColor;
            }
            SetRandomTarget();
        }
        else
            firstGame = false;
    }

    void SetRandomTarget()
    {
        int target = Random.Range(0, 5);
        PlayerMatComp.color = Materials[target].color;
        Spheres[target].IsTarget = true;
    }
  
    void SetTrue()
    {
        for (int i = 0; i < 5; i++)
            Spheres[i].IsTarget = true;
    }
}
