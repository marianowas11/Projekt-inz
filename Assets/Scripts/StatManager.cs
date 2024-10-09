using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public GameObject ttimer;
    public Timer timer;
    public HealthBar healthBar;
    public ExpBar expBar;
    public GameObject lvlUpMenu;

    //inne wymagane dane
    public int pause;
    //public bool playerLvlUp;

    //Item Stats
    public float garlicSpeed = 1.3f;
    public float garlicBaseDmg=5;
    public float galicDmg;


    //Player Stats
    [System.NonSerialized] public int playerLvl = 1;
    [System.NonSerialized] public float playerExp = 0;
    [System.NonSerialized] public float playerReqExp = 5;
    [System.NonSerialized] public float maxHp = 100;
    [System.NonSerialized] public float hp;
    [System.NonSerialized] public int coins=0;
    [System.NonSerialized] public float recovery = 0;
    [System.NonSerialized] public float armor = 0;
    [System.NonSerialized] public float moveSpeed = 1;
    [System.NonSerialized] public float might = 1;
    [System.NonSerialized] public float mightMax = 10;
    [System.NonSerialized] public float area = 1f;
    [System.NonSerialized] public float areaPowerUp = 1;
    [System.NonSerialized] public float areaMax = 10;
    [System.NonSerialized] public float speed = 1;
    [System.NonSerialized] public float speedMax = 5;
    [System.NonSerialized] public float duration = 1;
    [System.NonSerialized] public float durationMax = 5;
    [System.NonSerialized] public int amount = 0;
    [System.NonSerialized] public int amountMax = 10;
    [System.NonSerialized] public float cooldown = 1;
    [System.NonSerialized] public float cooldownMax = 0.1f;
    [System.NonSerialized] public float luck = 1;
    [System.NonSerialized] public float growth = 1;
    [System.NonSerialized] public float greed = 1;
    [System.NonSerialized] public float curse = 1;
    [System.NonSerialized] public float magnetArea = 4.5f;
    [System.NonSerialized] public int revival = 0;
    [System.NonSerialized] public int reroll = 0;
    [System.NonSerialized] public int skip = 0;
    [System.NonSerialized] public int banish = 0;
    [System.NonSerialized] public int deadEnemies=0;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer=ttimer.GetComponent<Timer>();
        pause = timer.pause;
    }

    // Update is called once per frame
    void Update()
    {
        // \/ Przy zdobyciu wystarczaj¹cej iloœci punktów doœwiadczenia 
        if (playerExp >= playerReqExp) PlayerLvlUp();// poziom postaci +1
        UpdateHealth();// aktualizacja paska ¿ycia gracza
        UpdateExp();//aktualizacja paska doœwiadczenia
    }
    void UpdateHealth()
    {
        healthBar.SetMaxHealth(maxHp,hp);
    }
    void UpdateExp()
    {
        expBar.SetMaxXp(playerReqExp, playerExp);
    }
    public void PlayerLvlUp()
    {
        playerLvl++;//podniesienie poziomu postaci
        Instantiate(lvlUpMenu);//menu wyboru przedmiotu
        Time.timeScale = 0;//zatrzymanie czasu
        playerExp -= playerReqExp;//odjêcie wymaganych
        if (playerLvl < 20)       //punktów postaci
        {                         //od aktualnych
            playerReqExp += 10;
        }else if (playerLvl == 20)
        {
            playerReqExp += 610;
        }else if(playerLvl > 20 && playerLvl < 40)
        {
            playerReqExp += 13;
        }else if (playerLvl == 40)
        {
            playerReqExp += 2413;
        }else if (playerLvl > 40)
        {
            playerReqExp += 16;
        }
    }
    public void AddHealth(int n)
    {
        hp += n;
        if(hp>maxHp) hp = maxHp;
    }
    public void AddCoins(int n)
    {
        int add = (int)Mathf.Round(n * greed);
        coins += add;
    }
}
