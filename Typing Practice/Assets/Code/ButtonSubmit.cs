using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B_Extensions;

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
