using System.Collections;
using TMPro;
using UnityEngine;
public class Logger
{
    private Queue _logQueue = new Queue();
    private TextMeshProUGUI _textMesh;
        
    public Logger(TextMeshProUGUI textMesh)
    {
        this._textMesh = textMesh;
        textMesh.text = "";
        Log("Logger started");
    }
    public void Log(string message)
    {
        _logQueue.Enqueue(message);
        if (_logQueue.Count > 5)
        {
            _logQueue.Dequeue();
        }
        _textMesh.text = "";
        foreach (var log in _logQueue)
        {
            _textMesh.text += log + "\n";
        }
    }
    
    public void reload()
    {
        _textMesh.text = "";
        foreach (var log in _logQueue)
        {
            _textMesh.text += log + "\n";
        }
    }
}