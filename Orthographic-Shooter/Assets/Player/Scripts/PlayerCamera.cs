using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

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

    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, 0, player.position.z) + _cameraPosition;
    }
}
