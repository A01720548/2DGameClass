using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 4f;
    private float movement = 0f;
    private Rigidbody2D rigid;
    private Animator playerAnimation;

    public float vel_jump = 7f;
    public Transform PointFloor;
    public float RadiusFloor;
    public LayerMask LayerFloor;
    private bool onFloor;

    public Vector3 pointRespawn;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        pointRespawn = new Vector3(-6.9f,-3.73f,-3.285513f);
    }

    // Update is called once per frame
    void Update()
    {
        onFloor = Physics2D.OverlapCircle(PointFloor.position, RadiusFloor, LayerFloor);
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f) { // Moves to right
            rigid.velocity = new Vector2(movement*velocity, rigid.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);

        } else if (movement < 0f) { // Moves to left
            rigid.velocity = new Vector2(movement*velocity, rigid.velocity.y);
        } else { // No movement on X axis
            rigid.velocity = new Vector2(0,rigid.velocity.y);
            transform.localScale = new Vector2(1f, 1f);

        }

        if (Input.GetButtonDown("Jump") && onFloor) {
            rigid.velocity = new Vector2(rigid.velocity.x, vel_jump);
        }


        playerAnimation.SetFloat("velocity", Mathf.Abs(rigid.velocity.x));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "fall") {
            transform.position = pointRespawn;
        }
        if (other.tag == "checkpoint") {
            pointRespawn = other.transform.position;
        }
    }
}
