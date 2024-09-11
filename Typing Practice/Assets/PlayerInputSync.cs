using Fusion;
using System;
using UnityEngine;

public class PlayerInputSync : NetworkBehaviour
{
    [UnitySerializeField][Networked, OnChangedRender(nameof(ShowLetter))] public NetworkString<_2> LastCharacter{ get; set; }

    private void ShowLetter()
    {
        print(LastCharacter+" Guardado");
    }

    public override void Spawned()
    {
        base.Spawned();
        //NWControllerKeyboardDetector.OnKeyPressed += CallSend;
    }
    
    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        base.Despawned(runner, hasState);
        //NWControllerKeyboardDetector.OnKeyPressed -= CallSend;
    }


    public override void FixedUpdateNetwork()
    {

        if (Runner.TryGetInputForPlayer<PlayerInputData>(Object.InputAuthority, out var input))
        {
            if (input.charShoot != '\0') // Si se ha presionado alguna tecla
            {
                Debug.Log($"Tecla presionada: {input.charShoot}");
                NetworkString<_2> charStr = new NetworkString<_2>(input.charShoot.ToString());
                LastCharacter = charStr;
                // Lógica para manejar la tecla presionada
            }
        }
    }

    private void CheckKey()
    {
        char value = GetKeyPressed();
        if (!value.Equals('*'))
        {
            NetworkString<_2> charStr = new NetworkString<_2>(value.ToString());
            //RPC_SendKeyPressed(charStr);
        }
    }

    private char GetKeyPressed()
    {
        //KeyCode.Semicolon
        foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode)))
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



    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_SendKeyPressed(NetworkString<_2> charChar)
    {
        print(charChar);
        LastCharacter = charChar;
    }
}

public struct PlayerInputData : INetworkInput
{
    public char charShoot;
}

public class Simulation : SimulationBehaviour
{ 

}