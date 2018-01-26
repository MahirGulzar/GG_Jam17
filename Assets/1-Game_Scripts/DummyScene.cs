using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScene : BaseMenu
{
    public override void Update()
    {
        base.Update();
        //Do anything
    }

    override public void OnBackBtnPress()
    {

        // Do My Custom Back Button Implementation
        Debug.Log("Custom Back Button Implementation");

    }

}
