using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Quaternion mouseRotation;
    private Quaternion offsetRotation;
    private float bulletSpread = 10f;
    private float rateOfFire = 10f;
    private float rateOfFireTimer = 0.0f;
    void Update()
    {
        rateOfFireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && rateOfFireTimer >= (1 / rateOfFire))
        {
            Shoot();
            rateOfFireTimer = 0;
        }        
    }
    
    void Shoot()
    {
        Vector3 shotDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        var shotAngle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;
        float angleOffset = Random.Range(-bulletSpread, bulletSpread);
        offsetRotation = Quaternion.Euler(0f, 0f, angleOffset);
        mouseRotation = Quaternion.Euler(0f, 0f, shotAngle + offsetRotation.eulerAngles.z);

        Instantiate(bulletPrefab, firePoint.position, mouseRotation);
    }

}

