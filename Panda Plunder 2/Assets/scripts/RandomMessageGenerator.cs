﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class RandomMessageGenerator
{
    private static System.Random rand = new System.Random();

    public static string GenerateRandomMessage(string[] options)
    {
        return options[rand.Next(options.Length)];
    }
}