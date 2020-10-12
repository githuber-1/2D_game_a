using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform player;
    public GameObject bulletPrefab;
    private Quaternion shotRotation;
    private Quaternion offsetRotation;
    private float bulletSpread = 1f;
    private float rateOfFire = 1f;
    private float rateOfFireTimer = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        rateOfFireTimer += Time.deltaTime;

        if (rateOfFireTimer > (1 / rateOfFire))
        {
            Shoot();
            rateOfFireTimer = 0;
        }
            
    }

    void Shoot()
    {
        Vector3 shotDirection = player.position - firePoint.position;
        var shotAngle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;
        float angleOffset = Random.Range(-bulletSpread, bulletSpread);
        offsetRotation = Quaternion.Euler(0f, 0f, angleOffset);
        shotRotation = Quaternion.Euler(0f, 0f, shotAngle + offsetRotation.eulerAngles.z);

        Instantiate(bulletPrefab, firePoint.position, shotRotation);
    }

}

