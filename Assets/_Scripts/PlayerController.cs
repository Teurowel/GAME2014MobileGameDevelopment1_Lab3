using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;

    public float horizontalSpeed = 0f;
    public float horizontalBoundary = 0f;
    public float maximumVelocityX = 0f;
    public Rigidbody2D rb = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Touch support
        foreach(var touch in Input.touches)
        {
            if(Camera.main.ScreenToWorldPoint(touch.position).x > transform.position.x)
            {
                rb.velocity = _Move(1.0f) * 0.90f;
            }

            if (Camera.main.ScreenToWorldPoint(touch.position).x < transform.position.x)
            {
                rb.velocity = _Move(-1.0f) * 0.90f;
            }
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            //Move right
            rb.velocity = _Move(1.0f) * 0.90f;
        }

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            //Move left
            rb.velocity = _Move(-1.0f) * 0.90f;
        }

        _CheckBounds();

        if (Time.frameCount % 50 == 0)
        {
            gameController.GetBullet(transform.position);
        }
    }

    private Vector2 _Move(float direction)
    {
        var newVelocity = new Vector2(horizontalSpeed * direction, 0f);
        return Vector2.ClampMagnitude(rb.velocity + newVelocity, maximumVelocityX);
    }

    private void _CheckBounds()
    {
        if(transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }
}
