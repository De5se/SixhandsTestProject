using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Animator animator;

    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float rotationSpeed;

    private bool _isRunning;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    
    private Transform _playerMesh;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _playerMesh = transform.GetChild(0);
    }

    private void Update()
    {
        Motion();
    }
    
    private void Motion()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        bool isMotion = (move != Vector3.zero);
        animator.SetBool(IsWalking, isMotion);
        
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
        animator.SetBool(IsRunning, (_isRunning && animator.GetBool(IsWalking)));
    }
    
    private void Rotate(Vector3 deltaMotion)
    {
        Vector3 relativePos = transform.position + deltaMotion * 1000;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);

        _playerMesh.rotation = Quaternion.Slerp(_playerMesh.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}