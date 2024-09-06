using Fusion;
using B_Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerDataView : NetworkBehaviour,IPlayerLeft
{
    public static PlayerDataView LocalPlayer { get; private set; } = null;
    [UnitySerializeField] [Networked, OnChangedRender(nameof(SetRole))] public int CharacterIndex { get; set;}
    [UnitySerializeField][Networked, OnChangedRender(nameof(ApplyIndex))] public int PlayerIndex { get; set; }
    [UnitySerializeField][Networked] public NetworkString<_256> DataCharacter { get; set; }

    private void ApplyIndex() 
    {
    }

    private void SetRole() 
    {
        
    }


    public override void Spawned()
    {
        if (LocalPlayer != null)
            return;
        if (Runner.LocalPlayer == Object.StateAuthority)
        { 
            LocalPlayer = this;
            print("ATRASADO");
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        //PASS AUTHORITY
        if (!Runner.IsSharedModeMasterClient)
            return;
        var playerDatas = FindObjectsByType<PlayerDataView>(FindObjectsSortMode.None);
        foreach (var item in playerDatas)
        {
            if (item.Object.StateAuthority.Equals(player)) 
                item.Object.RequestStateAuthority();
        }
    }

    public static void SetLocalByReconnection() 
    {
        var playerDatas = FindObjectsByType<PlayerDataView>(FindObjectsSortMode.None);

        foreach (var item in playerDatas)
        {

        }
    }

    public PlayerRef Authority => Object.StateAuthority;
}