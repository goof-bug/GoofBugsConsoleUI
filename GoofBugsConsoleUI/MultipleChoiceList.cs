using System;
using System.Collections.Generic;
using System.Text;

namespace GoofBugsConsoleUI
{
    public class MultipleChoiceList
    {
        string[] choices;

        char leftCharacter = '>';
        char rightCharacter = '<';

        bool escapable;
        public MultipleChoiceList(string[] _choices, bool _escapable)
        {
            choices = _choices;

            escapable = _escapable;
        }

        public MultipleChoiceList(string[] _choices, bool _escapable, char _leftCharacter, char _rightCharacter)
        {
            choices = _choices;

            escapable = _escapable;

            leftCharacter = _leftCharacter;
            rightCharacter = _rightCharacter;
        }

        public string InitiateSelection()
        {
            bool foobar = false;
            int currentSelection = 0;

            while (!foobar)
            {
                Console.Clear();

                for(int i = 0; i < choices.Length; i++)
                {
                    if(i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;

                        Console.Write(leftCharacter);

                        Console.Write(choices[i]);

                        Console.WriteLine(rightCharacter + "\n");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("-" + choices[i]+ "\n");
                    }
                }

                ConsoleKey keyPress = Console.ReadKey().Key;

                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        if (currentSelection != 0) currentSelection--;
                        //currentSelection--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelection != choices.Length - 1) currentSelection++;
                        //currentSelection++;
                        break;
                    case ConsoleKey.Enter:
                        return choices[currentSelection];
                    case ConsoleKey.Escape:
                        if (escapable) return null;
                        break;
                    default:
                        break;
                }
            }
            return null;
        }
    }
}