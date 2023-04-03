using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Atividade_GestaoEquipamentos
{
    internal class Program
    {
        static ArrayList listaNomeEquipamentos = new ArrayList();
        static ArrayList listaPrecoEquipamentos = new ArrayList();
        static ArrayList listaSerieEquipamentos = new ArrayList();
        static ArrayList listaDataEquipamentos = new ArrayList();
        static ArrayList listaFabricanteEquipamentos = new ArrayList();

        static ArrayList listaTituloChamados = new ArrayList();
        static ArrayList listaDescricaoChamados = new ArrayList();
        static ArrayList listaEquipamentoChamados = new ArrayList();
        static ArrayList listaDataChamados = new ArrayList();
        static ArrayList listaAberturaChamados = new ArrayList();
        static void Main(string[] args)
        {
            bool saidaPrograma = false;
            bool saidaEquipamento = false;
            bool saidaChamados = false;

            do
            {
                saidaEquipamento = false;
                saidaChamados = false;

                ImprimirMenus("geral", "");

                string opcaoGeral = PegarValor("\nEntre com uma opção:\n> ");

                switch (opcaoGeral)
                {
                    case "1":

                        do
                        {
                            ImprimirMenus("equipamentos", "");

                            string opcaoEquipamentos = PegarValor("\nEntre com uma opção:\n> ");

                            switch (opcaoEquipamentos)
                            {
                                case "1":

                                    ImprimirMensagem("Registrando Equipamento...", "inicializando");
                                    AdquirirNomeEquipamento(6, "", 0);
                                    AdquirirPrecoEquipamento("", 0);
                                    AdquirirSerieEquipamento("", 0);
                                    AdquirirDataEquipamento("", 0);
                                    AdquirirFabricanteEquipamento("", 0);
                                    ImprimirMensagem("Equipamento Registrado com Sucesso!", " ");

                                    break;

                                case "2":

                                    ImprimirMensagem("Mostrando Equipamentos...", "inicializando");
                                    VisualizarEquipamentos();
                                    Console.ReadLine();

                                    break;

                                case "3":

                                    ImprimirMensagem("Editando Equipamento...", "inicializando");
                                    VisualizarEquipamentos();
                                    int numeroSerie = Convert.ToInt32(PegarValor("\n\nEntre com o número de série do equipamento:\n> "));

                                    if (listaSerieEquipamentos.Contains(numeroSerie))
                                    {
                                        int indexDaSerie = listaSerieEquipamentos.IndexOf(numeroSerie);
                                        Console.WriteLine();

                                        AdquirirNomeEquipamento(6, "novo ", indexDaSerie);

                                        AdquirirPrecoEquipamento("novo ", indexDaSerie);

                                        AdquirirDataEquipamento("novo ", indexDaSerie);

                                        AdquirirFabricanteEquipamento("novo ", indexDaSerie);

                                        ImprimirMensagem("Equipamento Atualizado com Sucesso!", " ");
                                    }

                                    else
                                    {
                                        ImprimirMensagem("\nEntre com um número de série válido!", "erro");
                                    }

                                    break;

                                case "4":

                                    ImprimirMensagem("Removendo Equipamento...", "inicializando");
                                    VisualizarEquipamentos();
                                    numeroSerie = Convert.ToInt32(PegarValor("\n\nEntre com o número de série do equipamento:\n> "));

                                    if (listaSerieEquipamentos.Contains(numeroSerie))
                                    {
                                        int indexDaSerie = listaSerieEquipamentos.IndexOf(numeroSerie);
                                        Console.WriteLine();
                                        RemoverItensEquipamento(indexDaSerie);
                                        ImprimirMensagem("Equipamento Removido com Sucesso!", " ");
                                    }

                                    else
                                    {
                                        ImprimirMensagem("\nEntre com um número de série válido!", "erro");
                                    }

                                    break;

                                case "0":

                                    ImprimirMenus("saindo", "Saindo para o menu...");
                                    saidaEquipamento = true;
                                    break;

                                default:

                                    ImprimirMenus("nada", "");
                                    break;
                            }

                        } while (saidaEquipamento == false);

                        break;

                    case "2":

                        do
                        {
                            ImprimirMenus("chamados", "");
                            Console.WriteLine();
                            string opcaoChamados = PegarValor("\nEntre com uma opção:\n> ");

                            switch (opcaoChamados)
                            {

                                case "1":

                                    bool serieInvalida = false;

                                    ImprimirMensagem("Registrando Chamado...", "inicializando");

                                    AdquirirTituloChamado("", 0);

                                    AdquirirDescricaoChamado("", 0);

                                    int equipamentoChamado = (Convert.ToInt32(PegarValor("\nEntre com a série do equipamento para o chamado:\n> ")));

                                    if (listaSerieEquipamentos.Contains(equipamentoChamado))
                                    {
                                        int index = listaSerieEquipamentos.IndexOf(equipamentoChamado);
                                        string nome = Convert.ToString(listaNomeEquipamentos[index]);
                                        listaEquipamentoChamados.Add(nome);
                                    }
                                    else
                                    {
                                        ImprimirMensagem("Entre com um número de série válido!", "erro");
                                        serieInvalida = true;
                                    }

                                    if (serieInvalida == true)
                                    {
                                        break;
                                    }

                                    AdquirirDataChamado("", 0);

                                    ImprimirMensagem("Chamado Registrado com Sucesso!", "");

                                    break;

                                case "2":

                                    VisualizarChamados();
                                    Console.ReadLine();

                                    break;

                                case "3":
                                    bool serie = false;
                                    ImprimirMensagem("Editando Chamado...", "inicializando");
                                    VisualizarChamados();

                                    int numeroLinha = Convert.ToInt32(PegarValor("\n\nEntre com o número da linha que deseja editar:\n> "));
                                    Console.WriteLine();
                                    if (numeroLinha < listaTituloChamados.Count)
                                    {
                                        AdquirirTituloChamado("novo ", numeroLinha);

                                        AdquirirDescricaoChamado("novo ", numeroLinha);

                                        equipamentoChamado = (Convert.ToInt32(PegarValor("\nEntre com a série do equipamento para o novo chamado:\n> ")));

                                        if (listaSerieEquipamentos.Contains(equipamentoChamado))
                                        {
                                            int index = listaSerieEquipamentos.IndexOf(equipamentoChamado);
                                            string nome = Convert.ToString(listaNomeEquipamentos[index]);
                                            listaEquipamentoChamados.Add(nome);
                                        }
                                        else
                                        {
                                            ImprimirMensagem("Entre com um número de série válido!", "erro");
                                            serie = true;
                                        }

                                        if (serie == true)
                                        {
                                            break;
                                        }

                                        AdquirirDataChamado("novo ", numeroLinha);

                                        ImprimirMensagem("Chamado Atualizado com Sucesso!", "");
                                    }

                                    else
                                    {
                                        ImprimirMensagem("\nEntre com um número de linha válido!", "erro");
                                    }

                                    break;

                                case "4":

                                    ImprimirMensagem("Removendo Chamado...", "inicializando");

                                    VisualizarChamados();

                                    numeroLinha = Convert.ToInt32(PegarValor("\n\nEntre com o número de linha do chamado:\n> "));

                                    if (numeroLinha < listaTituloChamados.Count)
                                    {
                                        RemoverItensChamado(numeroLinha);
                                        ImprimirMensagem("Equipamento Removido com Sucesso!", " ");
                                    }

                                    else
                                    {
                                        ImprimirMensagem("\nEntre com um número de linha válido!", "erro");
                                    }

                                    break;

                                case "0":

                                    ImprimirMenus("saindo", "Saindo para o menu...");
                                    saidaChamados = true;
                                    break;

                                default:

                                    ImprimirMenus("nada", "");
                                    break;
                            }

                        } while (saidaChamados == false);

                        break;

                    case "0":

                        ImprimirMenus("saindo", "Saindo do programa...");
                        saidaPrograma = true;
                        break;

                    default:

                        ImprimirMenus("nada", "");
                        break;
                }

            } while (saidaPrograma == false);
        }

        private static void RemoverItensChamado(int numeroLinha)
        {
            listaTituloChamados.RemoveAt(numeroLinha);
            listaEquipamentoChamados.RemoveAt(numeroLinha);
            listaDescricaoChamados.RemoveAt(numeroLinha);
            listaDataChamados.RemoveAt(numeroLinha);
            listaAberturaChamados.RemoveAt(numeroLinha);
        }

        private static void VisualizarChamados()
        {
            Console.Clear();
            Console.Write("----------------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("\n| {0,-5} | {1,-20} | {2,-25} | {3,-10} | {4,-20} | ", "LINHAS", "TÍTULO", "EQUIPAMENTO", "DATA ABERTURA", "DIAS QUE ESTÁ ABERTO"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < listaTituloChamados.Count; i++)
            {
                Console.WriteLine(string.Format("| {0,-6} | {1,-20} | {2,-25} | {3,-13} | {4,-20} | ", i, listaTituloChamados[i], listaEquipamentoChamados[i], listaDataChamados[i], listaAberturaChamados[i]));
            }
        }

        private static void AdquirirDataChamado(string chamadoNovo, int index)
        {
            DateTime dataChamado = (Convert.ToDateTime(PegarValor($"\nEntre com a data de abertura do {chamadoNovo}chamado (/ ou -):\n> ")));
            var dataFormatada = String.Format("{0:dd/MM/yyyy}", dataChamado);
            DateTime dataAberta = DateTime.Now;
            TimeSpan diasAberto = dataAberta.Subtract(dataChamado);
            var dataAberturaFormatada = String.Format("{0:dd}", diasAberto);

            if (chamadoNovo == "novo ")
            {
                listaAberturaChamados[index] = (dataAberturaFormatada);
                listaDataChamados[index] = (dataFormatada);
            }
            else
            {
                listaAberturaChamados.Add(dataAberturaFormatada);
                listaDataChamados.Add(dataFormatada);
            }

        }

        private static void AdquirirDescricaoChamado(string chamadoNovo, int index)
        {
            string descricaoChamado = (PegarValor($"\nEntre com a descrição do {chamadoNovo}chamado:\n> "));

            if (chamadoNovo == "novo ")
            {
                listaDescricaoChamados[index] = descricaoChamado;
            }
            else
            {
                listaDescricaoChamados.Add(descricaoChamado);
            }
        }

        private static void AdquirirTituloChamado(string chamadoNovo, int index)
        {
            string tituloChamado = (PegarValor($"Entre com o título do {chamadoNovo}chamado:\n> "));
            if (chamadoNovo == "novo ")
            {
                listaTituloChamados[index] = tituloChamado;
            }

            else
            {
                listaTituloChamados.Add(tituloChamado);
            }

        }

        private static void RemoverItensEquipamento(int indexDaSerie)
        {

            listaNomeEquipamentos.RemoveAt(indexDaSerie);
            listaPrecoEquipamentos.RemoveAt(indexDaSerie);
            listaSerieEquipamentos.RemoveAt(indexDaSerie);
            listaFabricanteEquipamentos.RemoveAt(indexDaSerie);
            listaDataEquipamentos.RemoveAt(indexDaSerie);

        }

        private static void VisualizarEquipamentos()
        {
            Console.Write("-------------------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("\n| {0,-10} | {1,-25} | {2,-10} | {3,-20} | {4,-10} |", "ID", "NOME", "PREÇO", "FABRICANTE", "DATA"));
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < listaSerieEquipamentos.Count; i++)
            {
                Console.WriteLine(string.Format("| {0,-10} | {1,-25} | R${2,-8} | {3,-20} | {4,-10} |", listaSerieEquipamentos[i], listaNomeEquipamentos[i], listaPrecoEquipamentos[i], listaFabricanteEquipamentos[i], listaDataEquipamentos[i]));
            }
        }

        private static void AdquirirFabricanteEquipamento(string equipamentoNovo, int index)
        {
            string fabricanteEquipamento = (PegarValor($"\nEntre com o nome da fabricante do {equipamentoNovo}equipamento:\n> "));

            if (equipamentoNovo == "novo ")
            {
                listaFabricanteEquipamentos[index] = (fabricanteEquipamento);
            }
            else
            {
                listaFabricanteEquipamentos.Add(fabricanteEquipamento);
            }

        }

        private static void AdquirirDataEquipamento(string equipamentoNovo, int index)
        {
            DateTime dataEquipamento = Convert.ToDateTime(PegarValor($"\nEntre com a data de fabricação do {equipamentoNovo}equipamento (separada por / ou -):\n> "));
            var dataFormatada = String.Format("{0:dd/MM/yyyy}", dataEquipamento);

            if (equipamentoNovo == "novo ")
            {
                listaDataEquipamentos[index] = (dataFormatada);
            }
            else
            {
                listaDataEquipamentos.Add(dataFormatada);
            }

        }

        private static void AdquirirSerieEquipamento(string equipamentoNovo, int index)
        {
            int serieEquipamento = (Convert.ToInt32(PegarValor($"\nEntre com o número de série do {equipamentoNovo}equipamento:\n> ")));

            while (listaSerieEquipamentos.Contains(serieEquipamento))
            {
                ImprimirMensagem("\nNúmero de série já existe!", "erro");
                serieEquipamento = (Convert.ToInt32(PegarValor("Entre com o número de série do equipamento:\n> ")));
            }

            if (equipamentoNovo == "novo ")
            {
                listaSerieEquipamentos[index] = (serieEquipamento);
            }
            else
            {
                listaSerieEquipamentos.Add(serieEquipamento);
            }
        }

        private static void AdquirirPrecoEquipamento(string equipamentoNovo, int index)
        {
            decimal valorEquipamento = (Convert.ToDecimal(PegarValor($"\nEntre com o preço de aquisição do {equipamentoNovo}equipamento:\n> ")));
            valorEquipamento = Math.Round(valorEquipamento, 2);

            if (equipamentoNovo == "novo ")
            {
                listaPrecoEquipamentos[index] = (valorEquipamento);
            }
            else
            {
                listaPrecoEquipamentos.Add(valorEquipamento);
            }
        }

        private static void AdquirirNomeEquipamento(int tamanho, string equipamentoNovo, int index)
        {
            string nomeEquipamento;
            nomeEquipamento = (PegarValor($"Entre com o nome do {equipamentoNovo}equipamento (mínimo 6 caracteres):\n> "));

            while (nomeEquipamento.Length < tamanho)
            {
                ImprimirMensagem("\nNome com tamanho mínimo inválido!", "erro");
                nomeEquipamento = (PegarValor("Entre com o nome do equipamento (mínimo 6 caracteres):\n> "));
            }
            if (equipamentoNovo == "novo ")
            {
                listaNomeEquipamentos[index] = (nomeEquipamento);
            }
            else
            {
                listaNomeEquipamentos.Add(nomeEquipamento);
            }
        }

        private static void ImprimirMenus(string tag, string mensagem)
        {
            string funcoes = "\n[1] Criar;\n[2] Visualizar;\n[3] Atualizar;\n[4] Deletar;\n[0] Sair.";

            if (tag == "geral")
            {
                Console.Clear();
                Console.WriteLine("|Gestão De Equipamentos|");
                Console.WriteLine("\n[1] Equipamentos;\n[2] Chamados; \n[0] Sair.");
            }

            else if (tag == "equipamentos")
            {
                Console.Clear();
                Console.WriteLine("|Equipamentos|");
                Console.WriteLine(funcoes);
            }

            else if (tag == "chamados")
            {
                Console.Clear();
                Console.WriteLine("|Chamados|");
                Console.WriteLine(funcoes);
            }

            else if (tag == "saindo")
            {
                Console.Clear();
                Console.WriteLine(mensagem);
                Console.ReadLine();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Digite uma opção válida!");
                Console.ReadLine();
            }

        }

        private static string PegarValor(string mensagem)
        {
            Console.Write(mensagem);
            string valor = Console.ReadLine();
            return valor;
        }

        private static void ImprimirMensagem(string mensagem, string tipo)
        {
            if (tipo == "erro")
            {
                Console.WriteLine();
                Console.WriteLine(mensagem);
                Console.ReadLine();
                Console.Clear();
            }
            else if (tipo == "inicializando")
            {
                Console.Clear();
                Console.WriteLine(mensagem);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(mensagem);
                Console.ReadLine();
            }
        }
    }
}