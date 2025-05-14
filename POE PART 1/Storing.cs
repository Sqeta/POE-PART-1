using System;
using System.Collections.Generic;

namespace POE_PART_1
{
    public class Storing
    {
        memory_recal memory = new memory_recal();
        // Constructor that runs the chatbot
        public Storing()
        {
            Console.WriteLine("******************************************************************************************\n Welcome to The Cyber Security AI \n******************************************************************************************");

            // Set the console color for AI prompts
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("AI BOT - Please Enter your Name: ");
            string User_Name;
            string User_Question= string.Empty;

            // Lists to store possible responses and ignored words
            List<string> response = new List<string>();
            List<string> wordIgnor = new List<string>();

            // Fill responses and ignored words
            Store_Bot_Response(response);
            words_Ignore(wordIgnor);

            // Ask for user's name and validate it
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("User - ");
                User_Name = Console.ReadLine();
            } while (!Validate_UserName(User_Name));

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI BOT - nice to meet you " + User_Name);
            Console.WriteLine("AI BOT - Please Enter a Question Related to cyber Security Or enter (exit,bye,stop) to exit.");


            // Memory Recall Check
            
            string previousInterest = memory.DisplayMemory("interest");
            if (!string.IsNullOrEmpty(previousInterest))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"AI BOT - Last time, you were interested in: {previousInterest}. Would you like us to continue from where we left off? (yes/no)");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("User - ");
                string User_Response = Console.ReadLine();
                Console.ResetColor();

                if (User_Response.ToLower() == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"AI BOT - Alright! Here is what you wanted to know more about: {previousInterest}");
                    Console.ResetColor();
                }
            }
            // Loop until the user exits
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(User_Name + " - ");
                User_Question = Console.ReadLine();

                // Check if user wants to exit
                if (Exit_AI(User_Question, User_Name))
                {
                    break;
                }
                // Validate the question
                else if (Validate_UserQuestion(User_Question))
                {
                    // Detect sentiment in the user's question
                    string sentiment = DetectSentiment(User_Question);
                    AdjustResponseBasedOnSentiment(sentiment);

                    // Try to match a keyword from the filtered question
                    bool responseMatched = Split_Search(response, wordIgnor, User_Question);

                    // If no keyword was matched, try providing a random tip
                    if (!responseMatched)
                    {
                        Provide_Random_Response(User_Question);
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("AI BOT - Would you like me to remember this topic for next time? (yes/no): ");
                    string remember = Console.ReadLine();
                    Console.ResetColor();

                    if (remember.ToLower() == "yes")
                    {
                        memory.StoreMemory("interest", User_Question);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("AI BOT - Got it! I'll remember that for next time.");
                        Console.ResetColor();
                    }

                }



            } while (true); // Infinite loop until "exit" command
        }

        // Detect simple sentiments like "worried", "curious", "frustrated"
        private string DetectSentiment(string question)
        {
            string lowerQuestion = question.ToLower();

            if (lowerQuestion.Contains("worried") || lowerQuestion.Contains("concerned"))
            {
                return "worried";
            }
            else if (lowerQuestion.Contains("curious"))
            {
                return "curious";
            }
            else if (lowerQuestion.Contains("frustrated") || lowerQuestion.Contains("confused"))
            {
                return "frustrated";
            }
            else
            {
                return "neutral"; // Default to neutral sentiment
            }
        }

        // Adjust chatbot's response based on detected sentiment
        private void AdjustResponseBasedOnSentiment(string sentiment)
        {
            if (sentiment == "worried")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("AI BOT - I understand you're worried. Cybersecurity can be overwhelming, but don't worry! I'm here to help you.");
                Console.ResetColor();
            }
            else if (sentiment == "curious")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("AI BOT - Great to see you're curious! Ask away, and I'll provide you with all the information you need about cybersecurity.");
                Console.ResetColor();
            }
            else if (sentiment == "frustrated")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("AI BOT - It sounds like you're feeling frustrated. I know cybersecurity can be complex, but I'm here to guide you step by step.");
                Console.ResetColor();
            }

        }

        // Store a list of static bot responses
        public void Store_Bot_Response(List<string> Bot_Response)
        {
            Bot_Response.Add("Cybersecurity. It is the practice of protecting systems, networks, and data from digital attacks, unauthorized access, and damage.");
            Bot_Response.Add("Phishing. A scam where attackers trick you into revealing sensitive information by pretending to be a trusted entity.");
            Bot_Response.Add("Malware. Malicious software designed to damage or gain unauthorized access to a system, including viruses, worms, and trojans.");
            Bot_Response.Add("Ransomware. A type of malware that locks your files and demands payment to unlock them. Never pay the ransom!");
            Bot_Response.Add("Firewall. Blocks unauthorized access to your network, keeping your data safe from cyber threats.");
            Bot_Response.Add("VPN. Encrypts your internet traffic, hiding your identity and securing your connection.");
            Bot_Response.Add("Hacking. Can be ethical or malicious, always secure your accounts to prevent unauthorized access.");
            Bot_Response.Add("Two factor authentication. Adds an extra layer of security by requiring a second verification step.");
            Bot_Response.Add("Passwords. Need to be protected at all times, Use strong, unique ones and never share them.");
        }

        // Store common ignored words (used for filtering questions)
        public void words_Ignore(List<string> ignore)
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

        // Check if name is valid
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

        // Check if question is valid
        private bool Validate_UserQuestion(string question)
        {
            if (string.IsNullOrEmpty(question) || question.Trim().Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI BOT: Please enter a valid question.");
                return false;
            }
            return true;
        }

        // Search for matching keywords and respond
        private bool Split_Search(List<string> response, List<string> ignore, string question)
        {
            string[] filtered_q = question.ToLower().Split(' ');
            List<string> correct_filtered = new List<string>();
            bool found = false;

            foreach (string word in filtered_q)
            {
                if (!ignore.Contains(word))
                {
                    correct_filtered.Add(word);
                    found = true;
                }
            }

            if (!found || correct_filtered.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AI BOT - Your question seems unclear or unrelated to cybersecurity. Please try asking a valid question.");
                Console.ResetColor();
                return true;
            }

            bool responseFound = false;

            foreach (string res in response)
            {
                string[] responseParts = res.Split('.');
                if (responseParts.Length > 1)
                {
                    string keyword = responseParts[0].Trim().ToLower();
                    string description = responseParts[1].Trim();

                    foreach (string word in correct_filtered)
                    {
                        if (keyword.Contains(word))
                        {
                            Console.WriteLine("AI BOT - " + description);
                            Console.WriteLine("AI BOT - Let me know if you need further assistance or enter (exit/stop) to exit.");
                            responseFound = true;
                            break;
                        }
                    }
                }
                if (responseFound) break;
            }

            if (!responseFound)
            {
                // Check if gibberish or totally off-topic
                bool matchedTopic = false;
                string lowerQ = question.ToLower();
                List<string> knownTopics = new List<string> {
                    "cybersecurity", "phishing", "malware", "firewall", "ransomware",
                    "vpn", "hacking", "passwords", "authentication", "encryption",
                    "spyware", "data breach", "social engineering"
                };

                foreach (string topic in knownTopics)
                {
                    if (lowerQ.Contains(topic))
                    {
                        matchedTopic = true;
                        break;
                    }
                }

                if (!matchedTopic)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("AI BOT - Sorry, I couldn’t understand your question. Please ask something related to cybersecurity.");
                    Console.ResetColor();
                    return true; // Prevent random response
                }

                Provide_Random_Response(question); // fallback
            }

            return true;
        }

        // Provide a random response if no keyword matched
        private void Provide_Random_Response(string question)
        {
            // Dictionary of topics and tips
            Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
            {
                { "encryption", new List<string>
                {
                    "Encryption protects your data by converting it into unreadable code without a decryption key.",
                    "Use end-to-end encryption when communicating sensitive information online.",
                    "Strong encryption methods help prevent hackers from stealing private data.",
                    "Always encrypt sensitive files before storing or transferring them."
                }},
                { "passwords", new List<string>
                {
                    "Create strong passwords using a mix of letters, numbers, and symbols.",
                    "Avoid using the same password across multiple accounts.",
                    "Use a password manager to keep track of your unique passwords safely.",
                    "Change your passwords regularly to reduce the risk of compromise."
                }},
                { "spyware", new List<string>
                {
                    "Spyware secretly monitors your activity and steals information without your consent.",
                    "Avoid clicking on suspicious links or pop-ups to prevent spyware infections.",
                    "Run regular scans with anti-spyware tools to detect unwanted programs.",
                    "Keep your software updated to block spyware from exploiting old vulnerabilities."
                }},
                { "social engineering", new List<string>
                {
                    "Social engineering tricks people into giving up confidential information.",
                    "Be cautious of unexpected calls or messages requesting sensitive data.",
                    "Verify identities before sharing personal or financial information.",
                    "Training users to recognize manipulation tactics can reduce social engineering risks."
                }},
                { "data breach", new List<string>
                {
                    "A data breach exposes sensitive information to unauthorized individuals.",
                    "Limit the amount of personal data you share online to reduce breach impact.",
                    "Enable account alerts so you're notified quickly after a breach.",
                    "Regularly check if your credentials have been leaked using tools like Have I Been Pwned."
                }}
            };

            // Loop through dictionary keys to find a match in the user's question
            foreach (var keyword in keywordResponses.Keys)
            {
                if (question.ToLower().Contains(keyword))
                {
                    Random rand = new Random();
                    List<string> responses = keywordResponses[keyword];
                    string randomResponse = responses[rand.Next(responses.Count)];

                    // Show the random tip
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("AI BOT - " + randomResponse);
                    Console.ResetColor();
                    break; // Only one response should be shown
                }
            }
        }

        // Exit logic — returns true if user wants to stop
        public bool Exit_AI(string question, string nameofUser)
        {
            List<string> stop_words = new List<string> { "stop", "exit", "goodbye", "bye" };

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
