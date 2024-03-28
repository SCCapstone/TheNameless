using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPhaseManager : MonoBehaviour
{
    private bool phase1 = true; 
    private bool phase2, phase3 = false;

    void Start()
    {
        ActivatePhase();
    }

    // Called from button to switch to next phase of battle
    public void ChangePhase()
    {
        if(phase1)
        {
            phase1 = false;
            phase2 = true;
            phase3 = false;
        } 
        else if(phase2)
        {
            phase1 = false;
            phase2 = false;
            phase3 = true;
        }
        else if(phase3)
        {
            phase1 = false;
            phase2 = false;
            phase3 = false;
        }
        else
        {
            EndBattle();
        }

        ActivatePhase();
    }

    // Uses booleans to activate and deactivate the objects and scripts for each phase
    private void ActivatePhase()
    {
        PhaseOne(phase1);
        PhaseTwo(phase2);
        PhaseThree(phase3);
    }

    private void PhaseOne(bool phase)
    {
        //  TODO: use phase variable to set the active state of Phase 1 objects/scripts
    }

    private void PhaseTwo(bool phase)
    {
        //  TODO: use phase variable to set the active state of Phase 2 objects/scripts
    }

    private void PhaseThree(bool phase)
    {
        //  TODO: use phase variable to set the active state of Phase 3 objects/scripts
    }

    private void EndBattle()
    {
        //  TODO: Switch to ending cutscene
    }
}
