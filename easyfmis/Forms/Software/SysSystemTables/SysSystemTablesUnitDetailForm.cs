﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesUnitDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;

        Entities.MstUnitEntity mstUnitEntity;

        public SysSystemTablesUnitDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstUnitEntity unitEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstUnitEntity = unitEntity;

            LoadUnit();
            textBoxUnit.Focus();
        }

        public void LoadUnit()
        {
            if (mstUnitEntity != null)
            {
                textBoxUnit.Text = mstUnitEntity.Unit;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (mstUnitEntity == null)
            {
                Entities.MstUnitEntity newUnit = new Entities.MstUnitEntity()
                {
                    Unit = textBoxUnit.Text
                };

                Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();
                String[] addUnit = mstUnitController.AddUnit(newUnit);
                if (addUnit[1].Equals("0") == true)
                {
                    MessageBox.Show(addUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateUnitListDataSource();
                    Close();
                }
            }
            else
            {
                mstUnitEntity.Unit = textBoxUnit.Text;
                Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();
                String[] updateUnit = mstUnitController.UpdateUnit(mstUnitEntity);
                if (updateUnit[1].Equals("0") == true)
                {
                    MessageBox.Show(updateUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sysSystemTablesForm.UpdateUnitListDataSource();
                    Close();
                }

            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
