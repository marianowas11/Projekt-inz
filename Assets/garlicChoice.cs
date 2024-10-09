using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garlicChoice: MonoBehaviour
{
    public GameObject iitemManager;
    public ItemManager itemManager;

    private GameObject thisMenu;
    private Destroy menu;
    public Button bt;
    // Start is called before the first frame update
    void Start()
    {
        thisMenu = GameObject.Find("LevelUoScreen");
        menu = thisMenu.GetComponent<Destroy>();
        iitemManager = GameObject.Find("ItemManager");
        itemManager = iitemManager.GetComponent<ItemManager>();
        bt.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Clicked()
    {
        itemManager.ActivateItem("garlic");
        Time.timeScale = 1;
        menu.DestroyMenu();
    }
}
