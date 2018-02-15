using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Deck : MonoBehaviour {

    int[] data;
    int counter;
    GameObject p_obj;
    GameObject e_obj;

    void Start()
    {
        data = new int[31];
        counter = 0;
        p_obj = GameObject.Find("Player");
        e_obj = GameObject.Find("Enemy");
        //p_obj = ;
    }

    public void Init()
    {
        for(int i = 0; i < data.Length; i++)
        {
            if (i < 5) data[i] = 0;
            else if (i < 25) data[i] = 1;
            else if (i < 30) data[i] = 2;
            else data[i] = 3;
        }
        data = data.OrderBy(i => Guid.NewGuid()).ToArray();
    }

    public void Giveout()
    {
        int[] give = new int[5];
        for(int i = 0; i < 5; i++)
        {
            give[i] = data[counter];
            counter++;
        }
        p_obj.GetComponent<Player>().Set_hand(give);
        for (int i = 0; i < 5; i++)
        {
            give[i] = data[counter];
            counter++;
        }
        e_obj.GetComponent<Enemy>().Set_hand(give);
    }
}
