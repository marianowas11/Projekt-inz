using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDaggerText : MonoBehaviour
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
        switch (itemManager.daggerLvl)
        {
            case 0:
                GetComponent<UnityEngine.UI.Text>().text = "Ten n� jako� dziwnie si� rusza\nDamage:6.5, Area:1, \nSpeed:1, Cooldown:1s, Amount:1";
                break;
            case 1:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wi�cej Amount+1";
                break;
            case 2:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wi�cej Amount+1 oraz Damage+5";
                break;
            case 3:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wi�cej Amount+1, pr�dko�� wystrza�u -0.02s";
                break;
            case 4:
                GetComponent<UnityEngine.UI.Text>().text = "Pierce+1 Sztylet przebija o jednego przeciwnika wi�cej";
                break;
            case 5:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wi�cej Amount+1, pr�dko�� wystrza�u -0.02s";
                break;
            case 6:
                GetComponent<UnityEngine.UI.Text>().text = "O jeden pocisk wi�cej Amount+1 oraz Damage+5";
                break;
            case 7:
                GetComponent<UnityEngine.UI.Text>().text = "Pierce+1 Sztylet przebija o jednego przeciwnika wi�cej\npr�dko�� wystrza�u -0.02s";
                break;
        }
    }
}
