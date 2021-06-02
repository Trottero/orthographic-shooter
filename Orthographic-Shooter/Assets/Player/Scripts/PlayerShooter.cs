using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousepos = Input.mousePosition;
        mousepos.z = Vector3.Distance(transform.position, PlayerCamera.transform.position);
        var wp = PlayerCamera.ScreenToWorldPoint(mousepos);
        Debug.DrawLine(PlayerCamera.transform.position, wp);
        // Debug.Log(PlayerCamera.transform.position);
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.position - wp, out var hitinfo))
        {
            Debug.Log(hitinfo.point);
            Debug.DrawLine(transform.position, hitinfo.point, Color.magenta);
        }

        // Debug.DrawLine(transform.position, wp, Color.red);

        // wp.y = 6f;
        // Debug.Log(wp);
    }
}
