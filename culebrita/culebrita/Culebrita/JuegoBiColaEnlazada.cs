using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Threading;
using culebrita.BiColaEnlazada;
using culebrita.ColaArreglo;

namespace culebrita.Culebrita
{
    class JuegoBiColaEnlazada
    {

        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.


        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }


        private static void DibujaPantalla(Size size)
        {
            Console.Title = "Culebrita con BICOLA";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }



        private static void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        }




        private static Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }



        private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }




        private static bool MoverLaCulebrita(BiCola culebra, Point posiciónObjetivo,
             int longitudCulebra, Size screenSize)

        {
            Nodo lista;
            lista = culebra.frente;
        

            var lastPoint = (Point)culebra.finalBiCola();
        

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            for (int i = 0; i <= longitudCulebra && lista != null; i++) { 
                if(lista.elemento.Equals(posiciónObjetivo)) return false;
                lista = lista.siguiente;
            }
           
            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertar(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (culebra.numElementosBicola() > longitudCulebra)
            {
                var removePoint = (Point)culebra.quitar();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point MostrarComida(Size screenSize, BiCola culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.finalBiCola();
            var an = cabezaCulebra.X;
            var pa = cabezaCulebra.Y;
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.ToString().All(x => an != x || an != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }


        private static int veloci(int op)
        {
            int tiempo = 100;
            switch (op)
            {
                case 1:
                    {
                        tiempo = 100;
                        break;
                    }
                case 2:
                    {
                        tiempo = 50;
                        break;

                    }
                case 3:
                    {
                        tiempo = 25;
                        break;

                    }
            }
            return tiempo;

        }





        public void jugar()
        {

          

            var punteo = 0;
            var velocidad = veloci(1); //modificar estos valores y ver qué pasa
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            var culebrita = new BiCola();
            var longitudCulebra = 3; //modificar estos valores y ver qué pasa
            var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
            culebrita.insertar(posiciónActual);
            var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa

            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    Console.Beep();
                    posiciónComida = Point.Empty;
                    longitudCulebra++; //modificar estos valores y ver qué pasa  
                    punteo += 10; //modificar estos valores y ver qué pasa
                    if (punteo == 50)
                    {
                        velocidad = veloci(2);
                    }
                    else if (punteo == 100)
                    {
                        velocidad = veloci(3);
                    }

                    MuestraPunteo(punteo);
                }

                if (posiciónComida == Point.Empty) //entender qué hace esta linea
                {
                    posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write($"GAME OVER");
            Console.Beep(370, 1000);
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
