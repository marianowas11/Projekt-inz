using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public Button bt;
    public GameObject sklep;
    public GameObject mm;
    // Start is called before the first frame update
    void Start()
    {
        bt.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Clicked()
    {
        sklep.SetActive(false);
        mm.SetActive(true);
    }
}
