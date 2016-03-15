using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  // necessário para ter acesso as portas


namespace revutres_desktop
{
    public partial class Form1 : Form
    {
        string resposta_arduino;

        public Form1()
        {
            InitializeComponent();
            Console.Write("TESTE");
            timerCOM.Enabled = true;
        }

        public void refreshCOMList()
        {
            int i;
            bool quantDiferente;    //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (comboBoxPortasCOM.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBoxPortasCOM.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            comboBoxPortasCOM.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBoxPortasCOM.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            comboBoxPortasCOM.SelectedIndex = 0;
        }

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            refreshCOMList(); // Atualizando a lista de portas  a cada 1 segundo
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {
            if (serialPortCOM.IsOpen == false)
            {
                try
                {
                    serialPortCOM.PortName = comboBoxPortasCOM.Items[comboBoxPortasCOM.SelectedIndex].ToString();
                    serialPortCOM.Open();

                }
                catch
                {
                    return;
                }
                if (serialPortCOM.IsOpen)
                {
                    btn_conectar.Text = "Desconectar";
                    comboBoxPortasCOM.Enabled = false;

                }
            }
            else
            {

                try
                {
                    serialPortCOM.Close();
                    comboBoxPortasCOM.Enabled = true;
                    btn_conectar.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPortCOM.IsOpen == true)  // se porta aberta 
                serialPortCOM.Close();            //fecha a porta
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            if (serialPortCOM.IsOpen == true)          //porta está aberta
                serialPortCOM.Write(textBoxEnviar.Text);  //envia o texto presente no textbox Enviar
        }

        private void serialPortCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            resposta_arduino = serialPortCOM.ReadExisting();              //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            Console.Write("TESTE recebido");
            textBoxReceber.AppendText(resposta_arduino);
        }

        private void textBoxEnviar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_teste_Click(object sender, EventArgs e)
        {
            Console.WriteLine(" ADD ADD ADD ");
        }
    }
}
