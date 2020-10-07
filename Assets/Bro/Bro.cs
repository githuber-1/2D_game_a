using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bro : MonoBehaviour
{
    public float speed = 15.0f;

    void Start()
    {

    }

    void Update()
    {
       
        if (Input.GetKeyDown("right"))
        {
            if(transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (transform.rotation != Quaternion.Euler(0, 180, 0))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        float translation_y = Input.GetAxis("Vertical") * speed;
        float translation_x = Input.GetAxis("Horizontal") * speed;

        translation_y *= Time.deltaTime;
        translation_x *= Time.deltaTime;

        transform.Translate(0, translation_y, 0, Space.World);
        transform.Translate(translation_x, 0, 0, Space.World);

    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
