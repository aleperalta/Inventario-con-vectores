using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_inventario
{
    class Inventario
    {
        public Producto[] v = new Producto[15];
        public int _posicionActual;
        int _posicionEncontrada=2;

        public Inventario()
        {
            _posicionActual = 0;
        }

        public void agregar(Producto producto)
        {
            v[_posicionActual] = producto;

            _posicionActual++;
        }

        public void insertar(Producto producto, int posicionAInsertar)
        {
            for (int i = _posicionActual; i > posicionAInsertar - 1; i--)
                v[i] = v[i - 1];

            v[posicionAInsertar-1] = producto;
            _posicionActual++;
        }

        public void eliminar()
        {
            for (int i = _posicionEncontrada; i < _posicionActual; i++)
                v[i] = v[i + 1];

            v[_posicionActual - 1] = null;
            _posicionActual--;
        }

        public Producto buscar(int codigoP)
        {
            int i = 0;

            while (i < _posicionActual && v[i].codigo != codigoP)
            {
                _posicionEncontrada = 20;
                i++;
            }

            if (i == _posicionActual)
                return null;
            else
            {
                _posicionEncontrada = i;
                return v[i];
            }
        }

        public string mostrar()
        {
            string vProducto = "";

            for (int i = 0; i < _posicionActual; i++)
                vProducto += v[i].ToString() + Environment.NewLine;
            
            return vProducto;
        }

    }
}
