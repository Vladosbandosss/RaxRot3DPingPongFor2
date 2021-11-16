using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 20f;

    public float maxX = 14.7f, minX = -14.7f;

    void Start()
    {

    }


    void Update()
    {
        Movement();
        CheckBounds();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    void CheckBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        if (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;
    }
}
