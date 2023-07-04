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
using System.IO;
using System.Media;
using BrainLinkSDK_Windows;


namespace BrainLinkConnect
{
    public partial class FormSonido : Form
    {
        private Timer timer;
        public string frequency; 
        public float minuto;
        public int valorActual = 0;
        public int seg = 0;
        public int min = 0;
        public string elementoSeleccionado;
        private string nombrearchivo;
        public int frecuencia;
        private BrainLinkSDK brainLinkSDK;
        Dictionary<string, object> variables = new Dictionary<string, object>();

        private float ave = 0;

        private List<int> raw = new List<int>();

        private List<float> hrvList = new List<float>();

        private List<double> lastHRV = new List<double>();

        private List<(long, string)> Devices = new List<(long, string)>();


        public FormSonido(string elementoSeleccionado)
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




        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            valorActual++;
            label7.Text = valorActual.ToString();

            label9.Text = (valorActual % 60).ToString();
            label8.Text = (valorActual / 60).ToString();
            frequency = textfrecuencia.Text.ToString();

            frecuencia = int.Parse(frequency);
            minuto = float.Parse(texttiempo.Text.Trim());

            //Player.SoundLocation = fileName;

            if (valorActual % frecuencia == 0)
            {
                SoundPlayer sonido = new SoundPlayer();
                sonido.SoundLocation = "C:/Users/Miriam/OneDrive - Universidad de Burgos/Escritorio/SONIDO/boton.wav";
                sonido.Play();

                if ((valorActual + 1) / 60 == minuto)
                {
                    // Detener el temporizador
                    timer.Stop();

                    label11.BackColor = Color.Yellow;
                    label11.Text = "!SE HA AGOTADO LA SESION!";
                    return;
                }
             
            }

        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Start();
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;

            Debug.WriteLine("Click");
            brainLinkSDK.Start();
            listBox1.Items.Clear();
            Devices.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        }

        private void BrainLinkSDK_OnHRVDataEvent(int[] HRV, int Blink)
        {


        }

        private void BrainLinkSDK_OnGyroDataEvent(int X, int Y, int Z)
        {

        }

        private void BrainLinkSDK_OnEEGExtendDataEvent(BrainLinkExtendModel Model)
        {
            //Debug.WriteLine("Extend");

        }

        //private void Start_Click(object sender, EventArgs e)
        //{

        //}

        private void BrainLinkSDK_OnEEGDataEvent(BrainLinkModel Model)
        {
            
            nombrearchivo = elementoSeleccionado + ".csv";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), nombrearchivo);

            

            using (StreamWriter swr = new StreamWriter(filePath, true))
            {

                swr.Write(Model.Attention.ToString());
                swr.Write(",");
                swr.Write(Model.Meditation.ToString());
                swr.Write(",");
                swr.Write(Model.Delta.ToString());
                swr.Write(",");
                swr.Write(Model.Theta.ToString());
                swr.Write(",");
                swr.Write(Model.LowAlpha.ToString());
                swr.Write(",");
                swr.Write(Model.HighAlpha.ToString());
                swr.Write(",");
                swr.Write(Model.LowBeta.ToString());
                swr.Write(",");
                swr.Write(Model.HighBeta.ToString());
                swr.Write(",");
                swr.Write(Model.LowGamma.ToString());
                swr.Write(",");
                swr.Write(Model.HighGamma.ToString());
                swr.Write(",");
                swr.Write(Model.Signal.ToString());
                if (valorActual % frecuencia == 0)
                {
                    swr.Write("1");
                }
                else
                {
                    swr.Write("0");
                }
                swr.Write(",");
                swr.Write(DateTime.Now.ToString()); // Escribir el timestamp actual
                swr.WriteLine();
            }

        }



        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //Debug.WriteLine("Click");
        //    //brainLinkSDK.Start();

        //}

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

        private void textfrecuencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSonido_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click");
            brainLinkSDK.Start();
            listBox1.Items.Clear();
            Devices.Clear();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < Devices.Count)
            {
                (long, string) Device = Devices[listBox1.SelectedIndex];
                brainLinkSDK.connect(Device.Item1);
            }
        }
    }
}
