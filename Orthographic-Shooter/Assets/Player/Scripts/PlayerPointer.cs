using System.Collections;
using System.Collections.Generic;
using OrthographicShooter.Utils;
using UnityEngine;


public class PlayerPointer : MonoBehaviour
{
    public Camera PlayerCamera;

    private Plane _plane = new Plane(Vector3.down, new Vector3(0, 7, 0));
    private Vector3 _pointerPositionOnPlane = Vector3.zero;

    public Vector3 GetPointerPositionOnPlane()
    {
        return _pointerPositionOnPlane;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mousepos = Input.mousePosition;

        var ray = PlayerCamera.ScreenPointToRay(mousepos);

        Debug.DrawLine(PlayerCamera.transform.position, ray.origin);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        Utils.DrawPlane(Vector3.down, new Vector3(0, 7, 0));

        if (_plane.Raycast(ray, out var distance))
        {
            _pointerPositionOnPlane = ray.GetPoint(distance);
            var v3 = transform.position;
            v3.y = 7;
            Debug.DrawLine(v3, ray.GetPoint(distance), Color.magenta);
        }

    }
}
