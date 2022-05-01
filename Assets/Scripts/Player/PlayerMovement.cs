using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView _photonView;

    private CharacterController _controller;
    [SerializeField] private Animator animator;

    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float rotationSpeed;
    
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private bool _isGrounded;
    private bool _isRunning;

    private Vector3 _velocity;

    private readonly string _isWalkingString = "isWalking";
    private readonly string _isRunningString = "isRunning";
    
    private Transform _playerMesh;
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            this.enabled = false;
            return;
        }
        
        FindObjectOfType<CameraMotion>().objectToFollowUp = transform;
        
        _controller = GetComponent<CharacterController>();
        _playerMesh = transform.GetChild(0);
    }

    private void Update()
    {
        Motion();
    }

    private void Motion()
    {
        //y motion
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
        
        //x,z motion
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        
        bool isMotion = (move != Vector3.zero);
        animator.SetBool(_isWalkingString, isMotion);
        
        if (!isMotion)
        {
            return;
        }

        float speed = walkingSpeed;
        CheckEffects();
        if (_isRunning)
        {
            speed = runningSpeed;
        }

        _controller.Move(move * speed * Time.deltaTime);
        Rotate(move);
    }

    
    
    private void CheckEffects()
    {
        _isRunning = (Input.GetAxis("Running") > 0);
        animator.SetBool(_isRunningString, (_isRunning && animator.GetBool(_isWalkingString)));
    }
    
    private void Rotate(Vector3 deltaMotion)
    {
        Vector3 relativePos = transform.position + deltaMotion * 1000;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);

        _playerMesh.rotation = Quaternion.Slerp(_playerMesh.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}