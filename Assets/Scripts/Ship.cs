using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rb2d;
    CircleCollider2D circleCollider2D;
    Vector2  thrustDirection = new Vector2(0, 1);
    const float thrustForce = 2.0f;
    const float RotateDegreesPerSecond = 30.0f;
    float radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        radius = circleCollider2D.radius;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the ship
        float rotateInput = Input.GetAxis("Rotate");
        //calculate the rotation amount and apply rotation
        float rotateAmount = rotateInput * RotateDegreesPerSecond * Time.deltaTime;
        if(rotateInput != 0)
        {
            transform.Rotate(Vector3.forward, rotateAmount);
            //update the thrust direction
            thrustDirection = Quaternion.Euler(0, 0, (float)Math.Sin(rotateAmount)) * thrustDirection;
        }
    }

    void FixedUpdate()
    {
        //Thrust the ship forward
        if(Input.GetAxis("Thrust") > 0)
        {
            rb2d.AddForce(thrustDirection * thrustForce);
        }
    }

    void OnBecameInvisible()
    {
        //Wrap the ship to the other side of the screen
        Vector2 newPosition = transform.position;
        if(transform.position.y - radius > ScreenUtils.ScreenTop)
        {
            newPosition.y = ScreenUtils.ScreenBottom - radius;
        }
        else if(transform.position.y + radius < ScreenUtils.ScreenBottom)
        {
            newPosition.y = ScreenUtils.ScreenTop + radius;
        }
        if(transform.position.x - radius > ScreenUtils.ScreenRight)
        {
            newPosition.x = ScreenUtils.ScreenLeft - radius;
        }
        else if(transform.position.x + radius < ScreenUtils.ScreenLeft)
        {
            newPosition.x = ScreenUtils.ScreenRight + radius;
        }
        transform.position = newPosition;
    }
}
