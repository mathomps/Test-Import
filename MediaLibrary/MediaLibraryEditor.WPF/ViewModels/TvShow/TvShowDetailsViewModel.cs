﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MediaLibraryEditor.WPF.Models;
using System.Collections.ObjectModel;
using MediaLibraryEditor.WPF.Commands;
using System.Windows.Input;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    public class TvShowDetailsViewModel : ViewModelBase
    {

        private MediaCatalogueEntities _ctx;
        private Media_Item _tvShow;

        #region --  Constructor  --

        public TvShowDetailsViewModel(Guid tvShowId)
        {
            _ctx = new MediaCatalogueEntities();


            _tvShow = (from media in _ctx.Media_Item
                       where media.id == tvShowId
                       select media).FirstOrDefault();

            Title = _tvShow.Title;
            Description = _tvShow.Description;


            var segmentIds = from seg in _ctx.Media_Segment
                           where seg.Media_Item.id == tvShowId
                           orderby seg.SectionOffset
                           select seg.id;

            Segments = new ObservableCollection<TvShowSegment>();

            foreach (var seg in segmentIds)
            {
                Segments.Add(new TvShowSegment(seg));
            }

        }

        #endregion

        #region --  Commands  --

        private DelegateCommand _addSegmentCommand;
        private DelegateCommand _deleteSegmentCommand;

        public ICommand AddSegmentCommand
        {
            get
            {
                if (_addSegmentCommand == null)
                {
                    _addSegmentCommand = new DelegateCommand(AddSegment);
                }
                return _addSegmentCommand;
            }
        }

        public ICommand DeleteSegmentCommand
        {
            get
            {
                if (_deleteSegmentCommand == null)
                {
                    _deleteSegmentCommand = new DelegateCommand(DeleteSegment, CanDeleteSegment);
                }
                return _deleteSegmentCommand;
            }
        }

        private void AddSegment()
        {
            var seg = TvShowSegment.NewSegment(_tvShow.id);
            Segments.Add(seg);
            SelectedSegment = seg;
        }


        private bool CanDeleteSegment()
        {
            return SelectedSegment != null;
        }

        private void DeleteSegment()
        {

            SelectedSegment.DeleteCommand.Execute(null);

            // Remove from the Segments collection
            Segments.Remove(SelectedSegment);

        }

        #endregion

        #region --  Properties  --

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) { return; }
                _title = value;
                OnPropertyChanged("Title");
            }
        }


        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) { return; }
                _description = value;
                OnPropertyChanged("Description");
            }
        }


        private ObservableCollection<TvShowSegment> _segments;

        public ObservableCollection<TvShowSegment> Segments
        {
            get { return _segments; }
            set
            {
                if (value == _segments) { return; }
                _segments = value;
                OnPropertyChanged("Segments");
            }
        }


        private TvShowSegment _selectedSegment;

        public TvShowSegment SelectedSegment
        {
            get { return _selectedSegment; }
            set
            {
                if (value == _selectedSegment) { return; }
                _selectedSegment = value;
                OnPropertyChanged("SelectedSegment");
            }
        }



        #endregion

    }

}
