using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGame : MonoBehaviour {

    [SerializeField] Text textComponent;

    public Image imageComponent;

    [SerializeField] Stately startingState;

    Stately currentState;

    private void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStory();
        imageComponent.sprite = currentState.GetBackground();
    }

    private void ManageState()
    {
        var nextState = currentState.GetNextState();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextState[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = nextState[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = nextState[2];
        }
        textComponent.text = currentState.GetStory();
    }

}
