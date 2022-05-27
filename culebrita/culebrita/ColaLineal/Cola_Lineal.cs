
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.ColaLienal
{
    class Cola_Lineal
    {

        protected int fin;
        private static int MAZTAMQ = 99999999;
        protected int frente;
        protected int cont_Elementos;

        protected Object[] listaCola;

        public Cola_Lineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new object[MAZTAMQ];

        }

        public bool colaVacia()
        {
            return frente > fin;
        }

        public bool colaLlena()
        {
            return fin == MAZTAMQ - 1;
        }
        //Operaciones para trabajr con datos en la cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                listaCola[++fin] = elemento;
                cont_Elementos++;
            }
            else
            {
                throw new Exception("Overflow de la Cola");
            }
        }
        //Quitar elementos en la cola

        public Object quitar()
        {
            if (!colaVacia())
            {
                cont_Elementos--;
                return listaCola[frente++];

            }
            else
            {
                throw new Exception("Cola Vacia");
            }
        }

        //Limpiar toda la cola

        public void borrarCola()
        {
            frente = 0;
            fin = -1;
        }

        //Acceso a la cola
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {

                throw new Exception("Cola Vacia");
            }
        }
        public Object finalCola()// Nos devuelve el ultimo elemento de la cola
        {
            if (colaVacia())
            {
                throw new Exception("Cola Vacia");

            }
            return (listaCola[fin]);
        }
        public int cantidadElementos()// devuelve el valor de elementos en la cola
        {
            int totalElementos = cont_Elementos;

            return totalElementos;
        }
        public bool Any(Point posic)
        {
            bool valor = false;
            for (int i = 0; i < cantidadElementos(); i++)
            {
                Point dato = (Point)listaCola[i];
                if (dato.X == posic.X && dato.Y == posic.Y)
                {
                    valor = true;
                }
               
            }
            
            return valor;
        }


    }
}
