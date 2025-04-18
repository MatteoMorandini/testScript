using Unity.Engine;
using Unity.Engine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActioAsset inputActions;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;

    private Vector2 movePlayer;
    private Vector2 lookPlayer;

    private Animator m_animator;
    private RigidBody m_rigidBody;

    private float walkSpeed;
    private float rotateSpeed;
    private float jumpSPeed;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    } 
   
    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disables();
    }


    private void OnAwake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        jumpAction = InputSystem.actions.FindAction("Jump");

        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<RigidBody>();
    }

    private void Update()
    {
        movePlayer = moveAction.ReadValue<Vector2>();
        lookéPlayer = lookAction.ReadValue<Vector2>();
    }
}