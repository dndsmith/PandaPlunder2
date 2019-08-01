using System;

// Game 2

/*
 *  Used by ChestInteractable for the ChestOpened event.
 */

public class ChestOpenedEventArgs : EventArgs
{
    public ChestInteractable chest { get; set; }
}
