using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public int level = 0;
    [HideInInspector] public int key = 0;
    public bool ThisIsAppropiate(Progress other)
    {
        if (this.Equals(other))
            return true;

        var difference = Mathf.Abs(this.level - other.level);

        if (difference < 5)
            return true;
        return this.level > other.level;
    }
}
