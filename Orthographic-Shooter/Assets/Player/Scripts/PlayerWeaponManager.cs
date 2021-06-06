using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<WeaponController> Weapons = new List<WeaponController>();
    public List<WeaponController> StartingWeapons = new List<WeaponController>();
    // Start is called before the first frame update
    private PlayerController _playerController;
    private PlayerInputManager _playerInputManager;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerInputManager = GetComponent<PlayerInputManager>();

        foreach (var weapon in StartingWeapons)
        {
            AddWeapon(weapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var activeWeapon = GetActiveWeapon();
        if (_playerInputManager.GetFireHeld())
        {
            var fired = activeWeapon.TryShoot();
        }
    }

    void LateUpdate()
    {
        var activeWeapon = GetActiveWeapon();
        var v3 = transform.position;
        v3.y = 7;
        activeWeapon.AimingDirection = _playerInputManager.PlayerPointer.GetPointerPositionOnPlane() - v3;
    }

    void updateWeaponAiming()
    {

    }

    void AddWeapon(WeaponController weapon)
    {
        var instance = Instantiate(weapon, transform.position, Quaternion.LookRotation(transform.forward));
        instance.Owner = this.gameObject;
        Weapons.Add(instance);
    }

    private WeaponController GetActiveWeapon()
    {
        return Weapons.First();
    }
}
