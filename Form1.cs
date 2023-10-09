using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planificador_FcFs_Caballos
{
    public partial class Form1 : Form
    {
        private Queue<Proceso> cola_procesos = new Queue<Proceso>();
        private List<PictureBox> caballos_pictureBoxes = new List<PictureBox>();
        private Dictionary<PictureBox, int> caballos_velocidad = new Dictionary<PictureBox, int>();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int caballoActualIndex = 0;

        public Form1()
        {
            InitializeComponent();

            cola_procesos.Enqueue(new Proceso(1, 0, 3));
            cola_procesos.Enqueue(new Proceso(2, 1, 8));
            cola_procesos.Enqueue(new Proceso(3, 3, 2));
            cola_procesos.Enqueue(new Proceso(4, 9, 5));
            cola_procesos.Enqueue(new Proceso(5, 12, 6));

            caballos_pictureBoxes.Add(caballo_pictureBox1);
            caballos_pictureBoxes.Add(caballo_pictureBox2);
            caballos_pictureBoxes.Add(caballo_pictureBox3);
            caballos_pictureBoxes.Add(caballo_pictureBox4);
            caballos_pictureBoxes.Add(caballo_pictureBox5);

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            Point meta_coords = meta_label.Location;
            Point caballo_coords = caballo_pictureBox1.Location;
            int distancia = meta_coords.X - caballo_coords.X;


            foreach (var proceso in cola_procesos)
            {
                int velocidad = distancia / proceso.Tiempo_ejecucion;
                caballos_velocidad[caballos_pictureBoxes[proceso.Id - 1]] = velocidad;
            }

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Point meta_coords = meta_label.Location;

            PictureBox caballoActual = caballos_pictureBoxes[caballoActualIndex];
            int velocidad = caballos_velocidad[caballoActual];
            int nuevaPosicion = caballoActual.Location.X + velocidad;

            // Verificar si el caballo actual llegó a la meta
            if (nuevaPosicion >= meta_coords.X)
            {
                nuevaPosicion = meta_coords.X;
                caballoActualIndex++;

                // Verificar si todos los caballos han llegado a la meta
                if (caballoActualIndex >= caballos_pictureBoxes.Count)
                {
                    // Todos los caballos han llegado a la meta, detener el temporizador
                    timer.Stop();
                    MessageBox.Show("Todos los caballos han llegado a la meta.");
                    return;
                }
            }

            caballoActual.Location = new Point(nuevaPosicion, caballoActual.Location.Y);
        }

        private void meta_label_Click(object sender, EventArgs e)
        {

        }

    }
}
