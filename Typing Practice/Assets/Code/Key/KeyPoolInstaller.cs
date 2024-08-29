using System.Collections.Generic;
using UnityEngine;

public class KeyPoolInstaller: MonoBehaviour
{
    [SerializeField] private KeyboardDetector detector = null;
    [SerializeField] private List<KeyPoolInfo> pools = null;
    [SerializeField] private KeyPoolInfo infoFreePractice = null;
    private static bool repeatPool = false;
    private void Awake()
    {
        if (infoFreePractice != null)
        {
            KeyboardDetector.Pool = infoFreePractice.pool;
            detector.UpdateCurrentKey();
        }
        else
            InstallPool();
    }

    public void RepeatSession() => repeatPool = true;

    public void InstallPool()
    {
        RandomizePool();
        if (!repeatPool)
            KeyboardDetector.Pool = GetApropiatedPool();
        else
            repeatPool = false;
        detector.UpdateCurrentKey();
    }

    private KeyPool GetApropiatedPool()
    {
        var myLevelPool = pools.Find(p => CurrentProgress.CurrentProgressInstance.ThisIsAppropiate(p.pool.Progress));
        return myLevelPool.pool;
    }

    private void RandomizePool() 
    {
        for (int i = 0; i < 60; i++)
        {
            int random = Random.Range(0,pools.Count);
            var poolBuffer = pools[random];
            pools.Remove(poolBuffer);
            pools.Add(poolBuffer);
        }
    }
}