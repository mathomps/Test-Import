using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using GpsLibrary;

namespace GpsLibrary.UI
{
    class DataLogger
    {

        private NmeaGps m_Gps;
        private string m_Filename;
        private bool m_Logging;


        public bool Logging
        {
            get { return m_Logging; }
            set { m_Logging = value; }
        }

        public DataLogger(string filename, NmeaGps gps)
        {
            m_Filename = filename;
            m_Gps = gps;

            // Write Header line
            WriteLine(string.Format("# GPS Logger started at {0}", DateTime.Now.ToString()));
            WriteLine("");
            WriteLine("Timestamp, Lat, Long, Speed, Bearing");

            // Listen for Frame Received
            m_Gps.PositionReceived += new NmeaGps.PositionReceivedDelegate(m_Gps_PositionReceived);
            
        }

        void m_Gps_PositionReceived(object sender, EventArgs e)
        {
            if (m_Logging && (m_Gps.CurrentPosition != null) && (m_Gps.CurrentTime != null))
            {
                WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}",
                                        m_Gps.CurrentTime.ToString(),
                                        m_Gps.CurrentPosition.Latitude.TotalMinutes,
                                        m_Gps.CurrentPosition.Longitude.TotalMinutes,
                                        m_Gps.CurrentSpeed,
                                        m_Gps.CurrentBearing));
            }
        }

        

        private void WriteLine(string output)
        {
            StreamWriter sw = new StreamWriter(m_Filename, true);
            sw.WriteLine(output);
            sw.Close();
        }





    }
}
