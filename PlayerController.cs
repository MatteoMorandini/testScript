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

        if(jumpActio.WasPressedThisFrame())
        {
            jump();
        }
    }

    private void jump()
    {
        m_rigidBody.AddForceFoPosition(new Vecotr3(0, 5f, 0), Vecotr3.up, ForceMode.Impulse);
        m_animator.setTrigger("Jump");
    }

    private void FixUpdate()
    {
        walking();
        rotating();
    }

    private void walking()
    {
        m_animator.SetFlaot("Speed");
        m_rigidBody.MovePosition(m_rigidBody.position + transform.forward * movePlayer.y * walkSpeed * Time.deltaTime);
    
    }

    private void rotating ()
    {
        if (movePlayer.y != 0)
        {
            float rotationAmount = lookPlayer * rotateSpeed * Time.deltaTime;
            
            Quaternion deltaRotation = Qauternion.Euler(0,  rotationAmount, 0);

            m_rigidBody.moveRotation(m_rigidBody.rotation * deltaRotation);
        }
    }
}