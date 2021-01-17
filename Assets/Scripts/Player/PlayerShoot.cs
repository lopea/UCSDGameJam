using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject Projectile;

    [SerializeField]
    private float MaxDistance = 1000.0f;
    
    [SerializeField]
    private string DestroyTag = "_Enemy";

    private PlayerCamera _camera;

    RaycastHit _hit;

    private void Awake()
    {
        _camera = GetComponentInChildren<PlayerCamera>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")
            && Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, MaxDistance))
        {
            //Instantiate(Projectile, _hit.point, Quaternion.identity);
            if (_hit.collider.transform.tag == DestroyTag)
            {
                Destroy(_hit.collider.gameObject);
            }
        }

    }
}
