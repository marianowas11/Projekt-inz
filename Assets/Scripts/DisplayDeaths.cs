using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayDeaths : MonoBehaviour
{
    public GameObject sstatManager;
    public StatManager statManager;
    public string deathText;
    public int deaths = 0;
    // Start is called before the first frame update
    void Start()
    {
        sstatManager = GameObject.Find("StatManager");
        statManager = sstatManager.GetComponent<StatManager>();
        //coins = statManager.coins;
        DisplayDeathsCount();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayDeathsCount();
    }
    void DisplayDeathsCount()
    {
        deaths = statManager.deadEnemies;
        deathText = "" + deaths;
        GetComponent<UnityEngine.UI.Text>().text = deathText;
    }
}
