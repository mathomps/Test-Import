using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Models;


namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    public class TvShowSegmentViewModel : ViewModelBase
    {

        // This class wraps the Models.TvShowSegment class to make it more
        // friendly for binding to the UI

        private TvShowSegment _model;



        public TvShowSegmentViewModel(Guid seriesID)
        {
            _model = new TvShowSegment(seriesID);

            _startOffset = (new TimeSpan(_model.StartOffset.Value)).ToString();

        }

        #region --  Properties  --

        private string _startOffset;

        public string StartOffset
        {
            get { return _startOffset; }
            set
            {
                if (value == _startOffset) { return; }
                _startOffset = value;
                
                OnPropertyChanged("StartOffset");
            }
        }
        
        private string SegmentLength;

        public string MyProperty
        {
            get { return SegmentLength; }
            set
            {
                if (value == SegmentLength) { return; }
                SegmentLength = value;
                OnPropertyChanged("MyProperty");
            }
        }


        #endregion


        #region --  Private Methods  --

        


        #endregion

    }
}
