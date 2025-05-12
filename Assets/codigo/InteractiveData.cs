using UnityEngine;

public class InteractiveData : MonoBehaviour
{
    [Header("Interactive Data")]
    public string interactiveName;
    public string action;

    

    public string GetInteractiveName()
    {
        return interactiveName;
    }

    public string GetAction()
    {
        return action;
    }


    
}
