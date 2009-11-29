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

            foreach (var id in showIds)
            {
                TvShows.Add(new TvShowViewModel(id));
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
            var newShow = new TvShowViewModel(Guid.Empty);
            newShow.SeriesID = SeriesID;
            TvShows.Add(newShow);
            SelectedShow = newShow;
        }

        #endregion

        #region --  Properties  --

        public override string Title
        {
            get
            {
                return "TV - Edit Shows";
            }
        }

        private TvShowViewModel _selectedShow;

        public TvShowViewModel SelectedShow
        {
            get { return _selectedShow; }
            set
            {
                if (value != _selectedShow)
                {
                    _selectedShow = value;
                    OnPropertyChanged("SelectedShow");
                }
            }
        }


        private ObservableCollection<TvShowViewModel> _tvShows = new ObservableCollection<TvShowViewModel>();

        public ObservableCollection<TvShowViewModel> TvShows
        {
            get { return _tvShows; }
            set
            {
                if (value != _tvShows)
                {
                    _tvShows = value;
                    OnPropertyChanged("TvShows");
                }
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
