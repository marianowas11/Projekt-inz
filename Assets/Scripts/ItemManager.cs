using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //inicializing or activating skills, items etc
    public int activeItems = 0; 
    public int passiveItems = 0;
    public int garlicLvl = 0; //0 for inactive
    public int garlicMaxLvl = 8;
    public bool garlickPicked = false;
    public bool garlicLvlUp = false;
    public float garlicSize;
    private bool garlicDone = false;
    public bool check = false;

    public int wandLvl;
    public int daggerLvl;

    public GameObject garlic;
    public GameObject garlicIcon;

    public GameObject magicWand;
    public MagicStaffSpawner magicStaffSpawner;
    public GameObject magicWandIcon;

    public GameObject ddaggerSpawner;
    public DaggerSpawner daggerSpawner;
    public GameObject daggerIcon;

    public List<GameObject> allItems= new List<GameObject>();
    public List<GameObject> addedItems= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        magicStaffSpawner=magicWand.GetComponent<MagicStaffSpawner>();
        daggerSpawner=ddaggerSpawner.GetComponent<DaggerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddItem(GameObject i)
    {//dodanie przedmiotu do listy dodanych przdmiotów
        addedItems.Add(i);
    }
    public void ActivateItem(string name)
    {//dodawanie przedmiotu lub poziomu
        bool containsItem;//u¿yta do sprawdzenia czy przedmiot
        switch (name)    //jest ju¿ dodany
        {
            case "garlic":
                containsItem = addedItems.Contains(garlicIcon);
                garlickPicked = true;
                garlicLvl = 1;//ustawienie poziomu
                activeItems++;//iloœæ aktywnych poziomów
                garlic.SetActive(true);//aktywacja przedmiotu
                if(!containsItem)AddItem(garlicIcon);//jeœli nie posiada dodaj
                if (containsItem) garlicLvlUp=true;//jeœli posiada dodaj poziom
                break;
            case "magicWand":
                containsItem = addedItems.Contains(magicWandIcon);
                magicWand.SetActive(true);
                if (!containsItem) AddItem(magicWandIcon);
                if (containsItem) magicStaffSpawner.LvlUp();
                break;
            case "dagger":
                containsItem = addedItems.Contains(daggerIcon);
                ddaggerSpawner.SetActive(true);
                if (!containsItem) AddItem(daggerIcon);
                if (containsItem) daggerSpawner.DaggerLvlUp();
                break;
        }
    }

    
}
