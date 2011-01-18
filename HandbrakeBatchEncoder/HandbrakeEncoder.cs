using System.ComponentModel;
using System.Diagnostics;
using System.IO;

using HandbrakeBatchEncoder.Properties;
using System.Threading;
using System.Windows.Forms;

namespace HandbrakeBatchEncoder
{
    class HandbrakeEncoder
    {

        string _sourceFile;
        string _destinationFile;

        #region --  Constructor  --

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

        #endregion

        #region --  Public methods  --

        public void EncodeFile(object sender, DoWorkEventArgs e)
        {
            BackgroundEncodeFile(sender as BackgroundWorker, e);
        }

        #endregion

        #region -- Private Methods  --

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
                        var fs = new FileStream(_sourceFile, FileMode.Open, FileAccess.Read, FileShare.None);
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

                var handbrake = new Process();
                var tempDestination = Path.ChangeExtension(_destinationFile, ".tmp");

                var filenameArgs = string.Format(" -i \"{0}\" -o \"{1}\"", _sourceFile, tempDestination);

                var startInfo = handbrake.StartInfo;
                startInfo.FileName = Settings.Default.HandbrakeCliPath;
                startInfo.WorkingDirectory = Path.GetDirectoryName(Settings.Default.HandbrakeCliPath);
                startInfo.Arguments = Settings.Default.EncodeSettings + filenameArgs;
                //startInfo.UseShellExecute = false;
                //startInfo.RedirectStandardError = true;


                handbrake.Start();
                if (!handbrake.HasExited)
                {
                    //handbrake.PriorityClass = ProcessPriorityClass.Idle;
                    handbrake.WaitForExit();
                }
                else
                {
                    //var error = handbrake.StandardError.ReadToEnd();
                }

                // Rename the output file to .avi (or original file extension)
                string originalDestExtension = Path.GetExtension(_destinationFile);
                if (File.Exists(tempDestination))
                {
                    File.Move(tempDestination, Path.ChangeExtension(tempDestination, originalDestExtension));

                    string moveToPath = Path.Combine(Settings.Default.WatchFolder, Settings.Default.CompletedInputFolder);

                    // Move the source file to a Completed subfolder
                    if (!Directory.Exists(moveToPath))
                    {
                        // Folder doesn't exist - try to create it
                        try
                        {
                            Directory.CreateDirectory(moveToPath);
                        }
                        catch (IOException)
                        { }
                    }

                    if (Directory.Exists(moveToPath))
                    {
                        File.Move(_sourceFile, Path.Combine(moveToPath, Path.GetFileName(_sourceFile)));
                    }
                }

                worker.ReportProgress(100);
            }

        }

        #endregion

    }
}
