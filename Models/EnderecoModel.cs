using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelExemple.Models
{
    public class EnderecoModel
    {
        public Guid Id { get; set; }

        public string NomeRua { get; set; }

        public string Cidade { get; set; }

        public int NumeroRua { get; set; }
    }
}
