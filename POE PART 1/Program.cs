using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates an instance of the Voice_Greeting class
            // This is for audio welcome message
            new Voice_Greeting() { };

            // Creates an instance of the Logo class
            // This is for displaying the logo 
            new Logo() { };

            // Creates an instance of the Storing class
            // This initializes the chatbot functionality for cybersecurity-related queries
            new Storing() { };

            new memory_recal(){ };
        }
    }
}
