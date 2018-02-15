using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    Deck deck;
    Player p_obj;
    Enemy e_obj;
    int turn;
    // Use this for initialization
    IEnumerator Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        p_obj = GameObject.Find("Player").GetComponent<Player>();
        e_obj = GameObject.Find("Enemy").GetComponent<Enemy>();
        GameObject e_field = GameObject.FindGameObjectWithTag("e_field");
        GameObject p_field = GameObject.FindGameObjectWithTag("target");
        deck.Init();

        int win;
        int lose;

        for (turn = 0; turn < 3; turn++)
        {
            win = 0;
            lose = 0;
            deck.Giveout();
            Debug.Log("Your coins : " + p_obj.coin);
            yield return StartCoroutine(p_obj.Set_Bet());
            e_obj.Set_Bet(p_obj.bet);

            foreach (int num in e_obj.Choice_card())
            {
                yield return StartCoroutine(p_obj.Choice_card());
                e_field.GetComponent<Renderer>().enabled = true;
                if (p_field.GetComponent<Card>().type == e_field.GetComponent<Card>().type)
                {
                    Debug.Log("Draw!");
                }
                else if (p_field.GetComponent<Card>().type == 0 && e_field.GetComponent<Card>().type == 1)
                {
                    Debug.Log("Win!");
                    win++;
                }
                else if (p_field.GetComponent<Card>().type == 1 && e_field.GetComponent<Card>().type == 2)
                {
                    Debug.Log("Win!");
                    win++;
                }

                else if (p_field.GetComponent<Card>().type == 2 && e_field.GetComponent<Card>().type == 0)
                {
                    Debug.Log("Win!");
                    win++;
                }
                else if (p_field.GetComponent<Card>().type == 3)
                {
                    Debug.Log("Win!");
                    win++;
                }
                else
                {
                    Debug.Log("Lose...");
                    lose++;
                }

                yield return StartCoroutine(Sleep());
                p_field.GetComponent<Renderer>().enabled = false;
                e_field.GetComponent<Renderer>().enabled = false;

            }
            if(win > lose)
            {
                Debug.Log("You win!!");
                p_obj.coin += p_obj.bet;
                e_obj.coin -= e_obj.bet;
            }
            else if(win < lose)
            {
                Debug.Log("You lose...");
                p_obj.coin -= p_obj.bet;
                e_obj.coin += e_obj.bet;
            }
            else
            {
                Debug.Log("Draw.");
            }
            
        }
        if (p_obj.coin < e_obj.coin) Debug.Log("You lose... Please retire...");
        else if (p_obj.coin > e_obj.coin) Debug.Log("You Win! You can to advance!");
        else Debug.Log("Draw... Please play again!");

    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2);
    }
}
