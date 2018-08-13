using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RotateToFaceTarget))]
class RangedTower : Tower
{
    public Projectile projectile;
    [SerializeField] Transform firePosition;
    [SerializeField] float speed;

    private void Start()
    {
        maxAttackDistance = projectile.maxDistance;
    }

    protected override void DoAttack()
    {
        var proj = Instantiate<Projectile>(projectile, firePosition.position, firePosition.rotation);

        proj.SetOwner(gameObject);
        var body = proj.GetComponent<Rigidbody2D>();
        body.velocity = firePosition.up * speed;
    }

    protected override Vector3 GetDistancePosition()
    {
        return firePosition.position;
    }

}