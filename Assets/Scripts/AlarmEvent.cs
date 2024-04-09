using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEvent : MonoBehaviour
{
    
    
   
    
    public void AlarmEventTrigger()
    {
        GameManager.Instance.OnButtonClick();
    }
}
