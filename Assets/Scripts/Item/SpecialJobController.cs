using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialJobController : MonoBehaviour
{
    public GameObject specialJobsUI;
    public List<UnityEngine.UI.Button> jobButtons = new List<UnityEngine.UI.Button>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Show 3 selectable card prefabs on screen
            specialJobsUI.SetActive(true);
            // Change timescale to 0
            foreach (var button in jobButtons)
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() => OnJobSelected(button));
            }

            Time.timeScale = 0;
            // Handle card selection
            // Resume the game and destroy self when a card is selected
        }
    }
    private void OnJobSelected(UnityEngine.UI.Button selectedButton)
    {
        // Apply the effect of the selected card
        ApplyJobEffect(selectedButton.gameObject.name);
        // Resume the game
        Time.timeScale = 1f;
        // Destroy the card
        foreach (var button in jobButtons)
        {
            Destroy(button.gameObject);
        }
        // Disable the card selection canvas
        specialJobsUI.SetActive(false);
        // Destroy self
        Destroy(gameObject);
    }
    private void ApplyJobEffect(string jobName)
    {
        DataManager.Instance.specialWeaponGet = true;

        switch (jobName)
        {
            case "Shotgun":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.ShotGun.ToString();
                break;
            case "Rifle":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.Rifle.ToString();
                break;
            case "Sniper":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.Sniper.ToString();
                break;
            case "ShortSword":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.ShortSword.ToString();
                break;
            case "LongSword":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.LongSword.ToString();
                break;
            case "Axe":
                DataManager.Instance.SpecialWeapon = SpecialWeaponType.Axe.ToString();
                break;
            default:
                break;
        }
    }
}