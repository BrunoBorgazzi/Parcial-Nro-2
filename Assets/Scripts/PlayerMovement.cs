using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GameControler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 5f;
    public Transform cameraTransform;
    private CharacterController characterController;
    private float xRotation = 0f;
    
    private enum MovementMode { MouseLook, ArrowKeys }
    private MovementMode currentMode = MovementMode.MouseLook;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        if (cameraTransform == null)
        {
            Debug.LogError("cameraTransform no asignado.");
        }
    }

    void Update()
    {
        // Detectar modo de movimiento por teclas
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMode = MovementMode.ArrowKeys;
        }

        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) ||
            Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f)
        {
            currentMode = MovementMode.MouseLook;
        }

       // ROTACIÓN MOUSE
        if (currentMode == MovementMode.MouseLook)
        {
         float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
         float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

         xRotation -= mouseY;
         xRotation = Mathf.Clamp(xRotation, -90f, 90f);
         cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

         // Rotar al personaje solo en el eje Y (horizontal)
         transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + mouseX, 0f);
        }


        // --- Movimiento ---
        Vector3 move = Vector3.zero;

        if (currentMode == MovementMode.MouseLook)
        {
            float horizontal = Input.GetAxis("Horizontal"); // A/D
            float vertical = Input.GetAxis("Vertical");     // W/S

            move = transform.right * horizontal + transform.forward * vertical;
        }
        else if (currentMode == MovementMode.ArrowKeys)
        {
            float arrowHorizontal = 0f;
            float arrowVertical = 0f;

            if (Input.GetKey(KeyCode.RightArrow)) arrowHorizontal += 1f;
            if (Input.GetKey(KeyCode.LeftArrow)) arrowHorizontal -= 1f;
            if (Input.GetKey(KeyCode.UpArrow)) arrowVertical += 1f;
            if (Input.GetKey(KeyCode.DownArrow)) arrowVertical -= 1f;

            move = new Vector3(arrowHorizontal, 0f, arrowVertical);
            move = Vector3.ClampMagnitude(move, 1f);    // Evita moverse más rápido en diagonal
        }

        characterController.Move(move * moveSpeed * Time.deltaTime);
        
    }
}

