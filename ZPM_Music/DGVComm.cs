using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ZPM_Music
{
    public static class DGVComm
    {
        public static void setDGVColumns(this DataGridView grid, string label, string dataField, DataGridViewContentAlignment alignment, bool isVisible = true, bool isLock = true, int width = 100, DataGridViewColumn columnType = null)
        {
            int columnIndex = 0;

            if (columnType == null)
            {
                columnIndex = grid.Columns.Add(new DataGridViewTextBoxColumn());
            }
            else
            {
                columnIndex = grid.Columns.Add(columnType);
            }

            grid.Columns[columnIndex].HeaderText = label;
            grid.Columns[columnIndex].DataPropertyName = dataField;
            grid.Columns[columnIndex].DefaultCellStyle.Alignment = alignment;
            grid.Columns[columnIndex].Visible = isVisible;
            grid.Columns[columnIndex].ReadOnly = isLock;
            grid.Columns[columnIndex].Width = width;
        }

        public static void setDGVStyle(this DataGridView grid,Color color)
        {
            grid.AllowUserToAddRows = false;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersDefaultCellStyle.BackColor = color;            
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LawnGreen;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Red;
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.BackColor = color;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("楷体", 12);
            grid.DefaultCellStyle.SelectionBackColor = Color.LawnGreen;
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Red;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersVisible = false;
        }

        public static void setDoubleBufferedDataGirdView(this DataGridView dgv, bool flag)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, flag, null);
        }

        public static void setShowIndex(this DataGridView dgv)
        {
            dgv.RowHeadersVisible = true;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();          
            }
        }
    }
}
