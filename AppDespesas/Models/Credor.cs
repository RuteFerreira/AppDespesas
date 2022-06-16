using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDespesas.Models {
    public class Credor {

        public enum TipoServico { 
            Outros, 
            Eletricidade,
            Agua,
            Compras,
            Gas,
            Saude,
            Educacao
        };

        //Atributos Privados Manipulados pelas Propriedades
        private Guid _idCredor;
        private string _designacao;
        private TipoServico _tipoServico;

        public Guid IdCredor {
            get { return _idCredor; }
            set {
                if(_idCredor == Guid.Empty) _idCredor = value;
            }
        }

        public string Designacao {
            get { return _designacao; }
            set {_designacao = value; }
        }

        public TipoServico ServicoPrestado {
            get { return _tipoServico; }
            set { _tipoServico = value; }
        }

        public Credor() {
            _idCredor = Guid.Empty;
            Designacao = "A Definir";
            ServicoPrestado = TipoServico.Outros;
        }

        public override string ToString() {
            return $"{Designacao}";
        }

    }
}
