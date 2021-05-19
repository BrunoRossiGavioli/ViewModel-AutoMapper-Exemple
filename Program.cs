using AutoMapper;
using System;
using System.Text.Json;
using ViewModelExemple.Models;

namespace ViewModelExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfig(out IMapper mapper);

            WithOutViewModel(); //Sem a ViewModel

            WithViewModelAndAutoMapper(mapper); //Com ViewModel e AutoMapper   
        }

        public static void AutoMapperConfig(out IMapper mapper)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClienteEnderecoViewModel, ClienteModel>();
                cfg.CreateMap<ClienteEnderecoViewModel, EnderecoModel>();
            });

            mapper = config.CreateMapper();
        }

        public static void PularLinha(int repeticao)
        {
            for (int i = 0; i < repeticao; i++)
                Console.WriteLine("");
        }

        public static void WithViewModelAndAutoMapper(IMapper mapper)
        {
            PularLinha(3);
            Console.WriteLine("Com ViewModel e AutoMapper");

            var CliEn = new ClienteEnderecoViewModel()
            {
                Cidade = "Itu",
                ComidaFavorita = "Banana",
                Nome = "Robson Gustavo",
                NomeRua = "Almeida junior",
                NumeroRua = 555
            };

            var cliente = mapper.Map<ClienteEnderecoViewModel, ClienteModel>(CliEn);
            var endereco = mapper.Map<ClienteEnderecoViewModel, EnderecoModel>(CliEn);
            cliente.Id = Guid.NewGuid();
            endereco.Id = Guid.NewGuid();

            Console.WriteLine(JsonSerializer.Serialize(cliente));
            Console.WriteLine(JsonSerializer.Serialize(endereco));
            
            PularLinha(2);
        }

        public static void WithOutViewModel()
        {
            PularLinha(3);
            Console.WriteLine("Sem ViewModel");

            var CliEn = new ClienteEnderecoViewModel()
            {
                Nome = "Robson Gustavo",
                ComidaFavorita = "Banana",
                NomeRua = "Almeida junior",
                NumeroRua = 555,
                Cidade = "Itu"
            };

            var Cliente = new ClienteModel()
            { 
               ComidaFavorita = CliEn.ComidaFavorita,
               Id = Guid.NewGuid(),
               Nome = CliEn.Nome
            };

            var Endereco = new EnderecoModel()
            {
                Id = Guid.NewGuid(),
                Cidade = CliEn.Cidade,
                NomeRua = CliEn.NomeRua,
                NumeroRua = CliEn.NumeroRua
            };

            Console.WriteLine(JsonSerializer.Serialize(Cliente));
            Console.WriteLine(JsonSerializer.Serialize(Endereco));
        }
    }                                      
}
