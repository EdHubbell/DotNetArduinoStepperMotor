using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Note that the library has to run with a newly started Arduino. Otherwise, errors happen.   
/// </summary>

namespace DotNetArduinoStepperMotor
{
  
    public partial class Form1 : Form
    {
        private decimal decBufferVal = 0;


        private ArduinoSerialReader oArduinoSerialReader;


        public Form1()
        {
            InitializeComponent();

            decBufferVal = numUpDown.Value;

        }
        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal increment = numUpDown.Value - decBufferVal;

            decBufferVal = numUpDown.Value;


        }

        private async void btnRotateCW_Click(object sender, EventArgs e)
        {
            await oArduinoSerialReader.SendRotateCommandToArduinoSerial("DONE", 10000, true);
        }

        private async void btnRotateCCW_Click(object sender, EventArgs e)
        {
            await oArduinoSerialReader.SendRotateCommandToArduinoSerial("DONE", 10000, false);
        }

        private void btnFindAttachedArduinos_Click(object sender, EventArgs e)
        {
            ArduinoSerialReader.FillComboboxWithAttachedArduinos(cbArduinoAddress);
        }

        private void cbArduinoAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSelected = cbArduinoAddress.SelectedItem.ToString();
            if (sSelected.Length > 4)
            {
                string sArduinoAddress = sSelected.Substring(0, sSelected.IndexOf(" "));

                if (oArduinoSerialReader == null)
                {
                    oArduinoSerialReader = new ArduinoSerialReader(sArduinoAddress);
                }

                if (oArduinoSerialReader != null && oArduinoSerialReader.Address != sArduinoAddress)
                {
                    oArduinoSerialReader = new ArduinoSerialReader(sArduinoAddress);
                }
            }

        }
    }


}

