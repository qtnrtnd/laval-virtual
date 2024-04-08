using UnityEngine;
using UnityEngine.Rendering;

public class VolumeWeightSin : MonoBehaviour
{
    public Volume m_Volume;
    public float volume_weight = 0f;
    public float transitionTime = 3f; // Temps nécessaire pour passer de 1 à 0
    private float currentTransitionTime = 0f;
    private bool collisionDetected = false;
    private float initialVolumeWeight = 1f;
    void Update()
    {
        if (m_Volume != null)
        {
            m_Volume.weight = volume_weight;
        }
        if (collisionDetected)
        {
            currentTransitionTime += Time.deltaTime;

            // Calculer le nouvel état de la variable volume_weight
            float t = Mathf.Clamp01(currentTransitionTime / transitionTime);
            float newVolumeWeight = Mathf.Lerp(initialVolumeWeight, 0f, t);

            // Affecter la nouvelle valeur à la variable volume_weight (changez le nom de la variable en fonction de votre contexte)
            // Ici, j'utilise un Debug.Log pour illustrer le changement de valeur
            Debug.Log("Nouvelle valeur de volume_weight : " + newVolumeWeight);

            if (currentTransitionTime >= transitionTime)
            {
                collisionDetected = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with enemy");
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision out enemy");
    }
}