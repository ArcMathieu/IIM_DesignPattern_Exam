using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;
    
    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    [SerializeField] GameObject prefab;
    [SerializeField] AudioClip impactSd;

    [SerializeField] SDReference _SdRef;

    public event UnityAction OnImpact;

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }
    private void Start()
    {
        OnImpact += ImpactPS;
    }
    private void OnDestroy()
    {
        OnImpact -= ImpactPS;
    }
    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        collision.GetComponent<ITouchable>()?.Touch(Power);
        OnImpact.Invoke();
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

    //    collision.gameObject.GetComponent<ITouchable>()?.Touch(Power);
    //    Destroy(gameObject);
    //}
    public void ImpactPS()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        _SdRef.Instance.RandomSoundEffect(impactSd);
    }


    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }
}
