using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Timers", "Basic Timer", "Execute next command on Timer end")]

public class ExecuteOnTimer : Command
{
    public float duration;

    // Update is called once per frame
    public override void OnEnter()
    {
        Invoke("ContinueToNextCommand", duration);
    }

    public void ContinueToNextCommand()
    {
        Continue();
    }
}
