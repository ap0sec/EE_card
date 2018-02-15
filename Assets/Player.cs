using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public int coin = 30;
    public int bet = 0;

    /* 変数宣言が必要な場合は適宜ここから*/
    GameObject targetCard;
    public float distance = 100f;
    public int typeDate = 0;
    int looptriger;

    public GameObject canvas;
    GameObject p_obj;

    /*ここまで*/


    // Use this for initialization 一応残す
    void Start()
    {
        coin = 30;
        bet = 0;
        p_obj = GameObject.Find("Player");
        //Set_Betはコルーチンで呼び出す
        //StartCoroutine(p_obj.GetComponent<Player>().Set_Bet());
        targetCard = GameObject.FindGameObjectWithTag("target");
        //StartCoroutine("Choice_card");
    }

    // Update is called once per frame 一応残す
    void Update()
    {
		
    }

    void Set_hand(int[] type) //デッキからカードを引く時用メゾット
    {
		int i = 0;

		var childTransform = GameObject.Find ("p_hand").transform;

		foreach(Transform child in childTransform.transform)
        {
			var gchild = child.Find("Card_F").transform;

			var card = gchild.GetComponentInChildren<Card> ();
			card.type = type[i];
			Debug.Log("card: " + card);
			i++;
		}
    }

    IEnumerator Set_Bet() //ベット用メゾット
    {
        GameObject textbox;
        Text ger;

        //ベット用GUI表示.
        canvas.SetActive(true);
        textbox = GameObject.Find("Player/Canvas/InputField/Text");

        //入力待ち（コルーチン）
        while (!Input.GetKey(KeyCode.Space)) yield return 0;

        //int betに入力値をセット.
        ger = textbox.GetComponent<Text>();
        bet = Convert.ToInt32(ger.text);

        //GUI消失.
        canvas.SetActive(false);


    }

    IEnumerator Choice_card() //カード選択用メゾット
    {
        looptriger = 0;
        while (looptriger == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //クリックによるGameObject所得
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

				if (Physics.Raycast (ray, out hit, distance)) {
					if (hit.collider.gameObject.tag == "hands") {
						//所得したCardからType変数を所得
						GameObject CardObject = hit.collider.gameObject;
						Card script = CardObject.GetComponent<Card> ();
						typeDate = script.type;
						//盤上のカードにデータコピー
						//Debug.Log(targetCard);
						Card targetScript = targetCard.GetComponent<Card> ();
						targetScript.type = typeDate;
						//選択した手札を非表示化
						Renderer t_rend = CardObject.GetComponent<Renderer> ();
						Renderer f_rend = targetCard.GetComponent<Renderer> ();
						t_rend.enabled = false;
						f_rend.enabled = true;
						looptriger = 1;
					}
				}
            }
            yield return null;
        }
    }
}
