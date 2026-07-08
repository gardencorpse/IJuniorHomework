using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamagable
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _attackValue;

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            damage = Math.Max(0, damage);

            _health = -damage;
            Debug.Log($"{gameObject.name} получил урон {damage}, текущее здоровье {_health}");

            if (_health < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} is dead");
        }
    }

    protected void Attack(IDamagable target, int value)
    {
        target.TakeDamage(value);
    }
}
