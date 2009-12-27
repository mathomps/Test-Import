using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models
{
    class MediaCatalogueHelper
    {

        private static readonly Guid _musicVideoClipId = new Guid("{4d578361-1bae-46ed-ab79-14fa368a0c76}");
        private static readonly Guid _tvShowId = new Guid("{10a31cd6-86a2-473e-80aa-548c8ec7d16e}");

        public static Media_Type GetMusicVideoType(MediaCatalogueEntities ctx)
        {
            return (from mt in ctx.Media_Type
                    where mt.id == _musicVideoClipId
                    select mt).FirstOrDefault();
        }

        public static Media_Type GetTvShowType(MediaCatalogueEntities ctx)
        {
            return (from mt in ctx.Media_Type
                    where mt.id == _tvShowId
                    select mt).FirstOrDefault();
        }

        public static List<TvSeriesCategory> GetTvSeriesCategories(Guid tvSeriesId, MediaCatalogueEntities ctx)
        {

            var categoryIds = from category in ctx.TV_SeriesCategory
                              where category.TV_Series.id == tvSeriesId
                              orderby category.Title
                              select category.id;

            var categoriesList = new List<TvSeriesCategory>();

            foreach (var cId in categoryIds)
            {
                categoriesList.Add(new TvSeriesCategory(cId));
            }

            return categoriesList;

            //return (from sc in ctx.TV_SeriesCategory
            //        where sc.TV_Series.id == tvSeriesId
            //        orderby sc.Title
            //        select sc).ToList();
        }


        public static List<TvSeriesPresenter> GetTvSeriesPresenters(Guid tvSeriesId, MediaCatalogueEntities ctx)
        {

            var presenterIds = from presenter in ctx.TV_Presenter
                               where presenter.TV_Series.id == tvSeriesId
                               orderby presenter.Name
                               select presenter.id;
            var presentersList = new List<TvSeriesPresenter>();

            foreach (var pId in presenterIds)
            {
                presentersList.Add(new TvSeriesPresenter(pId));
            }

            return presentersList;

            //return (from pres in ctx.TV_Presenter
            //        where pres.TV_Series.id == tvSeriesId
            //        orderby pres.Name
            //        select pres).ToList();
        }

    }
}
