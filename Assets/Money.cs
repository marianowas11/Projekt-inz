using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        DisplayGold();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGold();
    }
    public void DisplayGold()
    {
        GetComponent<UnityEngine.UI.Text>().text = ""+PlayerPrefs.GetInt("coins",0);
        
    }
}
