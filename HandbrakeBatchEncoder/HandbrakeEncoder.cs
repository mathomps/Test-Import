using System.ComponentModel;
using System.Diagnostics;
using System.IO;

using HandbrakeBatchEncoder.Properties;
using System.Threading;

namespace HandbrakeBatchEncoder
{
    class HandbrakeEncoder
    {

        string _sourceFile;
        string _destinationFile;

        public HandbrakeEncoder()
        {
        }

        //public HandbrakeEncoder(string sourceFile, string destinationFile)
        //{
        //    _sourceFile = sourceFile;
        //    _destinationFile = destinationFile;
        //}


        public string SourceFile
        {
            get { return _sourceFile; }
            set { _sourceFile = value; }
        }

        public string DestinationFile
        {
            get { return _destinationFile; }
            set { _destinationFile = value; }
        }



        public void EncodeFile(object sender, DoWorkEventArgs e)
        {
            BackgroundEncodeFile(sender as BackgroundWorker, e);
        }



        private void BackgroundEncodeFile(BackgroundWorker worker, DoWorkEventArgs e)
        {
            // Make sure source file exists, but destination file doesn't (don't overwrite existing file)
            if (File.Exists(_sourceFile) && (!File.Exists(_destinationFile)))
            {
                // Wait for file to become readable...
                while (true)
                {
                    try
                    {
                        FileStream fs = new FileStream(_sourceFile, FileMode.Open, FileAccess.Read, FileShare.None);
                        fs.Close();
                        break;
                    }
                    catch (FileNotFoundException)
                    {
                        throw;
                    }
                    catch (IOException exc)
                    {
                        Thread.Sleep(1000);
                    }
                }


                // Encode the file

                Process handbrake = new Process();
                string tempDestination = Path.ChangeExtension(_destinationFile, ".tmp");

                string filenameArgs = string.Format(" -i \"{0}\" -o \"{1}\"", _sourceFile, tempDestination);

                var startInfo = handbrake.StartInfo;
                startInfo.FileName = Settings.Default.HandbrakeCliPath;
                startInfo.WorkingDirectory = Path.GetDirectoryName(Settings.Default.HandbrakeCliPath);
                startInfo.Arguments = Settings.Default.EncodeSettings + filenameArgs;

                handbrake.Start();
                handbrake.PriorityClass = ProcessPriorityClass.Idle;
                handbrake.WaitForExit();

                // Rename the output file to .avi (or original file extension)
                string originalDestExtension = Path.GetExtension(_destinationFile);
                File.Move(tempDestination, Path.ChangeExtension(tempDestination, originalDestExtension));

                string moveToPath = Path.Combine(Settings.Default.WatchFolder, Settings.Default.CompletedInputFolder);

                // Move the source file to a Completed subfolder
                File.Move(_sourceFile, Path.Combine(moveToPath, Path.GetFileName(_sourceFile)));

            }



        }

    }
}
