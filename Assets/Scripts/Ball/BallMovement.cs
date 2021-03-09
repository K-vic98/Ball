using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCastDistance;
    [SerializeField] private LayerMask _groundLayerMask;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + new Vector3(_speed * Time.deltaTime, 0, 0));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckLandAvailability())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private bool CheckLandAvailability()
    {
        return Physics.Raycast(transform.position, Vector2.down, _groundCastDistance, _groundLayerMask);
    }
}