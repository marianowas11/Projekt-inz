using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMagicWandText : MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;
    // Start is called before the first frame update
    void Start()
    {
        iitemManager = GameObject.Find("ItemManager");
        itemManager = iitemManager.GetComponent<ItemManager>();
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ChangeText()
    {
        switch (itemManager.wandLvl)
        {
            case 0:
                GetComponent<UnityEngine.UI.Text>().text = "Ten potê¿ny artefakt strzela w najbli¿szego przeciwnika magicznymi pociskami.\nDamage:10, Area:1, \nSpeed:1, Cooldown:1.2, Amount:1";
                break;
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wiêcej Amount+1";
                break;
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = "Cooldown zmniejszony o 0.2s";
                break;
            case 3:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wiêcej Amount+1";
                break;
            case 4:
                GetComponent<UnityEngine.UI.Text>().text = "Damage+10";
                break;
            case 5:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wiêcej Amount+1";
                break;
            case 6:
                GetComponent<UnityEngine.UI.Text>().text = "Pocisk przechodzi o jednego wroga wiêcej\nPierce+1";
                break;
            case 7:
                GetComponent<UnityEngine.UI.Text>().text = "Damage+10";
                break;
        }
    }
}
