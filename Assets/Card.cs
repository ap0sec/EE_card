using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    public Material teacher;
    public Material student;
    public Material retination;
    public Material jobee;

    public int type = 0; //0:teacher 1:student 2:retination 3:jobee
	
	// Update is called once per frame
	void Update () {
        switch (type)
        {
            case 0:
                this.GetComponent<Renderer>().material = teacher;
                break;
            case 1:
                this.GetComponent<Renderer>().material = student;
                break;
            case 2:
                this.GetComponent<Renderer>().material = retination;
                break;
            case 3:
                this.GetComponent<Renderer>().material = jobee;
                break;
        }
		
	}
}
