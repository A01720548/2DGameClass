using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 4f;
    private float movement = 0f;
    private Rigidbody2D rigid;
    private Animator playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(movement*velocity, rigid.velocity.y);
        playerAnimation.SetFloat("velocity", rigid.velocity.x);
    }
}
