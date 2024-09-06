using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpawner: SingletonNW<PlayerSpawner>, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef prefab = NetworkPrefabRef.Empty;
    [SerializeField] public Transform[] points;

    List<PlayerDataView> players = new List<PlayerDataView>();
    public override void Spawned()
    {
        base.Spawned();
        SpawnPlayer(Runner.LocalPlayer);
        
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        base.Despawned(runner, hasState);
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            SpawnPlayer(player);
        }
    }

    public (PlayerRef,PlayerDataView) SpawnPlayer(PlayerRef refPlayer)
    {
        var index = Runner.ActivePlayers.Count();
        var playerObject = Runner.Spawn(prefab, Vector3.zero, Quaternion.identity, refPlayer);
        Runner.SetPlayerObject(refPlayer, playerObject);
        var behaviour = playerObject.GetBehaviour<PlayerDataView>();
        players.Add(behaviour);
        return (refPlayer,behaviour);
    }
    public void PlayerLeft(PlayerRef player)
    {
        DespawnPlayer(player);
    }

    private void DespawnPlayer(PlayerRef refPlayer)
    {
        if (Runner.TryGetPlayerObject(refPlayer, out var playerNetworkObject))
            Runner.Despawn(playerNetworkObject);
        Runner.SetPlayerObject(refPlayer, null);
    }

    internal PlayerDataView GetDataViewByIndexPlayer(int indexPlayer)
    {
        var item = players.Find(d => d.PlayerIndex.Equals(indexPlayer));
        if (item == null)
            print("ABOUT SEND A EMPTY VALUe");
        return item;
    }
}
