using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerPointer PlayerPointer;
    private bool _fire1Held;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPointer = GetComponent<PlayerPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update toggle between fire down and fire up.
        if (Input.GetButtonDown("Fire1"))
        {
            _fire1Held = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            _fire1Held = false;
        }
    }

    public bool GetFireDown()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool GetFireHeld()
    {
        return _fire1Held;
    }
}
