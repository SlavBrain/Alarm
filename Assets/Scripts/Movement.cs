using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 20.0f;

    private Rigidbody2D _character;
    private float _horizontal;
    private float _vertical;
    private float _diagonalSpeedMultiplier = 0.7f;    

    void Start()
    {
        _character = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TrackPlayerManagment();
        TrackMouse();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void TrackMouse()
    {
        Vector3 mousePosMain = Input.mousePosition;
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void TrackPlayerManagment()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        if (_horizontal != 0 && _vertical != 0)
        {
            _horizontal *= _diagonalSpeedMultiplier;
            _vertical *= _diagonalSpeedMultiplier;
        }

        _character.velocity = new Vector2(_horizontal * _runSpeed, _vertical * _runSpeed);
    }
}