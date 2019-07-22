using System;

public class ChestOpenedEventArgs : EventArgs
{
    public ChestInteractable chest { get; set; }
}
