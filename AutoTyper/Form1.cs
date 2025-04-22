using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace AutoTyper
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsWodifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregiserHotKey(IntPtr hhwnd, int id);
        private const int Hotkey_ID = 9000;
        private const int HotKey_ID_Two = 9001;
        private const uint Control_HotKey = 0x0002; // CTRL key
        private const uint Alt_HotKey = 0x0001; // ALT key
        private bool shouldStop = false;
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, Hotkey_ID, Control_HotKey | Alt_HotKey, 0x41); // CTRL+Alt_A
            RegisterHotKey(this.Handle, HotKey_ID_Two, Control_HotKey | Alt_HotKey, 0x42); // CTRL+Alt+B
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HotKey = 0x0312;
            if (m.Msg == WM_HotKey && m.WParam.ToInt32() == Hotkey_ID)
            {
                //MessageBox.Show($"Hotkey CTRL+ALT+A pressed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                shouldStop = false;

                new Thread(() =>
                {
                    // access in background so stop hotkey works
                    int amount = (int)amountNumUpDown.Invoke(new Func<decimal>(() => amountNumUpDown.Value));
                    loopLabel.Text = $"1/{amount} completed";
                    string textToLoop = (string)textToLoopTextBox.Invoke(new Func<string>(() => textToLoopTextBox.Text));
                    
                    for (int i = 0; i < amount; i++)
                    {
                        if (shouldStop == true)
                            break;
                        SendKeys.SendWait(textToLoop);
                        SendKeys.SendWait("{ENTER}");
                        loopLabel.Text = $"{i+1}/{amount} completed";
                        Thread.Sleep(1500); // 1.5 seconds between messages
                    } 
                    if (shouldStop)
                    {
                        MessageBox.Show("Auto Typer has been stopped.", "", MessageBoxButtons.OK);
                    }

                }).Start();
            } 
            else if (m.Msg == WM_HotKey && m.WParam.ToInt32() == HotKey_ID_Two)
            {
                shouldStop = true;
            }
                base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
