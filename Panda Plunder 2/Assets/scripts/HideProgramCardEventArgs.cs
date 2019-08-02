using System;

// Game 2

/*
 *  Event data about the Program Card that was just hidden from the screen.
 *  Used for the HideProgramCard event in ProgramCardViewer.
 */

public class HideProgramCardEventArgs : EventArgs
{
    public ProgramCardInteractable programCard { get; set; }
}
