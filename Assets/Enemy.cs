using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int coin = 30;
    public int bet = 0;

    /* 変数宣言が必要な場合は適宜ここから*/
    GameObject targetCard;
    public float distance = 100f;
    public int typeDate = 0;
    int looptriger;

    GameObject p_obj;
    GameObject e_obj;

    /*ここまで*/


    // Use this for initialization 一応残す
    void Start()
    {
        coin = 30;
        bet = 0;
        p_obj = GameObject.Find("Player");
        e_obj = GameObject.Find("Enemy");
        //Set_Betはコルーチンで呼び出す
        //StartCoroutine(p_obj.GetComponent<Player>().Set_Bet());
        targetCard = GameObject.FindGameObjectWithTag("target");
        //StartCoroutine("Choice_card");
    }

    // Update is called once per frame 一応残す
    void Update()
    {

    }

    public void Set_hand(int[] type) //デッキからカードを引く時用メゾット
    {
        int i = 0;

        var childTransform = GameObject.Find("e_hand").transform;

        foreach (Transform child in childTransform.transform)
        {
            var gchild = child.Find("Card_F").transform;
            var card = gchild.GetComponentInChildren<Card>();
            card.type = type[i];
            child.Find("Card_B").GetComponent<Renderer>().enabled = true;
            i++;
        }
    }

    public void Set_Bet(int p_bet) //ベット用メゾット
    {
        bet = p_bet;
    }

    public IEnumerable Choice_card() //カード選択用メゾット
    {
        GameObject[] e_hand = GameObject.FindGameObjectsWithTag("e_hand");
        GameObject e_field = GameObject.FindGameObjectWithTag("e_field");
        for(int i = 0; i < 5; i++)
        {
            var childTransform = e_hand[i].transform;
            foreach(Transform child in childTransform.transform)
            {
                if(child.name == "Card_F")
                {
                    e_field.GetComponent<Card>().type = child.GetComponent<Card>().type;
                }else if(child.name == "Card_B")
                {
                    child.GetComponent<Renderer>().enabled = false;
                }
            }
            yield return i;
        }
    }
}
