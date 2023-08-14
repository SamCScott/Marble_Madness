using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 200;
    public Rigidbody rb;



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //initialize local rigidbody for singleplayer
        if (GameManager.Instance.multiplayer == false)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (GameManager.Instance.multiplayer == true)
        {

            SendInputToServer();
        }
        else
        {
            BallMove();

        }
    }


    //called locally when not 
    void BallMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 rolling = new Vector3(-moveY, 0.0f, moveX);

        rb.AddForce(rolling * speed * Time.deltaTime, ForceMode.Force);
        //rb.MovePosition(rolling * speed * Time.deltaTime);
    }

    private void SendInputToServer()
    {

        //currently sending inputs via keycode for server/client controls since this is what the material i found has shown me how to do it
        //i will update to work with controller axis when i get there
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.P)

        };

        ClientSend.PlayerMove(_inputs);
    }
}
