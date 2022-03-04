using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Unkillable_Process
{
    public partial class Form1 : Form
    {      
        
        public Form1()
            {
                InitializeComponent();
            }



        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);



        public void critical(int status)
        {
            int BreakOnTermi = 0x1D;
            Process.EnterDebugMode();
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermi,
            ref status, sizeof(int));

        }


            private void Form1_Load(object sender, EventArgs e)
            {

            }

        private void button1_Click(object sender, EventArgs e)
        {
            critical(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            critical(0);
        }
    }
    }


