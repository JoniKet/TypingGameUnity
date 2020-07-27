using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{   //TODO: Call some random words library instead of listing random words :D
    private string[] randomSentences =
    {
        "The cake is a lie",
        "Cake has been eaten",
        "Rudolf has a dog",
        "The ants enjoyed the barbecue more than the family",
        "The paintbrush was angry at the color the artist chose to use"
    };

    private string[] randomWords =
        {
            "coke",
            "kalja",
            "viina",
            "keppana",
            "olut",
            "tolkki",
            "mallas",
            "koskenkorva",
            "gambiina",
            "pikkug",
            "valdemar",
            "lonkero",
            "unity",
            "oispa",
            "malboro",
            "sandels",
            "koff",
            "karhu",
            "olvi",
            "marabello",
            "Doris",
            "Sisuviina",
            "leijona",
            "suomi"
        };

    public string GetRandomWord()
    {
        int index = Random.Range(0, this.randomWords.Length);
        return randomWords[index];

    }

    public string getRandomSentence()
    {
        int index = Random.Range(0, this.randomSentences.Length);
        return randomSentences[index];
    }
}
