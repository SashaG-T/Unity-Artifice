using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float speed;
    public float animationSpeed;

    Animator animator;
    Rigidbody2D rigidBody;

    enum Dir : int
    {
        Idle,
        Up,
        Down,
        Left,
        Right
    };

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        if(isLocalPlayer) {
            GameObject camera = GameObject.Find("Main Camera");
            camera.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer) {            
            float tessal = speed * Time.deltaTime;
            Vector2 d = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rigidBody.velocity = new Vector2(d.x * tessal, d.y * tessal);
        }
        
        Dir dir = Dir.Idle;
        float magnitude = rigidBody.velocity.magnitude;
        if(Mathf.Abs(magnitude) > 0.01f) {
            float x = rigidBody.velocity.x;
            float y = rigidBody.velocity.y;
            if (Mathf.Abs(x) < Mathf.Abs(y))
            {
                if (y < 0)
                {
                    dir = Dir.Down;
                }
                else if (y > 0)
                {
                    dir = Dir.Up;
                }
            }
            else
            {
                if(x < 0)
                {
                    dir = Dir.Left;
                }
                else if(x > 0)
                {
                    dir = Dir.Right;
                }
            }
        } else {
            rigidBody.velocity = new Vector2();
        }

        animator.SetInteger("moveDir", (int)dir);
        animator.speed = animationSpeed * magnitude;

    }
}
