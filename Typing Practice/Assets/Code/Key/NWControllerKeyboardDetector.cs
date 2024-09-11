using UnityEngine;

public class NWControllerKeyboardDetector:MonoBehaviour
{

    private KeyCode currentKey = KeyCode.None;

    public static event System.Action<char> OnKeyPressed;
    public static event System.Action<KeyCode> OnCurrentKeyUpdate;
    public static readonly float animationTimes = 0.6f;
    private bool stop = false;


    void Update()
    {
        CheckKey();
    }


    private void CheckKey()
    {
        char value = GetKeyPressed();
        OnKeyPressed?.Invoke(value);
    }

    private char GetKeyPressed()
    {
        //KeyCode.Semicolon
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (vKey.ToString().Contains("Mouse"))
                continue;

            if (Input.GetKeyDown(vKey))
            {
                if (vKey.ToString().Length > 1)
                    return NormalizeKey(vKey.ToString());
                else
                    return vKey.ToString()[0];
            }
        }
        return '*';
    }


    private static char NormalizeKey(string str)
    {
        if (str.Equals("Space"))
            return '_';
        if (str.Equals("Comma"))
            return ',';
        if (str.Equals("Period"))
            return '.';
        if (str.Equals("Minus"))
            return '-';
        if (str.Equals("Semicolon"))
            return 'Ñ';
        if (str.Equals("Alpha1"))
            return '1';
        if (str.Equals("Alpha2"))
            return '2';
        if (str.Equals("Alpha3"))
            return '3';
        if (str.Equals("Alpha4"))
            return '4';
        if (str.Equals("Alpha5"))
            return '5';
        if (str.Equals("Alpha6"))
            return '6';
        if (str.Equals("Alpha7"))
            return '7';
        if (str.Equals("Alpha8"))
            return '8';
        if (str.Equals("Alpha9"))
            return '9';
        if (str.Equals("Alpha0"))
            return '0';
        return str[0];
    }

}