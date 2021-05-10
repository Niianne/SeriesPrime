using System;

namespace DIO.Series
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}

        public Series(int id, Genero genero, string Titulo, string Descricao, int Ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio da Série: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
    
        public string retornaTitulo()
        {
            return this.Titulo;
        }
    
        public int retornaId()
        {
            return this.Id;
        }

        public bool retonaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir() {
            this.Excluido = true;
        }
    }

}