using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdviceController : MonoBehaviour
{
    [SerializeField] private GameObject adviceKeyboard;
    [SerializeField] private GameObject adviceHands;
    [SerializeField] private Toggle toggleHand = null;
    [SerializeField] private Toggle toggleKeyboard = null;

    private void Start()
    {
        toggleHand.onValueChanged.AddListener(ActiveHand);
        toggleKeyboard.onValueChanged.AddListener(ActiveKeyboard);
        CheckAdviceStorage(KeyStorage.Advice_Hand,ActiveHand);
        CheckAdviceStorage(KeyStorage.Advice_Keyboard, ActiveKeyboard);
    }

    private void CheckAdviceStorage(string key,System.Action<bool> action) 
    {
        if (PlayerPrefs.HasKey(key))
            action?.Invoke(PlayerPrefs.GetInt(key) ==1);
        else
            action?.Invoke(true);
    }

    public void ActiveKeyboard(bool active)
    {
        toggleKeyboard.image.color = active?Color.cyan:Color.white;
        adviceKeyboard.SetActive(active);
        PlayerPrefs.SetInt(KeyStorage.Advice_Keyboard,active?1:0);
    }

    public void ActiveHand(bool active)
    {
        toggleHand.image.color = active ? Color.cyan : Color.white;
        adviceHands.SetActive(active);
        PlayerPrefs.SetInt(KeyStorage.Advice_Hand, active ? 1 : 0);
    }
}
