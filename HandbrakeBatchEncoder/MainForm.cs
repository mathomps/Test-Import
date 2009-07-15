using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HandbrakeBatchEncoder.Properties;

namespace HandbrakeBatchEncoder
{
    public partial class MainForm : Form
    {
        FileSystemWatcher _sourceFolderWatcher;
        List<string> _encodeQueueFiles = new List<string>();

        delegate void UpdateEncodeQueueListDelegate();
        BackgroundWorker _encoderWorker = new BackgroundWorker();
        HandbrakeEncoder _encoder = new HandbrakeEncoder();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup watch on folder for file creations
            _sourceFolderWatcher = new FileSystemWatcher(Settings.Default.WatchFolder, "*.mpg");
            _sourceFolderWatcher.EnableRaisingEvents = true;

            _sourceFolderWatcher.Created += new FileSystemEventHandler(_sourceFolderWatcher_Created);

            // Update source path label
            uxWatchFolderNameLabel.Text = Settings.Default.WatchFolder;


            // Hook up Background Worker Events
            _encoderWorker.ProgressChanged += new ProgressChangedEventHandler(_encoderWorker_ProgressChanged);
            _encoderWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_encoderWorker_RunWorkerCompleted);
            _encoderWorker.DoWork += _encoder.EncodeFile;


            // Look for any existing files in folder
            var di = new DirectoryInfo(Settings.Default.WatchFolder);
            var fi = di.GetFiles("*.mpg");

            foreach (var fileInfo in fi)
            {
                _encodeQueueFiles.Add(fileInfo.FullName);
            }

            CheckAndQueueEncoderTask();
        }


        #region "--  Private Methods  --"

        private void CheckAndQueueEncoderTask()
        {
            if (!_encoderWorker.IsBusy)
            {
                if (_encodeQueueFiles.Count > 0)
                {
                    string sourceFile = _encodeQueueFiles[0];
                    string destinationFile = Path.Combine(Settings.Default.OutputFolder, Path.GetFileNameWithoutExtension(sourceFile));
                    destinationFile = Path.ChangeExtension(destinationFile, ".avi");


                    _encoder.SourceFile = sourceFile;
                    _encoder.DestinationFile = destinationFile;
                    //var enc = new HandbrakeEncoder(sourceFile, destinationFile);
                    //_encoderWorker.DoWork += enc.EncodeFile;
                    _encoderWorker.RunWorkerAsync();

                    UpdateEncodeQueueList();

                    _encodeQueueFiles.RemoveAt(0);
                }
                else
                {
                    UpdateEncodeQueueList();
                }

            }
            else
            {
                UpdateEncodeQueueList();
            }

        }

        private void UpdateEncodeQueueList()
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateEncodeQueueListDelegate(UpdateEncodeQueueList));
            }
            else
            {
                uxEncodeQueueListView.Items.Clear();
                foreach (var file in _encodeQueueFiles)
                {
                    uxEncodeQueueListView.Items.Add(Path.GetFileName(file));
                }

                if (_encodeQueueFiles.Count > 0)
                {
                    uxNowEncodingFile.Text = _encodeQueueFiles[0];
                }
                else
                {
                    uxNowEncodingFile.Text = "";
                }

            }
        }

        #endregion

        #region "--  FileSystemWatcher Events --"

        void _sourceFolderWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!_encodeQueueFiles.Contains(e.FullPath))
            {
                _encodeQueueFiles.Add(e.FullPath);
                CheckAndQueueEncoderTask();
            }

        }

        #endregion

        #region "--  Background Worker Events  --"

        void _encoderWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Worker has comleted, so see if there's another item in the queue to encode
            CheckAndQueueEncoderTask();
        }

        void _encoderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        #endregion

    }
}
