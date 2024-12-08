using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class Estilos
    {
        DataGridView dgv;

        public Estilos(DataGridView dgv)
        {
            this.dgv = dgv;
        }

        public void formatoCelda()
        {
            DataGridViewCellStyle styEstilo = new DataGridViewCellStyle();
            styEstilo.BackColor = Color.Yellow;
            styEstilo.ForeColor = Color.Blue;
            this.dgv.DefaultCellStyle = styEstilo;
        }

        public void formatoFilasAlternas()
        {
            DataGridViewCellStyle styAlterno;
            styAlterno = new DataGridViewCellStyle();
            styAlterno.BackColor = Color.LightBlue;
            styAlterno.ForeColor = Color.Black;
            this.dgv.AlternatingRowsDefaultCellStyle = styAlterno;
        }
    }
}
