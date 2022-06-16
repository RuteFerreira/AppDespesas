using AppDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDespesas {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private List<Despesa> _listaDespesas;
        private Despesa _workDespesa;

        public MainWindow() {
            InitializeComponent();
            inicializarLista();
        }

        private void inicializarLista() {
            Credor c1 = new Credor {
                IdCredor = Guid.NewGuid(),
                Designacao = "Outros Credores",
                ServicoPrestado = Credor.TipoServico.Outros
            };

            Credor c2 = new Credor {
                IdCredor = Guid.NewGuid(),
                Designacao = "EDP",
                ServicoPrestado = Credor.TipoServico.Eletricidade
            };

            Credor c3 = new Credor {
                IdCredor = Guid.NewGuid(),
                Designacao = "Istec",
                ServicoPrestado = Credor.TipoServico.Educacao
            };

            Credor c4 = new Credor {
                IdCredor = Guid.NewGuid(),
                Designacao = "STCP",
                ServicoPrestado = Credor.TipoServico.Outros
            };
            

            cmbFornecedor.Items.Clear();
            cmbFornecedor.Items.Add(c1);
            cmbFornecedor.Items.Add(c2);
            cmbFornecedor.Items.Add(c3);
            cmbFornecedor.Items.Add(c4);
           
            


            MetodoPagamento m1 = new MetodoPagamento { Designacao = "MBWay", IdPagamento = Guid.NewGuid() };
            MetodoPagamento m2 = new MetodoPagamento { Designacao = "ProntoPagamento", IdPagamento = Guid.NewGuid() };
            MetodoPagamento m3 = new MetodoPagamento { Designacao = "Multibanco", IdPagamento = Guid.NewGuid() };
            MetodoPagamento m4 = new MetodoPagamento { Designacao = "Transferência", IdPagamento = Guid.NewGuid() };
            cmbmodopagamento.Items.Clear();
            cmbmodopagamento.Items.Add(m1);
            cmbmodopagamento.Items.Add(m2);
            cmbmodopagamento.Items.Add(m3);
            cmbmodopagamento.Items.Add(m4);
            //cmbFornecedor.SelectedIndex = 0;   //1ª gaveta selecionada, a opção já não fica em branco

            _listaDespesas = new List<Despesa>();
            _listaDespesas.Add(new Despesa {
                IdDespesa = Guid.NewGuid(),
                Descricao = "Mensalidade do Istec",
                Valor = 55.55M,
                Pago = false,
                Fornecedor = c3
            });
            _listaDespesas.Add(new Despesa {
                IdDespesa = Guid.NewGuid(),
                Descricao = "Eletricidade Maio",
                Valor = 100.01M,
                Pago = false,
                Fornecedor = c2
            });
            //lstDespesas.ItemsSource = _listaDespesas;
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            lstDespesas.ItemsSource = null; //tirar a informação que lá está
            lstDespesas.ItemsSource = _listaDespesas;

            //inicializar todos os objetos que interajem com o utilizador
            cmbFornecedor.SelectedIndex = 0;    //1ª gaveta selecionada, a opção já não fica em branco
            cmbmodopagamento.SelectedIndex = 0;
            txtDescricao.Text = "";
            txtValor.Text = "";
            chkPago.IsChecked = false;
            dtpckDataPagamento.SelectedDate = DateTime.Now;
            btnGravar.Content = "Criar";
            btnApagar.Visibility = Visibility.Hidden;
            btnCancelar.IsEnabled = false;
            lstDespesas.IsEnabled = true;
            _workDespesa = new Despesa();   //guid.Empty, é um objecto novo


        }

        private void btnSair_Click(object sender, RoutedEventArgs e) {
            this.Close();

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e) {
            string valor = "";
            string descricao = "";
            string dtPagamento = "";
            Credor credorEscolhido = null;
            credorEscolhido = (Credor)cmbFornecedor.SelectedItem;
            valor = txtValor.Text;
            descricao = txtDescricao.Text;
            dtPagamento = dtpckDataPagamento.Text;
            if (valor != "" && descricao != "" && dtPagamento != "")
            {
                if (_workDespesa.IdDespesa == Guid.Empty)
                {   //novo--> inserção
                    _workDespesa = new Despesa();
                    _workDespesa.IdDespesa = Guid.NewGuid();
                    _workDespesa.Descricao = descricao;
                    _workDespesa.Valor = Convert.ToDecimal(valor);
                    _workDespesa.DtPagamento = Convert.ToDateTime(dtPagamento);
                    _workDespesa.Fornecedor = credorEscolhido;
                    _workDespesa.Pago = (bool)chkPago.IsChecked;
                    _listaDespesas.Add(_workDespesa);
                  
                }
                else
                {
                    //modo de edição
                    int gaveta = _listaDespesas.IndexOf(_workDespesa);
                    if(gaveta >= 0)
                    {
                        _workDespesa.Descricao = descricao;
                        _workDespesa.Valor = Convert.ToDecimal(valor);
                        _workDespesa.DtPagamento = Convert.ToDateTime(dtPagamento);
                        _workDespesa.Fornecedor = credorEscolhido;
                        _workDespesa.Pago = (bool)chkPago.IsChecked;
                        _listaDespesas[gaveta] = _workDespesa;                       
                    }
                }
                inicializarFormulario();
            }

            else
            {
                MessageBox.Show("Vê lá se preenches tudo!");
            }


        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            inicializarFormulario();

        }

        private void btnApagar_Click(object sender, RoutedEventArgs e) {
            _listaDespesas.Remove(_workDespesa);
            inicializarFormulario();

        }
        private void lstDespesas_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            //MessageBox.Show(dClicada.IdDespesa + dClicada.Descricao);
            //Entrar em modo de Edição:
            if (e.RemovedItems.Count == 0)
            {

                try
                {

                    _workDespesa = lstDespesas.SelectedItem as Despesa;
                    cmbFornecedor.SelectedItem = _workDespesa.Fornecedor;
                    txtDescricao.Text = _workDespesa.Descricao;
                    txtValor.Text = _workDespesa.Valor.ToString();
                    dtpckDataPagamento.SelectedDate = _workDespesa.DtPagamento;
                    chkPago.IsChecked = _workDespesa.Pago;
                    lstDespesas.IsEnabled = false;
                    btnGravar.Content = "Atualizar";
                    btnApagar.Visibility = Visibility.Visible;
                    btnCancelar.IsEnabled = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

