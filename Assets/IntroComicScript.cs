using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class IntroComicScript : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private GameObject LeftOversPanel;
    [SerializeField] private GameObject TVPanel;
    [SerializeField] private GameObject PhonePanel;
    [SerializeField] private GameObject WakeUpPanel;

    public void ExecuteBlock(string targetBlock)
    {
        if (flowchart != null)
        {
            flowchart.ExecuteBlock(targetBlock);
        }


    }

    public void SetActivePanel(string panel)
    {
        GetPanelByString(panel).SetActive(true);
    }

    private GameObject GetPanelByString(string panelName)
    {
        switch (panelName)
        {
            case "LeftOversPanel":
                return LeftOversPanel;

            case "TVPanel":
                return TVPanel;

            case "PhonePanel":
                return PhonePanel;

            case "WakeUpPanel":
                return WakeUpPanel;

        }
        return null;
    }
}
