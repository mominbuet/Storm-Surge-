using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WL_minus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string pathseperator = "\\";
        string FirstFilesEntries = "C:\\Users\\Gun2sh\\Desktop\\storm surge\\data\\Excess_WL\\2047\\", SecondFilesEntries = "C:\\Users\\Gun2sh\\Desktop\\Database\\WL\\2047";
        private void btnFirstClick(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                FirstFilesEntries = folderBrowserDialog1.SelectedPath;
                //FirstFilesEntries = Directory.GetFiles(path);
                 
            }
        }

        private void btnSecondClick(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                 SecondFilesEntries = folderBrowserDialog1.SelectedPath;
                //SecondFilesEntries = Directory.GetFiles(path);
                 
            }
        }
        public Dictionary<DateTime, double> getDataFromCSV(StreamReader reader)
        {

            Dictionary<DateTime, double> obs1 = new Dictionary<DateTime, double>();
            int i = 0;
            while (!reader.EndOfStream)
            {

                string line = reader.ReadLine();
                i++;
                if (i == 1) continue;

                string[] values = line.Split(',');

                DateTime tmpDate = DateTime.Parse(values[0]).Date;
                if (!obs1.ContainsKey(tmpDate))
                    obs1.Add(tmpDate, double.Parse(values[1]));
                else
                {
                    if (obs1[tmpDate] < double.Parse(values[1]))
                        obs1[tmpDate] = double.Parse(values[1]);
                }


            }
            return obs1;
        }
        private void btnGenerateClick(object sender, EventArgs e)
        {
            String savedir = "C:\\Users\\Gun2sh\\Desktop\\Camera";
            Dictionary<DateTime, double> resultsMap = new Dictionary<DateTime, double>();
            DialogResult result = folderBrowserDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                savedir = folderBrowserDialog1.SelectedPath;
            }
            try
            {
                
                string yearname = Path.GetFileName(Path.GetDirectoryName(FirstFilesEntries+pathseperator));
                if (Directory.Exists(savedir + pathseperator + yearname + pathseperator))
                {
                    Directory.Delete(savedir + pathseperator + yearname + pathseperator, true);
                }
                Directory.CreateDirectory(savedir + pathseperator + yearname + pathseperator);
                foreach (string stormName in Directory.GetDirectories(FirstFilesEntries))
                {
                    string strmname = Path.GetFileName(Path.GetDirectoryName(stormName + pathseperator));
                    if (Directory.Exists(savedir + pathseperator + yearname + pathseperator + strmname + pathseperator))
                    {
                        Directory.Delete(savedir + pathseperator + yearname + pathseperator + strmname + pathseperator, true);
                    }
                    Directory.CreateDirectory(savedir + pathseperator + yearname + pathseperator + strmname + pathseperator);
                    foreach (string firstDir in Directory.GetFiles(stormName))
                    {
                        //
                        StreamReader reader = new StreamReader(File.OpenRead(firstDir));
                        Dictionary<DateTime, double> obs1 = getDataFromCSV(reader);
                        lblyear.Text = obs1.Keys.ToList()[0].Year.ToString();
                        string filename = Path.GetFileName(firstDir);
                        if (File.Exists(SecondFilesEntries + pathseperator + filename))
                        {
                            StringBuilder csv = new StringBuilder();
                            csv.Append(String.Format("{0},{1}{2}", "date and time", "water level (m)", Environment.NewLine));
                            reader = new StreamReader(File.OpenRead(SecondFilesEntries + pathseperator + filename));
                            Dictionary<DateTime, double> obs2 = getDataFromCSV(reader);
                            foreach (DateTime dt in obs1.Keys)
                            {
                                double dtemp = obs1[dt] - obs2[dt];
                                if (!resultsMap.ContainsKey(dt))
                                    resultsMap.Add(dt, dtemp);
                                else
                                {
                                    if (resultsMap[dt] < dtemp)
                                        resultsMap[dt] = dtemp;
                                }
                            }
                            DateTime forhighestDT = DateTime.Now;
                            double val = 0.0;
                            foreach (DateTime dt in resultsMap.Keys)
                            {
                                if (chkHighest.Checked)
                                {
                                    if (val < resultsMap[dt]) {
                                        forhighestDT = dt;
                                        val = resultsMap[dt];
                                    }
                                }
                                else
                                    csv.Append(String.Format("{0},{1}{2}", dt.ToString("yyyy-MM-dd"), resultsMap[dt].ToString(), Environment.NewLine));
                            }
                            if (chkHighest.Checked) {
                                csv.Append(String.Format("{0},{1}{2}", forhighestDT.ToString("yyyy-MM-dd"), val.ToString(), Environment.NewLine));
                            }


                            File.WriteAllText(savedir + pathseperator + yearname + pathseperator +
                                strmname + pathseperator + filename, csv.ToString());
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
