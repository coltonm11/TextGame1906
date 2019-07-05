using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGame : MonoBehaviour {

    [SerializeField] int maxDrinks;

    [SerializeField] Text textComponent;
    [SerializeField] Text choicesTextComponent;
    [SerializeField] Image backgroundImageComponent;
    [SerializeField] Stately startingState;
    [SerializeField] Stately EndStateOne;

    [SerializeField] BartenderStates[] mainChoicesText;
    [SerializeField] Stately[] mainStates;

    Stately currentState;
    Stately[] secondaryStates;
    int numberOfChoicesAvailable;
    int numberOfDrinks;



    private void Start()
    {
        currentState = startingState;
        secondaryStates = currentState.GetAvailableStates();
        numberOfChoicesAvailable = secondaryStates.Length;
        backgroundImageComponent.sprite = currentState.GetBackground();
        numberOfDrinks = 0;
        UpdateStory();
    }

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("Alpha1")))
        {
            ManageState(0);
            //print("Alpha1");
        }
        if (Event.current.Equals(Event.KeyboardEvent("Alpha2")))
        {
            ManageState(1);
            //print("Alpha2");
        }
        if (Event.current.Equals(Event.KeyboardEvent("Alpha3")))
        {
            ManageState(2);
            //print("Alpha3");
        }
        if (Event.current.Equals(Event.KeyboardEvent("Alpha4")))
        {
            ManageState(3);
            //print("Alpha4");
        }
    }

    private void ManageState(int choiceNumber)
    {
        // End game in death
        if (numberOfDrinks == maxDrinks)
        {
            currentState = EndStateOne;
            UpdateStory();
            return;
        }

        // Story leg
        if (!currentState.callsBartender)
        {
            secondaryStates = currentState.GetAvailableStates();
            currentState = secondaryStates[choiceNumber];
        }

        // Back to barkeep
        else if (currentState.callsBartender)
        {
            currentState = mainStates[choiceNumber];

            if (mainStates[choiceNumber].finishedState != null)
            {
                mainStates[choiceNumber] = mainStates[choiceNumber].finishedState;
            }
        }

        UpdateStory();

    }

    public void UpdateStory()
    {

        if (!currentState.callsBartender)
        {
            textComponent.text = currentState.GetStoryText();
            choicesTextComponent.text = currentState.GetChoiceText();
        }

        else if (currentState.callsBartender)
        {
            textComponent.text = currentState.GetStoryText();
            choicesTextComponent.text = mainChoicesText[numberOfDrinks].GetBarkeepText();
            numberOfDrinks += 1;
        }

        backgroundImageComponent.sprite = currentState.GetBackground();

    }

}
