using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class ShotGun_Skill : MonoBehaviour
{
    public GameObject bigBullet;
    public GameObject bulletEffect;
    public Transform spawnPos;

    public GameObject rotation;
    public int ShootBulletCount;

    public float skillCoolTime;
    public float skillCool;
    private float coolTIme;

    public bool epicSkill;

    public GameObject[] CoolDownUI;
    public TextMeshProUGUI skillCoolDownText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (epicSkill)
        {
            if (Input.GetMouseButton(1) && skillCool > skillCoolTime)
            {
                for (int i = 0; i < 2; i++)
                {

                    for (int j = 0; j < ShootBulletCount; j++)
                    {
                        int count = ShootBulletCount / 2;
                        Quaternion rotate = Quaternion.Euler(0, 0, j - count);
                        Instantiate(bigBullet, spawnPos.position, rotation.transform.rotation * rotate);
                    }

                }

                Instantiate(bulletEffect, spawnPos.position, rotation.transform.rotation);
                skillCool = 0;
                for (int i = 0; i < CoolDownUI.Length; i++)
                {
                    CoolDownUI[i].SetActive(true);
                }
            }

            skillCool = skillCool + Time.deltaTime;


            if (skillCoolTime - skillCool > 0)
            {
                coolTIme = skillCoolTime - skillCool;
            }
            else if (skillCoolTime - skillCool < 0)
            {
                for (int i = 0; i < CoolDownUI.Length; i++)
                {
                    CoolDownUI[i].SetActive(false);
                }
            }

            skillCool = skillCool + Time.deltaTime;
            skillCoolDownText.text = coolTIme.ToString("0.0");


        }

    }
}