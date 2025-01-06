using System.Text;
using static System.Net.Mime.MediaTypeNames;

using Lib.Dogecoin;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using QRCoder;
using System.Xml.Linq;

namespace DogecoinAddressMiner
{
    public partial class MainForm : Form
    {
        public const string HDPATH = "m/44'/3'/0'/0/0";

        OutputBuffer _outputBufffer = new OutputBuffer(50);

        LibDogecoinContext _ctx = LibDogecoinContext.Instance;

        private long addressCounter = 0;
        private Stopwatch stopwatch = new Stopwatch();
        private long lastCounter = 0;
        private DateTime lastUpdate = DateTime.UtcNow;

        private System.Threading.Timer timer;

        Process[] processes;

        char start0 = '*';
        char start1 = '*';
        char start2 = '*';
        char start3 = '*';
        char start4 = '*';

        char end0 = '*';
        char end1 = '*';
        char end2 = '*';
        char end3 = '*';

        public MainForm()
        {
            InitializeComponent();
        }

        readonly object minerLock = new object();
        bool mining = false;

        void StartMining()
        {
            OutputMessage("Starting Address Miners...");
            mining = true;
            addressCounter = 0;
            lastCounter = 0;
            stopwatch.Restart();
            lastUpdate = DateTime.UtcNow;

            startChar0.Enabled = false;
            startChar1.Enabled = false;
            startChar2.Enabled = false;
            startChar3.Enabled = false;
            startChar4.Enabled = false;


            endChar0.Enabled = false;
            endChar1.Enabled = false;
            endChar2.Enabled = false;
            endChar3.Enabled = false;

            string filter = start0.ToString() + start1 + start2 + start3 + start4 + end0 + end1 + end2 + end3;

            // Determine the number of processes based on core count
            int coreCount = Environment.ProcessorCount;

            // Get the directory of the current executable
            string exePath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string childMinerPath = Path.Combine(exePath, "DogeVanityChildMiner.exe");


            // Array to hold process info
            processes = new Process[coreCount];

            for (int i = 0; i < coreCount; i++)
            {
                processes[i] = new Process();
                processes[i].StartInfo.FileName = childMinerPath;
                processes[i].StartInfo.ArgumentList.Add(filter);
                processes[i].StartInfo.UseShellExecute = false;
                processes[i].StartInfo.RedirectStandardOutput = true;

                processes[i].StartInfo.RedirectStandardError = true;
                processes[i].StartInfo.CreateNoWindow = true;

                processes[i].ErrorDataReceived += (sender, e) =>
                {
                    Console.WriteLine(e.Data);
                };

                processes[i].OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        if (e.Data.StartsWith("Count:"))
                        {
                            long currentCount = long.Parse(e.Data.Substring(6));
                            addressCounter += currentCount;
                        }
                        else if (e.Data.StartsWith("Match:"))
                        {

                            string mnemonic = e.Data.Substring(6);
                            // Update match label or textbox here
                            // Example:
                            this.Invoke((MethodInvoker)delegate { UpdateMatchUI(mnemonic); });
                            
                        }
                    }
                };

                processes[i].Start();
                processes[i].BeginOutputReadLine();
            }

            // Here you might want to start a background thread or timer to calculate addresses per second
            // Example:
            timer = new System.Threading.Timer(UpdateAddressesPerSecond, null, 1000, 1000);
        }

        private void UpdateMatchUI(string mnemonic)
        {
            var masterKeys = LibDogecoinContext.Instance.GenerateHDMasterPubKeypairFromMnemonic(mnemonic);

            if (LibDogecoinContext.Instance.VerifyHDMasterPubKeyPair(masterKeys.privateKey, masterKeys.publicKey))
            {
                var address = LibDogecoinContext.Instance.GetDerivedHDAddressByPath(masterKeys.privateKey, HDPATH, false);
                FoundSolution(mnemonic, address);
            }
        }

        // Example method to update addresses per second
        private void UpdateAddressesPerSecond(object state)
        {
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                long rate = (long)((double)(addressCounter - lastCounter) / (stopwatch.Elapsed.TotalSeconds));

                stopwatch.Restart();
                lastCounter = addressCounter;

                if (rate > 1)
                {
                    var time = CalculateDifficulty() / rate;

                    if(time < TimeSpan.MaxValue.TotalSeconds)
                    {

                        var ts = TimeSpan.FromSeconds(time);

                        // Calculating components
                        int years = ts.Days / 365; // Assuming a year has 365 days for simplicity
                        int months = (ts.Days % 365) / 30; // Assuming a month has 30 days for simplicity
                        int days = ts.Days % 30;
                        int hours = ts.Hours;
                        int minutes = ts.Minutes;

                        // Invoking OutputMessage for each time component
                        this.Invoke((MethodInvoker)delegate {

                            lock (minerLock)
                            {
                                if (mining)
                                {
                                    ClearOutput();
                                    OutputMessage("Minutes: " + minutes);
                                    OutputMessage("Hours: " + hours);
                                    OutputMessage("Days: " + days);
                                    OutputMessage("Months: " + months);
                                    OutputMessage("Years: " + years);
                                    OutputMessage("On average, a match will found every:");
                                }

                            }
                        });
                    }
                    else
                    {

                        // Invoking OutputMessage for each time component
                        this.Invoke((MethodInvoker)delegate {
                            lock (minerLock)
                            {
                                if (mining)
                                {
                                    ClearOutput();
                                    OutputMessage("> " + TimeSpan.MaxValue.Days / 365 + " years");
                                    OutputMessage("On average, a match will found every:");
                                }

                            }
                        });
                    }


                }

                this.Invoke((MethodInvoker)delegate { speedLabel.Text = $"Addresses/Sec: {rate}"; });
            }
        }

        void StopMining()
        {
            lock (minerLock)
            {
                mining = false;

                startChar0.Enabled = true;
                startChar1.Enabled = true;
                startChar2.Enabled = true;
                startChar3.Enabled = true;
                startChar4.Enabled = true;


                endChar0.Enabled = true;
                endChar1.Enabled = true;
                endChar2.Enabled = true;
                endChar3.Enabled = true;

                speedLabel.Text = "Addresses/Sec:";
                mineButton.Text = "Mine";
                outputBox.ScrollBars = ScrollBars.None;
                matchLabel.Text = string.Empty;
                matchTextBox.Text = string.Empty;
                timer.Dispose();

                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
        }





        void FoundSolution(string mnemonic, string address)
        {
            StopMining();
            _outputBufffer.Clear();

            var words = mnemonic.Split(" ");

            for(var i = words.Length-1; i >= 0; i--)
            {
                OutputMessage($"{i+1}: {words[i]}");
            }



            for (var i = 0; i < 20; i++)
            {
                _outputBufffer.AddLine("...");
            }
            OutputMessage("Found Address, Scroll to see Keys.");
            outputBox.ScrollBars = ScrollBars.Vertical;

            matchLabel.Text = address.Substring(0, 6) + "..." + address.Substring(address.Length - 4, 4);
            matchTextBox.Text = address;



            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("dogecoin:"+ address, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // 20 is the pixel size for each module

            // Set the QR code to the PictureBox
            matchQRPicture.Image = qrCodeImage;

        }


        void ClearOutput()
        {
            _outputBufffer.Clear();

            outputBox.Text = string.Empty;
        }

        void OutputMessage(string text)
        {
            _outputBufffer.AddLine(text);

            outputBox.Text = _outputBufffer.GetText();
        }


        public static bool IsValidBase58Character(string character)
        {
            // Base58 character set for Dogecoin P2PKH addresses
            string base58Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

            // Check if the input is a single character and within the base58 alphabet
            if (character.Length == 1)
            {
                return base58Alphabet.Contains(character);
            }
            return false;
        }

        int ValidateInput(TextBox textBox)
        {
            if (textBox == startChar0 && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                //special rules for this slot:

                char[] allowedChars = new char[] { '5', '6', '7', '8', '9', 'L', 'N', 'P', 'M', 'F', 'R', 'H', 'J', 'B', 'S', 'K', 'A', 'T', 'G', 'U', 'D', 'E', 'C', 'Q' };


                if (!allowedChars.Contains(textBox.Text[0]))
                {
                    OutputMessage("Invalid Character '" + textBox.Text + "' in '" +
                        (textBox.Name.StartsWith("s") ? "Starts With:" : "Ends With:")
                        + "' Slot #" + (Int32.Parse(textBox.Name.Last().ToString()) + 1));
                    return 1;
                }


            }

            if (!IsValidBase58Character(textBox.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                OutputMessage("Invalid Character '" + textBox.Text + "' in '" +
                    (textBox.Name.StartsWith("s") ? "Starts With:" : "Ends With:")
                    + "' Slot #" + (Int32.Parse(textBox.Name.Last().ToString()) + 1));

                return 1;
            }

            return 0;
        }

        private void mineButton_Click(object sender, EventArgs e)
        {
            if (mining)
            {
                StopMining();
                return;
            }

            ClearOutput();

            matchQRPicture.Image = null;

            int errors = 0;

            end0 = '*';
            end1 = '*';
            end2 = '*';
            end3 = '*';

            start0 = '*';
            start1 = '*';
            start2 = '*';
            start3 = '*';
            start4 = '*';


            errors += ValidateInput(endChar3);
            errors += ValidateInput(endChar2);
            errors += ValidateInput(endChar1);
            errors += ValidateInput(endChar0);

            errors += ValidateInput(startChar4);
            errors += ValidateInput(startChar3);
            errors += ValidateInput(startChar2);
            errors += ValidateInput(startChar1);
            errors += ValidateInput(startChar0);

            end0 = string.IsNullOrEmpty(endChar0.Text) ? '*' : endChar0.Text[0];
            end1 = string.IsNullOrEmpty(endChar1.Text) ? '*' : endChar1.Text[0];
            end2 = string.IsNullOrEmpty(endChar2.Text) ? '*' : endChar2.Text[0];
            end3 = string.IsNullOrEmpty(endChar3.Text) ? '*' : endChar3.Text[0];

            start0 = string.IsNullOrEmpty(startChar0.Text) ? '*' : startChar0.Text[0];
            start1 = string.IsNullOrEmpty(startChar1.Text) ? '*' : startChar1.Text[0];
            start2 = string.IsNullOrEmpty(startChar2.Text) ? '*' : startChar2.Text[0];
            start3 = string.IsNullOrEmpty(startChar3.Text) ? '*' : startChar3.Text[0];
            start4 = string.IsNullOrEmpty(startChar4.Text) ? '*' : startChar4.Text[0];

            matchLabel.Text = string.Empty;
            matchTextBox.Text = string.Empty;

            if (!(end0 != '*' || end1 != '*' || end2 != '*' || end3 != '*' ||
                start0 != '*' || start1 != '*' || start2 != '*' || start3 != '*' || start4 != '*'))
            {
                OutputMessage("Specify at least one character to mine!");
                return;

            }
            else if (errors == 0)
            {
                mineButton.Text = "Stop";
                StartMining();
            }



        }

        double CalculateDifficulty()
        {


            int count = 0;

            end0 = string.IsNullOrEmpty(endChar0.Text) ? '*' : endChar0.Text[0];
            end1 = string.IsNullOrEmpty(endChar1.Text) ? '*' : endChar1.Text[0];
            end2 = string.IsNullOrEmpty(endChar2.Text) ? '*' : endChar2.Text[0];
            end3 = string.IsNullOrEmpty(endChar3.Text) ? '*' : endChar3.Text[0];

            start0 = string.IsNullOrEmpty(startChar0.Text) ? '*' : startChar0.Text[0];
            start1 = string.IsNullOrEmpty(startChar1.Text) ? '*' : startChar1.Text[0];
            start2 = string.IsNullOrEmpty(startChar2.Text) ? '*' : startChar2.Text[0];
            start3 = string.IsNullOrEmpty(startChar3.Text) ? '*' : startChar3.Text[0];
            start4 = string.IsNullOrEmpty(startChar4.Text) ? '*' : startChar4.Text[0];


            if (end0 != '*') count++;
            if (end1 != '*') count++;
            if (end2 != '*') count++;
            if (end3 != '*') count++;
            if (start1 != '*') count++;
            if (start2 != '*') count++;
            if (start3 != '*') count++;
            if (start4 != '*') count++;

            return Math.Pow(58, count) * (start0 == '*' ? 1 : 24);
        }

        private void InputTextChanged(object sender, EventArgs e)
        {

            double difficulty = CalculateDifficulty();

            labelDifficulty.Text = "Difficulty: 1 Address per " + String.Format("{0:N0}", difficulty) + " mined.";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(processes != null)
            foreach(var process in processes)
            {
                process.Kill();
            }
        }
    }
}
