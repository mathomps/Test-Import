using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MediaLibrary.WCF
{

    [ServiceContract]
    public interface IMusicVideoService
    {

        #region --  Artists  --

        /// <summary>
        /// Gets all music video clip artist names, sorted alphabetically.
        /// </summary>
        [OperationContract]
        MusicArtist[] GetArtists();

        [OperationContract]
        void UpdateArtist(Guid id, string description);

        [OperationContract]
        void AddArtist(Guid id, string description);

        [OperationContract]
        void DeleteArtist(Guid id);

        #endregion

        #region --  Genres  --

        [OperationContract]
        MusicGenre[] GetGenres();

        [OperationContract]
        void UpdateGenre(Guid id, string description);

        [OperationContract]
        void AddGenre(Guid id, string description);

        [OperationContract]
        void DeleteGenre(Guid id);

        #endregion

        #region --  Video Clip  --

        /// <summary>
        /// Gets a single video clip, identified by its unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        MusicVideoClip GetVideoClip(Guid id);

        [OperationContract]
        MusicVideoClip[] SearchVideoClips(string filter);

        [OperationContract]
        MusicVideoClip[] GetAllVideoClips();

        [OperationContract]
        void UpdateVideoClip(MusicVideoClip clip);

        [OperationContract]
        void AddVideoClip(MusicVideoClip clip);

        [OperationContract]
        void DeleteVideoClip(Guid id);

        [OperationContract]
        byte[] GetClipImage(Guid id);

        #endregion

    }

}
