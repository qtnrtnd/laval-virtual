using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    EyesEvent : MonoBehaviour
{
    public void ClosedEvent()
    {
        GameManager.Instance.OnClosedEyes();
    }
    
    public void OpenedEvent()
    {
        GameManager.Instance.OnOpenedEyes();
    }
}
