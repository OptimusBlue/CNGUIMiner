using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimusBlueMiner
{
    public partial class Form1 : Form
    {
        Config config = null;
        Settings settings = null;
        public static WindowLogger windowLogger;
        public static bool minerRunning = false;
        /*private static bool coinChanged = false;*/
        public Form1()
        {
            InitializeComponent();
            windowLogger = new WindowLogger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.webBrowser1.Url = new Uri(String.Format("file:///{0}/offline.html", curDir));

            var configfile = System.IO.Path.Combine(curDir, "coins.json");
            var settingsfile = System.IO.Path.Combine(curDir, "settings.json");
            //fetch latest config file.. 
            try
            {
                using (WebClient wc = new WebClient())
                {
                    var configText = wc.DownloadString(new System.Uri("http://cnguiminer.com/cn-miner/coins.json"));
                    if (!string.IsNullOrEmpty(configText))
                    {
                        System.IO.File.WriteAllText(configfile, configText);
                    }
                }
            }
            catch { } //just use the local one if you can't fetch it
            //read config and load values
            config = JsonConvert.DeserializeObject<Config>(System.IO.File.ReadAllText(configfile));
            if (System.IO.File.Exists(settingsfile))
            {
                try
                {
                    settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText(settingsfile));
                }
                catch {
                    //if the "settings" can't be deserialized, the delete the settings file as we will start again... 
                    System.IO.File.Delete(settingsfile);
                }
            }

            lblHelpText.Text = config.HelpText;

            //Worker default value
            //textBoxWorker.Text = "CN GUI Miner";

            //load combobox coins
            foreach (var coin in config.Coins)
                comboBoxCoin.Items.Add(coin.Name);

            if (settings != null)
            {
                //select the coin and load up the address for the last coin used
                try
                {
                    if (settings.Coins != null && settings.Coins.Any())
                    {
                        var coin = settings.Coins.OrderByDescending(x=>x.DateUsed).FirstOrDefault();
                        comboBoxCoin.SelectedIndex = comboBoxCoin.Items.IndexOf(coin.Coin);
                        textBoxAddress.Text = coin.Address;
                    }
                    
                }
                catch (Exception)
                {
                    //set some default text
                    comboBoxCoin.Text = "Select the coin/pool to mine";
                }
            }
            else
            {
                //set some default text
                comboBoxCoin.Text = "Select the coin/pool to mine";
            }

        }

        private void buttonStartMining_Click(object sender, EventArgs e)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var coin = config.Coins.FirstOrDefault(x => x.Name == comboBoxCoin.Text);
            var algoCPU = (@"config\" + coin.Algo + "-cpu.txt");
            var algoAMD = (@"config\" + coin.Algo + "-amd.txt");
            var algoNVIDIA = (@"config\" + coin.Algo + "-nvidia.txt");

            if (comboBoxCoin.Text == "Select the coin/pool to mine")
            {
                MessageBox.Show("Please select a coin/pool to mine.", "No Coin/Pool", MessageBoxButtons.OK);
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxAddress.Text))
                {
                    MessageBox.Show("Please enter your address for the selected coin.", "No Address", MessageBoxButtons.OK);
                }
                else
                {
                    chkCPU.Enabled = false;
                    chkAMD.Enabled = false;
                    chkNvidia.Enabled = false;
                    //store local address for coin... 
                    var setting = new Setting();
                    if (settings == null)
                    {
                        settings = new Settings();
                    }
                    if (settings.Coins != null && settings.Coins.Any(x => x.Coin == comboBoxCoin.Text))
                    {
                        try
                        {
                            settings.Coins.Remove(settings.Coins.FirstOrDefault(x => x.Coin == comboBoxCoin.Text));
                        }
                        catch { }
                    }
                    else
                    {
                        if (settings.Coins == null)
                            settings.Coins = new List<Setting>();
                    }
                    setting.Address = textBoxAddress.Text;
                    setting.Coin = comboBoxCoin.Text;
                    setting.DateUsed = DateTime.Now;
                    settings.Coins.Add(setting);

                    System.IO.File.WriteAllText(System.IO.Path.Combine(curDir, "settings.json"), JsonConvert.SerializeObject(settings));
                    //fire up xmr stak
                    if (buttonStartMining.Text == "Start Mining")
                    {
                        var miningexe = System.IO.Path.Combine(curDir, "opti-stak.exe");
                        var conflictingProcesses = Process.GetProcessesByName("opti-stak").ToArray();
                        int numConflictingProcesses = conflictingProcesses.Length;


                        for (int i = 0; i < numConflictingProcesses; i++)
                        {
                            /* Need to kill any existing miners to ensure we get max possible hash rate here */
                            conflictingProcesses[i].Kill();
                        }

                        //delete and "pools.txt" file to prevent double connections :
                        if (System.IO.File.Exists(String.Format(@"{0}\pools.txt", curDir)))
                        {
                            System.IO.File.Delete(String.Format(@"{0}\pools.txt", curDir));
                        }

                        //Copy algo-cpu.txt to cpu.txt for miner config
                        if (System.IO.File.Exists(algoCPU))
                        {
                            File.Copy(algoCPU, "cpu.txt", true);
                        }

                        //Copy algo-amd.txt to amd.txt for miner config
                        if (System.IO.File.Exists(algoAMD))
                        {
                            File.Copy(algoAMD, "amd.txt", true);
                        }

                        //Copy algo-nvidia.txt to nvidia.txt for miner config
                        if (System.IO.File.Exists(algoNVIDIA))
                        {
                            File.Copy(algoNVIDIA, "nvidia.txt", true);
                        }


                        Process p = new Process();
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.Verb = "runas";
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.StartInfo.FileName = miningexe;
                        p.OutputDataReceived += CaptureOutput;

                        //var coin = config.Coins.FirstOrDefault(x => x.Name == comboBoxCoin.Text);
                        var args = new string[] { "-o", coin.PoolUrl + ":" + coin.PoolPort, "-u", textBoxAddress.Text, "-p", textBoxWorker.Text, "--currency", coin.Algo, "-r", textBoxWorker.Text, "-i", "6248" };

                        if (!chkCPU.Checked)
                        {
                            args = args.Concat(new string[] { "--noCPU" }).ToArray();
                        }
                        if (!chkAMD.Checked)
                        {
                            args = args.Concat(new string[] { "--noAMD" }).ToArray();
                        }
                        if (!chkNvidia.Checked)
                        {
                            args = args.Concat(new string[] { "--noNVIDIA" }).ToArray();
                        }

                        if (coin != null)
                        {
                            p.StartInfo.Arguments = CLIEncoder.Encode(args);

                            int maxConnectionAttempts = 5;

                            /* It takes a small amount of time to kill the other processes
                               if needed, so lets try and connect a few times before failing. */

                            for (int i = 0; i < maxConnectionAttempts; i++)
                            {
                                if (!minerRunning)
                                {
                                    p.Start();

                                    System.Threading.Thread.Sleep(1500);
                                    if (!p.HasExited)
                                    {
                                        p.BeginOutputReadLine();
                                        //p.WaitForExit();
                                        minerRunning = true;
                                    }
                                }
                            }
                            Thread.Sleep(2000);
                            if (minerRunning)
                            {
                                //first, get Url output to file... 
                                GetMinerStats();
                                webBrowser1.Url = new Uri(String.Format("file:///{0}/h.html", curDir));
                                if (checkBox1.Checked)
                                {
                                    minerRefreshTimer.Enabled = true;
                                }
                                //ToDO: Split Tab view with Page showing Pool Stats and Miner Stats from XMR Stak
                                //TODO: Refresh Timer
                            }
                            buttonStartMining.Text = "Stop Mining";
                        }
                        else {
                            MessageBox.Show("Could not start mining, please check coin selection and address");
                            buttonStartMining.Text = "Start Mining";
                        }
                    }
                    else
                    {
                        //kill mining process and change button text
                        buttonStartMining.Text = "Start Mining";
                        chkCPU.Enabled = true;
                        chkAMD.Enabled = true;
                        chkNvidia.Enabled = true;
                        var conflictingProcesses = Process.GetProcessesByName("opti-stak").ToArray();
                        int numConflictingProcesses = conflictingProcesses.Length;

                        for (int i = 0; i < numConflictingProcesses; i++)
                        {
                            /* Kill the mining processes on request */
                            conflictingProcesses[i].Kill();
                        }
                        minerRunning = false;
                        textBox1.Clear(); //clear mining round output
                        minerRefreshTimer.Enabled = false;

                        this.webBrowser1.Url = new Uri(String.Format("file:///{0}/offline.html", curDir));


                        //Move the cpu.txt, amd.txt and nvidia.txt config files to algo-cpu.txt, algo-amd.txt and algo-nvidia.txt - Enabling users to edit these configs for future use.
                        if (!File.Exists(algoCPU))
                        {
                            if (File.Exists("cpu.txt"))
                            {
                                File.Move("cpu.txt", algoCPU);
                            }
                        }

                        if (!File.Exists(algoAMD))
                        {
                            if (File.Exists("amd.txt"))
                            {
                                File.Move("amd.txt", algoAMD);
                            }
                        }

                        if (!File.Exists(algoNVIDIA))
                        {
                            if (File.Exists("nvidia.txt"))
                            {
                                File.Move("nvidia.txt", algoNVIDIA);
                            }
                        }


                    }
                }
            }


        }

        private void CaptureOutput(object sender, DataReceivedEventArgs e)
        {
            ShowOutput(e.Data, ConsoleColor.Green);
        }
        private void ShowOutput(string data, ConsoleColor color)
        {
            if (data != null)
            {
                windowLogger.Log(textBox1, data);
            }
        }
        private void checkBoxRefresh_CheckedChanged(object sender, EventArgs e)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (minerRunning)
            {
                minerRefreshTimer.Enabled = checkBox1.Checked;
            }
            else
            {
                minerRefreshTimer.Enabled = false;
                this.webBrowser1.Url = new Uri(String.Format("file:///{0}/offline.html", curDir));
            }
        }

        private void minerRefreshTimer_Tick(object sender, EventArgs e)
        {
            GetMinerStats();
            webBrowser1.Refresh();
        }

        private static void GetMinerStats()
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            try
            {
                using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
                {
                    // Or you can get the file content without saving it
                    string hCode = client.DownloadString("http://localhost:6248/h");
                    string rCode = client.DownloadString("http://localhost:6248/r");
                    string cCode = client.DownloadString("http://localhost:6248/c");

                    System.IO.File.WriteAllText(String.Format(@"{0}\h.html", curDir), ReformatHashRateReport(hCode));
                    System.IO.File.WriteAllText(String.Format(@"{0}\r.html", curDir), ReformatHashRateReport(rCode));
                    System.IO.File.WriteAllText(String.Format(@"{0}\c.html", curDir), ReformatHashRateReport(cCode));
                    if (!System.IO.File.Exists(String.Format(@"{0}\style.css", curDir)))
                    {
                        string cssCode = client.DownloadString("http://localhost:6248/style.css");
                        System.IO.File.WriteAllText(String.Format(@"{0}\style.css", curDir), cssCode);
                    }
                }
            }
            catch (Exception)
            {
                //empty catch to handle fast start stops of miner
            }
        }
        private static string ReformatHashRateReport(string htmlIn)
        {
            htmlIn = htmlIn.Replace("<span style='color: rgb(255, 160, 0)'>XMR</span>-Stak Monero", "Opti-Stak");
            htmlIn = htmlIn.Replace("<div class='flex-container'><div class='links flex-item'><a href='h'><div><span class='letter'>H</span>ashrate</div></a></div><div class='links flex-item'><a href='r'><div><span class='letter'>R</span>esults</div></a></div><div class='links flex-item'><a href='c'><div><span class='letter'>C</span>onnection</div></a></div></div>", "<table width='100%' border='0' cellpadding='4' cellspacing='0'><tr><td style='text-align:center;width:33%;'><a href='h.html'><div><span class='letter'>H</span>ashrate</div></a></td><td style='text-align:center;width:33%;'><a href='r.html'><div><span class='letter'>R</span>esults</div></a></td><td style='text-align:center;width:33%;'><a href='c.html'><div><span class='letter'>C</span>onnection</div></a></td></tr></table>");
            return htmlIn;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && buttonStartMining.Text == "Stop Mining")
            {
                minerRefreshTimer.Enabled = true;
            }
            else {
                minerRefreshTimer.Enabled = false;
            }
        }

        private void comboBoxCoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddress.Text = "";
            if (settings != null && settings.Coins != null && settings.Coins.Any(x => x.Coin == comboBoxCoin.Text))
            {
                try {
                    var setting = settings.Coins.FirstOrDefault(x => x.Coin == comboBoxCoin.Text);
                    if (setting != null)
                    {
                        textBoxAddress.Text = setting.Address;
                    }
                }
                catch { }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var SettingsPath = (String.Format(@"{0}\config", curDir));

            Process.Start("explorer.exe", SettingsPath);
        }
    }
}
