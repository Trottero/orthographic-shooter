using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerPointer PlayerPointer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPointer = GetComponent<PlayerPointer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
