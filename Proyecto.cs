using System;
using System.Collections.Generic;
using System.Text;

namespace Gestión_Proyectos
{
    class Proyecto
    {
        private string codigo;
        private string nombre;
        private double costo_base;
        private double costo_total;
        private List<Persona> integrantes;

        public Proyecto(string codigo, string nombre, double costo_base, List<Persona> integrantes)
        {
            Codigo = codigo;
            Nombre = nombre;
            Costo_base = costo_base;
            Integrantes = integrantes;           
            Costo_total = costo_total;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Costo_base { get => costo_base; set => costo_base = value; }
        public double Costo_total { get => costo_total; set => costo_total = value; }
        internal List<Persona> Integrantes { get => integrantes; set => integrantes = value; }

        public void calcularCostoTotal(double costo_base, List<Persona> integrantes)
        {
            double sumaSalarios = 0;
            foreach (var item in integrantes)
            {
                sumaSalarios += item.Salario;
            }
            double costo_administrativo = sumaSalarios * 0.035;
            this.costo_total = (costo_base + costo_administrativo + sumaSalarios);
        }
    }
}
