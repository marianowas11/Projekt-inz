using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Garlic : MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;
    public GameObject sstatManager;
    public StatManager statManager;

    //garlic
    public int garlicLvl = 0;
    GameObject g0;
    private int activeLvl = 1;
    [System.NonSerialized] public float garlicStartingArea = 4f;
    public float garlicArea;
    public float garlicDamage;
    public float garlicBaseDamage;
    public float garlicBonusDamage=0;
    public float garlicAreaMulti=1;
    //
    public float might;

    // Start is called before the first frame update
    void Start()
    {
        sstatManager = GameObject.Find("StatManager");
        statManager=sstatManager.GetComponent<StatManager>();
        iitemManager = GameObject.Find("ItemManager");
        itemManager = iitemManager.GetComponent<ItemManager>();
        //garlicDamage = statManager.garlicBaseDmg;
        g0 = GameObject.Find("garlic");
        garlicArea = garlicStartingArea * statManager.area * statManager.areaPowerUp * garlicAreaMulti;
        garlicLvl = itemManager.garlicLvl;
        garlicBaseDamage = statManager.garlicBaseDmg;
        might=statManager.might;
        garlicDamage = garlicBaseDamage*might;
        //print(garlicLvl);
    }

    // Update is called once per frame
    void Update()
    {
        garlicArea = ConvertNumber(ConvertNumber(garlicStartingArea, statManager.area) , ConvertNumber( statManager.areaPowerUp , garlicAreaMulti));
        garlicLvl = itemManager.garlicLvl;
        garlicBaseDamage = statManager.garlicBaseDmg;
        might = statManager.might;
        garlicDamage = ConvertNumber((garlicBaseDamage + garlicBonusDamage), might);
        transform.localScale = new Vector3(garlicArea, garlicArea, 1);
        if (itemManager.garlicLvlUp && garlicLvl <= itemManager.garlicMaxLvl - 1)
        {
            garlicLvl++;
            itemManager.garlicLvlUp = false;
        }
        //if (itemManager.garlicEx) garlicLvl = 0;
        if (garlicLvl > activeLvl || garlicLvl == 0)
        {
            //print("smt2");
            CheckForLvl(garlicLvl);
        }
    }
    
    void CheckForLvl(int i)
    {
        switch(i)
        {
            case 0:
                g0.SetActive(false);
                itemManager.garlicLvl = 0;
                break; 
            case 1:
                activeLvl = 1;
                itemManager.garlicLvl = 1;
                garlicBonusDamage= 0;
                break; 
            case 2:
                activeLvl = 2;
                itemManager.garlicLvl = 2;
                garlicAreaMulti += 0.4f;
                garlicBonusDamage += 2;
                break; 
            case 3:
                activeLvl = 3;
                itemManager.garlicLvl = 3;
                //garlicArea *= 1.4f;
                garlicBonusDamage += 1;
                break;
            case 4:
                activeLvl = 4;
                itemManager.garlicLvl = 4;
                garlicAreaMulti += 0.2f;
                garlicBonusDamage += 1;
                break;
            case 5:
                activeLvl = 5;
                itemManager.garlicLvl = 5;
                //garlicArea *= 1.4f;
                garlicBonusDamage += 2;
                break;
            case 6:
                activeLvl = 6;
                itemManager.garlicLvl = 6;
                garlicAreaMulti += 0.2f;
                garlicBonusDamage += 1;
                break;
            case 7:
                activeLvl = 7;
                itemManager.garlicLvl = 7;
                //garlicArea *= 1.4f;
                garlicBonusDamage += 1;
                break;
            case 8:
                activeLvl = 8;
                itemManager.garlicLvl = 8;
                garlicAreaMulti += 0.2f;
                garlicBonusDamage += 1;
                break;
        }
        //print(garlicLvl);
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
    private float ConvertNumber(float n1, float n2)
    {
        string smt = String.Format("{0}", (100000 * n1 * n2));

        return (float.Parse(smt) / 100000);
    }
}
