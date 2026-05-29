using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace CyberSecurityBotGUI
{
    public partial class MainWindow : Window
    {
        string userName = "";
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            BotReply("Hello! What is your name?");
        }

        private void BotReply(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("Bot: " + message)));
        }

        private void UserMessage(string message)
        {
            rtbChat.Document.Blocks.Add(
                new Paragraph(new Run("You: " + message)));
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = txtUserInput.Text.ToLower();

            UserMessage(input);

            // Name Memory
            if (userName == "")
            {
                if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    userName = input;
                    BotReply("Nice to meet you, " + userName + "!");
                }
                else
                {
                    BotReply("Please enter a valid name.");
                }

                txtUserInput.Clear();
                return;
            }

            // Password
            if (input.Contains("password"))
            {
                string[] responses =
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across accounts.",
                    "Use a password manager for better security."
                };

                BotReply(responses[random.Next(responses.Length)]);
            }

            // Phishing
            else if (input.Contains("phishing"))
            {
                string[] responses =
                {
                    "Do not click suspicious links.",
                    "Always verify the sender email address.",
                    "Phishing emails often create urgency or fear."
                };

                BotReply(responses[random.Next(responses.Length)]);
            }

            // Scam
            else if (input.Contains("scam"))
            {
                BotReply("Never share banking details with strangers online.");
            }

            // Privacy
            else if (input.Contains("privacy"))
            {
                BotReply("Review your social media privacy settings regularly.");
            }

            // Sentiment Detection
            else if (input.Contains("worried") || input.Contains("scared"))
            {
                BotReply("It's okay to be cautious. Cyber awareness helps keep you safe.");
            }

            else if (input.Contains("happy"))
            {
                BotReply("Glad to hear that! Stay cyber smart.");
            }

            // Help
            else if (input.Contains("help"))
            {
                BotReply("I can help with passwords, phishing, scams, and privacy.");
            }

            // Exit
            else if (input.Contains("exit"))
            {
                Application.Current.Shutdown();
            }

            else
            {
                BotReply("I do not understand. Type help for options.");
            }

            txtUserInput.Clear();
        }
    }
}