using Photon.Pun;
using UnityEngine;

public class PlayerInputManager : MonoBehaviourPun
{
    public PlayerManager PlayerManager;
    public Camera MyCamera;
    public CharacterController MyCharacterController;
    public Animator Animator;
    public float currentMoveSpeed = 5;
    public float gravity = -9.81f;

    static float mouseSensibilityX = 2f;
    static float mouseSensibilityY = 2f;
    float verticalLookRotation;

    private Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public float jumpHeight = 3f;

    public float CoolDownTime = 0;

    void Start()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            if (GetComponentInChildren<Camera>())
                GetComponentInChildren<Camera>().enabled = false;
            return;
        }
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (PlayerManager.State.isFreeze)
            return;

        PlayerManager.State.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (PlayerManager.State.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        CameraRotation();
        if (PlayerManager.State.isClimbing)
            Climb();
        else
        {
            MovementWithCharacterController();
            velocity.y += gravity * Time.deltaTime;
            MyCharacterController.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && PlayerManager.State is {isGrounded: true, isClimbing: false})
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (PlayerManager.State is {isAttacking: false, isClimbing: false} && IsNotInCoolDown())
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (PlayerManager.State.isAttacking)
                    return;
                Animator.SetTrigger("BasicAction");
                PlayerManager.State.isAttacking = true;
                StartCoolDown();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                PlayerManager.State.isAttacking = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Animator.SetBool("SpecialAction", true);
                PlayerManager.State.isAttacking = true;
                StartCoolDown();

            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Animator.SetBool("SpecialAction", false);
                PlayerManager.State.isAttacking = false;
            }
        }
    }

    private bool IsNotInCoolDown()
    {
        return Time.time >= CoolDownTime;
    }

    private void StartCoolDown()
    {
        CoolDownTime = Time.time + PlayerManager.MyClassData.AttackSpeed;
    }

    private void Climb()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.up * z + transform.forward * z;
        MyCharacterController.Move(move * currentMoveSpeed * Time.deltaTime);
    }

    private void MovementWithCharacterController()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        Animator.SetFloat("VelocityX", x);
        Animator.SetFloat("VelocityZ", z);
        Vector3 move = transform.right * x + transform.forward * z;

        MyCharacterController.Move(move * currentMoveSpeed * Time.deltaTime);

    }

    public void CameraRotation()
    {
        //if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        //{
        //    return;
        //}
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensibilityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensibilityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        MyCamera.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
}
