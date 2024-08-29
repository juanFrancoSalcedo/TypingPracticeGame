using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace B_Extensions
{
    public class BaseButtonAttendant : MonoBehaviour
    {
        protected Button buttonComponent => GetComponent<Button>();

        public void Click() => buttonComponent.onClick?.Invoke();
    }
}