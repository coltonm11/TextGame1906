using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BarkeeperState")]

public class BartenderStates : ScriptableObject
{

    [TextArea (10, 10)] public string BarkeepText;

    public string GetBarkeepText()
    {
        return BarkeepText;
    }

}
