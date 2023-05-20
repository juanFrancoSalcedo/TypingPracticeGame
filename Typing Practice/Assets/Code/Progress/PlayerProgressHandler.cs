using UnityEngine;

public static class PlayerProgressHandler 
{
    public static void SaveProgress() 
    {
        var json = JsonUtility.ToJson(CurrentProgress.CurrentProgressInstance);
        PlayerPrefs.SetString(CurrentProgress.Key, json);
    }

    public static Progress LoadProgress(string keyProgress) 
    {
        var progress = new Progress();
        if (PlayerPrefs.HasKey(keyProgress))
            progress = JsonUtility.FromJson<Progress>(PlayerPrefs.GetString(keyProgress));
        CurrentProgress.CurrentProgressInstance = progress;
        return progress;
    }
}
