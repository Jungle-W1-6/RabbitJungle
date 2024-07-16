using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Rifle : MonoBehaviour
{
    public int maxAmmo;
    public int ammo;


    public GameObject bullet;
    public GameObject bigBullet;
    public GameObject bulletEffect;
    public Transform spawnPos;

    public GameObject rotation;

    public float timeBetweenShots;
    public float shotTime;

    public bool isReloading;
    public bool skill;


    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && !isReloading)
        {
            if (Time.time > shotTime)
            {
                if (!skill)
                {
                    Instantiate(bullet, spawnPos.position, rotation.transform.rotation);
                    Instantiate(bulletEffect, spawnPos.position, rotation.transform.rotation);
                    ammo--;
                }
                else if (skill)
                {
                    Instantiate(bigBullet, spawnPos.position, rotation.transform.rotation);
                    Instantiate(bulletEffect, spawnPos.position, rotation.transform.rotation);
                }

                shotTime = Time.time + timeBetweenShots;
            }

        }
        Reload();
    }

    private void Reload()
    {
        if (ammo == 0)
        {
            StartCoroutine("ReloadTime");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("ReloadTime");
        }
    }

    IEnumerator ReloadTime()
    {
        isReloading = true;
        yield return new WaitForSeconds(1);
        ammo = maxAmmo;
        isReloading = false;
    }

}