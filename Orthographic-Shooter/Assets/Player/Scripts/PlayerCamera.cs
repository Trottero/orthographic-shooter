using System.Collections;
using System.Collections.Generic;
using Game.Behaviours;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Player;

    private Vector3 _cameraPosition;
    private Quaternion CameraRotation;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        _cameraPosition = _camera.transform.position;
        CameraRotation = _camera.transform.rotation;
    }

    void Update()
    {
        // Make objects transparant when the Player is behind them.
        // Cast ray from camera centre to ray.
        var playerDirection = Player.position - transform.position;
        Debug.DrawLine(transform.position, Player.position);
        if (Physics.Raycast(transform.position, playerDirection.normalized, out var hitInfo, playerDirection.magnitude - 1, -1))
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if (isHitValid(hitInfo))
            {

            }
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, 0, Player.position.z) + _cameraPosition;
    }

    bool isHitValid(RaycastHit hit)
    {
        if (hit.collider.gameObject.GetComponent<IgnoreCameraVisibility>() != null)
        {
            return false;
        }
        return true;
    }
}
