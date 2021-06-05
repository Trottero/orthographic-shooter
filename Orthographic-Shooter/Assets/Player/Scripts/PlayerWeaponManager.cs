using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List<WeaponController> Weapons = new List<WeaponController>();
    // Start is called before the first frame update
    private PlayerController _playerController;
    private PlayerInputManager _playerInputManager;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerInputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var activeWeapon = GetActiveWeapon();
        if (Input.GetKey("Fire1"))
        {
            var fired = activeWeapon.TryShoot();
        }
    }

    void updateWeaponAiming()
    {

    }

    private WeaponController GetActiveWeapon()
    {
        return Weapons.First();
    }
}
