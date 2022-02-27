using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{
    public bool isDialogActive;
    public void EnterDialog()
    {
        isDialogActive = true;
    }

    public void ExitDialog()
    {
        isDialogActive = false;
    }
}
