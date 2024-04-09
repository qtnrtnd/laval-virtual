using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    private GameManager _gameManager = GameManager.Instance;
    
    void OnTriggerEnter(Collider _)
    {
        _gameManager.audioSource.clip = _gameManager.hearthSound;
        _gameManager.audioSource.Play();
        
    }
}
