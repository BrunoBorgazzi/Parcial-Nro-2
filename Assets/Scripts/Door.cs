using UnityEngine;



public class Door : Chest
{
    public GameObject door; // Referencia al objeto de la puerta

    void Start()
    {
        promptUI.SetActive(false); // Ocultar al inicio el cartel
    }

    void Update()
    {
        if (Llave != 0 && Input.GetKeyDown(KeyCode.R))
        {
            door.SetActive(false);
            // Desactiva la puerta si el jugador tiene la llave
            //promptUI.SetActive(false); // Desactiva el cartel
        }
        
    //if (Llave==0)
      //  {
           // promptUI.SetActive(true); // Mostrar el cartel si el jugador tiene la llave

      //  }   ///promptUI.SetActive(false); // Ocultar el cartel si no tiene la llave
        
        
    }

}
// Profe no llegue a hacer funciona el tema de la llave, creo que tengo una setting mal de unity porque la verdad 
// que el codigo esta bien. no se activa el cartel que te pide la llave a la salida, con un poco mas de tiempo lo saco.