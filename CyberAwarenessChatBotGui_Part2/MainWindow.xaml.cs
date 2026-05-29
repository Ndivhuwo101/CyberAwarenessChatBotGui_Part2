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

        // Random Generator
        Random random = new Random();

        // Speech
        SpeechSynthesizer speaker = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();

            speaker.SpeakAsync("Hello! Welcome to the Cyber Security Awareness Bot.");

            BotReply("Hello! What is your name?");
        }

        // Bot Response
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

        // Main Chat Logic
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = txtUserInput.Text.ToLower().Trim();

            // Empty Input Handling
            if (string.IsNullOrWhiteSpace(input))
            {
                BotReply("Please type a message.");
                return;
            }

            UserMessage(input);

            // =========================
            // NAME HANDLING
            // =========================
            if (userName == "")
            {
                if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    userName = input;

                    BotReply("Nice to meet you, " + userName + "!");
                    BotReply("Which cybersecurity topic would you like help with today?");
                }
                else
                {
                    BotReply("Please enter a valid name using letters only.");
                }

                txtUserInput.Clear();
                return;
            }

            // =========================
            // PASSWORD KEYWORDS
            // =========================
            if (input.Contains("password") ||
                input.Contains("passcode") ||
                input.Contains("login") ||
                input.Contains("credential") ||
                input.Contains("authentication"))
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
            // PHISHING KEYWORDS
            // =========================
            else if (input.Contains("phishing") ||
                     input.Contains("fake email") ||
                     input.Contains("spam") ||
                     input.Contains("scam link") ||
                     input.Contains("malicious link"))
            {
                favouriteTopic = "phishing awareness";
                lastTopic = "phishing";

                string[] responses =
                {
                    "Always verify suspicious emails before clicking links.",
                    "Do not download attachments from unknown senders.",
                    "Phishing attacks often create urgency or fear."
                };

                BotReply(responses[random.Next(responses.Length)]);
            }

            // =========================
            // MALWARE KEYWORDS
            // =========================
            else if (input.Contains("virus") ||
                     input.Contains("malware") ||
                     input.Contains("trojan") ||
                     input.Contains("worm") ||
                     input.Contains("spyware") ||
                     input.Contains("ransomware"))
            {
                favouriteTopic = "malware protection";
                lastTopic = "malware";

                BotReply("Install trusted antivirus software and keep your system updated.");
            }

            // =========================
            // PRIVACY KEYWORDS
            // =========================
            else if (input.Contains("privacy") ||
                     input.Contains("tracking") ||
                     input.Contains("data collection") ||
                     input.Contains("personal data") ||
                     input.Contains("cookies"))
            {
                favouriteTopic = "privacy";
                lastTopic = "privacy";

                BotReply("Review your privacy settings regularly and avoid oversharing online.");
            }

            // =========================
            // SCAM KEYWORDS
            // =========================
            else if (input.Contains("scam") ||
                     input.Contains("fraud") ||
                     input.Contains("fake website") ||
                     input.Contains("money scam") ||
                     input.Contains("online scam"))
            {
                favouriteTopic = "online scams";
                lastTopic = "scam";

                BotReply("Never share banking details or OTP codes with strangers online.");
            }

            // =========================
            // HACKING KEYWORDS
            // =========================
            else if (input.Contains("hack") ||
                     input.Contains("hacker") ||
                     input.Contains("breach") ||
                     input.Contains("cyber attack") ||
                     input.Contains("exploit"))
            {
                favouriteTopic = "hacking awareness";
                lastTopic = "hacking";

                BotReply("Keep software updated to reduce hacking risks.");
            }

            // =========================
            // WIFI KEYWORDS
            // =========================
            else if (input.Contains("wifi") ||
                     input.Contains("public wifi") ||
                     input.Contains("network") ||
                     input.Contains("router") ||
                     input.Contains("hotspot"))
            {
                favouriteTopic = "network security";
                lastTopic = "wifi";

                BotReply("Avoid entering sensitive information on public Wi-Fi networks.");
            }

            // =========================
            // SOCIAL MEDIA KEYWORDS
            // =========================
            else if (input.Contains("facebook") ||
                     input.Contains("instagram") ||
                     input.Contains("tiktok") ||
                     input.Contains("social media") ||
                     input.Contains("twitter"))
            {
                favouriteTopic = "social media safety";
                lastTopic = "social";

                BotReply("Use private account settings and avoid accepting unknown friend requests.");
            }

            // =========================
            // DEVICE SECURITY KEYWORDS
            // =========================
            else if (input.Contains("phone") ||
                     input.Contains("laptop") ||
                     input.Contains("device") ||
                     input.Contains("computer") ||
                     input.Contains("tablet"))
            {
                favouriteTopic = "device security";
                lastTopic = "device";

                BotReply("Enable screen locks and keep your devices updated.");
            }

            // =========================
            // BANKING KEYWORDS
            // =========================
            else if (input.Contains("bank") ||
                     input.Contains("banking") ||
                     input.Contains("credit card") ||
                     input.Contains("debit card") ||
                     input.Contains("payment"))
            {
                favouriteTopic = "banking security";
                lastTopic = "banking";

                BotReply("Monitor bank activity regularly and never share PINs online.");
            }

            // =========================
            // EMAIL KEYWORDS
            // =========================
            else if (input.Contains("email") ||
                     input.Contains("inbox") ||
                     input.Contains("attachment") ||
                     input.Contains("gmail") ||
                     input.Contains("outlook"))
            {
                favouriteTopic = "email security";
                lastTopic = "email";

                BotReply("Avoid opening attachments from unknown senders.");
            }

            // =========================
            // MEMORY RECALL
            // =========================
            else if (input.Contains("remember") ||
                     input.Contains("what do i like"))
            {
                if (favouriteTopic != "")
                {
                    BotReply(userName + ", your favourite topic is " + favouriteTopic + ".");
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
                    BotReply("Enable two-factor authentication for extra password protection.");
                }
                else if (lastTopic == "phishing")
                {
                    BotReply("Phishing sites can look almost identical to legitimate websites.");
                }
                else if (lastTopic == "malware")
                {
                    BotReply("Avoid downloading files from untrusted websites.");
                }
                else if (lastTopic == "privacy")
                {
                    BotReply("Use strong privacy settings on all online accounts.");
                }
                else if (lastTopic == "wifi")
                {
                    BotReply("VPN services can improve safety on public Wi-Fi.");
                }
                else
                {
                    BotReply("Please tell me which topic you want to learn more about.");
                }
            }

            // =========================
            // SENTIMENT DETECTION
            // =========================
            else if (input.Contains("worried") ||
                     input.Contains("scared") ||
                     input.Contains("nervous"))
            {
                BotReply("It's understandable to feel concerned. Cybersecurity awareness helps you stay protected online.");
            }

            else if (input.Contains("frustrated") ||
                     input.Contains("angry"))
            {
                BotReply("Cybersecurity can feel overwhelming, but learning simple habits makes a big difference.");
            }

            else if (input.Contains("curious") ||
                     input.Contains("interested"))
            {
                BotReply("That's great! Learning cybersecurity is an excellent way to stay safe online.");
            }

            else if (input.Contains("happy") ||
                     input.Contains("good"))
            {
                BotReply("Glad to hear that! Keep practicing safe online habits.");
            }

            // =========================
            // HELP
            // =========================
            else if (input.Contains("help"))
            {
                BotReply("I can help with passwords, phishing, malware, scams, privacy, banking, Wi-Fi, and device security.");
            }

            // =========================
            // EXIT
            // =========================
            else if (input.Contains("exit") ||
                     input.Contains("quit") ||
                     input.Contains("bye"))
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
                    "I do not understand. Could you rephrase that?",
                    "Please ask about a cybersecurity topic.",
                    "Try asking about passwords, scams, privacy, malware, or phishing."
                };

                BotReply(unknownResponses[random.Next(unknownResponses.Length)]);
            }

            txtUserInput.Clear();
        }
    }
}