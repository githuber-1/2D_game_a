using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bro : MonoBehaviour
{
    public float runspeed = 15.0f;
    public float jumpspeed = 15.0f;

    [SerializeField] private LayerMask platformsLayerMask;

    private Rigidbody2D rigidBody2d;
    private PolygonCollider2D polyCollider2d;
    private Quaternion mouseRotation;

    private void Awake()
    {
        rigidBody2d = transform.GetComponent<Rigidbody2D>();
        polyCollider2d = transform.GetComponent<PolygonCollider2D>();
    }

 
    void Update()
    {
        HandleRotation();
        HandleMovement();
        HandleJump();
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(polyCollider2d.bounds.center, polyCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    private void HandleRotation()
    {
        Vector3 shotDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var angle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;

        if (angle < 90 || angle > -90)
        {
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (angle > 90 || angle < -90)
        {
            if (transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        
        if (Input.GetKeyDown("d"))
        {
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void HandleMovement()
    {
        float translation_x = Input.GetAxis("Horizontal") * runspeed;
        translation_x *= Time.deltaTime;
        transform.Translate(translation_x, 0, 0, Space.World);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown("w"))
        {
            if (IsGrounded())
            {
                rigidBody2d.velocity = Vector2.up * jumpspeed;
            }
        }
    }
}
