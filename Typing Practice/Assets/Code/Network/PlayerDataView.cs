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

public class PlayerDataView : NetworkBehaviour
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

    public PlayerRef Authority => Object.StateAuthority;
}