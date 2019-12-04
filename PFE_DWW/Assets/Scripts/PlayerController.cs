using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private AIDinosaur _dinosaur;

    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private float _rotSpeed = 5.0f;
    [SerializeField] private float _rotAngle = 45.0f;

    [SerializeField] public bool _dead;
    [SerializeField] public bool _crouch;
    [SerializeField] private int _crouchSet = 0;

    [SerializeField] private CharacterController _characterCollider;
    [SerializeField] private CharacterController _controller;

    void Start()
    {
        _characterCollider = gameObject.GetComponent<CharacterController>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        //if (_dinosaur.mounted)
        //{
        //    _animator.setbool("isriding", true);
        //}

        ComputeMove();

        if (moveDirection != Vector3.zero)
        {
            //_animator.SetBool("IsWalking", true);
            Rotate();
        }
        else
        {
            //_animator.SetBool("IsWalking", false);
        }

        DoMove();

        // Crouch
        IsPlayerCrouched();
    }

    private void ComputeMove()
    {
        if (_controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            moveDirection = _camera.transform.TransformDirection(moveDirection);
            moveDirection *= _speed;
        }
    }

    private void DoMove()
    {
        moveDirection.y -= _gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 lookDirection = moveDirection;
        lookDirection.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotSpeed * Time.deltaTime);
    }

    void IsPlayerCrouched()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CrouchCounter();
        }
    }

    void CrouchCounter()
    {
        _crouchSet++;

        if (_crouchSet > 1)
        {
            _crouchSet = 0;
        }

        if (_crouchSet == 0)
        {
            _crouch = false;
            _speed = 6.0f;
            transform.localScale = new Vector3(1, 1, 1);
            //_animator.SetBool("IsCrouching", false);
        }

        if (_crouchSet == 1)
        {
            _crouch = true;
            _speed = 3.0f;
            transform.localScale = new Vector3(1, 0.5f, 1);
            //_animator.SetBool("IsCrouching", true);
        }
    }
}
