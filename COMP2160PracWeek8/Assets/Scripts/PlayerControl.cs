using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed= 5;



    #region Input
    PlayerInput input;
    InputAction movementAction;


    #endregion

    private void Awake()
    {
        input = new PlayerInput();
        movementAction = input.Gameplay.Movement;

    }

    private void OnEnable()
    {
        input.Enable();
        movementAction.Enable();
        
    }

    void OnDisable()
    {
        input.Disable();
        movementAction.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = movementAction.ReadValue<Vector2>();
        transform.Translate(Vector2.up * speed * Time.deltaTime * moveInput.y);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * -moveInput.x);
    }
}
