using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManFSM1
{
    // PacMan states
    public enum PacManState
    {
        START_PAC,
        SUPERMAN,
        DEAD,
        LEVELUP,
        GAMEOVER,
    }
    public enum PacManEvents
    {
        ToEatCheeze,
        ToEatSuperTab,
        EatByGhost,
        ToEatLastCheeze,
        LifeLeft,
        NoLifeLeft,
        PacmanEatsSacredGhost,
        BraveGhostEatsPacman,
        SuperPacmanTimeOut,
        PacmanMovesLastLevel,
        LastLevelGameUp,
        NextLevel
    }
    //Variable to set intial state
    public PacManState PacmanCurrentState;
    public bool inValid = false;
    //Function to fire event
    // return the Pacman state.....
    public PacManState FireEvent(int eventNumber)
    {
        PacManEvents triggerEvent = (PacManEvents)eventNumber;
        if (PacmanCurrentState.Equals(PacManState.START_PAC))
        {
            switch (triggerEvent)
            {
                case PacManEvents.ToEatCheeze:
                    PacmanCurrentState = PacManState.START_PAC;
                    return PacmanCurrentState;
                    break;
                case PacManEvents.ToEatSuperTab:
                    PacmanCurrentState = PacManState.SUPERMAN;
                    return PacmanCurrentState;
                    break;
                case PacManEvents.EatByGhost:
                    PacmanCurrentState = PacManState.DEAD;
                    return PacmanCurrentState;
                    break;
                case PacManEvents.ToEatLastCheeze:
                    PacmanCurrentState = PacManState.LEVELUP;
                    return PacmanCurrentState;
                    break;
                default:
                    inValid = true;
                    return PacmanCurrentState;
                    break;
            }
        }
        else if (PacmanCurrentState.Equals(PacManState.SUPERMAN))
        {
            switch (triggerEvent)
            {
                case PacManEvents.ToEatCheeze:
                    PacmanCurrentState = PacManState.SUPERMAN;
                    return PacmanCurrentState;

                case PacManEvents.ToEatSuperTab:
                    PacmanCurrentState = PacManState.SUPERMAN;
                    return PacmanCurrentState;

                case PacManEvents.PacmanEatsSacredGhost:
                    PacmanCurrentState = PacManState.SUPERMAN;
                    return PacmanCurrentState;

                case PacManEvents.BraveGhostEatsPacman:
                    PacmanCurrentState = PacManState.DEAD;
                    return PacmanCurrentState;

                case PacManEvents.SuperPacmanTimeOut:
                    PacmanCurrentState = PacManState.START_PAC;
                    return PacmanCurrentState;

                default:
                    inValid = true;
                    return PacmanCurrentState;


            }
        }
        else if (PacmanCurrentState.Equals(PacManState.DEAD))
        {
            switch (triggerEvent)
            {
                case PacManEvents.NoLifeLeft:
                    PacmanCurrentState = PacManState.GAMEOVER;
                    return PacmanCurrentState;

                case PacManEvents.LifeLeft:
                    PacmanCurrentState = PacManState.START_PAC;
                    return PacmanCurrentState;

                default:
                    inValid = true;
                    return PacmanCurrentState;


            }
        }
        else if (PacmanCurrentState.Equals(PacManState.LEVELUP))
        {
            switch (triggerEvent)
            {
                case PacManEvents.NextLevel:
                    PacmanCurrentState = PacManState.START_PAC;
                    return PacmanCurrentState;

                case PacManEvents.LastLevelGameUp:
                    PacmanCurrentState = PacManState.GAMEOVER;
                    return PacmanCurrentState;

                default:
                    inValid = true;
                    return PacmanCurrentState;


            }
        }
        else
        {
            switch (triggerEvent)
            {
                case PacManEvents.LastLevelGameUp:
                    PacmanCurrentState = PacManState.GAMEOVER;
                    return PacmanCurrentState;

                default:
                    inValid = true;
                    return PacmanCurrentState;



            }
        }
    }
    //function to get pacman state
    public PacManState getCurrentState()
    {
        return PacmanCurrentState;
    }
    // Constructor to first time intialize the state...
    public PacManFSM1()
    {
        PacmanCurrentState = PacManState.START_PAC;
    }
}
