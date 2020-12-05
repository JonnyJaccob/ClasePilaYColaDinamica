using System;
using System.Collections.Generic;
using System.Text;

namespace ClasePilaYColaDinamica.Pila
{
    public class ClasePilaDinamica<Tipo> where Tipo : IEquatable<Tipo>,IComparable<Tipo>
    {
        public ClasePilaDinamica()
        {
            this.Top = null;
        }
        private ClaseNodo<Tipo> _Top;

        public ClaseNodo<Tipo> Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        private bool vacio
        {
            get
            {
                if (Top == null)
                {
                    return true;
                }
                return false;
            }
        }
        public void Push(Tipo objeto)
        {
            if (vacio)
            {
                ClaseNodo<Tipo> nodoNuevoo = new ClaseNodo<Tipo>();
                nodoNuevoo.ObjetoConDatos = objeto;
                nodoNuevoo.Siguiente = null;
                this.Top = nodoNuevoo;
                return;
            }
            ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
            nodoActual = Top;
            do
            {
                if (objeto.Equals(nodoActual.ObjetoConDatos))
                {
                    throw new Exception("Duplicado");
                }
                nodoActual = nodoActual.Siguiente;
            } while (nodoActual != null);
            ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
            nodoNuevo.ObjetoConDatos = objeto;
            nodoNuevo.Siguiente = Top;
            Top = nodoNuevo;
            return;
        }
        public Tipo Pop()
        {
            if (vacio)
            {
                throw new Exception("Esta vacio");
            }
            ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
            ClaseNodo<Tipo> nodoEliminado = new ClaseNodo<Tipo>();
            nodoActual = Top;
            Top = nodoActual.Siguiente;
            nodoEliminado = nodoActual;
            nodoActual = null;
            return nodoEliminado.ObjetoConDatos;
        }
        public Tipo Pop(Tipo objeto)
        {
            if (vacio)
            {
                throw new Exception("Esta vacio");
            }
            ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
            ClaseNodo<Tipo> nodoEliminado = new ClaseNodo<Tipo>();
            ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
            nodoActual = this.Top;
            do
            {
                if (objeto.Equals(this.Top.ObjetoConDatos))
                {
                    Top = nodoActual.Siguiente;
                    nodoEliminado = nodoActual;
                    nodoActual = null;
                    return nodoEliminado.ObjetoConDatos;
                }
                if (nodoActual.ObjetoConDatos.Equals(objeto))
                {
                    if (nodoActual.Siguiente == null)
                    {
                        nodoEliminado = nodoActual;
                        nodoPrevio.Siguiente = null;
                        nodoActual = null;
                        return nodoEliminado.ObjetoConDatos;
                    }
                    else
                    {
                        nodoEliminado = nodoActual;
                        nodoPrevio.Siguiente = nodoActual.Siguiente;
                        nodoActual = null;
                        return nodoEliminado.ObjetoConDatos;
                    }

                }
                nodoActual = nodoActual.Siguiente;
                nodoPrevio = nodoPrevio.Siguiente;
            } while (nodoActual == null);
            throw new Exception("No se encontro el objeto");
        }
        public IEnumerator<Tipo> GetEnumerator()
        {
            if (vacio)
            {
                yield break;
            }
            ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
            nodoActual = this.Top;
            do
            {
                yield return nodoActual.ObjetoConDatos;
                nodoActual = nodoActual.Siguiente;
            } while (nodoActual != null);
            yield break;
        }
        public void VaciarLista()
        {
            if (vacio)
            {

            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Top;
                while (nodoActual != null)
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                    nodoPrevio = null;
                }
                nodoPrevio = null;
                Top = null;
            }
        }
        public Tipo BuscarNodo(Tipo objeto)
        {
            if (vacio)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = this.Top;
                do
                {
                    if (nodoActual.ObjetoConDatos.Equals(objeto))
                    {
                        return (nodoActual.ObjetoConDatos);
                    }
                    if (objeto.CompareTo(nodoActual.ObjetoConDatos) < 0)
                    {
                        throw new Exception("El nodo no existe");
                    }
                    nodoActual = nodoActual.Siguiente;
                } while (nodoActual != null);
                throw new Exception("No se encontro el objeto");
            }
        }
        ~ClasePilaDinamica()
        {
            VaciarLista();
        }
    }
}

