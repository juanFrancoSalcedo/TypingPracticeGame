using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newronizer;

public class ButtonSubmit : BaseButtonAttendant
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttonComponent.onClick.Invoke();
        }
    }
}
