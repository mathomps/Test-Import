using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MediaLibrary.WCF
{

    public class MusicVideoService : IMusicVideoService
    {

        private readonly Guid _musicVideoClipTypeId = new Guid("{4d578361-1bae-46ed-ab79-14fa368a0c76}");

        #region --  Artist  --

        public MusicArtist[] GetArtists()
        {
            var ent = new MediaCatalogueEntities();
            var artists = (from a in ent.Music_Artist
                           orderby a.Name
                           select new MusicArtist
                                      {
                                          id = a.id,
                                          Description = a.Name
                                      }).ToList();
            return artists.ToArray();
        }

        public void UpdateArtist(Guid id, string description)
        {
            var ent = new MediaCatalogueEntities();
            var artist = (from a in ent.Music_Artist
                          where a.id == id
                          select a).FirstOrDefault();

            if (artist != null)
            {
                artist.Name = description;
                ent.SaveChanges();
            }
        }

        public void AddArtist(Guid id, string description)
        {
            var ent = new MediaCatalogueEntities();
            var artist = new Music_Artist();
            artist.id = id;
            artist.Name = description;
            ent.AddToMusic_Artist(artist);
            ent.SaveChanges();
        }

        public void DeleteArtist(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region --  Genres  --

        public MusicGenre[] GetGenres()
        {
            var ent = new MediaCatalogueEntities();
            var genres = (from g in ent.Music_Genre
                          orderby g.Description
                          select new MusicGenre
                          {
                              id = g.id,
                              Description = g.Description
                          }).ToList();
            return genres.ToArray();
        }

        public void UpdateGenre(Guid id, string description)
        {
            var ent = new MediaCatalogueEntities();
            var genre = (from g in ent.Music_Genre
                         where g.id == id
                         select g).FirstOrDefault();
            if (genre != null)
            {
                genre.Description = description;
                ent.SaveChanges();
            }
        }

        public void AddGenre(Guid id, string description)
        {
            var ent = new MediaCatalogueEntities();
            var genre = new Music_Genre();
            genre.id = id;
            genre.Description = description;
            ent.AddToMusic_Genre(genre);
            ent.SaveChanges();
        }

        public void DeleteGenre(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region --  Video Clips  --

        public MusicVideoClip GetVideoClip(Guid id)
        {
            var ent = new MediaCatalogueEntities();

            var clip = (from c in ent.Music_Track.Include("Media_Item")
                                                 .Include("Music_Artist")
                                                 .Include("Music_Genre")
                        where c.Media_Item.id == id
                        select new MusicVideoClip
                                   {
                                       id = c.id,
                                       SongName = c.Media_Item.Title,
                                       Duration = c.Duration.HasValue ? c.Duration.Value : 0,
                                       Artist = c.Music_Artist.Name,
                                       Genre = c.Music_Genre.Description
                                   }).FirstOrDefault();
            return clip;
        }

        public MusicVideoClip[] SearchVideoClips(string filter)
        {
            throw new NotImplementedException();
        }

        public MusicVideoClip[] GetAllVideoClips()
        {
            throw new NotImplementedException();
        }

        public void UpdateVideoClip(MusicVideoClip clip)
        {
            var ent = new MediaCatalogueEntities();

            var vc = (from c in ent.Music_Track.Include("Media_Item")
                                               .Include("Music_Genre")
                                               .Include("Music_Artist")
                      where c.id == clip.id
                      select c).FirstOrDefault();
            if (vc != null)
            {
                vc.Media_Item.Title = clip.SongName;
                vc.Duration = clip.Duration;

                // ToDo: Find the right Genre and Artist entities, and update the references

                ent.SaveChanges();
            }

        }

        public void AddVideoClip(MusicVideoClip clip)
        {
            var ent = new MediaCatalogueEntities();

            var vc = new Music_Track();
            vc.id = clip.id;
            vc.Duration = clip.Duration;

            // ToDo: Find/Add the artist and Genre entities

            ent.AddToMusic_Track(vc);       // This will change when Genre and Artist are linked to this Music_Track (no need to Add the newly created entity).
        }

        public void DeleteVideoClip(Guid id)
        {
            throw new NotImplementedException();
        }

        public byte[] GetClipImage(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
