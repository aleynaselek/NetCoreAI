﻿using System.Speech.Synthesis; 

class Program
{
    static void Main(string[] args)
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

        speechSynthesizer.Volume = 100; // Ses seviyesi
        speechSynthesizer.Rate = -1; // Hızı ayarla

        Console.Write("Metni Girin: ");
        string input;
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            speechSynthesizer.Speak(input);
        }

        Console.ReadLine();
    }
}