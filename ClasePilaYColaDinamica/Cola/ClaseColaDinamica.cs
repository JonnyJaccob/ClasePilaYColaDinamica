using System;
using System.Collections.Generic;
using System.Text;

namespace ClasePilaYColaDinamica.Cola
{
    public class ClaseColaDinamica<Tipo> where Tipo : IEquatable<Tipo>
    {
        private ClaseNodo<Tipo> _frente;

        public ClaseNodo<Tipo> Frente
        {
            get { return _frente; }
            set { _frente = value; }
        }
        private ClaseNodo<Tipo> _final;

        public ClaseNodo<Tipo> Final
        {
            get { return _final; }
            set { _final = value; }
        }

        //ClaseNodo<Tipo> _final = new ClaseNodo<Tipo>();
        public ClaseColaDinamica()
        {
            Frente = null;
            Final = null;
        }
        public bool vacio
        {
            get
            {
                if (Frente == null)
                {
                    return true;
                }
                return false;
            }
        }
        public IEnumerator<Tipo> GetEnumerator()
        {
            if (vacio)
            {
                yield break;
            }
            ClaseNodo<Tipo> NodoActual = new ClaseNodo<Tipo>();
            NodoActual = Frente;
            do
            {
                yield return NodoActual.ObjetoConDatos;
                NodoActual = NodoActual.Siguiente;
            } while (NodoActual != null);
            yield break;
        }

        public Tipo BuscarNodo(Tipo objeto)
        {
            ClaseNodo<Tipo> NodoActual = new ClaseNodo<Tipo>();
            NodoActual = Frente;
            do
            {
                if (objeto.Equals(NodoActual.ObjetoConDatos))
                {
                    return NodoActual.ObjetoConDatos;
                }
                NodoActual = NodoActual.Siguiente;
            } while (NodoActual != null);
            return default(Tipo);
        }
        public void AgregarNodo(Tipo objeto)
        {
            ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
            nodoNuevo.ObjetoConDatos = objeto;
            if (vacio)
            {
                Final = nodoNuevo;
                Frente = nodoNuevo;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = Frente;
                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        throw new Exception("No se permiten duplicados   ");
                    }
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                } while (nodoActual != null);
                nodoPrevio.Siguiente = nodoNuevo;
                Final = nodoNuevo;
            }

        }
        public Tipo EliminarNodo(Tipo objeto)
        {
            ClaseNodo<Tipo> nodoEliminado = new ClaseNodo<Tipo>();
            ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
            ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
            nodoActual = Frente;
            nodoPrevio = null;
            if (vacio)
            {
                throw new Exception("Esta vacio  ");
            }
            do
            {
                if (objeto.Equals(nodoActual.ObjetoConDatos))
                {
                    if (nodoPrevio == null)
                    {
                        return EliminarNodo();
                    }
                    else
                    {
                        Tipo objetoRetorno = nodoActual.ObjetoConDatos;
                        if (nodoActual == Frente)
                        {
                            Final = nodoPrevio;
                        }
                        else
                        {
                            nodoPrevio.Siguiente = nodoActual.Siguiente;
                            return objetoRetorno;
                        }
                    }
                }
                else
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                }

            } while (nodoActual != null);
            throw new Exception("No se encontro el elemento");
        }
        public Tipo EliminarNodo()
        {
            ClaseNodo<Tipo> nodoEliminado = new ClaseNodo<Tipo>();
            if (vacio)
            {
                throw new Exception("Esta vacio  ");
            }
            if (this._frente == this._final)
            {
                nodoEliminado = Frente;
                Frente = null;
                Final = null;
                return nodoEliminado.ObjetoConDatos;
            }
            ClaseNodo<Tipo> nodo = Frente;
            nodoEliminado = nodo;
            Frente = Frente.Siguiente;
            nodo = null;
            return nodoEliminado.ObjetoConDatos;
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
                nodoActual = Frente;
                while (nodoActual != null)
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                    nodoPrevio = null;
                }
                nodoPrevio = null;
                Frente = null;
            }
        }

        ~ClaseColaDinamica()
        {
            VaciarLista();
        }
    }
}
