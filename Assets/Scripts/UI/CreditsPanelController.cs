using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;

public class CreditsPanelController : GenericUIPanelController
{
    public override void ClosePanel()
    {
        UIManager.Instance().ClosePanel(UIPanelTypes.creditsPanel);

    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ClosePanel();
        }
    }
}
