using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime;
    float current_lifetime;
    [SerializeField] BoxCollider collider;

    // Update is called once per frame
    void Update()
    {
        current_lifetime += Time.deltaTime;
        if (current_lifetime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}

