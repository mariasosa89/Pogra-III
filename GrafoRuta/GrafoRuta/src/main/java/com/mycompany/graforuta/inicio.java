/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.graforuta;

import GrafosPkg.Grafo;

/**
 *
 * @author Ruldin Ayala
 */


//MUNICIPIOS DE JUTIAPA
//a.Agua Blanca
//b.Asunción Mita
//c.Atescatempa
//d.Comapa
//e.Conguaco
//f.El Adelanto
//g.El Progreso
//h.Jalpatagua
//i.Jerez
//j.Jutiapa
//k.Moyuta
//l.Pasaco
//m.Quesada
//n.San José Acatempa
//o.Santa Catarina Mita
//p.Yupiltepeque
//q.Zapotitlán

public class inicio {
    
    public static void main(String[] args) {
          Grafo g = new Grafo("abcdefghijklmnopq");
        
          
        g.agregarRuta('a','b', 20);
        g.agregarRuta('e','l', 45);
        g.agregarRuta('k','l', 47);
        g.agregarRuta('e','k', 6);
        g.agregarRuta('b','a', 81);
        g.agregarRuta('b','c', 79);
        g.agregarRuta('b','d', 34);
        g.agregarRuta('c','b', 6);
        g.agregarRuta('c','d', 35);
        
        char inicio = 'a';
        char fin    = 'q';
        
       String respuesta = g.encontrarRutaMinimaDijkstra(inicio, fin);
        System.out.println(respuesta);
   }
}
