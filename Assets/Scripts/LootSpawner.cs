using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    private GameObject lootParent;
    private GameObject sstatManager;
    private StatManager statManager;
    public float rarityPoolValue;
    public float rarityPoolValueNoLuck= 60;
    public float rarityPoolValueByLuck = 16.5f;//all 76.5
    public float luck;
    public float random;
    private float rarityGoldCoin = 50;
    private float rarityCoinBag = 10;
    private float rarityRitchCoinBag = 1;
    private float rarityRosary = 1;
    private float rarityVacuum = 2;
    private float rarityFood = 12;
    private float rarityGoldVacuum = 1;
    private float raritySmallClover = 0.5f;

    //prefabs of loot
    public GameObject expGem;
    public GameObject goldCoin;
    public GameObject coinBag;
    public GameObject ritchCoinBag;
    public GameObject rosary;
    public GameObject vacuum;
    public GameObject food;
    public GameObject goldVacuum;
    public GameObject smallClover;
    //end prefabs
    Dictionary<String, GameObject> patternMatch = new Dictionary<String, GameObject>(9);
    //public List<Tuple<GameObject,String, float>> lootList = new List<Tuple<GameObject,String, float>>();
    //public List<Loot> lootList
    // Start is called before the first frame update
    void Start()
    {
        rarityPoolValueByLuck = rarityRitchCoinBag + rarityRosary + rarityVacuum + rarityFood + raritySmallClover + rarityGoldVacuum;
        lootParent = GameObject.Find("Loot");
        sstatManager = GameObject.Find("StatManager");
        statManager=sstatManager.GetComponent<StatManager>();
        //lootList.Add(expGem,"expGem",);
        patternMatch.Add("expGem", expGem);
        patternMatch.Add("goldCoin", goldCoin);
        patternMatch.Add("coinBag", coinBag);
        patternMatch.Add("ritchCoinBag", ritchCoinBag);
        patternMatch.Add("rosary", rosary);
        patternMatch.Add("vacuum", vacuum);
        patternMatch.Add("food", food);
        patternMatch.Add("goldVacuum", goldVacuum);
        patternMatch.Add("smallClover", smallClover);
        luck = statManager.luck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnLoot(Vector3 pos)
    {
        luck = statManager.luck;
        rarityPoolValue = rarityPoolValueNoLuck + rarityPoolValueByLuck;
        float l1,l2,l3,l4,l5,l6,l7,l8;
        l1 = rarityGoldCoin;
        l2 = l1 + rarityCoinBag;
        l3 = l2 + rarityRitchCoinBag * luck;
        l4 = l3 + rarityRosary * luck;
        l5 = l4 + rarityVacuum * luck;
        l6 = l5 + rarityFood * luck;
        l7 = l6 + rarityGoldVacuum * luck;
        l8 = l7 + raritySmallClover * luck;

        //print(rarityPoolValue);
        //spawn expGem on pos
        SpawnPrefab("expGem", pos);
        //random = UnityEngine.Random.Range(0f, 1f);
        if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityGoldCoin,rarityPoolValue))
        {
            //spawn goldCoin
            SpawnPrefab("goldCoin", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityCoinBag, rarityPoolValue))
        {
            //spawn coinBag
            SpawnPrefab("coinBag", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityRitchCoinBag * luck, rarityPoolValue))
        {
            //spawn richCoinBag
            SpawnPrefab("ritchCoinBag", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityRosary * luck, rarityPoolValue))
        {
            //spawn rosary
            SpawnPrefab("rosary", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityVacuum * luck, rarityPoolValue))
        {
            //spawn vacuum
            SpawnPrefab("vacuum", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityFood * luck, rarityPoolValue))
        {
            //spawn food
            SpawnPrefab("food", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(rarityGoldVacuum * luck, rarityPoolValue))
        {
            //spawn goldVacuum
            SpawnPrefab("goldVacuum", pos);
        }
        else if (UnityEngine.Random.Range(0f, 1f) <= ConvertNumber(raritySmallClover * luck, rarityPoolValue))
        {
            //spawn smallClover
            SpawnPrefab("smallClover", pos);
        }
        
    }

    private void SpawnPrefab(string name, Vector3 pos)
    {
        //print("spawn: " + name);
        GameObject obj = Instantiate(patternMatch[name], pos, Quaternion.identity, lootParent.transform) as GameObject;
    }
    private float ConvertNumber(float n1, float n2)
    {
        string smt = String.Format("{0}", (100000* n1 / n2));

        return(float.Parse(smt) / 100000);
    }
}
