using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool IsGrounded;

    public Goomba goomba;
    private Rigidbody2D rigidBody;
    private float jumpForce = 12;
    public float jumpDamage = 5;
    void Awake()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    
    {
        IsGrounded = true;
        if(collider.gameObject.layer == 3)
        {
            IsGrounded = true;
            //Debug.Log(collider.gameObject.name);
            //Debug.Log(collider.gameObject.transform.position);
        }
        else if(collider.gameObject.layer == 6)
        {
            goomba = collider.gameObject.GetComponent<Goomba>();
            rigidBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            goomba.TakeDamage(jumpDamage);
        }
    }

 void OnTriggerStay2D(Collider2D Collider)
 {
    IsGrounded = true;
 }

    void OnTriggerExit2D(Collider2D collider)
    {
        IsGrounded = false;
    }
}
