using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace POE_PART_1
{
    public class Storing
    {//constructor
        public Storing()
        {
            // Displays the welcome message
            Console.WriteLine("__________________________________________________________________________________________\n Welcome to The Cyber Security AI \n__________________________________________________________________________________________");

            Console.ForegroundColor = ConsoleColor.Blue;

            // Prompts user for their name
            Console.WriteLine("AI BOT - Please Enter your Name: ");
            string User_Name;
            string User_Question;

            // Lists to store responses and ignored words
            ArrayList response = new ArrayList();
            ArrayList wordIgnor = new ArrayList();

            // Fills the response and ignored words lists
            Store_Bot_Response(response);
            words_Ignore(wordIgnor);

            // Keeps asking for the user's name until a valid name is provided
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("User - ");
                User_Name = Console.ReadLine();

            } while (!Validate_UserName(User_Name));

            Console.ResetColor();

            // Greets the user and asks for a question
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI BOT - nice to meet you " + User_Name);
            Console.WriteLine("AI BOT - Please Enter a Question Related to cyber Security Or enter (exit,bye,stop) to exit.");

            // Keeps taking user questions until an exit command is given
            do
            {
                //Loops to continuously take user questions until an exit word is entered
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(User_Name + " - ");
                User_Question = Console.ReadLine();

                // Check if the user wants to exit
                if (Exit_AI(User_Question, User_Name))
                {
                    break;
                }
                else if (Validate_UserQuestion(User_Question))
                {
                    // Processes the question to find a relevant response
                    Split_Search(response, wordIgnor, User_Question);
                }

            } while (true);
        }

        // Stores relevant responses related to cybersecurity
        public void Store_Bot_Response(ArrayList Bot_Response)
        {
            Bot_Response.Add("Cybersecurity. It is the practice of protecting systems, networks, and data from digital attacks, unauthorized access, and damage.");
            Bot_Response.Add("Phishing. A scam where attackers trick you into revealing sensitive information by pretending to be a trusted entity.");
            Bot_Response.Add("Malware. Malicious software designed to damage or gain unauthorized access to a system, including viruses, worms, and trojans.");
            Bot_Response.Add("Ransomware. A type of malware that locks your files and demands payment to unlock them. Never pay the ransom!");
            Bot_Response.Add("Firewall. Blocks unauthorized access to your network, keeping your data safe from cyber threats.");
            Bot_Response.Add("VPN. Encrypts your internet traffic, hiding your identity and securing your connection.");
            Bot_Response.Add("Hacking. Can be ethical or malicious. Always secure your accounts to prevent unauthorized access.");
            Bot_Response.Add("Two-factor authentication. Adds an extra layer of security by requiring a second verification step.");
            Bot_Response.Add("Passwords. Need to be protected at all times. Use strong, unique ones and never share them.");
        }

        // Stores words that should be ignored when analyzing the user's question
        public void words_Ignore(ArrayList ignore)
        {
            ignore.Add("tell");
            ignore.Add("what");
            ignore.Add("is");
            ignore.Add("me");
            ignore.Add("does");
            ignore.Add("why");
            ignore.Add("how");
            ignore.Add("a");
            ignore.Add("work");
        }

        // Validates that the user has entered an empty name
        private bool Validate_UserName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI BOT: Please enter a valid name, name cannot be empty.");
                return false;
            }
            return true;
        }

        // Validates that the user has entered a non-empty question
        private bool Validate_UserQuestion(string question)
        {
            // Checks if input is empty or too short
            if (string.IsNullOrEmpty(question) || question.Trim().Length < 3) 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI BOT: Please enter a valid question.");
                return false;
            }
            return true;
        }

        // Processes the user's question by removing ignored words and searching for a relevant response
        private void Split_Search(ArrayList response, ArrayList ignore, string question)
        {
            // Convert the question to lowercase and split it into individual words
            string[] filtered_q = question.ToLower().Split(' ');
            ArrayList correct_filtered = new ArrayList();
            bool found = false;

            // Go over through each word in the question and filter out ignored words
            foreach (string word in filtered_q)
            {
                if (!ignore.Contains(word)) // If the word is not in the ignore list, add it to the filtered list
                {
                    correct_filtered.Add(word);
                    // Set found to true, meaning at least one useful word was found
                    found = true;
                }
            }

            if (found) // If at least one relevant word remains after filtering
            {
                bool responseFound = false;

                // Iterate through the stored bot responses to find a matching keyword
                foreach (string res in response)
                {
                    string[] responseParts = res.Split('.'); // Split response at the period to separate keyword and description
                    if (responseParts.Length > 1)
                    {
                        string keyword = responseParts[0].Trim().ToLower(); // Extract and normalize the keyword
                        string description = responseParts[1].Trim(); // Extract the corresponding response description

                        // Compare each filtered word with the stored response keywords
                        foreach (string word in correct_filtered)
                        {
                            if (keyword.Contains(word)) // If a keyword match is found
                            {
                                Console.WriteLine("AI BOT - " + description); // Print the response related to the keyword
                                Console.WriteLine("AI BOT - Let me know if you need further assistance or enter (exit/stop) to exit.");
                                responseFound = true;
                                break; // Stop checking further if a match is found
                            }
                        }
                    }
                }

                // If no matching response is found, inform the user
                if (!responseFound)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("AI BOT - I couldn't find a relevant answer. Try asking differently.");
                    Console.ResetColor();
                }
            }
            else // If the entire question consists of ignored words
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AI BOT - Please ask something related to cybersecurity.");
                Console.ResetColor();
            }
        }


        // Checks if the user entered an exit command
        public bool Exit_AI(string question, string nameofUser)
        {
            ArrayList stop_words = new ArrayList { "stop", "exit", "goodbye", "bye" };

            foreach (string s in stop_words)
            {
                if (question.ToLower().Contains(s))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("__________________________________________________________________________________________");
                    Console.WriteLine("AI BOT: Goodbye " + nameofUser + " I hope I was able to help, looking forward to helping you again");
                    Console.WriteLine("__________________________________________________________________________________________");
                    return true;
                }
            }
            return false;
        }
    }
}
