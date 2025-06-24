using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Chest : IInteractable  // Clase que hereda de IInteractable
{
    public int Llave = 0; // Variable para verificar si se tiene la llave
    void Start()
    {
        {
            if (promptUI == null)   // Verificar si promptUI está asignado
            {
                Debug.LogError("Prompt UI no asignado en el Inspector.");
                return;
            }
            promptUI.SetActive(false); // Ocultar al inicio
        }

    }
    protected override void Interact()  
    {
        base.Interact();    // Llamar al método base Interact

        if (promptUI.activeSelf && Input.GetKeyDown(KeyCode.E)) // Verificar si el cartel está activo y se presiona la tecla E
        {
            Llave = 1; // Asignar la llave al jugador
            Debug.Log("Has recogido la llave.");
                        
        }


    }

    void Update()
    {

        Interact(); // Llamar al método Interact en cada frame

    }




    
   
}
