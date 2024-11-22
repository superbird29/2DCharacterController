using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Codehere : MonoBehaviour
{
    string NewMessage = "Clicked";
    public GameObject Text;
    public Button Test;
    void Start()
    {
        //Test.onClick.AddListener(ChangeText);
        GameObject expensive  = GameObject.Find("Mep");
        GameObject Still_Expensive = GameObject.FindGameObjectWithTag("Mop");
    }

    private void ChangeText()
    {
        //Text.GetComponent<TMP_Text>().text = NewMessage;
    }
}
