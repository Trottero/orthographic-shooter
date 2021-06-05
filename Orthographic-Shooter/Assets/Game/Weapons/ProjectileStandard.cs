using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStandard : ProjectileBase
{
    public float MaxLifeTime = 5f;
    public float Speed = 1f;
    public float HitWidth = 0.1f;

    private Vector3 _velocity;
    private ProjectileBase _projectileBase;
    private List<Collider> _ignoredColliders;

    // Called when instantiating this object
    void OnEnable()
    {
        _projectileBase = GetComponent<ProjectileBase>();

        _projectileBase.OnShoot += OnShoot;

        Destroy(gameObject, MaxLifeTime);
    }

    // Called when creating this object
    new void OnShoot()
    {
        _velocity = transform.forward * Speed;
    }

    bool IsHitValid(RaycastHit hit)
    {
        // ignore hits with an ignore component
        if (hit.collider.GetComponent<IgnoreHitDetection>())
        {
            return false;
        }

        // ignore hits with triggers that don't have a Damageable component
        if (hit.collider.isTrigger && hit.collider.GetComponent<Damageable>() == null)
        {
            return false;
        }

        // ignore hits with specific ignored colliders (self colliders, by default)
        if (_ignoredColliders != null && _ignoredColliders.Contains(hit.collider))
        {
            return false;
        }

        return true;
    }
}
