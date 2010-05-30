using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryEditor.WPF.Models.MusicVideo
{
    public class MusicVideoRepository
    {

        public MusicVideoItem GetMusicVideoItem(Guid id)
        {
            var ent = new MediaCatalogueEntities();
            var mv = ent.Music_Track.Where(mt => mt.id == id).FirstOrDefault();

            if (mv == null) return null;

            mv.Media_ItemReference.Load();
            mv.Music_ArtistReference.Load();

            var result = new MusicVideoItem
                             {
                                 Id = mv.id,
                                 Name = mv.Media_Item == null ? string.Empty : mv.Media_Item.Title,
                                 Artist = mv.Music_Artist == null ? string.Empty : mv.Music_Artist.Name,
                                 PlayLength = mv.Duration.HasValue ? mv.Duration.Value : 0
                             };

            return result;

        }

        public IEnumerable<MusicVideoItem> SearchVideoItems(string filter)
        {
            var ent = new MediaCatalogueEntities();
            IQueryable<Guid> mvs;

            if (string.IsNullOrEmpty(filter))
            {
                mvs = from mv in ent.Music_Track.Include("Media_Item").Include("Music_Artist")
                      select mv.id;
            }
            else
            {
                mvs = from mv in ent.Music_Track.Include("Media_Item").Include("Music_Artist")
                      where mv.Music_Artist.Name.Contains(filter) ||
                            mv.Media_Item.Title.Contains(filter)
                      select mv.id;
            }
            
            var result = new List<MusicVideoItem>();

            foreach (var id in mvs)
            {
                result.Add(GetMusicVideoItem(id));
            }

            return result;
            //return mvs.Select(id => GetMusicVideoItem(id)).ToList();

        }


        public IEnumerable<Artist> GetArtists()
        {
            var ent = new MediaCatalogueEntities();
            return ent.Music_Artist.OrderBy(a => a.Name).Select(a => new Artist {Id = a.id, Name = a.Name}).ToList();
        }


    }
}
