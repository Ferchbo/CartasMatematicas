using System;

namespace CartasMatematicas
{
    public partial class Form1 : Form
    {
        private int _num1, _num2;
        private Random _random;
        private OperacionEnum _operacion;
        private int _resultado;
        public Form1()
        {
            InitializeComponent();
            _random = new Random();
            IniciarPantalla();
        }

        private void IniciarPantalla()
        {
            lblRes.Text = string.Empty;

            lblNuevo.Visible = false;
            lblSel.Visible = true;

            lblOp1.Visible = true;
            lblOp2.Visible = true;
            lblOp4.Visible = true;
            lblOp4.Visible = true;
            lblOp5.Visible = true;
            lblOp6.Visible = true;

            TomaNum();
            TomaOpe();
            TomaResp();

        }

        private void TomaNum()
        {
            _num1 = _random.Next(1, 20);
            _num2 = _random.Next(1, 20);

            lblNum1.Text = _num1.ToString();
            lblNum2.Text = _num2.ToString();
        }

        private void TomaOpe()
        {
            var valorEnum = Enum.GetValues(typeof(OperacionEnum));
            _operacion = (OperacionEnum)valorEnum.GetValue(_random.Next(valorEnum.Length));

            lblOpe.Text = _operacion.TomaSimbolo();

        }

        private void TomaResp()
        {
            _resultado = _operacion.ObtResp(_num1, _num2);

            var valor = new List<int>
            {
                _resultado + 1,
                _resultado + 2,
                _resultado,
                _resultado - 3,
                _resultado -2,
                _resultado -1
            };

            var opcion = new List<int> { 1,2,3,4,5,6 };

            for (int i = 0; i < 6; i++)
            {
                var ramLabel = opcion[_random.Next(0, opcion.Count())];
                var ramValor = valor[_random.Next(valor.Count())];
                TomaOpcion(ramLabel, ramValor);

                valor.Remove(ramValor);
                opcion.Remove(ramLabel);
            }

        }

        private void TomaOpcion(int ramLabel, int ramValor)
        {
            switch (ramLabel)
            {
                case 1: lblOp1.Text = ramValor.ToString(); break;
                case 2: lblOp2.Text = ramValor.ToString(); break;
                case 3: lblOp3.Text = ramValor.ToString(); break;
                case 4: lblOp4.Text = ramValor.ToString(); break;
                case 5: lblOp5.Text = ramValor.ToString(); break;
                case 6: lblOp6.Text = ramValor.ToString(); break;
            }
        }

        private void lblOp_Click(object sender, EventArgs e)
        {
            if (sender is not Label)
                return;

            var seleccion = int.Parse(((Label)sender).Text);

            if (seleccion == _resultado)
            {
                lblRes.Text = "Correcto";
                lblRes.ForeColor = Color.Green;

                lblNuevo.Visible = true;
                lblSel.Visible = false;
            }
            else
            {
                lblRes.Text = "Esta MAL";
                lblRes.ForeColor = Color.Red;

                ((Label)sender).Visible = false;
            }

        }

        private void lblNuevo_Click(object sender, EventArgs e)
        {
            IniciarPantalla();
        }
    }
}