using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace culebrita.ColaArreglo
{
    class Cola_Circular
    {
       public  int fin;
        private static int MAXTAMQ = 99;
       protected int frente;
        public Object[] listaCola;
        public int cont_Elementos = 0;

        // avavnza un aposi ion

        private int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;
        }

        public Cola_Circular()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            listaCola =  new object[MAXTAMQ];
        }

        // Validaciones

        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }

        public bool colaLlena()
        {
            return frente == siguiente(siguiente(fin));
        }

        //operaciones de modificacion de cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;
                cont_Elementos++;
            }
            else
            {
                throw new Exception("Overflow de la cola");
            }


        }
        // quitar elemento
        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                frente = siguiente(frente);
                cont_Elementos--;
                return tm;

            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public void borrarCola()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            cont_Elementos = 0;
        }

        //obtener el valor de frente
        public object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }


        //METODOS ADICIONALES
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


    }//Fin de la class
}
