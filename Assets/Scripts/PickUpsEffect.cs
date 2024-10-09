using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PickUpsEffect : MonoBehaviour
{
    private GameObject sstatManager;
    private StatManager statManager;
    private GameObject Magnet;
    private Magnet magnet;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        sstatManager = GameObject.Find("StatManager");
        statManager=sstatManager.GetComponent<StatManager>();
        Magnet = GameObject.Find("magnet");
        magnet=Magnet.GetComponent<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExpGem()
    {//dodanie podniesonych punktów doœwiadczenia * bonuc
        statManager.playerExp+=(int)Mathf.Round(1*statManager.growth);
    }
    public void GoldCoin()
    {//dodanie monet równie¿ z dodaniem bonusu
        statManager.AddCoins(1);
    }
    public void CoinBag()
    {
        statManager.AddCoins(10);
    }
    public void RichCoinBag()
    {
        statManager.AddCoins(100);
    }
    public void Food()
    {//uleczenie bohatera
        statManager.AddHealth(30);
    }
    public void GoldVacuum()
    {//podniesienie wszytskich monet na ziemii
        foreach(GameObject coin in GameObject.FindGameObjectsWithTag("coin"))
        {
            Destroy(coin);
            statManager.coins += (int)Mathf.Round(1 * statManager.greed);
        }
        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("coin2"))
        {
            Destroy(coin);
            statManager.coins += (int)Mathf.Round(10 * statManager.greed);
        }
        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("coin3"))
        {
            Destroy(coin);
            statManager.coins += (int)Mathf.Round(100 * statManager.greed);
        }
    }
    public void Vacuum()
    {//podniesienie wszytskich punktów doœwiadczenia
        foreach (GameObject expGem in GameObject.FindGameObjectsWithTag("expGem"))
        {
            Destroy(expGem);
            statManager.playerExp += (int)Mathf.Round(1 * statManager.growth);
        }
    }

    public void Rosary()
    {
        foreach (GameObject rosary in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyHealth enemyHealth=rosary.GetComponent<EnemyHealth>();
            enemyHealth.Death();
        }
    }

    public void SmallClover()
    {
        statManager.luck += 0.1f;
    }

    public void FollowPlayer(GameObject gb, Rigidbody2D rb)
    {
        Vector3 playerPosition = player.transform.position;
        //pause = timer.pause;
        Vector2 direction = playerPosition - gb.transform.position;
        direction.Normalize();
        Vector2 movement = direction;
        int moveSpeed = 10;
        print("vacuum");
        gb.transform.position = (Vector2)gb.transform.position + (movement * moveSpeed * Time.deltaTime);
    }
}
