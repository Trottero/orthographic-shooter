using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;
    public float DashSpeed = 10f;
    public int DashDuration = 100;
    public float DashCooldown = 1f;
    public float Gravity = -9.81f;
    public Vector3 RespawnPosition;
    public float RespawnYThreshold = 0f;

    private CharacterController _controller;
    private int _dashCounter;
    private Vector3 playerVelocity;

    private float _dashCooldown = 0;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.transform.position.y < RespawnYThreshold)
        {
            _controller.enabled = false;
            _controller.transform.position = RespawnPosition;
            _controller.enabled = true;

            // Reset gravity
            playerVelocity.y = 0;
            // Reset dash
            _dashCounter = 0;
        }

        var dashing = _dashCounter % DashDuration != 0;

        // Reset player velocity
        if (_controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = Quaternion.Euler(0, 45, 0) * direction;

        var distance = Time.deltaTime * Speed;
        if (_dashCooldown > 0)
        {
            _dashCooldown = Mathf.Clamp(_dashCooldown - Time.deltaTime, 0, DashCooldown);
        }

        if (!dashing && _dashCooldown == 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _dashCounter++;
                _dashCooldown = DashCooldown;
                distance *= DashSpeed;
            }
        }
        else if (dashing)
        {
            // Dashing
            _dashCounter++;
            _dashCounter %= DashDuration;
            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            distance *= DashSpeed;
        }


        _controller.Move(direction * distance);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        if (!dashing)
        {
            // Apply gravity (only when not dashing)
            applyGravity();
        }
    }

    private void applyGravity()
    {
        playerVelocity.y += Gravity * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);

    }

    void OnDrawGizmos()
    {
        // Draw current forward direction
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    }
}
