using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour
{

    public GameObject[] hand = new GameObject[5];
    public int coin = 30;
    public int bet = 0;

    //引数は自由に追加してもらって構いません
    //その場合はsampleに従う形で何が必要なのか書いてくださ
    //戻り値は基本的にvoidで mainから叩くときに何か欲しくなったらこっちからいじるかも
    //marge・conflict消化は小高がやります


    /* 変数宣言が必要な場合は適宜ここから*/
    GameObject p_obj;

    /*ここまで*/

    //sample
    void Sample(int a, double b, bool c)
    {
        //a:〇〇の状態を示す変数
        //b:✕✕の座標
        //c:内部分岐用のフラグ

        //本文

    }

    // Use this for initialization 一応残す
    void Start()
    {
        p_obj = GameObject.Find("Player");
        //Set_Betはコルーチンで呼び出す
        StartCoroutine(p_obj.GetComponent<Player>().Set_Bet());
    }

    // Update is called once per frame 一応残す
    void Update()
    {

    }

    void Set_hand(int[] type) //デッキからカードを引く時用メゾット 大浦
    {

    }

    IEnumerator Set_Bet() //ベット用メゾット 宇津木
    {
        //便宜的に, update()から呼び出し.

        GameObject textbox;
        GameObject field;
        Text ger;

        textbox = GameObject.Find("Player/Canvas/InputField/Text");
        field = GameObject.Find("Player/Canvas/InputField");

        //ベット用GUI表示.
        field.GetComponent<Image>().enabled = true;
        textbox.GetComponent<Text>().enabled = true;

        //入力待ち（コルーチン）
        while (!Input.GetKey(KeyCode.Space)) yield return 0;

        //int betに入力値をセット.
        ger = textbox.GetComponent<Text>();
        bet = Convert.ToInt32(ger.text);

        //GUI消失.
        field.GetComponent<Image>().enabled = false;
        textbox.GetComponent<Text>().enabled = false;


    }

    void Choice_card() //カード選択用メゾット 岩田
    {

    }

}
