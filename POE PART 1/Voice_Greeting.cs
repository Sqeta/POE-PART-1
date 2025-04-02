using System.IO;
using System.Media;
using System;

namespace POE_PART_1
{
    public class Voice_Greeting
    {
        // Constructor
        public Voice_Greeting()
        {

            //getting the app full location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            // Remove "bin\\Debug\\" from the path to get back to the main project directory
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //combine the paths 

            //try and catch to play the audio
            try
            {
                // Get the full directory where the application is running
                string full_path = Path.Combine(new_path, "voice greeting.wav");

                // Create a SoundPlayer object and load the audio file
                using (SoundPlayer theplayer = new SoundPlayer(full_path))
                {
                    // Play the audio file synchronously (program waits until the sound finishes playing)
                    theplayer.PlaySync();
                }

            }
            // If the file is missing or another error occurs, handle it
            catch (Exception error)
            {
                // Display the error message in the console
                Console.WriteLine(error.Message);
            }

        }

    }
}