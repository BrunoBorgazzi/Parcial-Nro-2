using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : IInteractable

{  
    public GameObject trampa; // Referencia al objeto de la trampa
    public GameObject Door; // Referencia al objeto de la puerta         

    // Asegurarse de que las referencias estén asignadas en el Inspector

    private void Start()
    {
        Door.SetActive(false); // Asegurarse de que la puerta esté inactiva al inicio
        promptUI.SetActive(false); // Asegurarse de que el mensaje esté inactivo al inicio 

    }

   

    protected override void OnTriggerEnter(Collider other)
    {
        promptUI.SetActive(true); // Activar el cartel al entrar en el área del trigger

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trap area.");
            Door.SetActive(true);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trap area.");
            promptUI.SetActive(false); // Desactivar el cartel al salir del área del trigger
            trampa.SetActive(false); // Desactivar la trampa


        }
    }


}
