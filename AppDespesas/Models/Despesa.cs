using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDespesas.Models {
    public class Despesa {
        private Guid _idDespesa;
        private Credor _fornecedor;
        private MetodoPagamento _metodoPagamento;
        private string _descricao;
        private decimal _valor;
        private DateTime _dtPagamento;
        private bool _pago;

        public Guid IdDespesa {
            get { return _idDespesa; }
            set {
                if (_idDespesa == Guid.Empty) _idDespesa = value;
            }
        }
        public MetodoPagamento ModoPagamento
        {
            get { return _metodoPagamento; }
            set { _metodoPagamento = value; }
        }


        public Credor Fornecedor {
            get { return _fornecedor; }
            set { _fornecedor = value; }
        }

        public string Descricao {
            get { return _descricao; }
            set {
                _descricao = value;
                if (_descricao.Equals("")) _descricao = "Não Indicada";
            }
        }

        public decimal Valor {
            get { return _valor; }
            set {
                _valor = value;
                if (_valor < 0) _valor = 0;
            }
        }

        public DateTime DtPagamento {
            get { return _dtPagamento; }
            set { _dtPagamento = value; }
        }

        public bool Pago {
            get { return _pago; }
            set {
                _pago = value;
            }
        }

        public string PagoPorExtenso
        {
            get
            {
                //return (Pago) ? "SIM" : "Não";
                string mensagem = "";
                if (Pago) mensagem = "SIM";
                else mensagem = "Não";
                return mensagem;
            }
        }
                     // public string FormaPagamento
                    // {
                    //  get
                   // {
                    //return (Pago) ? "SIM" : "Não";
                   //  string mensagem = "";
                  // if (Pago) mensagem = "SIM";
                 //    else mensagem = "Não";
                //    return mensagem;
               //  }
              //  }
        

        public Despesa() {
            _idDespesa = Guid.Empty;
            Fornecedor = new Credor();
            Descricao = "";
            DtPagamento = DateTime.Now;
            Valor = 0.0M;
            Pago = false;
        }
    }
}
