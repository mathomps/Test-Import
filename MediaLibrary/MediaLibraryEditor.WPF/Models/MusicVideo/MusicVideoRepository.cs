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


            // A MusicTrack should have a linked Music_Artist, Music_Genre, and Media_Item
            // A Media_Item should have a linked Media_File

            mv.Media_ItemReference.Load();
            mv.Music_ArtistReference.Load();

            //mv.Media_Item.

            var result = new MusicVideoItem
                             {
                                 Id = mv.id,
                                 Name = mv.Media_Item == null ? string.Empty : mv.Media_Item.Title,
                                 Artist = mv.Music_Artist == null ? string.Empty : mv.Music_Artist.Name,
                                 PlayLength = mv.Duration.HasValue ? mv.Duration.Value : 0
                             };

            // Get Media_File info
            if (mv.Media_Item != null)
            {
                mv.Media_Item.Media_FileReference.Load();
                var mediaFileInfo = mv.Media_Item.Media_File;
                if (mediaFileInfo != null)
                {
                    result.FileInfo = new MediaFileInfo
                                          {
                                              Filename = mediaFileInfo.Filename,
                                              ModifiedDate = mediaFileInfo.ModifiedDate,
                                              Size = mediaFileInfo.Size
                                          };
                }
            }

            return result;

        }

        public void UpdateMusicVideoItem(MusicVideoItem item)
        {
            var ent = new MediaCatalogueEntities();


            // Find existing Music_Track record
            var musicTrack = ent.Music_Track.Where(mt => mt.id == item.Id).FirstOrDefault();

            if (musicTrack == null)
            {
                musicTrack = new Music_Track();
                ent.AddToMusic_Track(musicTrack);
            }

            musicTrack.Duration = item.PlayLength;

            // Find/Create Media_Item record
            musicTrack.Media_ItemReference.Load();
            var mediaItem = musicTrack.Media_Item ?? new Media_Item();

            mediaItem.Title = item.Name;


            // Find/Create Artist record
            if (!string.IsNullOrEmpty(item.Artist))
            {
                var artist = ent.Music_Artist.Where(a => a.Name == item.Artist).FirstOrDefault();
            }


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
            return ent.Music_Artist.OrderBy(a => a.Name).Select(a => new Artist { Id = a.id, Name = a.Name }).ToList();
        }


    }
}
