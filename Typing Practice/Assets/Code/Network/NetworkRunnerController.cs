using Fusion;
using Fusion.Sockets;
using B_Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerController : Singleton<NetworkRunnerController>, INetworkRunnerCallbacks
{
    public static event Action OnPlayerJoin = null;
    public static event Action OnStartConnection = null;
    public static event Action OnConected;
    public Action OnLostConnection = null;
    private NetworkRunner networkRunnerInstance;
    public NetworkRunner NetworkRunnerInstance => networkRunnerInstance;
    public async void StartGame(int indexRoom, int indexScene)
    {
        OnStartConnection?.Invoke();
        if (networkRunnerInstance == null)
            CreateRunner();

        var startGameArgs = DefaultGameArgs(indexRoom, indexScene);
        var scene = SceneRef.FromIndex(indexScene);
        var task = networkRunnerInstance.StartGame(startGameArgs);
        var result = await task;

        if (result.Ok)
        {
            if (networkRunnerInstance.IsSceneAuthority)
            {
                await networkRunnerInstance.LoadScene(scene);
                OnConected?.Invoke();
            }
        }
        else
            Debug.Log("Error StartGamePress: " + result.ShutdownReason);

    }

    private StartGameArgs DefaultGameArgs(int indexRoom, int indexScene)
    {
        var scene = SceneRef.FromIndex(indexScene);
        var sceneInfo = new NetworkSceneInfo();
        if (scene.IsValid)
        {
            sceneInfo.AddSceneRef(scene, LoadSceneMode.Single);
        }

        var startGameArgs = new StartGameArgs();
        startGameArgs.Scene = scene;
        startGameArgs.GameMode = GameMode.AutoHostOrClient;
        startGameArgs.SessionName = Constants.KeyRooms.namesRooms[indexRoom];
        startGameArgs.PlayerCount = 10;
        startGameArgs.SceneManager = networkRunnerInstance.GetComponent<INetworkSceneManager>();
        return startGameArgs;
    }

    private void CreateRunner()
    {
        var runnerLoaded = Resources.Load<NetworkRunner>(Constants.KeyResources.PrototypePath + "/NetworkRunner");
        networkRunnerInstance = Instantiate(runnerLoaded);
        networkRunnerInstance.AddCallbacks(this);
        networkRunnerInstance.ProvideInput = true;
    }

    #region Listen runner events

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("nos conectamos al servidor conexion");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("Fallo la conexion");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("se pregunta por la conexion");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("s");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        OnLostConnection?.Invoke();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("s");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("s");
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        Debug.Log("s");
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        Debug.Log("s");
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        OnPlayerJoin?.Invoke();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("s");
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        Debug.Log("s");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        Debug.Log("s");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {


    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("s");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        OnLostConnection?.Invoke();

    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
    #endregion
}
