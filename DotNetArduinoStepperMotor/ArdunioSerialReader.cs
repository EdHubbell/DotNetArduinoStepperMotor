using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using NLog;
using System.Management;
using System.Windows.Forms;

namespace DotNetArduinoStepperMotor 
{
    class ArduinoSerialReader
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private String sArduinoPortAddress = "";
        private SerialPort portArduino = null;
        private string serialResponse = "";


        public ArduinoSerialReader(string sPortAddress)
        {
            sArduinoPortAddress = sPortAddress;
            portArduino = null;
            InitArduinoSerialConnection();
        }

        public string Address
        {
            get
            {
                return sArduinoPortAddress;
            }
        }


        private void InitArduinoSerialConnection()
        {
            try
            {
                if (portArduino == null)
                {
                    portArduino = new SerialPort(sArduinoPortAddress, 115200, Parity.None, 8, StopBits.One);
                }

                if (portArduino.IsOpen == false)
                {
                    //open the port
                    portArduino.Open();

                    // Wait a bit after the immediate connection so that we can ignore initial values.
                    Thread.Sleep(2000);

                    // And clear out any values in the buffer. In this case, the arduino code sends along stuff when the microcontroller starts up.
                    portArduino.ReadExisting();

                    // Add the event handler only once. 
                    portArduino.DataReceived += Port_DataReceived;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Access to "))
                {
                    portArduino.Close();
                }

                logger.Error(ex);
            }


        }


        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;

            // read input
            string incoming = port.ReadExisting();
            // append to serialResponse
            serialResponse += incoming;

        }

        public async Task<string> SendRotateCommandToArduinoSerial(string sEndText, int iTimeoutMsec, bool bClockwise)
        {
            string sResponse = string.Empty;
            try
            {
                InitArduinoSerialConnection();

                // Reset the serial response here. We want to make sure it is empty 
                // so that in case there were results stuck in there after a timeout are flushed.
                serialResponse = string.Empty;

                string sCommand = bClockwise ? "r" : "l";

                portArduino.WriteLine(sCommand);

                Stopwatch timeoutStopWatch = new Stopwatch();
                timeoutStopWatch.Start();

                while (serialResponse.ToUpper().Contains(sEndText.ToUpper()) == false && timeoutStopWatch.ElapsedMilliseconds < iTimeoutMsec)
                {
                    // The data from the Arduino should end with a line that says 'Done' in it. Loop until that's true or the timeout has been reached.
                    await Task.Delay(100);
                }

                if (timeoutStopWatch.ElapsedMilliseconds >= iTimeoutMsec)
                {
                    sResponse = "serial timeout";
                }
                else
                {
                    sResponse = serialResponse;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            portArduino.DataReceived -= Port_DataReceived;

            return sResponse;

        }

        public static void FillComboboxWithAttachedArduinos(ComboBox cbArduinoAddress)
        {

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();

                var portNameList = (from n in portnames
                                    join p in ports on
                                    n equals p["DeviceID"].ToString()
                                    select n + " - " + p["Caption"]).ToList();


                List<string> filteredPortNameList = new List<string>();

                //  Only show devices that register as USB Serial Device, not just all the ports.
                foreach (string sPort in portNameList)
                {
                    if (sPort.ToUpper().Contains("USB SERIAL DEVICE") || sPort.ToUpper().Contains("ARDUINO"))
                    {
                        filteredPortNameList.Add(sPort);
                    }
                }

                if (filteredPortNameList.Count == 0)
                {
                    MessageBox.Show("No USB Serial Devices or Arduinos found. Please make sure the Arduino is plugged in.", "Arduino Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cbArduinoAddress.DataSource = filteredPortNameList;
                }

            }

        }


    }
}
