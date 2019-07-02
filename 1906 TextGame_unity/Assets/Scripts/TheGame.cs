using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGame : MonoBehaviour {

    [SerializeField] Text textComponent;

    [SerializeField] Image imageComponent;

    [SerializeField] Stately startingState;

    [SerializeField] BartenderStates[] BarTenderState;

    [SerializeField] Stately[] drinkStates;

    [SerializeField] Stately EndStateOne;

    Stately currentState;

    int numberOfDrinks;
    [SerializeField] int maxDrinks;


    private void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStory();
        imageComponent.sprite = currentState.GetBackground();
    }

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        if (!currentState.WantsBartenderState && numberOfDrinks < maxDrinks)
        {
            var nextState = currentState.GetNextState();
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                currentState = nextState[0];
                UpdateStory();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                currentState = nextState[1];
                UpdateStory();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                currentState = nextState[2];
                UpdateStory();
            }
        }

        else if (currentState.WantsBartenderState && numberOfDrinks < maxDrinks)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                currentState = drinkStates[0];
                if (drinkStates[0].finishedState != null)
                {
                    drinkStates[0] = drinkStates[0].finishedState;
                }
                UpdateStory();

            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                currentState = drinkStates[1];
                if (drinkStates[1].finishedState != null)
                {
                    drinkStates[1] = drinkStates[1].finishedState;
                }
                UpdateStory();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                currentState = drinkStates[2];
                if (drinkStates[2].finishedState != null)
                {
                    drinkStates[2] = drinkStates[2].finishedState;
                }
                UpdateStory();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                currentState = drinkStates[3];
                UpdateStory();
            }
        }

        if (numberOfDrinks >= maxDrinks)
        {
            currentState = EndStateOne;
            if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
            {
                UpdateStory();
            }
        }

    }

    public void UpdateStory()
    {
        if (!currentState.WantsBartenderState)
        {
            textComponent.text = currentState.GetStory();
        }
        else if (currentState.WantsBartenderState)
        {
            textComponent.text = currentState.GetStory() + GetBartenderText(numberOfDrinks);
        }

        imageComponent.sprite = currentState.GetBackground();

        print(numberOfDrinks);

    }

    public string GetBartenderText(int i)
    {
        i = numberOfDrinks;
        numberOfDrinks += 1;
        return BarTenderState[i].GetBarkeepText();
    }

}
