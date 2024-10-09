using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;
    public GameObject sstatManager;
    public StatManager statManager;

    private bool gA = false;
    public string startingItem = "magicWand";

    [System.NonSerialized] public float growth;
    [System.NonSerialized] public int bonus = 0;
    // Start is called before the first frame update
    void Start()
    {
        iitemManager = GameObject.Find("ItemManager");
        itemManager = iitemManager.GetComponent<ItemManager>();
        sstatManager = GameObject.Find("StatManager");
        statManager=sstatManager.GetComponent<StatManager>();
        itemManager.ActivateItem(startingItem);
        growth = statManager.growth;
    }
    
    // Update is called once per frame
    void Update()
    {
        growth = statManager.growth;
        if (itemManager.check)
        {
            transform.position = transform.position + new Vector3(0, 0, -1);
            transform.position = transform.position + new Vector3(0, 0, 1);
            itemManager.check = false;
        }
        PlayerLevelingBonus();
    }
    private void PlayerLevelingBonus()
    {
        if (statManager.playerLvl >= 5 && statManager.playerLvl <=9 && bonus < 1)
        {
            statManager.growth += 0.1f;
            bonus++;
        }
        if (statManager.playerLvl >= 10 && statManager.playerLvl <= 15 && bonus < 2)
        {
            statManager.growth += 0.1f;
            bonus++;
        }
        if (statManager.playerLvl >= 15 && bonus < 3) 
        {
            statManager.growth += 0.1f;
            bonus++;
        }
    }
    void ActivateStartingItem()
    {
        if (GameObject.Find(startingItem) == null)
        {
            if (!gA)
            {
                itemManager.ActivateItem(startingItem);
                gA = true;
            }
        }
    }
}
