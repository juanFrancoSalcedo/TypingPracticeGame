using UnityEngine;

public class RandomizeKeyPool 
{
    public static string previousKey = "";
    public static KeyCode GetRandomKey(KeyPool pool)
    {
        var key = pool.keysPool[Random.Range(0, pool.keysPool.Count)];
        for (int i = 0; i < 6; i++)
            if(key.ToString().Equals(previousKey))
                key = pool.keysPool[Random.Range(0, pool.keysPool.Count)];
        previousKey = key.ToString();
        return key;
    }
}
