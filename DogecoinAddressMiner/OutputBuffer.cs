using System;
using System.Text;

internal class OutputBuffer
{
    private string[] buffer;
    private int currentIndex = 0;
    private int count = 0;
    private readonly object syncLock = new object(); // Lock object for thread safety

    public OutputBuffer(int size = 50)
    {
        buffer = new string[size];
    }

    /// <summary>
    /// Adds a line to the start of the buffer, removing the oldest if the buffer is full.
    /// </summary>
    /// <param name="line">The line to add to the buffer.</param>
    public void AddLine(string line)
    {
        lock (syncLock) // Lock to ensure thread safety
        {
            // If buffer is full, overwrite the oldest entry
            if (count == buffer.Length)
            {
                buffer[currentIndex] = line;
            }
            else
            {
                buffer[count] = line;
                count++;
            }

            // Move the current index to the next position, wrapping around if necessary
            currentIndex = (currentIndex + 1) % buffer.Length;
        }
    }

    /// <summary>
    /// Clears all lines from the buffer.
    /// </summary>
    public void Clear()
    {
        lock (syncLock) // Lock to ensure thread safety
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = null;
            }
            currentIndex = 0;
            count = 0;
        }
    }

    /// <summary>
    /// Returns all lines in the buffer concatenated into a single string.
    /// </summary>
    /// <returns>A string containing all buffered lines.</returns>
    public string GetText()
    {
        lock (syncLock) // Lock to ensure thread safety
        {
            StringBuilder result = new StringBuilder();

            // Start from the current position and go backwards through the buffer
            if (count > 0)
            {
                int index = (currentIndex + buffer.Length - 1) % buffer.Length;
                for (int i = 0; i < Math.Min(count, buffer.Length); i++)
                {
                    if (buffer[index] != null)
                    {
                        result.AppendLine(buffer[index]);
                    }
                    index = (index + buffer.Length - 1) % buffer.Length; // Move to the previous item
                }
            }

            return result.ToString();
        }
    }
}