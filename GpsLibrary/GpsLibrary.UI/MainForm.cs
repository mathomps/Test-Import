using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GpsLibrary;


namespace GpsLibrary.UI
{
    public partial class MainForm : Form
    {

        private NmeaGps m_Gps;
        private DataLogger m_Logger;


        public MainForm()
        {
            InitializeComponent();

            m_Gps = new NmeaGps();
            m_Gps.PositionReceived += new NmeaGps.PositionReceivedDelegate(m_Gps_PositionReceived);

            m_Logger = new DataLogger("GpsLog.txt", m_Gps);
            m_Logger.Logging = true;
        }

        void m_Gps_PositionReceived(object sender, EventArgs e)
        {
            UpdateDebugText(m_Gps.LastString);
        }

        

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            m_Gps.Shutdown();
        }

        private void uxInitializeButton_Click(object sender, EventArgs e)
        {
            m_Gps.Initialize("COM1");
        }

     

        private delegate void UpdateDebugTextDelegate(string text);

        private void UpdateDebugText(string text)
        {

            if (uxDebugText.InvokeRequired)
            {
                Invoke(new UpdateDebugTextDelegate(UpdateDebugText), new object[] { text });
            }
            else
            {
                uxDebugText.Text += text;

                if (m_Gps.CurrentPosition != null)
                {
                    uxLatitudeLabel.Text = m_Gps.CurrentPosition.Latitude.ToString();
                    uxLongitudeLabel.Text = m_Gps.CurrentPosition.Longitude.ToString();
                }
                uxSpeedLabel.Text = m_Gps.CurrentSpeed.ToString("0.00");
                uxBearingLabel.Text = m_Gps.CurrentBearing.ToString("0") + "°";

                if (m_Gps.CurrentTime != null)
                {
                    uxTimeLabel.Text = m_Gps.CurrentTime.ToString();
                }

            }

        }

        private void uxClearButton_Click(object sender, EventArgs e)
        {
            uxDebugText.Text = "";
        }

        private void uxInitialiseMenuItem_Click(object sender, EventArgs e)
        {
            m_Gps.Initialize("COM1");
        }
        
    }
}