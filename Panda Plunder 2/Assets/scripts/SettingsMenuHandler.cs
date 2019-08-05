using UnityEngine;
using UnityEngine.UI;

// Game 2
// NOT FINISHED

/*
 *  Handles interactions with the settings menu.
 *  TODO: If a setting is changed, it handles it by writing that change to the player's save file.
 */

public class SettingsMenuHandler : MainMenuHandler
{
    // index 0: movement dropdown
    // index 1: interact dropdown
    public Dropdown[] dropdowns;

    private int[] currentSelection = new int[2];

    // write to streaming assets, get from streaming assets
    private void Start()
    {
        //currentSelection = player saved data
    }

    private void Update()
    {
        if(dropdowns[0].value != currentSelection[0])
        {
            // write to streaming assets
            currentSelection[0] = dropdowns[0].value;
        }
        if (dropdowns[1].value != currentSelection[1])
        {
            // write to streaming assets
            currentSelection[1] = dropdowns[1].value;
        }
    }
}
