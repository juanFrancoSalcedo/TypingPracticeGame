using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B_Extensions;
using System;
using Zenject;
using System.Xml;

public class ButtonEnterRoom : BaseButtonAttendant
{
    [Inject] NetworkRunnerController runnerController;
    [SerializeField] private int numberRoom;
    [SerializeField] private int indexScene;
    void Start()
    {
        buttonComponent.onClick.AddListener(StartGame);   
    }

    private void StartGame() => runnerController.StartGame(numberRoom, indexScene);
}
