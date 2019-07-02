using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stately")]

public class Stately : ScriptableObject {

    [TextArea(14, 10)] [SerializeField] string storyText;

    [SerializeField] public bool WantsBartenderState;

    [SerializeField] public Stately finishedState;

    [SerializeField] Stately[] nextStates;

    [SerializeField] Sprite image;


    public string GetStory()
    {
        return storyText;
    }

    public Stately[] GetNextState()
    {
        return nextStates;
    }

    public Sprite GetBackground()
    {
        return image;
    }

}
