using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuesManager : MonoBehaviour
{
    public Button bt;
    public string value;
    public int worth;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        bt.onClick.AddListener(Clicked);
        DisplayText();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText();
    }
    void Clicked()
    {
        if (PlayerPrefs.GetInt("coins", 0) >= worth)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - worth);
            PlayerPrefs.SetInt(value, PlayerPrefs.GetInt(value, 0) + 1);
            DisplayText();
        }
    }
    private void DisplayText()
    {
        txt.text = "" + PlayerPrefs.GetInt(value, 0);
    }
}
