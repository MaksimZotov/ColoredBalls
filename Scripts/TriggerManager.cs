using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static EventVoid TriggerEnterTrue;
    public static EventVoid TriggerEnterFalse;

    float time1, time2;

    void OnTriggerEnter(Collider col)
    {
        if (TriggerEnterTrue != null && col.GetComponent<Sphere>().IsTarget)
        {
            time1 = Time.time;
            if (Mathf.Abs(time2 - time1) > 0.1f)
                TriggerEnterTrue();
        }
        else if (TriggerEnterFalse != null && !col.GetComponent<Sphere>().IsTarget)
        {
            time2 = Time.time;
            if (Mathf.Abs(time2 - time1) > 0.1f)
                TriggerEnterFalse();
        }
    }
   
}
