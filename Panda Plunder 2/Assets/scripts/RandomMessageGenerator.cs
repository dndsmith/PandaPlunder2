using UnityEngine;
using UnityEngine.UI;
using System;

// Game 2

/*
 *  Generates a random message (e.g. the title screen).
 *  That is, given an array of strings, it will return one of the strings randomly from that array.
 */

public class RandomMessageGenerator
{
    private static System.Random rand = new System.Random();

    public static string GenerateRandomMessage(string[] options)
    {
        return options[rand.Next(options.Length)];
    }
}
