using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(Image))]
public class KeyHandler : MonoBehaviour
{
    [SerializeField] private Color colorCorrect = Color.white;
    [SerializeField] private Color defaultColor = Color.white;

    [SerializeField] private KeyCode codeKey = KeyCode.None;
    Image image => GetComponent<Image>();

    private void OnEnable() => KeyboardDetector.OnCurrentKeyUpdate += DisplayKeyPressed;
    private void OnDisable() => KeyboardDetector.OnCurrentKeyUpdate -= DisplayKeyPressed;

    private void DisplayKeyPressed(KeyCode code)
    {
        image.color = defaultColor;
        if (!code.Equals(codeKey))
            return;

        image.color = colorCorrect;
    }
}