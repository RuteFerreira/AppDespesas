using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDespesas.Models
{
    public class MetodoPagamento
    {
        //public enum TipoPagamento
        //{
        //    Outros,
        //    MbWay,
        //    Multibanco,
        //    Dinheiro,
        //    Transferencia,
            
        //};

        //Atributos Privados Manipulados pelas Propriedades
        private Guid _idPagamento;
        private string _designacao;
        //private TipoPagamento _tipoPagamento;

        public Guid IdPagamento
        {
            get { return _idPagamento; }
            set
            {
                if (_idPagamento == Guid.Empty) _idPagamento = value;
            }
        }

        public string Designacao
        {
            get { return _designacao; }
            set { _designacao = value; }
        }

        //public TipoPagamento ServicoPrestado
        //{
        //    get { return _tipoPagamento; }
        //    set { _tipoPagamento = value; }
        //}

        public MetodoPagamento()
        {
            _idPagamento = Guid.Empty;
            Designacao = "A Definir";
           // ServicoPrestado = TipoPagamento.Outros;
        }

        public override string ToString()
        {
            return $"{Designacao}";
        }

    }
}

    

