/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package GrafosPkg;

/**
 *
 * @author Ruldin Ayala
 * Preguntas:
 * Para qué sirve la implementación Comparable?
 * y porqué es de tipo Nodo
 */
public class Nodo implements Comparable<Nodo> {
    char id;
    int  distancia   = Integer.MAX_VALUE;
    Nodo procedencia = null;
    
    public Nodo(char x, int d, Nodo p) { 
        id=x; distancia=d; procedencia=p; 
    }
    
    public Nodo(char x) { 
        this(x, 0, null); 
    }
    
    public int compareTo(Nodo tmp) { 
        return this.distancia-tmp.distancia; 
    }
    
    public boolean equals(Object o) {
        Nodo tmp = (Nodo) o;
        return tmp.id==this.id;
    }
}
