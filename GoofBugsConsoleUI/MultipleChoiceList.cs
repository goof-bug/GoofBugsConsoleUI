using System;
using System.Collections.Generic;
using System.Text;

namespace GoofBugsConsoleUI
{
    /// <remarks>A class for creating and letting the user interacting with multiple choice lists.</remarks>
    public class MultipleChoiceList
    {
        string title;

        string[] choices;

        char leftCharacter = '>';
        char rightCharacter = '<';

        bool escapable;

        /// <summary>
        /// The counstructor for a new multiple choice list.
        /// </summary>
        /// <param name="_title">A string with the title/question that the user will be shown together with the choices.</param>
        /// <param name="_choices">A string array containing all the choices the user can choose from.</param>
        /// <param name="_escapable">A bool that decides if the user can use esc to escape out of the selection without making a choice.</param>
        public MultipleChoiceList(string _title, string[] _choices, bool _escapable)
        {
            title = _title;

            choices = _choices;

            escapable = _escapable;
        }

        /// <summary>
        /// The counstructor for a new multiple choice list.
        /// </summary>
        /// <param name="_title">A string with the title/question that the user will be shown together with the choices.</param>
        /// <param name="_choices">A string array containing all the choices the user can choose from.</param>
        /// <param name="_escapable">A bool that decides if the user can use esc to escape out of the selection without making a choice.</param>
        /// <param name="_leftCharacter">A char that will be printed to the left of the currently selected choice.</param>
        /// <param name="_rightCharacter">A char that will be printed to the right of the currently selected choice.</param>
        public MultipleChoiceList(string _title, string[] _choices, bool _escapable, char _leftCharacter, char _rightCharacter)
        {
            title = _title;

            choices = _choices;

            escapable = _escapable;

            leftCharacter = _leftCharacter;
            rightCharacter = _rightCharacter;
        }

        /// <summary>
        /// Method that starts a loop where the user can navigate and select a choice and then returns the result.
        /// </summary>
        /// <returns>a string with the choice the user choose, if the user escaped the selection this returns null.</returns>
        public string InitiateSelection()
        {
            bool selectionMade = false;

            // int that keeps track of the current selection.
            int currentSelection = 0;

            // Continue looping until the user has made a valid selection or escaped.
            while (!selectionMade)
            {
                Console.Clear();

                Console.WriteLine(title);

                //Write the choiches to the screen with the current selection highlighted.
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

                //Let the user navigate the selections.
                
                ConsoleKey keyPress = Console.ReadKey().Key;

                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        //Make sure the selection is within bounds.
                        if (currentSelection != 0) currentSelection--;
                        break;
                    case ConsoleKey.DownArrow:
                        //Make sure the selection is within bounds.
                        if (currentSelection != choices.Length - 1) currentSelection++;
                        break;
                    case ConsoleKey.Enter:
                        return choices[currentSelection];
                    case ConsoleKey.Escape:
                        //Only let the user escape if the list is configured as escapeable.
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