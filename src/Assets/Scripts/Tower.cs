using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Tower : MonoBehaviour
{
    [SerializeField] float timeBetweenFires;
    public UnityEvent OnFire;
    float timeTillFire;
    public float maxAttackDistance;
    public int cost;

    Enemy target;

    protected abstract void DoAttack();

    protected abstract Vector3 GetDistancePosition();


    void Fire()
    {
        if (timeTillFire > 0)
            return;

        DoAttack();

        if (OnFire != null)
        {
            OnFire.Invoke();
        }

        timeTillFire = timeBetweenFires;
    }

    private void Update()
    {
        if (timeTillFire > 0)
        {
            timeTillFire -= Time.deltaTime;
        }

        var pos = GetDistancePosition();

        if (target == null || Vector3.Distance(pos, target.transform.position) >= maxAttackDistance)
        {
            target = null;
            foreach (var enemy in EnemyLocator.Instance.GetEnemies())
            {
                if (Vector3.Distance(pos, enemy.transform.position) < maxAttackDistance)
                {
                    target = enemy;
                    break;
                }
            }
        }

        if (target != null)
        {
            Fire();
        }
    }
}