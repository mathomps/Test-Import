using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using HandbrakeBatchEncoder.Properties;

namespace HandbrakeBatchEncoder
{
    public partial class MainForm : Form
    {
        #region --  Private Fields  --

        private readonly Regex _supportedSourceFileExtensions = new Regex(@"\.(avi|mpg|mpeg)$");

        private delegate void UpdateEncodeQueueListDelegate();

        private FileSystemWatcher _sourceFolderWatcher;
        private readonly List<string> _encodeQueueFiles = new List<string>();
        private readonly BackgroundWorker _encoderWorker = new BackgroundWorker { WorkerReportsProgress = true };
        private readonly HandbrakeEncoder _encoder = new HandbrakeEncoder();

        #endregion

        #region --  Constructor  --

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region -- Form Events  --

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup watch on folder for file creations
            _sourceFolderWatcher = new FileSystemWatcher(Settings.Default.WatchFolder) { EnableRaisingEvents = true };
            _sourceFolderWatcher.Created += _sourceFolderWatcher_Created;

            // Update source path label
            uxWatchFolderNameLabel.Text = Settings.Default.WatchFolder;

            // Hook up Background Worker Events
            // _encoderWorker.ProgressChanged += _encoderWorker_ProgressChanged;
            _encoderWorker.RunWorkerCompleted += _encoderWorker_RunWorkerCompleted;
            _encoderWorker.DoWork += _encoder.EncodeFile;

            // Look for any existing files in folder
            var di = new DirectoryInfo(Settings.Default.WatchFolder);
            var fi = di.GetFiles();

            foreach (var fileInfo in fi)
            {
                AddFileToQueue(fileInfo.FullName);
            }

            CheckAndQueueEncoderTask();
        }

        #endregion

        #region --  Private Methods  --

        /// <summary>
        /// Checks if the HandbrakeEncoder is available to immediately start
        /// encoding the next file. If it is not, nothing is done until the
        /// encoder is no longer busy.
        /// </summary>
        private void CheckAndQueueEncoderTask()
        {
            UpdateEncodeQueueList();

            if (_encoderWorker.IsBusy || _encodeQueueFiles.Count == 0)
            {
                return;
            }

            // Start encoding the next file in the queue
            var sourceFile = _encodeQueueFiles[0];
            var destinationFile = Path.Combine(Settings.Default.OutputFolder,
                                                  Path.GetFileNameWithoutExtension(sourceFile));
            destinationFile = Path.ChangeExtension(destinationFile, ".m4v");

            _encoder.SourceFilename = sourceFile;
            _encoder.DestinationFilename = destinationFile;
            _encoderWorker.RunWorkerAsync();

            //UpdateEncodeQueueList();

            //_encodeQueueFiles.RemoveAt(0);
        }

        /// <summary>
        /// Updates the pending list of files to be encoded in the UI.
        /// </summary>
        private void UpdateEncodeQueueList()
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateEncodeQueueListDelegate(UpdateEncodeQueueList));
                return;
            }

            uxEncodeQueueListView.Items.Clear();
            foreach (var file in _encodeQueueFiles)
            {
                uxEncodeQueueListView.Items.Add(Path.GetFileName(file));
            }

            uxNowEncodingFile.Text = _encodeQueueFiles.Count > 0 ? Path.GetFileName(_encodeQueueFiles[0]) : "";

        }

        /// <summary>
        /// Adds a new file to the Encoder queue.
        /// </summary>
        /// <param name="filename"></param>
        private void AddFileToQueue(string filename)
        {
            // Make sure file is of a supported type.
            if (!_supportedSourceFileExtensions.IsMatch(filename))
                return;
            if (_encodeQueueFiles.Contains(filename))
                return;
            _encodeQueueFiles.Add(filename);
        }

        #endregion

        #region --  FileSystemWatcher Events --

        void _sourceFolderWatcher_Created(object sender, FileSystemEventArgs e)
        {
            AddFileToQueue(e.FullPath);
            CheckAndQueueEncoderTask();
        }

        #endregion

        #region --  Background Worker Events  --

        void _encoderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Pop the completed job off the queue
            if (_encodeQueueFiles.Count > 0)
            {
                _encodeQueueFiles.RemoveAt(0);
            }

            // See if there's another item in the queue to encode
            CheckAndQueueEncoderTask();
        }

        //void _encoderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{

        //}

        #endregion

    }
}
