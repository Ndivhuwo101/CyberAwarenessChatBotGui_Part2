using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace CyberSecurityBotGUI
{
    public partial class MainWindow : Window
    {
        // Memory Variables
        string userName = "";
        string favouriteTopic = "";
        string lastTopic = "";

        // Random Response Generator
        Random random = new Random();

        // Speech Synthesizer
        SpeechSynthesizer speaker = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();

            // Voice Greeting
            speaker.SpeakAsync("Hello! Welcome to the Cyber Security Awareness Bot.");

            BotReply("Hello! What is your name?");
        }

        // Bot Message
        private void BotReply(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("Bot: " + message)));

            speaker.SpeakAsync(message);
        }

        // User Message
        private void UserMessage(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("You: " + message)));
        }

        // Send Button
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = txtUserInput.Text.ToLower().Trim();

            // Error Handling for Empty Input
            if (string.IsNullOrWhiteSpace(input))
            {
                BotReply("Please type a message.");
                return;
            }

            UserMessage(input);

            // =========================
            // NAME VALIDATION & MEMORY
            // =========================
            if (userName == "")
            {
                if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    userName = input;
                    BotReply("Nice to meet you, " + userName + "!");
                }
                else
                {
                    BotReply("Please enter a valid name using letters only.");
                }

                txtUserInput.Clear();
                return;
            }

            // =========================
            // PASSWORDS
            // =========================
            if (input.Contains("password"))
            {
                favouriteTopic = "password security";
                lastTopic = "password";

                string[] responses =
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across accounts.",
                    "Use a password manager for better security."
                };

                BotReply(responses[random.Next(responses.Length)]);
            }

            // =========================
            // PHISHING
            // =========================
            else if (input.Contains("phishing"))
            {
                favouriteTopic = "phishing awareness";
                lastTopic = "phishing";

                string[] responses =
                {
                    "Do not click suspicious links.",
                    "Always verify the sender email address.",
                    "Phishing emails often create urgency or fear."
                };

                BotReply(responses[random.Next(responses.Length)]);
            }

            // =========================
            // SCAMS
            // =========================
            else if (input.Contains("scam"))
            {
                favouriteTopic = "online scams";
                lastTopic = "scam";

                BotReply("Never share banking details with strangers online.");
            }

            // =========================
            // PRIVACY
            // =========================
            else if (input.Contains("privacy"))
            {
                favouriteTopic = "privacy";
                lastTopic = "privacy";

                BotReply("Great! I'll remember that you're interested in privacy. Review your account privacy settings regularly.");
            }

            // =========================
            // ONLINE SAFETY
            // =========================
            else if (input.Contains("safe"))
            {
                lastTopic = "safety";

                BotReply("Keep your software updated and avoid using public Wi-Fi for sensitive activities.");
            }

            // =========================
            // MEMORY RECALL
            // =========================
            else if (input.Contains("remember") ||
                     input.Contains("what do i like"))
            {
                if (favouriteTopic != "")
                {
                    BotReply(userName + ", you are interested in " + favouriteTopic + ".");
                }
                else
                {
                    BotReply("I have not learned your favourite cybersecurity topic yet.");
                }
            }

            // =========================
            // FOLLOW-UP QUESTIONS
            // =========================
            else if (input.Contains("tell me more") ||
                     input.Contains("more") ||
                     input.Contains("explain"))
            {
                if (lastTopic == "password")
                {
                    BotReply("You should also enable two-factor authentication for better password security.");
                }
                else if (lastTopic == "phishing")
                {
                    BotReply("Phishing attacks may use fake websites that look real.");
                }
                else if (lastTopic == "privacy")
                {
                    BotReply("Avoid sharing personal information publicly online.");
                }
                else if (lastTopic == "scam")
                {
                    BotReply("Online scams often promise quick money or prizes.");
                }
                else if (lastTopic == "safety")
                {
                    BotReply("Installing antivirus software can improve your online safety.");
                }
                else
                {
                    BotReply("Can you tell me which cybersecurity topic you want to know more about?");
                }
            }

            // =========================
            // SENTIMENT DETECTION
            // =========================
            else if (input.Contains("worried") ||
                     input.Contains("scared"))
            {
                BotReply("It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.");
            }

            else if (input.Contains("frustrated"))
            {
                BotReply("Cybersecurity can sometimes feel overwhelming, but learning small safety habits helps a lot.");
            }

            else if (input.Contains("curious"))
            {
                BotReply("Curiosity is great! Learning about cybersecurity helps protect your personal information.");
            }

            else if (input.Contains("happy"))
            {
                BotReply("Glad to hear that! Keep practicing safe online habits.");
            }

            // =========================
            // HELP
            // =========================
            else if (input.Contains("help"))
            {
                BotReply("I can help with passwords, phishing, scams, privacy, and online safety.");
            }

            // =========================
            // EXIT
            // =========================
            else if (input.Contains("exit"))
            {
                BotReply("Goodbye " + userName + "! Stay safe online.");

                Application.Current.Shutdown();
            }

            // =========================
            // UNKNOWN INPUTS
            // =========================
            else
            {
                string[] unknownResponses =
                {
                    "I'm not sure I understand. Could you rephrase that?",
                    "Can you give me more details?",
                    "Try asking about passwords, phishing, scams, or privacy."
                };

                BotReply(unknownResponses[random.Next(unknownResponses.Length)]);
            }

            // Clear TextBox
            txtUserInput.Clear();
        }
    }
}