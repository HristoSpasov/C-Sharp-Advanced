﻿using _06.Custom_Enum_Attribute.Attributes;

namespace _06.Custom_Enum_Attribute.Enums
{
    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
}