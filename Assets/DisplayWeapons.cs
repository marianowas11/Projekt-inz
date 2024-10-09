using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeapons : MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;
    public GameObject W1, W2, W3, W4, W5;
    private int n=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(itemManager.addedItems.Count > n) 
        {
            DisplayW();
        }
        
    }
    public void DisplayW()
    {
        n=itemManager.addedItems.Count;
        int i = 1;
        foreach (GameObject item in itemManager.addedItems)
        {
            switch (i)
            {
                case 1:
                    Instantiate(item,W1.transform);
                    break;
                case 2:
                    Instantiate(item, W2.transform);
                    break;
                case 3:
                    Instantiate(item, W3.transform);
                    break;
                case 4:
                    Instantiate(item, W4.transform);
                    break;
                case 5:
                    Instantiate(item, W5.transform);
                    break;
            }
            i++;
        }
    }
}
