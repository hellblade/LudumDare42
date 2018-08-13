using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
class MeleeTower : Tower
{
    [SerializeField] Transform weaponPosition;
    [SerializeField] float maxRange;
    [SerializeField] float rotateSpeed;

    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        maxAttackDistance = maxRange;
    }


    protected override void DoAttack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        body.angularVelocity = rotateSpeed;
        yield return new WaitForSeconds(rotateSpeed / 360.0f);
        body.angularVelocity = 0;
    }

    protected override Vector3 GetDistancePosition()
    {
        return transform.position;
    }

}