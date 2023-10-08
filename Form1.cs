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

        public Form1()
        {
            InitializeComponent();

            cola_procesos.Enqueue(new Proceso(1, 0, 3));
            cola_procesos.Enqueue(new Proceso(2, 1, 5));
            cola_procesos.Enqueue(new Proceso(3, 3, 2));
            cola_procesos.Enqueue(new Proceso(4, 9, 5));
            cola_procesos.Enqueue(new Proceso(5, 12, 5));

            caballos_pictureBoxes.Add(caballo_pictureBox1);
            caballos_pictureBoxes.Add(caballo_pictureBox2);
            caballos_pictureBoxes.Add(caballo_pictureBox3);
            caballos_pictureBoxes.Add(caballo_pictureBox4);
            caballos_pictureBoxes.Add(caballo_pictureBox5);
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            Point meta_coords = meta_label.Location;
            Point caballo_coords = caballo_pictureBox1.Location;
            int distancia = meta_coords.X - caballo_coords.X;


            foreach (var proceso in cola_procesos)
            {
                int velocidad = distancia / proceso.Tiempo_ejecucion;
                foreach (var caballo in caballos_pictureBoxes)
                {
                    for (int pos = caballo.Location.X; pos <= meta_coords.X; pos += velocidad)
                    {
                        caballo.Location = new Point(pos, caballo.Location.Y);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private void meta_label_Click(object sender, EventArgs e)
        {

        }

    }
}
