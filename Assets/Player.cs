using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Player : MonoBehaviour {

    public GameObject[] hand = new GameObject[5];
    public int coin = 30;
    public int bet = 0;

    //引数は自由に追加してもらって構いません
    //その場合はsampleに従う形で何が必要なのか書いてくださ
    //戻り値は基本的にvoidで mainから叩くときに何か欲しくなったらこっちからいじるかも
    //marge・conflict消化は小高がやります


    /* 変数宣言が必要な場合は適宜ここから*/
	private Text ger;
	GameObject hoge;
	GameObject hoge2;
	GameObject hoge3;
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
	void Start () {
		hoge2 = GameObject.Find("GameObject");
		hoge2.GetComponent<Player>().Set_Bet();
	}
	
	// Update is called once per frame 一応残す
	void Update () {

	//トリガーがわからないので, 便宜的にスペースキーが押されたタイミングでSet_Bet呼び出し.
		//if(Input.GetKey(KeyCode.Space)){
		//	hoge2 = GameObject.Find("GameObject");
		//	hoge2.GetComponent<Player>().Set_Bet();
		//}

	}

    void Set_hand(int[] type) //デッキからカードを引く時用メゾット 大浦
    {

    }

    void Set_Bet() //ベット用メゾット 宇津木
    {
	//便宜的に, update()から呼び出し.

	hoge = GameObject.Find("GameObject/bet/Canvas/InputField/Text");
	hoge3 = GameObject.Find("GameObject/bet/Canvas/InputField");

	//ベット用GUI表示.
	hoge3.GetComponent<Image>().enabled = true;
	hoge.GetComponent<Text>().enabled = true;
	
	while(Input.GetKey(KeyCode.Space) != true){}
	//int betに入力値をセット.
	ger = hoge.GetComponent<Text>();
	bet = Convert.ToInt32(ger.text);
	//Debug.Log(bet);
	
	//GUI消失.
	hoge3.GetComponent<Image>().enabled = false;
	hoge.GetComponent<Text>().enabled = false;
	

    }

    void Choice_card() //カード選択用メゾット 岩田
    {

    }

}
