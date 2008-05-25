using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GpsLibrary
{
    public class Latitude
    {

        private double m_TotalMinutes;     // Positive values are North, negative are South of equator
        
        private int m_Degrees;
        private double m_Minutes;
        private bool m_IsNorth;

        #region --  C o n s t r u c t o r  --

        /// <summary>
        /// Creates a new Latitude object from a NMEA string representation of a Latitude coordinate
        /// </summary>
        /// <param name="offset">NMEA compressed Latitude string e.g. '0012.3456'</param>
        /// <param name="direction">Direction, either 'N' or 'S' of the equator</param>
        public Latitude(string offset, string direction)
        {
            // Offset should be in format 'DDMM.MMMM' (degrees, minutes)

            Regex re = new Regex(@"^(?<Degrees>\d{2,3})(?<Minutes>\d{2}(?:.\d{1,})?)$");
            Match m = re.Match(offset);

            if (m.Success)
            {
                m_Degrees = int.Parse(m.Groups["Degrees"].Value);
                m_Minutes = double.Parse(m.Groups["Minutes"].Value);

                // Validation: Max Degrees is 90.0, Minutes can't be > 60.0
                bool valid = true;

                if (m_Degrees > 89)
                {
                    if (m_Degrees == 90)
                    {
                        if (m_Minutes > 0)
                        {
                            // Fail
                            valid = false;
                        }
                    }
                    else
                    {
                        // Instant fail (Degrees > 90)
                        valid = false;
                    }
                }

                if (m_Minutes >= 60)
                {
                    valid = false;
                }

                if (!valid)
                {
                    throw new ArgumentOutOfRangeException("offset", "The specified offset is not within valid bounds.");
                }


                m_TotalMinutes = (m_Degrees * 60) + m_Minutes;


                switch (direction.ToLower())
                {
                    case "n":
                        m_IsNorth = true;
                        break;

                    case "s":
                        m_TotalMinutes = -m_TotalMinutes;
                        m_IsNorth = false;
                        break;

                    default:
                        break;
                }

            }
            else
            {
                throw new ArgumentException("offset", "The offset specified is not in a valid format.");
            }

        }

        #endregion

        #region --  P r o p e r t i e s  --

        public double TotalMinutes
        {
            get { return m_TotalMinutes; }
        }

        public int Degrees
        {
            get { return m_Degrees; }
        }

        public double Minutes
        {
            get { return m_Minutes; }
        }

        public bool IsNorth
        {
            get { return m_IsNorth; }
        }

        #endregion

        #region --  P u b l i c   M e t h o d s  --

        public override string ToString()
        {
            string direction;

            if (m_IsNorth)
            {
                direction = "N";
            }
            else
            {
                direction = "S";
            }

            return string.Format("{0}°{1}'{2}", m_Degrees, m_Minutes, direction);

        }

        #endregion

    }
}
