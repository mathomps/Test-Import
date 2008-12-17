using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor
{
    class Global
    {
        private static Data.MediaCatalogueDataContext m_DataContext;

        public static Data.MediaCatalogueDataContext DataContext
        {
            get
            {
                if (m_DataContext == null)
                {
                    m_DataContext = new Data.MediaCatalogueDataContext();
                }
                return m_DataContext;
            }
        }

    }
}
