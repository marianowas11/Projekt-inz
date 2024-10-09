using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject lootPrefab;
    
    public string lootName;
    public float lootChance;
    public List<Loot> lootList = new List<Loot>(); 
    // Start is called before the first frame update
    public Loot(GameObject lootPrefab,string lootName,float lootChance)
    {
        this.lootPrefab= lootPrefab;
        this.lootName= lootName;
        this.lootChance= lootChance;
        
    }
    Loot GetDroppedItems()
    {
        int randomNumber = Random.Range(1, 100);
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in lootList)
        {
            if(randomNumber <= item.lootChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPos)
    {
        Loot droppedItem= GetDroppedItems();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItem.lootPrefab, spawnPos,Quaternion.identity);
        }
    }

    public void Start()
    {
        //GameObject gb = Instantiate();
    }
}
