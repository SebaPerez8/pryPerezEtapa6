using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace pryPerezEtapa6
{

    public class clsVehiculo
    {

        private Random random = new Random();
        private List<Rectangle> vehiculos = new List<Rectangle>();


        private Bitmap[] imagenesVehiculos = {
            Properties.Resources.auto,
            Properties.Resources.avion,
            Properties.Resources.barco
        };

        public void CrearVehiculoAleatorio(PictureBox pic)
        {
            int width = pic.Width;
            int height = pic.Height;
            int vehiculoWidth = 100;
            int vehiculoHeight = 50;

            Bitmap imagenAleatoria = SeleccionarImagenAleatoria();

            Point posicionAleatoria;
            do
            {
                posicionAleatoria = new Point(random.Next(width - vehiculoWidth), random.Next(height - vehiculoHeight));
            } while (VerificarSuperposicion(posicionAleatoria, vehiculoWidth, vehiculoHeight));

            vehiculos.Add(new Rectangle(posicionAleatoria, new Size(vehiculoWidth, vehiculoHeight)));

            // Inicializa la imagen del PictureBox si es nula
            if (pic.Image == null)
            {
                pic.Image = new Bitmap(width, height);
            }

            // Crear un Bitmap con la imagen seleccionada y asignar al PictureBox
            using (Graphics g = Graphics.FromImage(pic.Image))
            {
                g.DrawImage(imagenAleatoria, posicionAleatoria.X, posicionAleatoria.Y, vehiculoWidth, vehiculoHeight);
            }

            pic.Invalidate();
        }

        private Bitmap SeleccionarImagenAleatoria()
        {
            int indiceAleatorio = random.Next(imagenesVehiculos.Length);
            return imagenesVehiculos[indiceAleatorio];
        }

        private bool VerificarSuperposicion(Point nuevaPosicion, int width, int height)
        {
            Rectangle nuevoVehiculo = new Rectangle(nuevaPosicion, new Size(width, height));
            foreach (Rectangle vehiculo in vehiculos)
            {
                if (nuevoVehiculo.IntersectsWith(vehiculo))
                {
                    return true;
                }
            }
            return false;
        }

        public void LimpiarPictureBox(PictureBox pic)
        {
            if (pic.Image != null)
            {
                pic.Image.Dispose();
                pic.Image = null;
            }
            vehiculos.Clear();
        }
    }
}
