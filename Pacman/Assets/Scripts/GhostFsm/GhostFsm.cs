using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
// your current state variable: that hold current state of pacman
// Ghost Fsm states
public class GhostFsm
    {
        public enum GhostState
        {
            ChasePac,
            Sacredghost,
            EyeState
        }
        // Ghost Fsm Events
        enum GhostEvent
        {
            MoveRandom,
            EatPacMan,
            PacManEatSuperTab,
            PacEatScaredGhost,
            SuperPacManTimeOut,
            MoveToIntialState,
        }
        
        public GhostState State;
        public bool inValid = false;
        // function to fire event........
        // return current state....
        public GhostState fireEvent(int trigerEventt)
        {
            // code to handle the ChasePac State
            // Convert into Enum value
            GhostEvent trigerEvent = (GhostEvent)trigerEventt;
            if (State.Equals(GhostState.ChasePac))
            {
                switch (trigerEvent)
                {
                    case GhostEvent.MoveRandom:
                        State = GhostState.ChasePac;
                        return State;                       
                    case GhostEvent.EatPacMan:
                        State = GhostState.ChasePac;
                        return State;                      
                    case GhostEvent.PacManEatSuperTab:
                        State = GhostState.Sacredghost;
                        return State;                       
                    default:
                        inValid = true;
                        return State;                  
                }
            }
            // code to handle the Sacred ghost state
            else if (State.Equals(GhostState.Sacredghost))
            {
                switch (trigerEvent)
                {
                    case GhostEvent.PacEatScaredGhost:
                        State = GhostState.EyeState;
                        return State;
                        
                    case GhostEvent.SuperPacManTimeOut:
                        State = GhostState.ChasePac;
                        return State;                       
                    default:
                        inValid = true;
                        return State;                       
                }
            }
            // code to handle the Eye state
            else
            {
                switch (trigerEvent)
                {
                    case GhostEvent.MoveToIntialState:
                        State = GhostState.ChasePac;
                        return State;
                        
                    default:
                        inValid = true;
                        return State;                       
                }
            }
        }
        // function to access the current state.....
       public GhostState get()
        {
            return State;
        }
       
       

        public GhostFsm()
        {
            State = GhostState.ChasePac;

        }

        
    }

