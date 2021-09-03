using System;
using System.Collections.Generic;

namespace WebMarket.Libreria
{
    public class LPaginador<T>
    {
        ////cantidad de resultados por página 
        //private int pagi_cuantos = 8;
        ////cantidad de enlaces que se mostrarán como máximo en la barra de navegación 
        //private int pagi_nav_num_enlaces = 3;
        //private int pagi_actual;
        ////definimos qué irá en el enlace a la página anterior 
        //private String pagi_nav_anterior = " &laquo; Anterior ";
        ////definimos qué irá en el enlace a la página siguiente 
        //private String pagi_nav_siguiente = " Siguiente &raquo; ";
        ////definimos qué irá en el enlace a la página siguiente 
        //private String pagi_nav_primera = " &laquo; Primero ";
        //private String pagi_nav_ultima = " Último &raquo; ";
        //private String pagi_navegacion = null;

        //public object[] paginador(List<T> table, int pagina, int registros, String area, String controller,
        //    String action, String host)
        //{
        //    pagi_actual = pagina == 0 ? 1 : pagina;
        //    pagi_cuantos = registros > 0 ? registros : pagi_cuantos;

        //    int pagi_totalReg = table.Count;
        //    double valor1 = Math.Ceiling((double)pagi_totalReg / (double)pagi_cuantos);
        //    int pagi_totalPags = Convert.ToInt16(Math.Ceiling(valor1));
        //    if (pagi_actual != 1)
        //    {
        //        // Si no estamos en la página 1. Ponemos el enlace "primera" 
        //        int pagi_url = 1; //será el número de página al que enlazamos 
        //        pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/"
        //            + action + "?id=" + pagi_url + "&registros=" + pagi_cuantos + "&area=" + area + "'>"
        //            + pagi_nav_primera + "</a>";

        //        // Si no estamos en la página 1. Ponemos el enlace "anterior" 
        //        pagi_url = pagi_actual - 1; //será el número de página al que enlazamos 
        //        pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action
        //            + "?id=" + pagi_url + "&registros=" + pagi_cuantos + "&area=" + area + "'>"
        //            + pagi_nav_anterior + " </a>";
        //    }
        //    return null;
        //}
    }
}
