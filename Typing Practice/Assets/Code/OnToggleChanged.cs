using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class OnToggleChanged : MonoBehaviour
{
    [SerializeField] UnityEvent onToggleOn, onToggleOff;
    Toggle t;
    bool toggleOnTriggered, toggleOffTriggered;
    private void Awake()
    {
        t = GetComponent<Toggle>();
    }

    private void Update()
    {
        if(t.isOn && onToggleOn != null && !toggleOnTriggered)
        {
            toggleOnTriggered = true;
            toggleOffTriggered = false;
            onToggleOn.Invoke();
        }
        if(!t.isOn && onToggleOff != null && !toggleOffTriggered)
        {
            toggleOffTriggered = true;
            toggleOnTriggered = false;

            onToggleOff.Invoke();
        }
    }
}
