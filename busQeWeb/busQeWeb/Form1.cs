using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
//using System.Threading.Tasks;
using System.Timers;
using System.Net;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Configuration;
//using System.DirectoryServices.AccountManagement;

namespace busQeWeb
{
    public partial class Form1 : Form
    {

        public string SESSAO_USAURIO_NOME;
        public int CODIGO_USUARIO_ACESSO = 203040;
        public string CaminhoRaiz = @"C:\temp\fotos\";
        public string CaminhoArquivos = @"C:\temp\fotos\entrada\";
        public string CaminhoSaida = @"C:\temp\fotos\saida\";
        public string CaminhoErro = @"C:\temp\fotos\erro\";
        public ArrayList BancoPalavra = new ArrayList();


        public event KeyEventHandler KeyUp;
        //public event KeyEventHandler KeyPress;

        public Form1()
        {
 
            InitializeComponent();
            this.TopMost = true;

            ConfigirarAmbiente();
            FormatarJanela();
            
            AdicionarAplicacaoAoIniciar();
            configurarUsuario();

            KeyPreview = true;
           // KeyUp += new KeyEventHandler(Form1_KeyUp);

           // this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {

            validarBusca();

           // Application.Exit();
        }



        public void validarBusca() {

            int usuarioCodigo = 1;

            string PalavraChave = txtPesquisa.Text;
            string AplicacaoBusca = "default";
            PalavraChave = PalavraChave.Trim();
            int tamanho = PalavraChave.Length;


            if (PalavraChave.Length < 2)
            {
                txtPesquisa.Enabled = true;
                //MessageBox.Show("Ops! Digite algo para pesquisar.");
                lblPesquisar.BackColor = Color.Red;
                lblPesquisar.ForeColor = Color.White;
                lblPesquisar.Text = "Digite algo para pesquisar!";

            }
            else
            {

                txtPesquisa.Enabled = false;
                lblPesquisar.BackColor = Color.Green;
                lblPesquisar.ForeColor = Color.White;
                lblPesquisar.Text = "Pesquisando...";


                string local = "codigo";
                string aplicacao = "";
                string palavra = "";

                string valor = ""; //7899658392017 //502310


                if (PalavraChave.IndexOf(":") != -1)
                {

                    char separador = ':';
                    string[] colunas;
                    colunas = PalavraChave.Split(separador);
                    aplicacao = colunas[0].ToString().Trim();
                    palavra = colunas[1].ToString().Trim();

                    //-------------

                    if (aplicacao.Length > 2)
                    {

                        if (BancoPalavra.Contains(aplicacao) == true)
                        {
                            AplicacaoBusca = aplicacao;
                        }
                        else
                        {
                            aplicacao = "padrao";
                        }

                    }
                    else
                    {
                        aplicacao = "padrao";
                    }

                    AplicacaoBusca = aplicacao;


                    //-------------

                    if (palavra.Length > 2)
                    {
                        PalavraChave = palavra;
                    }
                    else
                    {
                        PalavraChave = "";
                    }

                    //-------------


                    Console.WriteLine("AplicacaoBusca: " + AplicacaoBusca + " -- PalavraChave: " + PalavraChave);
                }
                else
                {
                    Console.WriteLine("Utilizar aplicacao padrao");
                }


                if (PalavraChave.Length > 2 && AplicacaoBusca.Length > 2)
                {

                    Console.WriteLine("AplicacaoBusca: OK -- PalavraChave: OK");


                    // caso seja numero
                    int saida;
                    bool sucesso = int.TryParse(PalavraChave, out saida);
                    if (sucesso == true)
                    {
                        Console.WriteLine("___tamanho: " + tamanho);

                        // MessageBox.Show("tamanho: " + tamanho + "");

                        switch (tamanho)
                        {
                            case 6:
                                local = "codigo";
                                PesquisarWeb(local, PalavraChave, usuarioCodigo, AplicacaoBusca);
                                break;
                            case 13:
                                local = "ean";
                                PesquisarWeb(local, PalavraChave, usuarioCodigo, AplicacaoBusca);
                                break;
                            default:
                                local = "nome";
                                PesquisarWeb(local, PalavraChave, usuarioCodigo, AplicacaoBusca);
                                break;
                        }


                    }
                    else
                    { // caso seja texto
                        local = "descricao";
                        PalavraChave = PalavraChave.Replace(" ", "+");
                        PesquisarWeb(local, PalavraChave, usuarioCodigo, AplicacaoBusca);
                    }

                    MoverJanela();

                }
                else
                {

                    /// alerta @@
                    lblPesquisar.BackColor = Color.Red;
                    lblPesquisar.ForeColor = Color.White;
                    lblPesquisar.Text = "Termos incorretos. Tente novamente!";
                    txtPesquisa.Enabled = true;
                }

            }


        }



        public void PesquisarWeb(string local, string valor, int usuario, string app) {


            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "http://www.busqe.com/redir?q=" + valor + "&l="+ local + "&u="+ CODIGO_USUARIO_ACESSO + "&app="+ app;
            proc.Start();

            txtPesquisa.Enabled = true;

            // MessageBox.Show("local: " + local + " -- valor: " + valor + " ");
            Console.WriteLine("local: " + local + " -- valor: " + valor + " ");
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            //e.Handled = true;
            //string tecla = 

          
           


           // Console.WriteLine("Escrevendo..." + txtPesquisa.Text);
            /*
            if (e.KeyCode.ToString() == "F12")
            {
                e.Handled = true;
            }
            */

        }

        private void btnPesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("You pressed enter! Good job!");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                MessageBox.Show("You pressed escape! What's wrong?");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Console.WriteLine("Carregando...");
            //this.Width = 1;
            //base.OnLoad(e);
        }

        public void FormatarJanela()
        {


            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.CenterToScreen();

            // this.FormBorderStyle = FormBorderStyle.FixedDialog; //
            //this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.FormBorderStyle = FormBorderStyle.None;
            // this.Opacity = .75;


            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.BackColor = Color.FromArgb(255, 204, 0);
            btnPesquisa.BackColor = Color.FromArgb(255, 255, 255);
            btnPesquisa.FlatStyle = FlatStyle.Flat;
            btnPesquisa.FlatAppearance.BorderSize = 0;

            btnFechar.BackColor = Color.FromArgb(255, 204, 0);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 0);
            btnFechar.FlatAppearance.BorderSize = 0;


            btnOpcao1.BackColor = Color.FromArgb(255, 204, 0);
            btnOpcao1.FlatStyle = FlatStyle.Flat;
            btnOpcao1.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 0);
            btnOpcao1.FlatAppearance.BorderSize = 0;
            if (BancoPalavra.Count > 0)
            {
                btnOpcao1.Text =  BancoPalavra[0].ToString();
                //btnOpcao1.Text = "Produto";
            }
            else
            {
                btnOpcao1.Text = "";
            }

            btnOpcao2.BackColor = Color.FromArgb(255, 204, 0);
            btnOpcao2.FlatStyle = FlatStyle.Flat;
            btnOpcao2.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 0);
            btnOpcao2.FlatAppearance.BorderSize = 0;

            if (BancoPalavra.Count > 1) { 
                btnOpcao2.Text = BancoPalavra[1].ToString();
            }
            else
            {
                btnOpcao2.Text = "";
            }


            btnOpcao3.BackColor = Color.FromArgb(255, 204, 0);
            btnOpcao3.FlatStyle = FlatStyle.Flat;
            btnOpcao3.FlatAppearance.BorderColor = Color.FromArgb(255, 204, 0);
            btnOpcao3.FlatAppearance.BorderSize = 0;
            if (BancoPalavra.Count > 2)
            {
                btnOpcao3.Text = BancoPalavra[2].ToString();
            }
            else {
                btnOpcao3.Text = "";
            }

            //this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            txtPesquisa.Font = new Font("Arial", 25.5f);


            this.FormBorderStyle = FormBorderStyle.None;

            Panel pnlTop = new Panel() { Height = 1, Dock = DockStyle.Top, BackColor = Color.Orange };
            this.Controls.Add(pnlTop);

            Panel pnlRight = new Panel() { Width = 1, Dock = DockStyle.Right, BackColor = Color.Orange };
            this.Controls.Add(pnlRight);

            Panel pnlBottom = new Panel() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Orange };
            this.Controls.Add(pnlBottom);

            Panel pnlLeft = new Panel() { Width = 1, Dock = DockStyle.Left, BackColor = Color.Orange };
            this.Controls.Add(pnlLeft);


        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(this.frmInicio_KeyDown);

          //  MessageBox.Show("  TESTE ");


        }
        
        private void ConfigirarAmbiente() {


            string ArquivoProgramas = @"C:\temp\";

            // string ArquivoProgramas = @"C:\windows\";

            //string ArquivoProgramas = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string CaminhoRaiz = Path.Combine(ArquivoProgramas, "busQe");
            string CaminhoSaida = Path.Combine(ArquivoProgramas, "busQe/config/" + CODIGO_USUARIO_ACESSO);
            string CaminhoErro = Path.Combine(ArquivoProgramas, "busQe/error");
            string CaminhoDados = Path.Combine(ArquivoProgramas, "busQe/data");

            Console.WriteLine("Criando... " + CaminhoRaiz);

            try
            {
               // DirectoryInfo dirInfo = new DirectoryInfo(CaminhoArquivos);

                if (!Directory.Exists(CaminhoRaiz))
                {

                    Directory.CreateDirectory(CaminhoRaiz);
                    Directory.CreateDirectory(CaminhoSaida);
                    Directory.CreateDirectory(CaminhoErro);
                    Directory.CreateDirectory(CaminhoDados);


                    Console.WriteLine("SUCESSO_CRIAR_DIRETORIO");
                }
                else
                {
                    Console.WriteLine("SUCESSO_DIRETORIO_OK");
                }


                comandoBuscar(CaminhoSaida);



            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO_CRIAR_DIRETORIO: " + ex.ToString());
              //  MessageBox.Show("Erro criar pasta: " + ex.ToString());
            }

        }

        private void configurarUsuario() {

            try {



                WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                String username = wp.Identity.Name;


                string usuario = WindowsIdentity.GetCurrent().User.ToString();

                string Nome = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                SESSAO_USAURIO_NOME = WindowsIdentity.GetCurrent().Name;
                // SESSAO_USAURIO_NOME = WindowsIdentity.GetCurrent().User.Value;
                //SESSAO_USAURIO_NOME = WindowsIdentity.GetCurrent().User.ToString();
                 Console.WriteLine("SUCESSO_CARREGAR_USUARIO: " + SESSAO_USAURIO_NOME );

                //string currentUser = WindowsIdentity.GetCurrent().Name.ToString();



            }
            catch (Exception ex) {

                Console.WriteLine("ERRO_CARREGAR_USUARIO: " + ex.ToString());
            }


        }

        private void comandoBuscar(string caminhos) {
           // string comando = "";

            string path = caminhos + "/config.busqe";
            if (!File.Exists(path))
            {
                File.Create(path);
                Console.WriteLine("Criando arquivo config");

            }else{

                int counter = 0;
                string line;

                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length < 20)
                    {
                        BancoPalavra.Add(line.ToString());

                    }
                   // Console.WriteLine(line);
                    counter++;
                }

                Console.WriteLine("Total de apps: " + BancoPalavra.Count);
                

                file.Close();
                Console.WriteLine("Lendo arquivo config" + counter);

            }


            //return comando;
        }

        public void AdicionarAplicacaoAoIniciar()
        {
            try
            {


                RegistryKey busQe = Registry.CurrentUser.CreateSubKey("busQe");

                if (busQe != null)
                {
                    Console.WriteLine("REGISTRO_VERIFICAR_CHAVE");

                    foreach (string subKeyName in busQe.GetSubKeyNames())
                    {
                        using (RegistryKey tempKey = busQe.OpenSubKey(subKeyName))
                        {
                            foreach (string valueName in tempKey.GetValueNames())
                            {

                                Console.WriteLine("{0,-8}: {1}", valueName, tempKey.GetValue(valueName).ToString());
                            }
                        }
                    }


                } else {

                    Console.WriteLine("REGISTRO_CRIANDO_CHAVE");
                   
                    using (RegistryKey Aplicativo = busQe.CreateSubKey("Aplicativo"), Usuario = busQe.CreateSubKey("Usuario"))
                    {
                        Aplicativo.SetValue("Nome", "busQeweb");
                        Aplicativo.SetValue("Codigo", 1);

                        Usuario.SetValue("Nivel", "3");
                        Usuario.SetValue("Codigo", CODIGO_USUARIO_ACESSO);
                    }
                }

                busQe.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO_REGISTRAR_SOFTWARE " + ex.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

          //  ContarRevereso();

            float valor = 1.0f;
            for (int i = 10 - 1; i >= 0; i--)
            {
                valor -= 0.1f;

               // Console.WriteLine(" i =" + i + " ---  " + valor);

                this.Opacity = valor;
                Thread.Sleep(10);
               
            }

            Application.Exit();

        }


        public void MoverJanela() {

            int w, h, top, esq;

            w = this.Width;
            h = this.Height;
            top = this.Top;
            esq = this.Left;

            int resV = SystemInformation.VirtualScreen.Height;
            int resH = SystemInformation.VirtualScreen.Width;
            int posV = (resV - 300);

            for (int i = top; i < posV; i++)
            {

                this.DesktopLocation = new Point(esq, (i));
                Thread.Sleep(1);

            }

        }


        public void ContarRevereso()
        {

            float valor = 1.0f;
            for (int i = 10 - 1; i >= 0; i--)
            {
                valor -= 0.1f;

                Console.WriteLine(" i =" + i + " ---  " + valor);

                this.Opacity = valor;
                Thread.Sleep(50);
                Application.Exit();
            }

            // return valor;
        }


        private void btnOpcao1_Click(object sender, EventArgs e)
        {
            string app = btnOpcao1.Text.ToString().ToLower();
            string busca = txtPesquisa.Text;
            //string busca2 = "";
            if (busca.Length > 2 && app.Length>2) {

                busca = checarBusca(busca);
                txtPesquisa.Text = app + ":" + busca;
                validarBusca();
            }

        }

        private void btnOpcao2_Click(object sender, EventArgs e)
        {
            string app = btnOpcao2.Text.ToString().ToLower(); ;
            string busca = txtPesquisa.Text;
            if (busca.Length > 2 && app.Length > 2)
            {
                busca = checarBusca(busca);
                txtPesquisa.Text = app + ":" + busca;
                validarBusca();
            }

        }

        private void btnOpcao3_Click(object sender, EventArgs e)
        {
            string app = btnOpcao3.Text.ToString().ToLower(); ;
            string busca = txtPesquisa.Text;
            if (busca.Length > 2 && app.Length > 2)
            {
                busca = checarBusca(busca);
                txtPesquisa.Text = app + ":" + busca;
                validarBusca();
            }

        }

        public string checarBusca(string PalavraChave) {


            string valor ="";
           // string aplicacao = "";
            string palavra = "";

            if (PalavraChave.IndexOf(":") != -1)
            {

                char separador = ':';
                string[] colunas;
                colunas = PalavraChave.Split(separador);
               // aplicacao = colunas[0].ToString().Trim();
                palavra = colunas[1].ToString().Trim();
                valor = palavra;
            }
            else {
                valor = PalavraChave;
            }

             return valor;

        }









}
}
