using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private Vector3 _initialPosition;
    private Vector3 _newPosition;
    private float _travelDistance;

    void Start()
    {
        rb.velocity = transform.right * speed;
        _initialPosition = transform.position;
    }

    private void Update()
    {
        HandleDestruction();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(30);
            Destroy(gameObject);
        }
    }

    private void HandleDestruction()
    {
        _newPosition = transform.position;
        _travelDistance = Vector3.Magnitude(_newPosition - _initialPosition);
        if (_travelDistance >= 30)
        {
            Destroy(gameObject);
        }
    }
    
}
