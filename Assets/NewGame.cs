using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public Button bt;
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
        SceneManager.LoadScene("Map1");
    }
}
