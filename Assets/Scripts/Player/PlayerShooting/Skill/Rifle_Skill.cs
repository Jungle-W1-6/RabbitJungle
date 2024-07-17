using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using TMPro;
using UnityEngine.UI;


public class Rifle_Skill : MonoBehaviour
{
    public GameObject rifle;

    public float skillTime;
    public float skillCool;
    public float skillCoolTime;
    private float coolTIme;

    private bool skill;

    public bool epicSkill;

    public GameObject[] CoolDownUI;
    public TextMeshProUGUI skillCoolDownText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CoolDownUI.Length; i++)
        {
            CoolDownUI[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (epicSkill)
        {
            if (!skill && skillCool > skillCoolTime)
            {
                if (Input.GetMouseButton(1))
                {
                    skill = true;
                    rifle.GetComponent<Gun_Rifle>().skill = skill;
                }
            }
            else if (skill)
            {
                skillTime = skillTime + Time.deltaTime;

                if (skillTime > 3)
                {
                    skill = false;
                    skillTime = 0;
                    rifle.GetComponent<Gun_Rifle>().skill = skill;
                    skillCool = 0;

                    for (int i = 0; i < CoolDownUI.Length; i++)
                    {
                        CoolDownUI[i].SetActive(true);
                    }
                }
            }

            if(skillCoolTime - skillCool > 0)
            {
                coolTIme = skillCoolTime - skillCool;
            }
            else if(skillCoolTime - skillCool < 0)
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
