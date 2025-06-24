using System;
using UnityEngine;
using UnityEngine.UI;

public class IInteractable : MonoBehaviour  // Clase base para objetos interactuables 
{
    
    public GameObject promptUI; // Asigna el cartel desde el Inspector

    // Revisar si el player entra al area del trigger
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area.");
            if (promptUI != null)
                promptUI.SetActive(true);
    
        }
    }
     // Revisar si el player sale del area del trigger
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }

    protected virtual void Interact()
    {
        // Este método puede ser sobreescrito por las clases que hereden de IInteractable
    }


}
