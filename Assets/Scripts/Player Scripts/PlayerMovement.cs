using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    public float walk_Speed = 3f; // Speed for player's running and moving
    public float z_Speed = 3f;

    private float rotation_Y = -180f;
    private float rotation_Speed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("The value is: " + Input.GetAxisRaw(Axis.HORIZONTAL_AXIS));
        RotatePlayer();
        AnimatePlayerWalk();
    }
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (walk_Speed));
    }

    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(Input.GetAxisRaw(Axis.VERTICAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }
    }
}
