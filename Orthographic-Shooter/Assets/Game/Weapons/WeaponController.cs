using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Vector3 MuzzleWorldVelocity { get; internal set; }
    // Projectile to spawn upon shooting
    public ProjectileBase ProjectilePrefab;
    // Who's holding this weapon?
    public GameObject Owner;
    public float DelayBetweenShots = 1f;

    private float _lastTimeShot = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Should be called whenever the shooting button has been held down.
    public bool TryShoot()
    {
        // Check ammo clip and delay between shots
        if (_lastTimeShot + DelayBetweenShots < Time.time)
        {
            HandleShoot();
            return true;
        }
        return false;
    }

    private void HandleShoot()
    {
        // Create and shoot projectile
        // Spawn object
        // Give object velocity
        Vector3 shotDirection = Owner.transform.forward;
        ProjectileBase newProjectile = Instantiate(ProjectilePrefab, Owner.transform.position,
            Quaternion.LookRotation(shotDirection));
        newProjectile.Shoot(this);

        _lastTimeShot = Time.time;
    }
}
