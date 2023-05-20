using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandsController : MonoBehaviour
{
    [Header("")]
    [SerializeField] private List<HandClue> fingerTips = new List<HandClue>();

    private void OnEnable() => KeyboardDetector.OnCurrentKeyUpdate += DisplayClue;

    private void OnDisable() => KeyboardDetector.OnCurrentKeyUpdate -= DisplayClue;

    private void DisplayClue(KeyCode obj)
    {
        fingerTips.ForEach(c => c.DisplayFingertip(false));
        fingerTips.Find(c => c.EqualsKeys(obj))?.DisplayFingertip(true);
    }
}

[System.Serializable]
public class HandClue
{
    [SerializeField] Finger keyClue = Finger.None;
    [SerializeField] Image fingertip = null;

    public bool EqualsKeys(KeyCode code)
    {
        return keyClue == code.GetFinger();
    }

    public void DisplayFingertip(bool active)
    {
        fingertip.gameObject.SetActive(active);
    }
}

public static class KeyCodeExtensions
{
    public static Finger GetFinger(this KeyCode code)
    {
        if (code == KeyCode.Q ||
            code == KeyCode.A ||
            code == KeyCode.Z) 
            return Finger.LittleL;
        if (code == KeyCode.W ||
            code == KeyCode.S ||
            code == KeyCode.X)
            return Finger.RingL;
        if (code == KeyCode.E ||
            code == KeyCode.D ||
            code == KeyCode.C)
            return Finger.MiddleL;
        if (code == KeyCode.R ||
            code == KeyCode.F ||
            code == KeyCode.V ||
            code == KeyCode.T ||
            code == KeyCode.G ||
            code == KeyCode.B)
            return Finger.IndexL;



        if (code == KeyCode.P ||
            code == KeyCode.Semicolon ||
            code == KeyCode.Minus)
            return Finger.LittleR;
        if (code == KeyCode.O ||
            code == KeyCode.L ||
            code == KeyCode.Period)
            return Finger.RingR;
        if (code == KeyCode.I ||
            code == KeyCode.K ||
            code == KeyCode.Comma)
            return Finger.MiddleR;
        if (code == KeyCode.Y ||
            code == KeyCode.H ||
            code == KeyCode.N ||
            code == KeyCode.U ||
            code == KeyCode.J ||
            code == KeyCode.M)
            return Finger.IndexR;

        if (code == KeyCode.Space)
            return Finger.Thumbs;

        return Finger.None;
    }
}

public enum Finger
{
    None,
    Thumbs,
    IndexR,
    IndexL,
    MiddleR,
    MiddleL,
    RingR,
    RingL,
    LittleR,
    LittleL,
}
