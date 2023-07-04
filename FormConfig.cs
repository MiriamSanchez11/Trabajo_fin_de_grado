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
using BrainLinkSDK_Windows;


namespace BrainLinkConnect
{
    public partial class FormConfig : Form
    {
        
        private Timer timer;
        private string[] fileNames;
        private Form2 Form2;
        private int currentIndex = 0;
        public string frequency; // Frecuencia en milisegundos
        private string elementoSeleccionado;
        public float minuto;
        public int valorActual = -1;
        public int seg = 0;
        public int min = 0;
        private BrainLinkSDK brainLinkSDK;
        Dictionary<string, object> variables = new Dictionary<string, object>();
        public string nombrearchivo;
        private float ave = 0;

        private List<int> raw = new List<int>();

        private List<float> hrvList = new List<float>();

        private List<double> lastHRV = new List<double>();

        private List<(long, string)> Devices = new List<(long, string)>();

        public FormConfig(string elementoSeleccionado)
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

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public string SelectedFolderPath { get; private set; }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.Desktop;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                SelectedFolderPath = folder.SelectedPath + "\\";
                fileNames = Directory.GetFiles(SelectedFolderPath, "*.jpg", SearchOption.TopDirectoryOnly)
                        .Union(Directory.GetFiles(SelectedFolderPath, "*.png", SearchOption.TopDirectoryOnly))
                        .Union(Directory.GetFiles(SelectedFolderPath, "*.bmp", SearchOption.TopDirectoryOnly))
                        .ToArray();


                if (fileNames.Length > 0)
                {
                   

                    // Inicializar el índice de la imagen actual
                    currentIndex = 0;

                    // Mostrar la primera imagen
                    MostrarImagen(fileNames[currentIndex]);

                    
                }
            }
        }

        private void MostrarImagen(string fileName)
        {
            pictureBox1.Image = Image.FromFile(fileName);
        }

        // Evento Tick del temporizador
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Incrementar el índice de la imagen actual
            //currentIndex++;
            
            valorActual++;
            label7.Text = valorActual.ToString();
            label9.Text = (valorActual % 60).ToString();
            label8.Text = (valorActual / 60).ToString();
            frequency =textfrecuencia.Text.ToString();

            int frecuencia = int.Parse(frequency);

            minuto = float.Parse(texttiempo.Text.Trim());
            

            if (valorActual % frecuencia == 0)
            {

                MostrarImagen(fileNames[currentIndex]);
                
                if ((currentIndex + 1) == fileNames.Length || (valorActual+1)/60 == minuto)
                {
                    // Detener el temporizador
                    timer.Stop();
                    label11.BackColor = Color.Yellow;
                    label11.Text = "!SE HA AGOTADO LA SESION!";
                    return;
                }
                else
                {
                    currentIndex++;
                }
               
            }

          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Start();
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;

        }

        private void Connect_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void label11_Click(object sender, EventArgs e)
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
            string fileName = Path.GetFileName(fileNames[currentIndex]);

            // Escribir las cabeceras de las columnas si el archivo no existe

            using (StreamWriter stw = new StreamWriter(filePath, true))
            {

                stw.Write(Model.Attention.ToString());
                stw.Write(",");
                stw.Write(Model.Meditation.ToString());
                stw.Write(",");
                stw.Write(Model.Delta.ToString());
                stw.Write(",");
                stw.Write(Model.Theta.ToString());
                stw.Write(",");
                stw.Write(Model.LowAlpha.ToString());
                stw.Write(",");
                stw.Write(Model.HighAlpha.ToString());
                stw.Write(",");
                stw.Write(Model.LowBeta.ToString());
                stw.Write(",");
                stw.Write(Model.HighBeta.ToString());
                stw.Write(",");
                stw.Write(Model.LowGamma.ToString());
                stw.Write(",");
                stw.Write(Model.HighGamma.ToString());
                stw.Write(",");
                stw.Write(Model.Signal.ToString());
                stw.Write(fileName);
                stw.Write(",");
                stw.Write(DateTime.Now.ToString()); // Escribir el timestamp actual
                stw.WriteLine();
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

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Connect_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < Devices.Count)
            {
                (long, string) Device = Devices[listBox1.SelectedIndex];
                brainLinkSDK.connect(Device.Item1);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click");
            brainLinkSDK.Start();
            listBox1.Items.Clear();
            Devices.Clear();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {

        }
    }
    }

