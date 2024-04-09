using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PompierEvent : MonoBehaviour
{
    private GameManager _gameManager = GameManager.Instance;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _gameManager.audioSource.clip = _gameManager.PompierSound;
        _gameManager.audioSource.Play();
    } 
}
