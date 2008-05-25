using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace GpsLibrary
{
    public class NmeaGps
    {

        public delegate void PositionReceivedDelegate(object sender, EventArgs e);
        public event PositionReceivedDelegate PositionReceived;

        public delegate void GpsDataReceivedDelegate(object sender, EventArgs e);
        public event GpsDataReceivedDelegate GpsDataReceived;

        public delegate void GpsSentenceReceivedDelegate(object sender, EventArgs e);
        public event GpsSentenceReceivedDelegate GpsSentenceReceived;

        private SerialPort m_ComPort;
        private string m_LastStringReceived;
        private string m_PartialSentence;
        private string m_LastSentence;


        private Dictionary<int, Satellite> m_Satellites;

        private Position m_CurrentPosition;
        private float m_CurrentSpeed;
        private float m_CurrentBearing;
        private TimeSpan m_CurrentTime;

        #region --  P r o p e r t i e s  --

        public Dictionary<int, Satellite> Satellites
        {
            get { return m_Satellites; }
        }


        public Position CurrentPosition
        {
            get { return m_CurrentPosition; }
        }

        public float CurrentSpeed
        {
            get { return m_CurrentSpeed; }
        }

        public float CurrentBearing
        {
            get { return m_CurrentBearing; }
        }

        public TimeSpan CurrentTime
        {
            get { return m_CurrentTime; }
        }

        public string LastString
        {
            get { return m_LastStringReceived; }
        }


        #endregion

        #region --  P u b l i c   M e t h o d s  --

        public void Initialize(string portName)
        {

            m_ComPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            m_ComPort.Open();

            m_ComPort.DataReceived += new SerialDataReceivedEventHandler(m_ComPort_DataReceived);

        }

        public void Shutdown()
        {
            if (m_ComPort != null)
            {
                if (m_ComPort.IsOpen)
                {
                    m_ComPort.Close();
                }

                //m_ComPort.DiscardInBuffer();
                m_ComPort.Dispose();
                m_ComPort = null;
            }
        }

        #endregion

        void m_ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char[] readChars = new char[m_ComPort.BytesToRead];
            m_ComPort.Read(readChars, 0, readChars.Length);

            m_LastStringReceived = new string(readChars);

            BuildSentence(m_LastStringReceived);

            // We are looking for a 'Sentence'
            // Starts with '$' and ends with '*' + 2 digit hex checksum + CR + LF

            OnGpsDataReceived(EventArgs.Empty);

        }

        protected void BuildSentence(string stream)
        {
            int i = stream.IndexOf('\n');

            if (i > 0)
            {
                // Found the end of a sentence
                m_PartialSentence += stream.Substring(0, i);
                m_LastSentence = m_PartialSentence;
                m_PartialSentence = "";


                // Raise SentenceFound event
                // ToDo: The event should include the LastSentence (?)
                OnSentenceReceived(EventArgs.Empty);


                // Process the rest of the sentence
                if (i < stream.Length - 1)                      // Make sure that the LF is not the last character in the stream (otherwise there is nothing to do)
                {
                    BuildSentence(stream.Substring(i + 1));
                }
            }
            else
            {
                // No end in sight yet, just keep accumulating :-)
                m_PartialSentence += stream;
            }


        }

        protected virtual void OnSentenceReceived(EventArgs e)
        {
            // ToDo: Implement code here

            if (m_LastSentence.StartsWith("$"))
            {
                int checksumPosition = m_LastSentence.IndexOf("*");
                string checksum;

                if (checksumPosition > 0)
                {
                    checksum = m_LastSentence.Substring(checksumPosition + 1, 2);
                }

                string[] words = m_LastSentence.Substring(0,checksumPosition).Split(',');
                
                switch (words[0].ToUpper())
                {
                    case "$GPRMC":
                        ParseGprmcSentence(words);
                        break;

                    case "$GPGSV":
                        ParseGpgsvSentence(words);
                        break;

                    default:
                        break;
                }

                // Raise the event 
                if (GpsSentenceReceived != null)
                {
                    GpsSentenceReceived(this, e);
                }

            }
        }

        protected virtual void OnGpsDataReceived(EventArgs e)
        {
            if (GpsDataReceived != null)
            {
                GpsDataReceived(this, e);
            }
        }




        private void ParseGprmcSentence(string[] words)
        {
            // Current Time
            if ( (words[1] != "") && (words[1].Length >= 6) )
            {
                string time = words[1];
                //int hours = int.Parse(time.Substring(0, 2));
                //int minutes = int.Parse(time.Substring(2, 2));
                double seconds = double.Parse(time.Substring(4));
                int wholeSeconds = (int)Math.Floor(seconds);
                int milliseconds = (int)((seconds - wholeSeconds) * 100);
                m_CurrentTime = new TimeSpan(0, int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(2, 2)), wholeSeconds, milliseconds);
            }

            // Latitude and Longitude
            if ((words[3] != "") && (words[4] != "") && (words[5] != "") && (words[6] != ""))
            {
                Latitude lat = new Latitude(words[3], words[4]);
                Longitude lng = new Longitude(words[5], words[6]);
                m_CurrentPosition = new Position(lat, lng);
            }

            if (words[7] != "")
            {
                // Convert Knots to Km/h
                m_CurrentSpeed = (float)(float.Parse(words[7]) * 1.852);
            }

            if (words[8] != "")
            {
                m_CurrentBearing = float.Parse(words[8]);
            }

            OnPositionReceived(EventArgs.Empty);

        }

        protected virtual void OnPositionReceived(EventArgs e)
        {
            if (PositionReceived != null)
            {
                PositionReceived(this, e);
            }
        }


        private void ParseGpgsvSentence(string[] words)
        {


        }

    }
}
