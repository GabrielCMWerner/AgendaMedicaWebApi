﻿using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloCirurgia;
using AgendaMedica.Dominio.ModuloConsulta;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Disponibilidade { get; set; }
        public List<Consulta> Consultas { get; set; }
        public List<Cirurgia> Cirurgias { get; set; }

        public Medico()
        {
            Consultas = new List<Consulta>();
            Cirurgias = new List<Cirurgia>();
        }

        public Medico(string crm, string nome, string telefone) : this()
        {
            Crm = crm;
            Nome = nome;
            Telefone = telefone;
        }
    }
}
