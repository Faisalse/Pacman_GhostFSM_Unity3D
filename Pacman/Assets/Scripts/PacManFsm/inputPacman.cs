using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputPacman : MonoBehaviour
{
    public PacManFSM1 pacManFSM1;
    public InputField inputField;
    public Text cuurentState;
    public Text InvalidEvent;
    // Start is called before the first frame update
    void Start()
    {
        pacManFSM1 = new PacManFSM1();
        Debug.Log("Asad");
        cuurentState.text = "Current state-> " + pacManFSM1.PacmanCurrentState;
        changeColor((int)pacManFSM1.getCurrentState());
        
    }

    // set even function is called once per frame

    public void setget()
    {
        InvalidEvent.text = "";
        int n = int.Parse(inputField.text);
        pacManFSM1.FireEvent(n);
        //ChangeColorGhost((int)Ghost.State);
        //Debug.Log(n);
        if (pacManFSM1.inValid)
        {
            InvalidEvent.text = "Invalid Event";
            //Debug.Log("Invalid Event");
            pacManFSM1.inValid = false;
        }
        else
        {
            cuurentState.text = "Current state-> " + pacManFSM1.PacmanCurrentState;
            changeColor((int)pacManFSM1.getCurrentState());
        }
    }

    public void changeColor(int n)
    {
        switch (n)
        {
            case 0:
                this.GetComponent<Renderer>().material.color = Color.black;
                break;
            case 1:
                this.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 3:
                this.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 4:
                this.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            
            default:
                
                break;
        }
    }
}
