using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class UserTyping : MonoBehaviour
{
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode))
                                                 .Cast<KeyCode>()
                                                 .Where(k => ((int)k < (int)KeyCode.LeftCurlyBracket && 
                                                              (int)k > (int)KeyCode.BackQuote))
                                                 .ToArray();
    public TMP_InputField userInputTextBox;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        userInputTextBox = gameObject.GetComponentInChildren<TMP_InputField>();
        userInputTextBox.ActivateInputField();
        userInputTextBox.Select();
        userInputTextBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        // Check if current input text matches any enemy text on the field
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            string enemyWord = enemy.GetComponent<EnemyController>().enemyText.text;
            if (userInputTextBox.text.TrimStart('>').ToLower() == enemyWord.ToLower() && enemy.GetComponent<EnemyController>().isActive)
            {
                enemy.GetComponent<EnemyController>().MovePlayerAboveEnemy();
                userInputTextBox.text = "";
            }
        }

        // Update the user input
        
        // Backspace is pressed
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //userInputTextBox.text = ">";
        }
    }
}
