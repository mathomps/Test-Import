using System;
using System.Collections.Generic;
using System.Text;

namespace GpsLibrary
{
    public class Satellite
    {

        private int m_PRC;
        private int m_Elevation;
        private int m_Azumith;
        private int m_SignalStrength;

        #region --  C o n s t r u c t o r  --

        public Satellite(int prc, int elevation, int azumith, int signalStrength)
        {
            m_PRC = prc;
            m_Elevation = elevation;
            m_Azumith = azumith;
            m_SignalStrength = signalStrength;
        }

        #endregion 

        #region --  P r o p e r t i e s  --

        public int PRC
        {
            get { return m_PRC; }
        }

        public int Elevation
        {
            get { return m_Elevation; }
        }

        public int Azumith
        {
            get { return m_Azumith; }
        }

        public int SignalStrength
        {
            get { return m_SignalStrength; }
        }

        #endregion

    }
}
