using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        //meet Jump condition
        if(spaceDown && onGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;

            animPlayer.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 2);
        }
    }
}
