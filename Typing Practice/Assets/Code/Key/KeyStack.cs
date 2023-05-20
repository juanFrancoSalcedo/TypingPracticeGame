using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class KeyStack : MonoBehaviour
{
    [SerializeField] KeyStackView view = null;
    public StringBuilder Builder { get; private set; }

    private void Awake() => Builder = new StringBuilder();

    private void OnEnable() => KeyboardDetector.OnKeyPressed += StackChar;

    private void OnDisable() => KeyboardDetector.OnKeyPressed -= StackChar;

    private void StackChar(char _char, bool isCorrect) 
    {
        Builder.Append(_char);
        view.AddChar(_char,isCorrect);
    }


    [System.Serializable]
    public class KeyStackView 
    {
        [SerializeField] private Text textComponent = null;
        [SerializeField] private string hexaWrong= "C92C6D";
        [SerializeField] private string hexaCorrect= "537FE7";

        public void AddChar(char _char, bool isCorrect) 
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<color=#{GetHexaColor(isCorrect)}>{_char}</color>").Append(textComponent.text);
            textComponent.text = builder.ToString();
        }

        private string GetHexaColor(bool isCorrect) => isCorrect ?hexaCorrect:hexaWrong;
    }
}
