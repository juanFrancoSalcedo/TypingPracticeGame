using UnityEngine;
using UnityEngine.UI;
using B_Extensions;
using B_Extensions.SceneLoader;
using System;

[RequireComponent(typeof(CallerSceneLoader))]
public class SlotDataView: BaseButtonAttendant
{
    [SerializeField] private Text textLevel = null;
    [SerializeField] int numberInProgress = 0;
    [SerializeField] private Button btnDelete = null;
    CallerSceneLoader SceneLoaderCall => GetComponent<CallerSceneLoader>();
    private void Start()
    {
        buttonComponent.onClick.AddListener(SetProgress);
        btnDelete.onClick.AddListener(DeleteData);
        DisplayInfo(PlayerProgressHandler.LoadProgress(Key));
    }

    private void DeleteData()
    {
        PlayerPrefs.DeleteKey(Key);
        DisplayInfo(PlayerProgressHandler.LoadProgress(Key));
    }

    public void SetProgress()
    {
        var progress = PlayerProgressHandler.LoadProgress(Key);
        progress.key = numberInProgress;
        CurrentProgress.CurrentProgressInstance = progress;
        SceneLoaderCall.LoadScene();
    }

    public void DisplayInfo(Progress progress) 
    {
        if (progress == null)
            return;
        textLevel.text = "Progress: "+progress.level.ToString();
    }
    private string Key => KeyStorage.ProgressSufix + numberInProgress;

}
