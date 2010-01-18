using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MediaLibraryEditor.WPF.Commands;
using MediaLibraryEditor.WPF.Models;
using System.Collections.ObjectModel;

namespace MediaLibraryEditor.WPF.ViewModels.TvShow
{
    class TvShowsViewModel : OperationViewModel
    {
        MediaCatalogueEntities _ctx;
        Guid _seriesID;


        #region --  Constructor  --

        //public TvShowsViewModel()
        //{
        //    // Get the list of TV shows
        //    _ctx = new MediaCatalogueEntities();

        //    var tvShowType = MediaCatalogueHelper.GetTvShowType(_ctx);

        //    var showIds = from mediaItem in _ctx.Media_Item
        //                  where mediaItem.Media_Type.id == tvShowType.id
        //                  select mediaItem.id;


        //    //var shows = from mediaItem in _ctx.Media_Item.Include("Tv_SeriesMedia")
        //    //            where mediaItem.TV_SeriesMedia.Count > 0
        //    //            select mediaItem;

        //    foreach (var id in showIds)
        //    {
        //        TvShows.Add(new TvShowViewModel(id));
        //    }

        //}

        /// <summary>
        /// Creates a new instance of the TvShowsViewModel for a particular Series.
        /// </summary>
        /// <param name="seriesId"></param>
        public TvShowsViewModel(Guid seriesId)
        {
            _ctx = new MediaCatalogueEntities();

            SeriesID = seriesId;

            var tvShowType = MediaCatalogueHelper.GetTvShowType(_ctx);

            //var showIds = from mediaItem in _ctx.Media_Item
            //              where mediaItem.Media_Type.id == tvShowType.id
            //              select mediaItem.id;

            var showIds = from seriesMedia in _ctx.TV_SeriesMedia
                                                  .Include("Media_Item")
                                                  .Include("TV_Series")
                          where seriesMedia.TV_Series.id == SeriesID
                          select seriesMedia.Media_Item.id;


            //var shows = from mediaItem in _ctx.Media_Item.Include("Tv_SeriesMedia")
            //            where mediaItem.TV_SeriesMedia.Count > 0
            //            select mediaItem;

            TvShows = new ObservableCollection<TvShow>();

            foreach (var id in showIds)
            {
                TvShows.Add(new TvShow(id));
            }

        }

        #endregion

        #region --  ICommand  --

        private DelegateCommand _addCommand;

        public ICommand AddShowCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(AddShow, CanAddShow);
                }
                return _addCommand;
            }
        }

        private bool CanAddShow()
        {
            return true;
        }

        private void AddShow()
        {
            var newShow = TvShow.NewTvShow(SeriesID);
            TvShows.Add(newShow);
            SelectedShow = newShow;
        }


        private DelegateCommand _deleteShowCommand;

        public ICommand DeleteShowCommand
        {
            get
            {
                if (_deleteShowCommand == null)
                {
                    _deleteShowCommand = new DelegateCommand(DeleteShow, CanDeleteShow);
                }
                return _deleteShowCommand;
            }
        }

        private bool CanDeleteShow()
        {
            return SelectedShow != null && SelectedShow.DeleteCommand.CanExecute(null);
        }

        private void DeleteShow()
        {
            SelectedShow.DeleteCommand.Execute(null);
            TvShows.Remove(SelectedShow);
            SelectedShow = null;
        }


        private DelegateCommand _saveShowCommand;

        public ICommand SaveShowCommand
        {
            get
            {
                if (_saveShowCommand == null)
                {
                    _saveShowCommand = new DelegateCommand(SaveShow, CanSaveShow);
                }
                return _saveShowCommand;
            }
        }

        private bool CanSaveShow()
        {
            return SelectedShow != null && SelectedShow.UpdateCommand.CanExecute(null);
        }

        private void SaveShow()
        {
            SelectedShow.UpdateCommand.Execute(null);
        }



        private DelegateCommand _editSegmentsCommand;

        public ICommand EditSegmentsCommand
        {
            get
            {
                if (_editSegmentsCommand == null)
                {
                    _editSegmentsCommand = new DelegateCommand(EditSegments, CanEditSegments);
                }
                return _editSegmentsCommand;
            }
        }

        private bool CanEditSegments()
        {
            return SelectedShow != null && SelectedShow.EditSegmentsCommand.CanExecute(null);
        }

        private void EditSegments()
        {
            SelectedShow.EditSegmentsCommand.Execute(null);
        }

        #endregion

        #region --  Properties  --

        public override string Title
        {
            get { return "TV - Edit Shows"; }
        }

        private TvShow _selectedShow;

        public TvShow SelectedShow
        {
            get { return _selectedShow; }
            set
            {
                if (value == _selectedShow) { return; }
                _selectedShow = value;
                OnPropertyChanged("SelectedShow");
            }
        }

        private ObservableCollection<TvShow> _tvShows;

        public ObservableCollection<TvShow> TvShows
        {
            get { return _tvShows; }
            set
            {
                if (value == _tvShows) { return; }
                _tvShows = value;
                OnPropertyChanged("TvShows");
            }
        }

        public Guid SeriesID
        {
            get { return _seriesID; }
            private set
            {
                _seriesID = value;
            }
        }

        #endregion

    }
}
