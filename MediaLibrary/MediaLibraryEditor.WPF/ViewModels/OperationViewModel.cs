using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.ViewModels
{
    /// <summary>
    /// Base class for which all top-level operation ViewModels should derive.
    /// </summary>
    public class OperationViewModel : ViewModelBase
    {

        public virtual string Title
        {
            get { throw new NotImplementedException(); }
        }

    }
}
