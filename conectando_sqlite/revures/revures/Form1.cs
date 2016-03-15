using revures.conf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Console.Write("btnEntrar_Click...\n");
            DB db = new DB();
            db.openConnection();
            db.executeQuery("INSERT INTO users(username, password) VALUES ('Noemille', 'tatatata')");

            db.testeSELECT();
            db.closeConnection();
        }
    }
}
