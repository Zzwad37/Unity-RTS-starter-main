using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 2f;

    void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Deactivate()
    {
        PoolManager.Instance.ReturnToPool(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision
        Deactivate();
    }
}
