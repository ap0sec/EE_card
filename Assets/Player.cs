﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject[] hand = new GameObject[5];
    public int coin = 30;
    public int bet = 0;

    //引数は自由に追加してもらって構いません
    //その場合はsampleに従う形で何が必要なのか書いてください
    //戻り値は基本的にvoidで mainから叩くときに何か欲しくなったらこっちからいじるかも
    //marge・conflict消化は小高がやります


    /* 変数宣言が必要な場合は適宜ここから*/

	private GameObject _child;
	private GameObject _gchild;



    /*ここまで*/

    //sample
    void sample(int a, double b, bool c)
    {
        //a:〇〇の状態を示す変数
        //b:✕✕の座標
        //c:内部分岐用のフラグ

        //本文

    }

    // Use this for initialization 一応残す
	void Start () {
		
	}
	
	// Update is called once per frame 一応残す
	void Update () {
		
	}

    void Set_hand(int[] type) //デッキからカードを引く時用メゾット 大浦
    {
		int i = 0;
		Debug.Log ("name:" + gameObject.name);
		if (GameObject.Find ("hand").transform.IsChildOf (transform)) {
			Debug.Log ("true");
		} else {
			Debug.Log ("false");
		}
		_child = transform.Find("hand").gameObject;
		var childTransform = GameObject.Find ("hand").transform;


		foreach(Transform child in childTransform.transform){
			Debug.Log ("name:" + child.name);

			var gchild = child.Find("Card_F").transform;
			Debug.Log ("name:" + gchild.name);

			var card = gchild.GetComponentInChildren<Card> ();
			card.type = type[i];
			Debug.Log("card: " + card);
			i++;
		}			
    }

    void Set_Bet() //ベット用メゾット 宇津木
    {

    }

    void Choice_card() //カード選択用メゾット 岩田
    {

    }

}
