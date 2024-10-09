using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGarlicText : MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;
    // Start is called before the first frame update
    void Start()
    {
        iitemManager = GameObject.Find("ItemManager");
        itemManager=iitemManager.GetComponent<ItemManager>();
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeText()
    {
        switch (itemManager.garlicLvl)
        {
            case 0:
                GetComponent<UnityEngine.UI.Text>().text = "Ten okropny smród zadaje okrótne obra¿enia\nDamage:5, Area:1, \nSpeed:1, Cooldown:1.3";
                break; 
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = "Area +40% and Damage +2";
                break; 
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = "Cooldown reduced by 0.1s and Damage +1";
                break; 
            case 3:
                GetComponent<UnityEngine.UI.Text>().text = "Area +20% and Damage +1";
                break; 
            case 4:
                GetComponent<UnityEngine.UI.Text>().text = "Cooldown -0.1s and Damage +2";
                break; 
            case 5:
                GetComponent<UnityEngine.UI.Text>().text = "Area +20% and Damage +1";
                break; 
            case 6:
                GetComponent<UnityEngine.UI.Text>().text = "Cooldown -0.1s and Damage +1";
                break; 
            case 7:
                GetComponent<UnityEngine.UI.Text>().text = "Area +20% and Damage +1";
                break;
        }
    }
}
