using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int id;
    public string username;

    public Rigidbody rb;

    public float moveSpeed = 400f;

    public bool test = false;
    private bool[] inputs;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveSpeed *= Time.fixedDeltaTime;
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;

        inputs = new bool[5];
    }

    public void FixedUpdate()
    {
        if (test == true)
        {
            BallMove();
        }
        else
        {

            Vector2 _inputDirection = Vector2.zero;
            if (inputs[0])
            {
                _inputDirection.x -= 1;
            }
            if (inputs[1])
            {
                _inputDirection.x += 1;
            }
            if (inputs[2])
            {
                _inputDirection.y -= 1;
            }
            if (inputs[3])
            {
                _inputDirection.y += 1;
            }

            Move(_inputDirection);
        }
    }

    void BallMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 rolling = new Vector3(-moveY, 0.0f, moveX);

        rb.AddForce(rolling * moveSpeed * Time.deltaTime, ForceMode.Force);
        //rb.MovePosition(rolling * speed * Time.deltaTime);
    }

    private void Move(Vector2 _inputDirection)
    {
        Vector3 _moveDirection = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        _moveDirection *= moveSpeed;


        rb.AddForce(_moveDirection, ForceMode.Force);


        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }


    public void SetInput(bool[] _inputs, Quaternion _rotation)
    {
        inputs = _inputs;
        transform.rotation = _rotation;
    }
}
