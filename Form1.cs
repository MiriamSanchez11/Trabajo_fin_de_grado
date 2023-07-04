using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BrainLinkSDK_Windows;
using System.Threading;
using System.IO;
using BrainLinkConnect.Modelo;



namespace BrainLinkConnect
{

    public partial class Form1 : Form
    {
        private BrainLinkSDK brainLinkSDK;
        Dictionary<string, object> variables = new Dictionary<string, object>();
        private string elementoSeleccionado;
        //private Form2 Form2;

        private float ave = 0;

        private List<int> raw = new List<int>();

        private List<float> hrvList = new List<float>();

        private List<double> lastHRV = new List<double>();

        private List<(long, string)> Devices = new List<(long, string)>();
        public string nombrearchivo;
        public Form1(string elementoSeleccionado)
        {
            InitializeComponent();
            this.elementoSeleccionado = elementoSeleccionado;
            brainLinkSDK = new BrainLinkSDK();
            brainLinkSDK.OnEEGDataEvent += new BrainLinkSDKEEGDataEvent(BrainLinkSDK_OnEEGDataEvent);
            brainLinkSDK.OnEEGExtendEvent += new BrainLinkSDKEEGExtendDataEvent(BrainLinkSDK_OnEEGExtendDataEvent);
            brainLinkSDK.OnGyroDataEvent += new BrainLinkSDKGyroDataEvent(BrainLinkSDK_OnGyroDataEvent);
            brainLinkSDK.OnHRVDataEvent += new BrainLinkSDKHRVDataEvent(BrainLinkSDK_OnHRVDataEvent);
            brainLinkSDK.OnRawDataEvent += new BrainLinkSDKRawDataEvent(BrainLinkSDK_OnRawDataEvent);
            brainLinkSDK.OnDeviceFound += new BrainLinkSDKOnDeviceFoundEvent(BrainLinkSDK_OnDeviceFoundEvent);
        }

        private void BrainLinkSDK_OnDeviceFoundEvent(long Address, string Name)
        {
            Debug.WriteLine("Discover name " + Name);
            listBox1.Items.Add(Name + " : " + Address.ToString("X12"));
            Devices.Add((Address, Name));
        }        

        private void BrainLinkSDK_OnRawDataEvent(int Raw)
        {
            raw.Add(Raw);
            if (raw.Count > 512)
            {
                raw.Remove(raw[0]);
            }
            chart1.Series[0].Points.DataBindY(raw);
        }

        private void BrainLinkSDK_OnHRVDataEvent(int[] HRV, int Blink)
        {
            for (int i = 0; i < HRV.Length; i++)
            {
                hrvBox.Text += HRV[i] + "ms ";
                hrvList.Add(HRV[i]);
            }
            if (hrvList.Count >= 60)
            {
                double hrv = StandardDiviation(hrvList.ToArray());
                lastHRV.Add(hrv);
                if (lastHRV.Count > 5)
                {
                    lastHRV.RemoveAt(0);
                }
                string hrvString = "";
                for (int i = 0; i < lastHRV.Count; i++)
                {
                    hrvString += "hrv" + i + ":" + lastHRV[i].ToString("F2");
                }
                hrvString += " avg:" + ave.ToString("F2") + " size:" + hrvList.Count;
                hrvList.Clear();
                hrvLabel.Text = hrvString;
                hrvBox.Text = "";
            }
        }

        private void BrainLinkSDK_OnGyroDataEvent(int X, int Y, int Z)
        {
            xvalue.Text = X.ToString();
            yvalue.Text = Y.ToString();
            zvalue.Text = Z.ToString();
        }

        private void BrainLinkSDK_OnEEGExtendDataEvent(BrainLinkExtendModel Model)
        {
            //Debug.WriteLine("Extend");
            ap.Text = Model.Ap.ToString();
            ele.Text = Model.Electric.ToString();
            version.Text = Model.Version.ToString();
            temp.Text = Model.Temperature.ToString();
            heart.Text = Model.HeartRate.ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click");
            brainLinkSDK.Start();
            listBox1.Items.Clear();
            Devices.Clear();
        }

        private void BrainLinkSDK_OnEEGDataEvent(BrainLinkModel Model)
        {
            att.Text = Model.Attention.ToString();
            med.Text = Model.Meditation.ToString();
            delta.Text = Model.Delta.ToString();
            theta.Text = Model.Theta.ToString();
            lalpha.Text = Model.LowAlpha.ToString();
            halpha.Text = Model.HighAlpha.ToString();
            lbeta.Text = Model.LowBeta.ToString();
            hbeta.Text = Model.HighBeta.ToString();
            lgamma.Text = Model.LowGamma.ToString();
            hgamma.Text = Model.HighGamma.ToString();
            signal.Text = Model.Signal.ToString();
            
            
            nombrearchivo = elementoSeleccionado + ".csv";
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), nombrearchivo);
            
            
            

            
            
            // Escribir las cabeceras de las columnas si el archivo no existe

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {

                sw.Write(Model.Attention.ToString());
                sw.Write(",");
                sw.Write(Model.Meditation.ToString());
                sw.Write(",");
                sw.Write(Model.Delta.ToString());
                sw.Write(",");
                sw.Write(Model.Theta.ToString());
                sw.Write(",");
                sw.Write(Model.LowAlpha.ToString());
                sw.Write(",");
                sw.Write(Model.HighAlpha.ToString());
                sw.Write(",");
                sw.Write(Model.LowBeta.ToString());
                sw.Write(",");
                sw.Write(Model.HighBeta.ToString());
                sw.Write(",");
                sw.Write(Model.LowGamma.ToString());
                sw.Write(",");
                sw.Write(Model.HighGamma.ToString());
                sw.Write(",");
                sw.Write(Model.Signal.ToString());
                sw.Write(",");
                sw.WriteLine();
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("Click");
            //brainLinkSDK.Start();
            
        }

        private double StandardDiviation(float[] x)
        {
            ave = x.Average();
            double dVar = 0;
            for (int i = 0; i < x.Length; i++)
            {
                dVar += (x[i] - ave) * (x[i] - ave);
            }
            return Math.Sqrt(dVar / x.Length);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            brainLinkSDK.SetApEnable(checkBox1.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            brainLinkSDK.SetGyroEnable(checkBox2.Checked);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            brainLinkSDK.Close();
            brainLinkSDK = null;
            Dispose();
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < Devices.Count)
            {
                (long, string) Device = Devices[listBox1.SelectedIndex];
                brainLinkSDK.connect(Device.Item1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void hrvBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
