using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    public GameObject solarPunkChoice;
    public GameObject steamPunkChoice;
    public GameObject cyberPunkChoice;
    public GameObject abilityChooser;
    public GameObject player;
    public GameObject fading;
    public GameObject endScreen;
    public GameObject hint1;
    public GameObject reticle;
    public GameObject hoverReticle;

    public SolarAbility solarAbility;
    public SteamAbility steamAbility;
    public CyberAbility cyberAbility;
    public PlayerController playerController;

    public bool AbilityChoice;
    private bool end;
    private bool hintEnd1;

    public Animator animator;

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        solarPunkChoice.SetActive(true);
        abilityChooser.SetActive(false);
        reticle.SetActive(true);
        hoverReticle.SetActive(false);
        solarAbility.enabled = true;
        steamAbility.enabled = false;
        cyberAbility.enabled = false;
        end = false;
        hint1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReticleIdle()
    {
        reticle.SetActive(true);
        hoverReticle.SetActive(false);
    }

    public void HoverReticle()
    {
        hoverReticle.SetActive(true);
        reticle.SetActive(false);
    }

    public void GrabbedReticle()
    {
        reticle.SetActive(false);
        hoverReticle.SetActive(false);
    }

    public void AbilityChoiceOpen()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
        hoverReticle.SetActive(false);
        Cursor.visible = true;
        abilityChooser.SetActive(true);
    }

    public void AbilityChoiceClose()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reticle.SetActive(true);
        abilityChooser.SetActive(false);
    }

    public void SolarChoice()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reticle.SetActive(true);
        solarPunkChoice.SetActive(true);
        steamPunkChoice.SetActive(false);
        cyberPunkChoice.SetActive(false);
        abilityChooser.SetActive(false);
        solarAbility.enabled = true;
        steamAbility.enabled = false;
        cyberAbility.enabled = false;
    }

    public void SteamChoice()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reticle.SetActive(true);
        solarPunkChoice.SetActive(false);
        steamPunkChoice.SetActive(true);
        cyberPunkChoice.SetActive(false);
        abilityChooser.SetActive(false);
        solarAbility.enabled = false;
        steamAbility.enabled = true;
        cyberAbility.enabled = false;
    }

    public void CyberChoice()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reticle.SetActive(true);
        solarPunkChoice.SetActive(false);
        steamPunkChoice.SetActive(false);
        cyberPunkChoice.SetActive(true);
        abilityChooser.SetActive(false);
        solarAbility.enabled = false;
        steamAbility.enabled = false;
        cyberAbility.enabled = true;
    }

    public void EndGame()
    {
        if (end == false)
        {
            StartCoroutine(End());
            StopCoroutine(End());
        }
    }

    public void Hinting1()
    {
        if (hintEnd1 == false)
        {
            StartCoroutine(Hint1());
            StopCoroutine(Hint1());
        }
    }

    public IEnumerator End()
    {
        end = true;
        fading.SetActive(true);
        playerController.enabled = false;
        rb.velocity = Vector3.zero;
        animator.SetBool("FadingOut", true);
        yield return new WaitForSeconds(2);
        fading.SetActive(false);
        endScreen.SetActive(true);
    }

    public IEnumerator Hint1()
    {
        hintEnd1 = true;
        hint1.SetActive(true);
        yield return new WaitForSeconds(8);
        hint1.SetActive(false);
    }
}
