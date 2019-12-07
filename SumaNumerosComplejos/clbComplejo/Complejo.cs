using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace clbComplejo
{
    public class Complejo
    {
        #region Campos y propiedades

        private double _a;

        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        private double _b;

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        #endregion
        #region Constructores
        public Complejo() //por omisión considerando 1+i
        {
            _a = 1;
            _b = 1;
        }

        public Complejo(double a, double b) //Por parámetros
        {
            _a = a;
            _b = b;
        }

        public Complejo(Complejo C) //Constructor copia
        {
            _a = C.A;
            _b = C.B;
        }

        #endregion
        #region Métodos propios de la clase

        public override string ToString()
        {
            if (_b == 1)
            {
                return (_a.ToString() + " " + "+" + " " + "i");
            }
            else
            {
                return (_a.ToString() + " " + "+" + " " + _b.ToString() + "i");
            }

        }

        public void Graficar(Canvas unCanvas, Complejo c1, Complejo c2)
        {
            if (Graficable(c1, c2) == true)
            {
                double h = unCanvas.Height;
                double w = unCanvas.Width;
                double escala = 20;

                Line Complejo1 = new Line();
                Line Complejo2 = new Line();
                Line SumaComplejos = new Line();
                Line DeC1aC2 = new Line();
                Line DeC2aC1 = new Line();

                Complejo1.X1 = 0;  //tuve que hacerlo como la resta porque me toma c1 como la suma ;___;
                Complejo1.Y1 = h;
                Complejo1.X2 = escala * (c1.A - c2.A);
                Complejo1.Y2 = h - (escala * (c1.B - c2.B));
                Complejo1.Stroke = Brushes.DarkMagenta;
                Complejo1.StrokeThickness = 1;
                unCanvas.Children.Add(Complejo1);

                Complejo2.X1 = 0;
                Complejo2.Y1 = h;
                Complejo2.X2 = escala * c2.A;
                Complejo2.Y2 = h - (escala * c2.B);
                Complejo2.StrokeThickness = 1;
                Complejo2.Stroke = Brushes.DarkRed;
                unCanvas.Children.Add(Complejo2);


                SumaComplejos.X1 = 0;
                SumaComplejos.Y1 = h;
                SumaComplejos.X2 = escala * c1.A;
                SumaComplejos.Y2 = h - (escala * c1.B);
                SumaComplejos.Stroke = Brushes.OrangeRed;
                SumaComplejos.StrokeThickness = 1;
                unCanvas.Children.Add(SumaComplejos);

                DeC1aC2.X1 = escala * (c1.A - c2.A);
                DeC1aC2.Y1 = h - (escala * (c1.B - c2.B));
                DeC1aC2.X2 = escala * c1.A;
                DeC1aC2.Y2 = h - (escala * c1.B);
                DeC1aC2.StrokeThickness = 1;
                DeC1aC2.Stroke = Brushes.LightCoral;
                unCanvas.Children.Add(DeC1aC2);


                DeC2aC1.X1 = escala * c2.A;
                DeC2aC1.Y1 = h - (escala * c2.B);
                DeC2aC1.X2 = c1.A * escala;
                DeC2aC1.Y2 = h - (escala * c1.B);
                DeC2aC1.Stroke = Brushes.LightCoral;
                DeC2aC1.StrokeThickness = 1;
                unCanvas.Children.Add(DeC2aC1);


                Line EjeX = new Line();
                Line EjeY = new Line();
                EjeX.StrokeThickness = 1;
                EjeY.StrokeThickness = 1;
                EjeX.Stroke = Brushes.Black;
                EjeY.Stroke = Brushes.Black;

                EjeX.X1 = 0;
                EjeX.Y1 = h;
                EjeX.X2 = w;
                EjeX.Y2 = h;

                EjeY.X1 = 0;
                EjeY.Y1 = 0;
                EjeY.X2 = 0;
                EjeY.Y2 = h;

                unCanvas.Children.Add(EjeY);
                unCanvas.Children.Add(EjeX);
                MedidasEjeX(unCanvas);
                MedidasEjeY(unCanvas);

            }
            else
                MessageBox.Show("No es graficable el resultado :( No alcanzaría a dimensionarse en el Canvas. Lo sentimos");

        }

        public void MedidasEjeY(Canvas unCanvas)
        {
            double h = unCanvas.Height;
            double w = unCanvas.Width;
            double escala = 20;
            double yX1 = 0;
            double yX2 = 5;
            double yY1 = escala;
            double yY2 = yX1;
            for (int i = 0; yY1 < unCanvas.Height; i++)
            {
                Line medidaY = new Line();
                medidaY.X1 = yX1;
                medidaY.X2 = yX2;
                medidaY.Y1 = yY1;
                medidaY.Y2 = yY2;

                medidaY.StrokeThickness = 1;
                medidaY.Stroke = Brushes.DarkOrchid;
                unCanvas.Children.Add(medidaY);
                yY1 = yY1 + escala;
                yY2 = yY1;
            }
        }

        public void MedidasEjeX(Canvas unCanvas)
        {
            double h = unCanvas.Height;
            double w = unCanvas.Width;
            double escala = 20;
            double x1 = escala;
            double x2 = x1;
            double y1 = h;
            double y2 = h - 5;
            for (int i = 0; x1 < unCanvas.Width; i++)
            {
                Line medidaX = new Line();
                medidaX.X1 = x1;
                medidaX.X2 = x2;
                medidaX.Y1 = y1;
                medidaX.Y2 = y2;

                medidaX.Stroke = Brushes.DarkOrchid;
                medidaX.StrokeThickness = 1;
                unCanvas.Children.Add(medidaX);
                x1 = x1 + escala;
                x2 = x1;

            }

        }

        public bool Graficable(Complejo c1, Complejo c2)
        {
            if ((c1.A < 0) || (c2.A < 0) || (c1.B < 0) || (c2.B < 0))
            {
                return false;
            }
            else
            {
                if ((c1.A > 20) || (c2.A > 20) || (c1.B > 20) || (c2.B > 20))
                {
                    return false;
                }
                else
                {
                    c1.Sumar(c2);
                    if ((c1.A > 20) || (c1.B > 20))
                    {
                        return false;
                    }
                    else
                        return true;

                }
            }
        }

        public void Sumar(Complejo c)
        {
            _a = _a + c.A;
            _b = _b + c.B;
        }



        #endregion
    }
}
