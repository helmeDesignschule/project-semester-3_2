using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime = 5;
    [SerializeField] private int damage = 1;

    public void Shoot(MoverBase shooter, Vector2 targetedPosition)
    {
        Vector2 direction = targetedPosition - shooter.GetPosition();
        direction.Normalize();
        
        Physics2D.IgnoreCollision(shooter.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        StartCoroutine(DespawnAfterTimeCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        HealthPointManager target = col.collider.GetComponent<HealthPointManager>();
        if (target != null)
            target.DealDamage(damage);
        Destroy(gameObject);
    }

    private IEnumerator DespawnAfterTimeCoroutine()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
