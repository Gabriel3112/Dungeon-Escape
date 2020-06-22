using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public float jumpForce;

    public float distanceToGround;

    public LayerMask[] layers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        JumpInput();
        isGround();
        Debug.Log(isGround());
        
        
    }

    private void MoveInput(){
        float X = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(X * speed, rb.velocity.y);
    }

    private void JumpInput(){
        if(Input.GetKeyDown(KeyCode.Space) && isGround()){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    bool isGround(){
        if(Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, LayerMask.GetMask("Ground"))){
            return true;
        }
        else{
            return false;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.down * distanceToGround);
    }
}
