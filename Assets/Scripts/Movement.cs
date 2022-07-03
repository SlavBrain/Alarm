using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _body;

    private float _horizontal;
    private float _vertical;
    private float _diagonalSpeedMultiplier = 0.7f;
    [SerializeField] private float _runSpeed = 20.0f;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Vector3 mousePosMain = Input.mousePosition;
        //mousePosMain.z = Mathf.Abs(cameraPos.position.z);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0)
        {
            _horizontal *= _diagonalSpeedMultiplier;
            _vertical *= _diagonalSpeedMultiplier;
        }

        _body.velocity = new Vector2(_horizontal * _runSpeed, _vertical * _runSpeed);
    }
}