using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : MonoBehaviour
{

   [Header("Movimentation")]
    public float speedMoviment = 10f;     // volocidade do movimento do player
    public float forceJump= 10; //Forca do pulo do Player
    public float PlayerDamping = 5f;
    public Rigidbody rb; // RigidyBody Player
    [HideInInspector]public float moveH; 
    [HideInInspector]public float moveV;

    
    [Header("Rotation")]
    public GameObject head; // cabeça do player
    public float    sensitivityX =  100f; // sensibilidade da rotação
    public float    sensitivityY =  100f; // sensibilidade da rotação
    public float    minRotationX =  -45f; // angulo minimo ao olhar para baixo
    public float    maxRotationX =  45f; // angulo maximo para olhara para cima
    private float   currentRotationX = 0f; // rotação atual;

    [HideInInspector]public Animator        animatorPlayer;
    [HideInInspector]public StateMachine    stateMachine;
    [HideInInspector]public IdleState       idleState;
    [HideInInspector]public WalkingState    walkingState;
    [HideInInspector]public JumpState       jumpState;

    [Header("Grounded")]
    public bool isground;
    public LayerMask LayerMaskGrounded;
    public Transform GroundedTransform;
    
     
    void Start()
    {
        // Pegar RigidyBody do objeto em que o script esta
        rb = GetComponent<Rigidbody>();

        // pEgar animator do PLayer
        animatorPlayer = GetComponentInChildren<Animator>();

        // StateMachine
        stateMachine = new StateMachine();
        // Estados
        idleState = new IdleState(this);
        walkingState = new WalkingState(this);
        jumpState = new JumpState(this);

        // Define estado incial
        stateMachine.ChangeState(idleState);

        // Define o amortecimento linear do rigidbody (rb):
        rb.linearDamping = isground? PlayerDamping : 0f;

        // Congela Rotação do Rigidbody(rb)
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Rotation();
        Moviment();
        stateMachine.Update();
    }

    void Moviment()
    {
        // Imputs
         moveH = Input.GetAxis("Horizontal");
         moveV = Input.GetAxis("Vertical");

    }

    void Rotation(){
    Cursor.visible = false;
    Screen.lockCursor = true;
    float mouseX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

    // Manter a rotação do eixo Y da cabeça  entre o angulo minimo e o maximo;
    currentRotationX -= mouseY;
    currentRotationX = Mathf.Clamp(currentRotationX, minRotationX, maxRotationX);
    // Manter a rotação do eixo Y da cabeça  entre o angulo minimo e o maximo;s

    // Rotaciona localmente a cabeça do player apenas no eixo Y (horizontal)
    head.transform.localRotation = Quaternion.Euler(currentRotationX,0f,0f);
    transform.Rotate(0, mouseX, 0);

    }

    /* ---------------------------------------------------------JUMP--------------------------------------------------
     Sistema de pulo fica aqui.
    ------------------------------------------------------------------------------------------------------------------*/
    void  Jump(){

        isground = Physics.CheckSphere(transform.position, 1.2f, LayerMaskGrounded);

        // Get Entrada Teclado Jump
        bool inputJump = Input.GetKeyDown(KeyCode.Space);

        // Verificar entrada se 1 executar pulo
        if(inputJump && isground){
            stateMachine.ChangeState(jumpState);
        }
    }
}
