using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpawner: SingletonNW<PlayerSpawner>, IPlayerJoined
{
    [SerializeField] private NetworkPrefabRef prefab = NetworkPrefabRef.Empty;
    [SerializeField] public Transform[] points;

 

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        base.Despawned(runner, hasState);
    }

    public override void Spawned()
    {
        if (!Runner.IsServer)
            return;

        foreach (var item in Runner.ActivePlayers)
        {
            SpawnPlayer(item);
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        SpawnPlayer(player);
    }

    public (PlayerRef,PlayerDataView) SpawnPlayer(PlayerRef refPlayer)
    {
        var index = Runner.ActivePlayers.Count();
        var playerObject = Runner.Spawn(prefab, Vector3.zero, Quaternion.identity, refPlayer);
        Runner.SetPlayerObject(refPlayer, playerObject);
        var behaviour = playerObject.GetBehaviour<PlayerDataView>();
        return (refPlayer,behaviour);
    }
    //public void PlayerLeft(PlayerRef player)
    //{
    //    DespawnPlayer(player);
    //}

    //private void DespawnPlayer(PlayerRef refPlayer)
    //{
    //    if (Runner.TryGetPlayerObject(refPlayer, out var playerNetworkObject))
    //        Runner.Despawn(playerNetworkObject);
    //    Runner.SetPlayerObject(refPlayer, null);
    //}

    //internal PlayerDataView GetDataViewByIndexPlayer(int indexPlayer)
    //{
    //    var item = players.Find(d => d.PlayerIndex.Equals(indexPlayer));
    //    if (item == null)
    //        print("ABOUT SEND A EMPTY VALUe");
    //    return item;
    //}
}
