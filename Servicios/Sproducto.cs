﻿using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sproducto
    {

        private static List<producto> list;

        DBproductos dao;
        public Sproducto() {
            if (list == null)
            {
                list = new List<producto>();
            }
            dao = new DBproductos();

        }
        public bool add(producto p)
        {
          
            try
            {
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool remove(producto p) {

            try
            {
                list.Remove(p);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool update(producto p)
        {
            return true;
        }
        public List<producto>GetProductos() {
            return dao.getAll();
        }

        //Obtenemos todos los productos dependiendo del tipo del prodcuto que estemos recibiendo 
        public List<producto>GetProductos(string type)
        {
            switch (type)
            {
                case "Computadores":
                    var scomputadores = new Scomputadores();
                    return scomputadores.GetComputadors().ToList<producto>();
                case "Celulares":
                    var scelulares = new Scelulares();
                    return scelulares.GetCelulares().ToList<producto>();
                case "Asesorios":
                    var sasesorios = new Sasesorios();
                    return sasesorios.GetAsesorios().ToList<producto>();
                default:
                    return dao.getAll();    

            }
        }
        public List<marca> GetMarcas()
        {
            var _dao = new DBmarca();
            return _dao.getAll();
        }
        public List<producto> FiltProductosM(marca m, List<producto> list)
        {
            list = list.FindAll(x => x.marca.id == m.id);
            return list;
        }
        public List<double> get_Esta() {
            return dao.getEsta();
        }
        public List<double> get_Tot()
        {
            return dao.getTo(); 
        }
        public List<precios> FiltProductosP(List<producto> list)
        {
            /*
             * Realizamos operaciones matematicas para poder obtener 
             * los cuartiles que seran mostrados en los precios como un filtro
             */
            if(list == null)
            {
                return new List<precios>();
            }
            var _list = new List<precios>();
            double min= list.Min(x => x.precio);
            double max = list.Max(x => x.precio);
            double rango = max - min;
            double primerCuartil = min + (rango * 0.25);
            double segundoCuartil = min + (rango * 0.50);
            double tercerCuartil = min + (rango * 0.75);
            _list.Add(new precios()
            {
                minPrecio=min,
                maxPrecio=primerCuartil
            });
            _list.Add(new precios()
            {
                minPrecio=primerCuartil,
                maxPrecio=segundoCuartil
            });
            _list.Add(new precios
            {
                minPrecio = segundoCuartil,
                maxPrecio = tercerCuartil
            });
            _list.Add(new precios
            {
                minPrecio = tercerCuartil,
                maxPrecio = max
            });
            foreach( precios p in _list)
            {
                p.set_precio();
            }
            return _list;
        }
    }
    //Clase que nos permite obtner modelar los precios mediante los cuartiles
    public class precios
    {
        public double minPrecio { get; set; }
        public double maxPrecio { get; set; }
        public string precio { get; set; }
        public void set_precio() { precio = minPrecio.ToString("C0") + " - " + maxPrecio.ToString("C0"); }
  
    } 
}
