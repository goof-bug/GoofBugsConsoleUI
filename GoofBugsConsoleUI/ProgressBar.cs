using System;

namespace GoofBugsConsoleUI
{
    public class ProgressBar
    {
        /// The length of the progress bar in characters.
        int barLength;
        /// The inclusive maximum value of the value range. The minimum is always 0.
        int maxValue;
        /// The value that is used to calculate the full segments of the bar.
        float stepValue;

        /// The current value of the bar.
        int currentValue = 0;

        /// The string that represents the progressbar.
        string progressBar;

        /// The characters that represent the full and blank segments.
        char fullSegment = '█';
        char blankSegment = '░';

        /// The bool that determines if the decorative border is included in the progressBar string.
        bool border = false;

        /// <summary>
        /// Constructor for a new progress bar.
        /// </summary>
        /// <param name="_barLength">The length of the bar in characters.</param>
        /// <param name="_maxValue">The inclusive maximum value of the value range.</param>
        public ProgressBar(int _barLength, int _maxValue)
        {
            barLength = _barLength;
            maxValue = _maxValue;

            stepValue = maxValue / barLength;
        }

        /// <summary>
        /// Constructor for a new progress bar.
        /// </summary>
        /// <param name="_barLength">The length of the bar in characters.</param>
        /// <param name="_maxValue">The inclusive maximum value of the value range.</param>
        /// <param name="_border">The bool that determines if the decorative bordes is included.</param>
        public ProgressBar(int _barLength, int _maxValue, bool _border)
        {
            barLength = _barLength;
            maxValue = _maxValue;
            border = _border;

            stepValue = maxValue / barLength;
        }

        /// <summary>
        /// Constructor for a new progress bar.
        /// </summary>
        /// <param name="_barLength">The length of the bar in characters.</param>
        /// <param name="_maxValue">The inclusive maximum value of the value range.</param>
        /// <param name="_border">The bool that determines if the decorative bordes is included.</param>
        /// <param name="_fullSegment">The char that represents a full segment.</param>
        /// <param name="_blankSegment">The char that represents a blank segment.</param>
        public ProgressBar(int _barLength, int _maxValue, bool _border, char _fullSegment, char _blankSegment)
        {
            barLength = _barLength;
            maxValue = _maxValue;
            border = _border;

            fullSegment = _fullSegment;
            blankSegment = _blankSegment;

            // Calculate the stepValue.
            stepValue = maxValue / barLength;
        }

        /// <summary>
        /// Method for generating and returning a progress bar with the current value.
        /// </summary>
        /// <returns>a string that represents the current progress.</returns>
        public string GetProgressBarString()
        {
            UpdateProgressBar();
            return progressBar;
        }

        /// <summary>
        /// Method that calculates and returns the percentage of the currentValue and maxValue.
        /// </summary>
        /// <returns>a float between 0 and 100 that represents the percentage.</returns>
        public float GetPercentage()
        {
            return ((float)currentValue / (float)maxValue) * 100;
        }

        /// <summary>
        /// Sets the current value that the progress bar should represent.
        /// </summary>
        /// <param name="_currentValue">The value that should be set.</param>
        public void SetCurrentValue(int _currentValue)
        {
            // If current value is outside of the accepted range throw an exception, if it is assign the value.
            if (_currentValue < 0 || _currentValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("_currentValue", "currentValue must be greater or equal to zero and less or equal to maxValue.");
            }
            currentValue = _currentValue;
        }

        /// <summary>
        /// Method that generates a new progress bar from the current value.
        /// </summary>
        void UpdateProgressBar()
        {
            // Determine how many segments should be full.
            int barProgress = (int)(currentValue / stepValue);

            // Generate a new temporary string.
            string _progressBar = "";

            // Add the correct amount of full segments.
            for (int i = 0; i < barProgress; i++)
            {
                _progressBar += fullSegment;
            }

            // Pad the bar left to the desired bar length.
            _progressBar.PadRight(barLength, blankSegment);

            // If the border bool is set generate the border.
            if (border)
            {
                _progressBar += "┐\n└";
                for (int i = 0; i < barLength - 1; i++)
                {
                    _progressBar += "─";
                }
                _progressBar += "┘";
            }

            // Assign the temporary string to the real string.
            progressBar = _progressBar;
        }
    }
}
