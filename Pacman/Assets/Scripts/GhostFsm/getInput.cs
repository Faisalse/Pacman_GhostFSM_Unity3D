using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getInput : MonoBehaviour
{
    public GhostFsm Ghost;
    public InputField currentEvent;
    public Text currentState;
    public Text InvalidEvent;

    public void Start()
    {
        Ghost = new GhostFsm();
        
        currentState.text = "Current state-> " + Ghost.State;
        this.GetComponent<Renderer>().material.color = Color.blue;
    }
    public void setget()
    {
        InvalidEvent.text = "";
        int n =  int.Parse(currentEvent.text);
        
        
        Ghost.fireEvent(n);
        ChangeColorGhost((int)Ghost.State);
        //Debug.Log(n);
        if (Ghost.inValid)
        {
            InvalidEvent.text = "Invalid Event";
            //Debug.Log("Invalid Event");
            Ghost.inValid = false;
        }
        else
        {
            currentState.text = "Current state-> " + Ghost.State;
        }
        


    }

    public void ChangeColorGhost(int ab)
    {
        if (ab == 0)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if(ab == 1)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

}
