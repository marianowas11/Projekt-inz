using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoinCount : MonoBehaviour
{
    public GameObject sstatManager;
    public StatManager statManager;
    public string coinText;
    public int coins=0;
    // Start is called before the first frame update
    void Start()
    {
        sstatManager = GameObject.Find("StatManager");
        statManager=sstatManager.GetComponent<StatManager>();
        //coins = statManager.coins;
        DisplayCoins();
    }

    // Update is called once per frame
    void Update()
    {
            DisplayCoins();
            //coins= statManager.coins;
    }
    void DisplayCoins()
    {
        coins = statManager.coins;
        coinText = ""+coins;
        GetComponent<UnityEngine.UI.Text>().text = coinText;
    }
}
