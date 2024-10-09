using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToTheGame : MonoBehaviour
{
    public Button bt;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        bt.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Back()
    {
        go.SetActive(false);
        Time.timeScale = 1;
    }
}
