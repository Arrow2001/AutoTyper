using System.Runtime.InteropServices;

namespace AutoTyper
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hhwnd, int id);
        private const int Hotkey_ID = 9000;
        private const int HotKey_ID_Two = 9001;
        private const uint Control_HotKey = 0x0002; // CTRL key
        private const uint Alt_HotKey = 0x0001; // ALT key
        private bool isTyping = false;
        private CancellationTokenSource cancelToken;

        public Form1()
        {
            InitializeComponent();
            this.Activated += (s, e) => this.TopMost = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, Hotkey_ID, Control_HotKey | Alt_HotKey, 0x41); // CTRL+Alt_A
            RegisterHotKey(this.Handle, HotKey_ID_Two, Control_HotKey | Alt_HotKey, 0x42); // CTRL+Alt+B
        }

        private async void StartAutoType(int amount, string textToLoop)
        {
            isTyping = true;
            ToggleUI(false);
            cancelToken = new CancellationTokenSource();
            var token = cancelToken.Token;

            try
            {
                SafeInvoke(() =>
                {
                    loopLabel.Text = $"0/{amount} completed.";
                    loopProgress.Minimum = 0;
                    loopProgress.Maximum = amount;
                    loopProgress.Value = 0;
                });

                for (int i=0; i<amount; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    SendKeys.SendWait(textToLoop);
                    SendKeys.SendWait("{ENTER}");
                    SafeInvoke(() =>
                    {
                        loopLabel.Text = $"{i + 1}/{amount} completed";
                        int remaining = amount - (i + 1);
                        TimeSpan eta = TimeSpan.FromMilliseconds(remaining * 2000);
                        etaLabel.Text = $"ETA: {eta.Minutes}m{eta.Seconds}s";
                        loopProgress.Value = i + 1;
                    });
                    await Task.Delay(2000, token); // 1.5 second wait
                }
                if (token.IsCancellationRequested)
                {
                    MessageBox.Show($"AutoTyper has been stopped.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show($"AutoTyper has finished.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (TaskCanceledException)
            {

            } catch (Exception ex)
            {
                MessageBox.Show($"An error has occurred: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                isTyping = false;
                ToggleUI(true);
                SafeInvoke(() =>
                {
                    loopLabel.Text = "Ready";
                    loopProgress.Value = 0;
                    etaLabel.Text = "ETA:";
                });
                cancelToken.Dispose();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HotKey = 0x0312;
            if (m.Msg == WM_HotKey && m.WParam.ToInt32() == Hotkey_ID)
            {
                if (isTyping) return;
                int amount = (int)amountNumUpDown.Invoke(new Func<decimal>(() => amountNumUpDown.Value));
                string textToLoop = (string)textToLoopTextBox.Invoke(new Func<string>(() => textToLoopTextBox.Text));
                StartAutoType(amount, textToLoop);
            }
            else if (m.Msg == WM_HotKey && m.WParam.ToInt32() == HotKey_ID_Two)
            {
                cancelToken?.Cancel();
            }
            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Unregister Hotkeys
            UnregisterHotKey(this.Handle, Hotkey_ID);
            UnregisterHotKey(this.Handle, HotKey_ID_Two);
        }

        private void ToggleUI(bool isEnable)
        {
            SafeInvoke(() =>
            {
                amountNumUpDown.Enabled = isEnable;
                textToLoopTextBox.Enabled = isEnable;
            });
        }

        private void SafeInvoke(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }
    }
}
