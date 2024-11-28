﻿using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProducto
    {
        #region Singleton
        private static readonly logProducto _instancia = new logProducto();
        public static logProducto Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        #region Métodos
        // Método para agregar un producto
        public bool AgregarProducto(entProducto producto)
        {
            try
            {
                return datProducto.Instancia.AgregarProducto(producto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Método para editar un producto
        public bool EditarProducto(entProducto producto)
        {
            try
            {
                return datProducto.Instancia.EditarProducto(producto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Método para buscar un producto por ID
        public entProducto BuscarProductoPorID(int idProducto)
        {
            try
            {
                return datProducto.Instancia.BuscarProductoPorID(idProducto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Método para listar productos
        public List<entProducto> ListarProductos()
        {
            try
            {
                return datProducto.Instancia.ListarProductos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Método para inhabilitar un producto
        public bool InhabilitarProducto(int productoID)
        {
            try
            {
                return datProducto.Instancia.InhabilitarProducto(productoID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<KeyValuePair<int, string>> ObtenerTiposProducto()
        {
            try
            {
                return datProducto.Instancia.ObtenerTiposProducto(); // O datTipoProducto.Instancia si lo tienes separado
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<KeyValuePair<int, string>> ObtenerEstandaresProducto()
        {
            try
            {
                return datProducto.Instancia.ObtenerEstandaresProducto(); // O datEstandarProducto.Instancia si está separado
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entProducto BuscarProductoId(int idProducto)
        {
            try
            {
                return datProducto.Instancia.BuscarProductoId(idProducto); // Llama al método en datProducto
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entCliente> ListarClientes()
        {
            try
            {
                return datCliente.Instancia.ObtenerClientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Métodos
    }
}