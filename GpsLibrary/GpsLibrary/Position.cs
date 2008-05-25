using System;
using System.Collections.Generic;
using System.Text;

namespace GpsLibrary
{
    public class Position
    {
        private Latitude m_Latitude;
        private Longitude m_Longitude;

        #region --  P r o p e r t i e s  --

        public Latitude Latitude
        {
            get { return m_Latitude; }
            set { m_Latitude = value; }
        }

        public Longitude Longitude
        {
            get { return m_Longitude; }
            set { m_Longitude = value; }
        }

        #endregion

        #region --  C o n s t r u c t o r  --

        public Position()
        {
        }

        public Position(Latitude latitude, Longitude longitude)
        {
            m_Latitude = latitude;
            m_Longitude = longitude;
        }

        #endregion

        #region --  P u b l i c   M e t h o d s  --

        public override string ToString()
        {
            return String.Format("{0}, {1}", m_Latitude, m_Longitude);
        }

        #endregion
    
    }
}
