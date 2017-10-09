using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Avaliacao.Entidade;




namespace Avaliacao.site.avaliacao
{
    public partial class microondas : System.Web.UI.Page
    {
        //protected int valorTempo;
        protected static string contador;
        protected static bool emProcesso = false;
        protected static bool processoCompleto = false;
        protected static string processCompletoMsg = "";
        protected static List<Programa> listaProgramas;
        protected static string caracterAlimento;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPotencia.Text = "10";
                listaProgramas  = criaListaPrograma();
            }
        }

        protected void btnLigar_Click(object sender, EventArgs e)
        {
            processoCompleto = false;
            Timer1.Enabled = true;
            pnMessage.Visible = false;
            pnInstrucoes.Visible = false;

            btnLigar.Enabled = false;
            btnAquecer.Enabled = false;
            btnReset.Enabled = false;

            Thread workerThread = new Thread(new ThreadStart(botaoLigar));
            workerThread.Start();
        }

        private void botaoLigar()
        {
            contador = "";
            pnFinal.Visible = false;
            lbAquecendo.Text = "";

            emProcesso = true;

            try
            {
                int valorTempo = Int32.Parse(txtTempo.Text);
                int valorPotencia = Int32.Parse(txtPotencia.Text);

                BLL.Avaliacao.validaCamposAquecerNormal(valorTempo, valorPotencia);

                for (int i = 1; i <= valorTempo; i++)
                {

                    contador = contador + caracterAlimento;

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                processoCompleto = true;
                Timer1.Enabled = false;
            }
            catch (Exception ex)
            {
                pnMessage.Visible = true;
                message.Text = "" + ex.Message;
                Timer1.Enabled = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            processoCompleto = true;

            verificaFimProcesso();

            processCompletoMsg = "Programa parado.";

            parametrizaMensagemFim(processCompletoMsg);

            btnCancelar.Enabled = false;
            btnReset.Enabled = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("microondas.aspx", true);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (emProcesso)
            {
                lbAquecendo.Text = contador;
            }

            verificaFimProcesso();
            processCompletoMsg = "Aquecida";
            parametrizaMensagemFim(processCompletoMsg);
            btnReset.Enabled = true;
        }

        protected void verificaFimProcesso() {

            if (processoCompleto)
            {
                Timer1.Enabled = false;
                pnFinal.Visible = true;
                //lbFim.Text = processCompletoMsg;
            }
        }

        protected void parametrizaMensagemFim(string msn) {

            lbFim.Text = msn;
        }

        protected void btnAquecer_Click(object sender, EventArgs e)
        {
            txtTempo.Text = "30";
            txtPotencia.Text = "8";

            btnLigar.Enabled = false;
            btnAquecer.Enabled = false;
            btnReset.Enabled = false;
            btnBuscar.Enabled = false;

            processoCompleto = false;
            Timer1.Enabled = true;
            pnMessage.Visible = false;

            Thread workerThread = new Thread(new ThreadStart(botaoAquecerRapido));
            workerThread.Start();
        }

        private void botaoAquecerRapido() {

            contador = "";
            pnFinal.Visible = false;
            pnInstrucoes.Visible = false;
            lbAquecendo.Text = "";

            emProcesso = true;

            int tempo = 30;

            for (int i = 1; i <= tempo; i++)
            {
                contador = contador + ".";

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            processoCompleto = true;
            Timer1.Enabled = false;
        }

        protected List<Programa> criaListaPrograma() {

            List<Programa> progrs = new List<Programa>();

            progrs.Add(new Programa() { nome = "FRANGO", instrucao = "Frango Assado", potencia = 10, tempo = 50, caracterer = "#" });
            progrs.Add(new Programa() { nome = "PEIXE", instrucao = "Peixe Assado", potencia = 9, tempo = 35, caracterer = "@" });
            progrs.Add(new Programa() { nome = "CARNE", instrucao = "Carne Assado", potencia = 8, tempo = 25, caracterer = "%" });
            progrs.Add(new Programa() { nome = "PIZZA", instrucao = "Pizza Assado", potencia = 7, tempo = 15, caracterer = "$" });
            progrs.Add(new Programa() { nome = "BOLO", instrucao = "Bolo Assado", potencia = 6, tempo = 60, caracterer = "*" });

            return progrs;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string alimento = txtAlimento.Text.ToUpper();
            pnInstrucoes.Visible = false;

            string alimentoReturn = listaProgramas.Select(campo => campo.nome).FirstOrDefault(c => c == alimento);

            foreach (Programa p in listaProgramas)
            {
                if (string.IsNullOrEmpty(alimentoReturn)) {
                    pnMessage.Visible = true;
                    txtNome.Text = alimento;
                    message.Text = "Este programa não existe, adicione na lista";
                    pnAddProg.Visible = true;
                    break;
                }

                if (p.nome.Equals(alimentoReturn))
                {
                    pnInstrucoes.Visible = true;
                    lbNome.Text = p.nome;
                    lbInstru.Text = p.instrucao;
                    lbTempo.Text = p.tempo.ToString();
                    lbPotencia.Text = p.potencia.ToString();

                    txtTempo.Text = p.tempo.ToString();
                    txtPotencia.Text = p.potencia.ToString();

                    caracterAlimento = p.caracterer;
                    break;

                }
            }
        }

        protected void btnAddProg_Click(object sender, EventArgs e)
        {
            try
            {
                pnMessage.Visible = false;
                pnAddProg.Visible = false;

                adicionaProgramaNovo();
            }
            catch (Exception ex) {
                pnMessage.Visible = true;
                message.Text = "" + ex.Message;
            }
        }

        protected void adicionaProgramaNovo() {

            BLL.Programa.validaCamposAddPrograma(txtNome.Text,
                                                 txtIntru.Text,
                                                 Int32.Parse(txtPotenciaA.Text),
                                                 Int32.Parse(txtTempoA.Text),
                                                 txtCaracter.Text);

            listaProgramas.Add(new Programa()
            {
                nome = txtNome.Text.ToUpper(),
                instrucao = txtIntru.Text,
                potencia = Int32.Parse(txtPotenciaA.Text),
                tempo = Int32.Parse(txtTempoA.Text),
                caracterer = txtCaracter.Text
            });
        }

        
    }
}