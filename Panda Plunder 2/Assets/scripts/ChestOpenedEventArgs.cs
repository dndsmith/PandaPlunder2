using System;

// Game 2

/*
 *  Event data about which chest has been opened.
 *  Used by ChestInteractable for the ChestOpened event.
 */

public class ChestOpenedEventArgs : EventArgs
{
    public ChestInteractable chest { get; set; }
}
