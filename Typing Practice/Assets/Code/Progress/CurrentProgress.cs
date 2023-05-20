public static class CurrentProgress
{
    private static Progress currentProgress;
    public static Progress CurrentProgressInstance
    {
        get 
        {
            if (currentProgress == null)
                currentProgress = new Progress();
            return currentProgress;
        }
        set 
        {
            currentProgress = value;
        }
    }
    public static string Key => KeyStorage.ProgressSufix + currentProgress.key;
}
