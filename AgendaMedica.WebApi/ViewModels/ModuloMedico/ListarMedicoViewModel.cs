﻿namespace AgendaMedicaApi.ViewModels.ModuloMedico
{
    public class ListarMedicoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Disponibilidade { get; set; }
    }
}