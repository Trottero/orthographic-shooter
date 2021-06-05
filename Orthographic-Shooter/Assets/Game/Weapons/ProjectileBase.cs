using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBase : MonoBehaviour
{
    public WeaponController Owner;

    public Vector3 InitialPosition { get; private set; }
    public Vector3 InitialDirection { get; private set; }
    public Vector3 InheritedMuzzleVelocity { get; private set; }

    // Behaviour for child is stored here.
    public UnityAction OnShoot;

    // Fires the projectile forward
    public void Shoot(WeaponController controller)
    {
        Owner = controller;
        InitialPosition = transform.position;
        InitialDirection = transform.forward;
        InheritedMuzzleVelocity = controller.MuzzleWorldVelocity;

        OnShoot?.Invoke();
    }
}
