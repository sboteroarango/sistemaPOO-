using System;
using System.Collections.Generic;
using System.Text;

namespace Gestión_Proyectos
{
    class Persona
    {
        private string nombre;
        private int horas_dedicacion; 
        private double salario;

        public Persona(string nombre, int horas_dedicacion)
        {
            Nombre = nombre;
            Horas_dedicacion = horas_dedicacion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Salario
        {
            get
            {
                return salario;
            }
        }
        public int Horas_dedicacion 
        {
            get 
            {
                return horas_dedicacion;
            }
            set
            {
                horas_dedicacion = value;
                if (horas_dedicacion <= 20)
                {
                    salario = 1014980;
                }
                else
                {
                    salario = 1014980 + (1014980*0.3);
                }
            }
        }
    }
}
