using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickUp : MonoBehaviour
{
    public GameObject ttimer;
    public Timer timer;
    public GameObject iitemManager;
    public PickUpsEffect pickUpsEffect;

    public int pause;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer=ttimer.GetComponent<Timer>();
        pause = timer.pause;
        iitemManager = GameObject.Find("ItemManager");
        pickUpsEffect=iitemManager.GetComponent<PickUpsEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "coin")
            {
                pickUpsEffect.GoldCoin();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "expGem")
            {
                pickUpsEffect.ExpGem();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "food")
            {
                pickUpsEffect.Food();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "goldVacuum")
            {
                pickUpsEffect.GoldVacuum();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "coin2")
            {
                pickUpsEffect.CoinBag();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "coin3")
            {
                pickUpsEffect.RichCoinBag();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "rosary")
            {
                pickUpsEffect.Rosary();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "smallClover")
            {
                pickUpsEffect.SmallClover();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Vacuum")
            {
                pickUpsEffect.Vacuum();
                Destroy(collision.gameObject);
            }
        
    }
}
