using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaHPLED
{
    public partial class Form1 : Form
    {
        #region World Vars
        Byte[] Queend = new Byte[] { 0x51, 0x75, 0x65, 0x00, 0x00, 0x80, 0xBF, 0x00, 0x65, 0x6E, 0x64 };
        int CurrentHealthOffset = 47;
        int MaxHealthOffset = 51;
        int DeadOffset = -22;
        int TimerOffset = 12799;
        Process Dota2;
        IntPtr CHealthAddress;
        IntPtr MHealthAddress;
        IntPtr DeadAddress;
        IntPtr TimerAddress;
        const int PROCESS_WM_READ = 0x0010;
        private volatile int _current = 0;
        private volatile int _max = 1;
        private volatile int _death = 0;
        private volatile int _time = 0;
        SerialPort ard = new SerialPort("COM3", 9600);
        #endregion

        #region Variable Accessors
        public int CurrentHealth
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
            }
        }
        public int MaximumHealth
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
        public int DeathStatus
        {
            get
            {
                return _death;
            }
            set
            {
                _death = value;
            }
        }
        public int RespawnTimer
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }
        #endregion

        #region Form Operations
        public Form1()
        {
            InitializeComponent();
        }     
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bob.StopWatching();
            voyeurThread.Join();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 230;
            //lights = new Button[] { light1, light2, light3, light4, light5, light6, light7, light8, light9, light10 };
            //offAll();
        }
        #endregion

        #region Button Operations
        private void findProcess_Click(object sender, EventArgs e)
        {
            Process[] tempList = Process.GetProcessesByName("dota");
            if (tempList.Length > 1)
            {
                MessageBox.Show("Multiple instances of Dota 2 found! Narrow these down to one!");
            }
            else
            {
                Dota2 = tempList[0];
                labelHookedVariable.Text = "Yes";
                labelPIDVariable.Text = Dota2.Id.ToString();
            }
        }
        private void hookHealth_Click(object sender, EventArgs e)
        {
            this.Height = 270;
            IntPtr QueendAddress = addressSearch(Dota2, Queend);
            if (QueendAddress.Equals(IntPtr.Zero))
            {
                this.Height = 230;
                MessageBox.Show("Failure to find");
            }
            else
            {
                CHealthAddress = new IntPtr(QueendAddress.ToInt32() + CurrentHealthOffset);
                MHealthAddress = new IntPtr(QueendAddress.ToInt32() + MaxHealthOffset);
                DeadAddress = new IntPtr(QueendAddress.ToInt32() + DeadOffset);
                TimerAddress = new IntPtr(QueendAddress.ToInt32() + TimerOffset);
                try
                {
                    ard.Open();
                    labelArdStatus.Text = "Online";
                    labelArdStatus.ForeColor = Color.Green;
                }
                catch (Exception l)
                {
                    MessageBox.Show("Unable to open Arduino port, please try again.\n" + l.ToString());
                }
            }
        }
        #endregion

        #region Find Address
        public IntPtr addressSearch(Process dota, byte[] toSearch)
        {
            IntPtr p = OpenProcess(0x10, true, dota.Id); //0x10-read
            this.Height = 270;
            uint PTR = 0x03000000; //begin of memory
            byte[] buff = new byte[toSearch.Length];
            int bytesRead;

            while (PTR < 0x04000000)   //end of memory // u can specify to read less if u know he does not fill it all
            {
                ReadProcessMemory(p, new IntPtr(PTR), buff, buff.Length, out bytesRead);
                int testCase = SpecialByteCompare(buff, toSearch);
                switch (testCase)
                {
                    case 2:
                        return new IntPtr(PTR);
                    case 1:
                        PTR += (uint)toSearch.Length;
                        break;
                    case 0:
                        PTR += 0x1;
                        break;
                    case -1:
                        throw new ImpossibleExceptionException();
                }
            }
            return IntPtr.Zero;
        }

        private static int SpecialByteCompare(byte[] comparingTo, byte[] comparingWith)  //read memory, first byte array, second byte array, number of missing byte's
        {
            if (comparingTo.Length != (comparingWith.Length))
            {
                return -1;
            }
            if (!comparingTo.Contains<byte>(comparingWith[0]))
            {
                return 1;
            }
            for (int i = 0; i < comparingWith.Length; i++)
            {
                if (comparingTo[i] != comparingWith[i])
                    return 0;
            }
            return 2;
        }

        #region Imported
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        [Out] byte[] lpBuffer,
        int dwSize,
        out int lpNumberOfBytesRead
        );
        #endregion
        #endregion

        #region Thread
        Watcher bob;
        Thread voyeurThread;
        //Goulding ellie;
        //Thread lightsThread;
        bool running = false;
        
        delegate void SetTextCallback(int Chealth, int Mhealth, int Dead, int RTime);
        public void updateNumbers(int Chealth, int Mhealth, int Dead, int RTime)
        {
            if (labelCHVar.InvokeRequired || labelDeathVar.InvokeRequired || labelMHVar.InvokeRequired || labelRTVar.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(updateNumbers);
                this.Invoke(d, new object[] { Chealth, Mhealth, Dead, RTime });
            }
            else
            {
                _current = Chealth;
                _max = Mhealth;
                _death = (Dead > 70000) ? 0 : 1;
                _time = (RTime >= 0) ? RTime : 0;
                ard.Write(_current.ToString()+";"+_max.ToString()+";"+_death.ToString()+";"+_time.ToString());
                labelCHVar.Text = _current.ToString();
                labelMHVar.Text = _max.ToString();
                labelDeathVar.Text = _death.ToString();
                labelRTVar.Text = _time.ToString();
                labelComRead.Text = ard.ReadLine();
            }
        }
        private void buttonBegin_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                bob = new Watcher(Dota2, CHealthAddress, MHealthAddress, DeadAddress, TimerAddress, this);
                voyeurThread = new Thread(bob.PleaseWatch);
                voyeurThread.IsBackground = true;
                voyeurThread.Start();
                //ellie = new Goulding(this);
                //lightsThread = new Thread(ellie.repetition);
                //lightsThread.IsBackground = true;
                //lightsThread.Start();
                buttonBegin.Text = "Stop Evaluation";
            }
            else
            {
                //ellie.stopRepetition();
                //lightsThread.Join();
                bob.StopWatching();
                voyeurThread.Join();
                buttonBegin.Text = "Begin Evaluation";
            }
        }
        #endregion
        
        #region Lights Functions
        /*
        Button[] lights;
        public void turnOn(params int[] lightNumbers)
        {
            for (int i = 0; i < lightNumbers.Length; i++)
            {
                lights[i].BackColor = Color.Green;
            }
        }
        public void turnOff(params int[] lightNumbers)
        {
            for (int i = 0; i < lightNumbers.Length; i++)
            {
                lights[i].BackColor = Color.Red;
            }
        }
        public void onAll()
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].BackColor = Color.Green;
            }
        }
        public void offAll()
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].BackColor = Color.Red;
            }
        }*/
        #endregion
    }

    public class Watcher
    {
        Process Dota2;
        IntPtr CHealthAddress;
        IntPtr MHealthAddress;
        IntPtr DeadAddress;
        IntPtr TimerAddress;
        Form1 Owner;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out int lpNumberOfBytesRead
        );

        public Watcher(Process dota, IntPtr ch, IntPtr mh, IntPtr d, IntPtr t, Form1 _owner)
        {
            Dota2 = dota;
            CHealthAddress = ch;
            MHealthAddress = mh;
            DeadAddress = d;
            TimerAddress = t;
            Owner = _owner;
        }

        private volatile bool working = true;

        public void PleaseWatch()
        {
            IntPtr p = OpenProcess(0x10, true, Dota2.Id); //0x10-read
            int bytesRead = 0;
            while (working)
            {
                byte[] currentHealth = new byte[4];
                ReadProcessMemory(p, CHealthAddress, currentHealth, 4, out bytesRead);
                byte[] maxHealth = new byte[4];
                ReadProcessMemory(p, MHealthAddress, maxHealth, 4, out bytesRead);
                byte[] deadStatus = new byte[4];
                ReadProcessMemory(p, DeadAddress, deadStatus, 4, out bytesRead);
                byte[] respawnTimer = new byte[4];
                ReadProcessMemory(p, TimerAddress, respawnTimer, 4, out bytesRead);
                Owner.updateNumbers(BitConverter.ToInt32(currentHealth, 0), BitConverter.ToInt32(maxHealth, 0), BitConverter.ToInt32(deadStatus, 0), BitConverter.ToInt32(respawnTimer, 0));
                Thread.Sleep(20);
            }
        }

        public void StopWatching()
        {
            working = false;
        }
    }

    public class ImpossibleExceptionException : Exception
    {
        public ImpossibleExceptionException() { }

        public ImpossibleExceptionException(String message) : base(message) { }
    }

    /*
    public class Goulding
    {
        private Form1 _parent;
        private volatile bool working = true;

        public Goulding(Form1 parent)
        {
            _parent = parent;
        }

        public void repetition()
        {
            int lightsOn = 0;
            int startRespawnTime = 0;
            while (working)
            {
                if (_parent.DeathStatus == 0)
                {
                    startRespawnTime = 0;
                    double frac = _parent.CurrentHealth / _parent.MaximumHealth;
                    int nowLights = (int)Math.Ceiling(frac * 10);
                    if (nowLights > lightsOn)
                    {
                        int[] onCommand = new int[nowLights - lightsOn];
                        for(int i=0;i<onCommand.Length;i++)
                        {
                            onCommand[i] = lightsOn + i;
                        }
                        _parent.turnOn(onCommand);
                    }
                    else if(lightsOn > nowLights)
                    {
                        int[] offCommand = new int[lightsOn - nowLights];
                        for (int i = 0; i < offCommand.Length; i++)
                        {
                            offCommand[i] = nowLights - i;
                        }
                        _parent.turnOff(offCommand);
                    }
                }
                else
                {
                    if (startRespawnTime == 0)
                    {
                        startRespawnTime = _parent.RespawnTimer;
                        _parent.offAll();
                    }
                }
            }
        }
        public void stopRepetition()
        {
            working = false;
        }
    }
    */
}