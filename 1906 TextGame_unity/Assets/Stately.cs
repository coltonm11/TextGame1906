using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stately")]

public class Stately : ScriptableObject {

    [TextArea(14, 10)] [SerializeField] string storyText;
    [SerializeField] Stately[] nextStates;

    public Material image;

    public string GetStory()
    {
        return storyText;
    }

    public Stately[] GetNextState()
    {
        return nextStates;
    }

}
