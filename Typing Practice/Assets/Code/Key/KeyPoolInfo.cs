using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Key Pool", menuName = "Create Key Pool")]
public class KeyPoolInfo : ScriptableObject
{
    [field:SerializeField] public KeyPool pool { get; private set; } = null;
}
