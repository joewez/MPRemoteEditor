using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPRemoteEditor
{
    public class MPRemoteRoutines
    {
        public string COMM_PORT = "";
        public int BAUD_RATE = 115200;
        public int WAIT = 0;
        public bool DTR_ENABLED = false;

        private string _mpremote;
        private string _command_prefix;

        public MPRemoteRoutines()
        {
            string[] ports = SerialPort.GetPortNames();

            List<string> goodPorts = new List<string>();
            string exclusions = ConfigurationManager.AppSettings["CommPortExclusions"];
            string[] nums = exclusions.Split(',');
            foreach (string port in ports)
            {
                bool excluded = false;
                foreach (string portnum in nums)
                {
                    if (port == "COM" + portnum)
                    {
                        excluded = true;
                        break;
                    }
                }
                if (!excluded)
                    goodPorts.Add(port);
            }

            COMM_PORT = ConfigurationManager.AppSettings["CommPort"].Trim();
            if (COMM_PORT != "" && !COMM_PORT.ToUpper().StartsWith("COM"))
                COMM_PORT = "COM" + COMM_PORT;

            DTR_ENABLED = Utils.DecodeBoolean("DTREnable");
            

            if (!String.IsNullOrEmpty(COMM_PORT))
            {
                bool found = false;
                foreach (string port in goodPorts)
                {
                    if (port == COMM_PORT)
                    {
                        found = true;                        
                        break;
                    }
                }
                if (!found)
                {
                    GetComPort(goodPorts);
                }
            }
            else
            {
                if (goodPorts.Count() == 1)
                { 
                    //COMM_PORT = goodPorts[0];
                    GetComPort(goodPorts);
                }
                else
                {
                    GetComPort(goodPorts);
                }
            }

            string baudratestr = ConfigurationManager.AppSettings["BaudRate"];
            if (baudratestr != "")
                BAUD_RATE = Convert.ToInt32(baudratestr);

            string waitstr = ConfigurationManager.AppSettings["Wait"];
            if (waitstr != "")
                WAIT = Convert.ToInt32(waitstr);

            _mpremote = "mpremote";
            _command_prefix = "connect " + COMM_PORT + " ";

            CloseCommPort(COMM_PORT);
        }

        private void LogError(Exception ex)
        {
            string LogFile = Path.Combine(Application.ExecutablePath, "mpremote_errors.txt");
            using (StreamWriter sr = new StreamWriter(LogFile, true))
            {
                sr.WriteLine("EXCEPTION at " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss t"));
                sr.WriteLine("\t" + ex.Message);
                sr.WriteLine("\t" + ex.StackTrace);
                sr.WriteLine("\t" + ex.InnerException);
            }
        }

        private void GetComPort(List<string> ports)
        {
            SelectComForm s = new SelectComForm();
            ((ComboBox)s.Controls["cboPorts"]).Items.Clear();
            foreach (string port in ports.OrderBy(g => Convert.ToInt32(g.Substring(3))).ToArray())
                ((ComboBox)s.Controls["cboPorts"]).Items.Add(port);
            if (((ComboBox)s.Controls["cboPorts"]).Items.Count == 1)
                ((ComboBox)s.Controls["cboPorts"]).SelectedIndex = 0;
            ((CheckBox)s.Controls["chkDTREnabled"]).Checked = DTR_ENABLED;
            s.ShowDialog();
            COMM_PORT = s.SELECTED_COMM_PORT;
            DTR_ENABLED = s.DTR_ENABLED;
            s.Dispose();
        }

        void CloseCommPort(string PortName)
        {
            SerialPort sp = new SerialPort();
            sp.PortName = PortName;
            sp.Close();
        }

        public List<string> GetDir(string path, string LB, string RB)
        {
            List<string> dir = new List<string>();

            try
            {
                List<string> entries = new List<string>();

                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;                
                p.StartInfo.WorkingDirectory = Application.StartupPath;
                p.StartInfo.FileName = _mpremote;
                if (path == "")
                    p.StartInfo.Arguments = _command_prefix + "ls";
                else
                    p.StartInfo.Arguments = _command_prefix + "ls " + ((char)34).ToString() + path + ((char)34).ToString();
                p.StartInfo.RedirectStandardOutput = true;

                try
                {
                    p.Start();
                    p.OutputDataReceived += (sender, e) => entries.Add(e.Data);
                    p.BeginOutputReadLine();
                    p.WaitForExit();
                }
                catch (Exception ex2)
                {
                    LogError(ex2);
                }

                List<string> folders = new List<string>();
                List<string> files = new List<string>();

                foreach (string entry in entries)
                {
                    if (entry != null && entry != "" && !entry.StartsWith("ls"))
                    {
                        string nugget = entry.Trim();
                        if (nugget.EndsWith("/"))
                        {
                            nugget = nugget.Substring(0, nugget.Length - 1);
                            folders.Add(nugget.Substring(nugget.IndexOf(' ') + 1));
                        }
                        else
                            files.Add(nugget.Substring(nugget.IndexOf(' ') + 1));
                    }
                }

                foreach (string folder in folders.OrderBy(f => f).ToList())
                    dir.Add(LB + folder + RB);
                foreach (string file in files.OrderBy(f => f).ToList())
                    dir.Add(file);

            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return dir;
        }

        private void Execute(string command)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WorkingDirectory = Application.StartupPath;
                p.StartInfo.FileName = _mpremote;
                p.StartInfo.Arguments = _command_prefix + command;
                p.Start();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        public void GetFile(string devicefile, string localfile)
        {
            Execute("cp :" + devicefile + " " + localfile);
        }

        public void PutFile(string localfile, string devicefile)
        {
            Execute("cp " + localfile + " :" + devicefile);
        }

        public void DeleteFile(string devicefile)
        {
            Execute("rm :" + devicefile);
        }

        public void CreateDir(string NewDirectory)
        {
            Execute("mkdir " + NewDirectory);
        }

        public void DeleteDir(string DirectoryToDelete)
        {
            Execute("rmdir " + DirectoryToDelete);
        }

        public void SoftReset()
        {
            Execute("soft-reset");
        }

        public void MoveFile(string SrcFile, string DestFile)
        {
            string TempFile = Path.GetTempFileName();
            Execute("cp :" + SrcFile + " " + TempFile);
            Execute("cp " + TempFile + " :" + DestFile);
            Execute("rm :" + SrcFile);
            File.Delete(TempFile);
        }

        public string ListModules()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.StartInfo.FileName = _mpremote;
            p.StartInfo.Arguments = _command_prefix + "exec \"help('modules')\"";
            p.Start();
            string errors = p.StandardError.ReadToEnd();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            output = output.Replace("\r\n", " ").Replace("  ", " ");
            while (output.IndexOf("  ") > -1)
                output = output.Replace("  ", " ");
            output = output.Replace("Plus any modules on the filesystem", "");
            return output;
        }

        public string ExecuteOutput(string command)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.StartInfo.FileName = _mpremote;
            p.StartInfo.Arguments = _command_prefix + command;
            p.Start();
            string errors = p.StandardError.ReadToEnd();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }

        public List<string> GetDirTest(string path, string LB, string RB)
        {
            List<string> dir = new List<string>();

            try
            {
                string lscmd = "ls";
                if (path != "")
                    lscmd = "ls " + ((char)34).ToString() + path + ((char)34).ToString();
                string output = ExecuteOutput(lscmd);

                string[] entries = output.Replace("\r\n", "|").Split('|');

                List<string> folders = new List<string>();
                List<string> files = new List<string>();

                foreach (string entry in entries)
                {
                    if (entry != null && entry != "" && !entry.StartsWith("ls"))
                    {
                        string nugget = entry.Trim();
                        if (nugget.EndsWith("/"))
                        {
                            nugget = nugget.Substring(0, nugget.Length - 1);
                            folders.Add(nugget.Substring(nugget.IndexOf(' ') + 1));
                        }
                        else
                            files.Add(nugget.Substring(nugget.IndexOf(' ') + 1));
                    }
                }

                foreach (string folder in folders.OrderBy(f => f).ToList())
                    dir.Add(LB + folder + RB);
                foreach (string file in files.OrderBy(f => f).ToList())
                    dir.Add(file);

            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return dir;
        }


    }
}
