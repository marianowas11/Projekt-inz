using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class LuckyChance : MonoBehaviour
{

    public GameObject i1, i2, i3;
    public GameObject garlic, magicwand, dagger;
    List<GameObject> listAll=new List<GameObject>();
    List<GameObject> list=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        listAll.Add(garlic);
        listAll.Add(magicwand);
        listAll.Add(dagger);
        //list = listAll;
        //print(listAll);
        Populate();
    }
    public void Populate()
    {
        int random;
        for(int i = 0; i < 3; i++)
        {
            //random = Random.Range(0, list.Count);
            switch (i+1)
            {
                case 1:
                    Instantiate(listAll[0], i1.transform);
                    break;
                case 2:
                    Instantiate(listAll[1], i2.transform);
                    break;
                case 3:
                    Instantiate(listAll[2], i3.transform);
                    break;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
