using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OrthographicShooter.Utils;
using UnityEngine;

public class ProjectileStandard : ProjectileBase
{
    public float MaxLifeTime = 5f;
    public float Speed = 1f;
    public float HitWidth = 0.1f;

    private Vector3 _velocity;
    private Vector3 _lastPosition;
    private ProjectileBase _projectileBase;
    private List<Collider> _ignoredColliders;

    const QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Collide;

    // Called when instantiating this object
    void OnEnable()
    {
        _projectileBase = GetComponent<ProjectileBase>();
        _projectileBase.OnShoot += OnShoot;
        Destroy(gameObject, MaxLifeTime);
    }

    void Update()
    {
        _lastPosition = transform.position;
        transform.position += _velocity * Time.deltaTime;
        //
        // Do checks for collision
        CheckCollisions();
    }

    private void CheckCollisions()
    {
        var displacementSinceLastFrame = transform.position - _lastPosition;
        var rayCastHits = Physics.SphereCastAll(_lastPosition, HitWidth, displacementSinceLastFrame.normalized, displacementSinceLastFrame.magnitude, -1, triggerInteraction).Where(IsHitValid);
        if (rayCastHits.Count() > 0)
        {
            var closestHit = rayCastHits.MinBy(x => x.distance);
            OnHit(closestHit);
        }
    }

    // Called when creating this object
    public new void OnShoot()
    {
        _velocity = transform.forward * Speed;
        _ignoredColliders = _projectileBase.SourceWeapon.Owner.GetComponentsInChildren<Collider>().ToList();
    }

    private bool IsHitValid(RaycastHit hit)
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

    private void OnHit(RaycastHit hit)
    {
        Destroy(this.gameObject);
    }
}
