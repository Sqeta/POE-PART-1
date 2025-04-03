Cybersecurity AI Chatbot

Cybersecurity AI Chatbot built using C# for interactive, real-time communication.
The chatbot provides cybersecurity-related information and answers user questions.
Incorporates a voice greeting and displays a logo in ASCII art at the start.
Responds to questions about various cybersecurity topics such as phishing, ransomware, malware, etc.
Allows the user to exit the conversation using simple commands like exit, bye, or stop.
Audio Greeting: Plays an audio message to greet the user when the program starts.
Logo Display: Loads and displays the logo image in ASCII format on the console.

Chatbot Q&A Interaction:
Handles cybersecurity-related queries from users.
Provides pre-stored responses for common questions related to cyber threats and security practices.
Handles questions about phishing, malware, firewalls, VPNs, and much more.
Exit Commands: The user can exit the conversation by typing any of the following commands, exit, bye, stop

Voice Greeting
The Voice Greeting class is responsible for playing an audio file to greet the user when the application starts.
The application looks for the file in the root directory and plays it meaning the program will wait until the audio finishes playing.

Logo Display
The Logo class converts the Cyber Security image into ASCII characters and displays it on the console.
It resizes the image and adjusts the color output using the Console class to show the logo as an ASCII art representation in the terminal.

Chatbot Interaction
The Storing class manages user interaction. It:
Prompts the user for their name and validates it.
Asks the user to input a cybersecurity-related question.
Matches the question against a pre-defined list of responses related to common cybersecurity topics.
Filters out unnecessary words (e.g., "what", "is", "me") to improve the accuracy of the response.
Continues the conversation until the user exits by typing one of the exit commands.

User Question Processing
The user enters a question, and the chatbot removes common stop words (such as "what", "is", "me") from the question.
It checks the remaining keywords against a list of stored responses about cybersecurity.
If a relevant response is found, it displays the answer in the console.
If no relevant response is found, the chatbot asks the user to rephrase their question or provide additional details.

Exit Commands
The chatbot listens for commands like exit, bye, or stop.
If one of these commands is detected, the chatbot politely ends the conversation and exits the program.


![Screenshot 2025-04-03 211758](https://github.com/user-attachments/assets/cebb59bf-f155-408d-be28-9d83aa08dcac)


![Screenshot 2025-04-03 213116](https://github.com/user-attachments/assets/2a4a2ca1-4533-4b0a-a1b5-1555a50f928b)


![Screenshot 2025-04-03 213226](https://github.com/user-attachments/assets/16afa99c-1f7a-40de-8b88-59a09221384b)


![Screenshot 2025-04-03 213821](https://github.com/user-attachments/assets/ab1dddbc-3d77-4d2b-8a42-9ae5124fc594)


