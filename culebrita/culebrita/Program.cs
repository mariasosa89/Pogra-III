using culebrita.Culebrita;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace culebrita
{
    class Program
    {

        
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando
        //modificar el uso de queue y reemplazarlo con cada una de las estructuras de de cola vista en clase
        //Elaborar Video explicando el funcionamiento del código y del programa.


        //internal enum Direction
        //{
        //    Abajo, Izquierda, Derecha, Arriba
        //}


        //private static void DibujaPantalla(Size size)
        //{
        //    Console.Title = "Culebrita comelona";
        //    Console.WindowHeight = size.Height + 2;
        //    Console.WindowWidth = size.Width + 2;
        //    Console.BufferHeight = Console.WindowHeight;
        //    Console.BufferWidth = Console.WindowWidth;
        //    Console.CursorVisible = false;
        //    Console.BackgroundColor = ConsoleColor.White;
        //    Console.Clear();

        //    Console.BackgroundColor = ConsoleColor.Black;
        //    for (int row = 0; row < size.Height; row++)
        //    {
        //        for (int col = 0; col < size.Width; col++)
        //        {
        //            Console.SetCursorPosition(col + 1, row + 1);
        //            Console.Write(" ");
        //        }
        //    }
        //}



        //private static void MuestraPunteo(int punteo)
        //{
        //    Console.BackgroundColor = ConsoleColor.White;
        //    Console.ForegroundColor = ConsoleColor.Black;
        //    Console.SetCursorPosition(1, 0);
        //    Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        //}




        //private static Direction ObtieneDireccion(Direction direccionAcutal)
        //{
        //    if (!Console.KeyAvailable) return direccionAcutal;

        //    var tecla = Console.ReadKey(true).Key;
        //    switch (tecla)
        //    {
        //        case ConsoleKey.DownArrow:
        //            if (direccionAcutal != Direction.Arriba)
        //                direccionAcutal = Direction.Abajo;
        //            break;
        //        case ConsoleKey.LeftArrow:
        //            if (direccionAcutal != Direction.Derecha)
        //                direccionAcutal = Direction.Izquierda;
        //            break;
        //        case ConsoleKey.RightArrow:
        //            if (direccionAcutal != Direction.Izquierda)
        //                direccionAcutal = Direction.Derecha;
        //            break;
        //        case ConsoleKey.UpArrow:
        //            if (direccionAcutal != Direction.Abajo)
        //                direccionAcutal = Direction.Arriba;
        //            break;
        //    }
        //    return direccionAcutal;
        //}



        //private static Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        //{
        //    Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
        //    switch (direction)
        //    {
        //        case Direction.Arriba:
        //            siguienteDireccion.Y--;
        //            break;
        //        case Direction.Izquierda:
        //            siguienteDireccion.X--;
        //            break;
        //        case Direction.Abajo:
        //            siguienteDireccion.Y++;
        //            break;
        //        case Direction.Derecha:
        //            siguienteDireccion.X++;
        //            break;
        //    }
        //    return siguienteDireccion;
        //}



        //private static bool MoverLaCulebrita(Queue<Point> culebra, Point posiciónObjetivo,
        //    int longitudCulebra, Size screenSize)
        //{
        //    var lastPoint = culebra.Last();

        //    if (lastPoint.Equals(posiciónObjetivo)) return true;

        //    if (culebra.Any(x => x.Equals(posiciónObjetivo))) return false;

        //    if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
        //            || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
        //    {
        //        return false;
        //    }

        //    Console.BackgroundColor = ConsoleColor.Green;
        //    Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
        //    Console.WriteLine(" ");

        //    culebra.Enqueue(posiciónObjetivo);

        //    Console.BackgroundColor = ConsoleColor.Red;
        //    Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
        //    Console.Write(" ");


        //    if (culebra.Count > longitudCulebra)
        //    {
        //        var removePoint = culebra.Dequeue();
        //        Console.BackgroundColor = ConsoleColor.Black;
        //        Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
        //        Console.Write(" ");
        //    }
        //    return true;
        //}

        //private static Point MostrarComida(Size screenSize, Queue<Point> culebra)
        //{
        //    var lugarComida = Point.Empty;
        //    var cabezaCulebra = culebra.Last();
        //    var rnd = new Random();
        //    do
        //    {
        //        var x = rnd.Next(0, screenSize.Width - 1);
        //        var y = rnd.Next(0, screenSize.Height - 1);
        //        if (culebra.All(p => p.X != x || p.Y != y)
        //            && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
        //        {
        //            lugarComida = new Point(x, y);
        //        }

        //    } while (lugarComida == Point.Empty);

        //    Console.BackgroundColor = ConsoleColor.Blue;
        //    Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
        //    Console.Write(" ");

        //    return lugarComida;
        //}



        static void Menu()
        {
            bool ejecutar = false;

            for (int k = 0; ;)
            {
                PintaMenu(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: ejecutar = true; break;
                }

                if (k < 0) k = 4; else if (k > 4) k = 0;

                if (ejecutar)
                {
                    ejecutar = false;
                    switch (k)
                    {
                        case 0: Opcion1(); break;
                        case 1: Opcion2(); break;
                        case 2: Opcion3(); break;
                        case 3: Opcion4(); break;
                        case 4: return;
                    }
                }
            }
        }

        static void PintaMenu(int k)
        {
            ConsoleColor cc = ConsoleColor.White;
            ConsoleColor sel = ConsoleColor.Green;
            var tamañoPantalla = new Size(60, 20);
            JuegoColaLineal pan = new JuegoColaLineal();

            pan.DibujaPantalla(tamañoPantalla);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(22, 2);
            Console.WriteLine("JUEGO CULEBRITA");
            Console.Beep();
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("1. COLA CIRCULAR");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("2. BICOLA");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("3. COLA LINEAL");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("4. COLA CON LISTA");
            Console.SetCursorPosition(5, 13);
            Console.ForegroundColor = k == 4 ? sel : cc;
            Console.WriteLine("5. SALIR");
        }

        static void Opcion1()//INVOCAMOS JUEGO CON COLA CIRCULAR
        { 
            JuegoColaCircular jugar = new JuegoColaCircular();
            jugar.jugar();
        }

        static void Opcion2()//INVOCAMOS JUEGO CON BICOLA
        {
            JuegoBiColaEnlazada jugar = new JuegoBiColaEnlazada();
            jugar.jugar();


        }
        static void Opcion3()//INVOCAMOS JUEGO CON COLALINEAL
        {
            JuegoColaLineal jugar = new JuegoColaLineal();
            jugar.jugar();

        }
        static void Opcion4()//INVOCAMOS JUEGO CON COLA-LISTA
        {

            JuegoColaconLista jugar = new JuegoColaconLista();
            jugar.jugar();

        }


        static void Main()//MAIN
        {
            
            Menu();

            
        }



    }//end class
}




