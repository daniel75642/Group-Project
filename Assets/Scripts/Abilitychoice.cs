using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilitychoice : MonoBehaviour
{

    //Keybinds

    KeyCode chooseAbility = KeyCode.Q;

    //Scripts

    public GameManager gameManager;

    //Bools

    private bool abilityChoice;

    // Start is called before the first frame update
    void Start()
    {
        abilityChoice = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Choose Ability

        if (Input.GetKeyDown(chooseAbility) && abilityChoice == false)
        {
            gameManager.AbilityChoiceOpen();
            abilityChoice = true;
        }

        else if (Input.GetKeyDown(chooseAbility) && abilityChoice == true)
        {
            gameManager.AbilityChoiceClose();
            abilityChoice = false;
        }
    }
}
