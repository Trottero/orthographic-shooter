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
    public Vector3 AimingDirection;
    public float DelayBetweenShots = 1f;


    private float _lastTimeShot = Mathf.NegativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        _lastTimeShot = Time.timeSinceLevelLoad;
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

        var v3 = Owner.transform.position;
        v3.y = 7;
        ProjectileBase newProjectile = Instantiate(ProjectilePrefab, v3,
            Quaternion.LookRotation(AimingDirection));
        newProjectile.Shoot(this);

        _lastTimeShot = Time.time;
    }
}
