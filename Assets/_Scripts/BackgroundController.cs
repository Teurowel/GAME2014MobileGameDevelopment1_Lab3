using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        var newPosition = new Vector3(0.0f, verticalSpeed, 0.0f);
        transform.position -= newPosition;
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void _CheckBounds()
    {
        //check bottom bounds
        if(transform.position.y <= -10.0f)
        {
            _Reset();
        }
    }
}
