using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;


public partial class KeyboardDetector : MonoBehaviour
{
    public static KeyPool Pool { get; set; } = new KeyPool();
    [SerializeField] private KeyDetectorView view;

    private KeyCode currentKey = KeyCode.None;
    public KeyCode CurrentKey
    {
        get => currentKey;
        private set
        {
            currentKey = value;
            OnCurrentKeyUpdate?.Invoke(currentKey);
        }
    }
    public static event System.Action<char, bool> OnKeyPressed;
    public static event System.Action<KeyCode> OnCurrentKeyUpdate;
    public static readonly float animationTimes = 0.6f;
    private bool stop = false;


    void Update()
    {
        if (stop || !Input.anyKeyDown)
            return;
        if (Input.GetKeyDown(CurrentKey))
            CheckKey(true);
        else
            CheckKey(false);
    }
    // NAME OF KEY
    //private void OnGUI()
    //{
    //    Event e = Event.current;
    //    print(e.ToString());
    //}
    public void Stop() => stop = true;

    private void CheckKey(bool isCorrect)
    {
        char value = GetKeyPressed();
        if (value.Equals('*'))
            return;
        OnKeyPressed?.Invoke(value, isCorrect);
        UpdateCurrentKey();
        view.DisplayCorrect(isCorrect);
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

    public void UpdateCurrentKey()
    {
        CurrentKey = RandomizeKeyPool.GetRandomKey(Pool);
        view.DisplayKey(this);
    }

    private static char NormalizeKey(string str)
    {
        print(str);
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
