using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyfmis.Forms.Software
{
    public partial class SysSoftwareForm : Form
    {
        public SysSoftwareForm()
        {
            InitializeComponent();
            InitializeDefaultForm();

            Controllers.SysSoftwareController sysSoftwareController = new Controllers.SysSoftwareController();

            panelSidebarMenu.Visible = false;
        }

        // =========
        // Tab Pages
        // =========
        public TabPage tabPageItemList = new TabPage { Name = "tabPageItemList", Text = "Setup - Item List" };
        public TabPage tabPageItemDetail = new TabPage { Name = "tabPageItemDetail", Text = "Setup - Item Detail" };
        public TabPage tabPageCustomerList = new TabPage { Name = "tabPageCustomerList", Text = "Setup - Customer List" };
        public TabPage tabPageCustomerDetail = new TabPage { Name = "tabPageCustomerDetail", Text = "Setup - Customer Detail" };
        public TabPage tabPageDiscountingList = new TabPage { Name = "tabPageDiscountingList", Text = "Setup - Discounting List" };
        public TabPage tabPageDiscountingDetail = new TabPage { Name = "tabPageDiscountingDetail", Text = "Setup - Discounting Detail" };
        public TabPage tabPageUserList = new TabPage { Name = "tabPageUserList", Text = "Setup - User List" };
        public TabPage tabPageUserDetail = new TabPage { Name = "tabPageUserDetail", Text = "Setup - User Detail" };

        public TabPage tabPagePOSSalesList = new TabPage { Name = "tabPagePOSSalesList", Text = "Activity - POS Barcode - Sales List" };
        public TabPage tabPagePOSSalesDetail = new TabPage { Name = "tabPagePOSSalesDetail", Text = "Activity - POS Barcode - Sales Detail" };
        public TabPage tabPageStockInList = new TabPage { Name = "tabPageStockInList", Text = "Activity - Stock-In List" };
        public TabPage tabPageStockInDetail = new TabPage { Name = "tabPageStockInDetail", Text = "Activity - Stock-In Detail" };
        public TabPage tabPageStockOutList = new TabPage { Name = "tabPageStockOutList", Text = "Activity - Stock-Out List" };
        public TabPage tabPageStockOutDetail = new TabPage { Name = "tabPageStockOutDetail", Text = "Activity - Stock-Out Detail" };
        public TabPage tabPageStockCountList = new TabPage { Name = "tabPageStockCountList", Text = "Activity - Stock-Count List" };
        public TabPage tabPageStockCountDetail = new TabPage { Name = "tabPageStockCountDetail", Text = "Activity - Stock-Count Detail" };
        public TabPage tabPageDisbursementList = new TabPage { Name = "tabPageDisbursementList", Text = "Activity - Remittance List" };
        public TabPage tabPageDisbursementDetail = new TabPage { Name = "tabPageDisbursementDetail", Text = "Activity - Remittance Detail" };

        public TabPage tabPagePOSReport = new TabPage { Name = "tabPagePOSReport", Text = "Report - POS Report" };
        public TabPage tabPageSalesReports = new TabPage { Name = "tabPageSalesReports ", Text = "Report - Sales Report" };
        public TabPage tabPageInventoryReports = new TabPage { Name = "tabPageInventoryReports ", Text = "Report - Inventory Report" };
        public TabPage tabPageRemittanceReports = new TabPage { Name = "tabPageRemittanceReports ", Text = "Report - Remittance Report" };

        public TabPage tabPageSystemTables = new TabPage { Name = "tabPageSystemTables", Text = "System - System Tables" };

        public TabPage tabPageSettings = new TabPage { Name = "tabPageSettings", Text = "Settings" };

        // =====
        // Forms
        // =====
        //public MstItem.MstItemListForm mstItemListForm = null;
        //public MstItem.MstItemDetailForm mstItemDetailForm = null;
        //public MstCustomer.MstCustomerListForm mstCustomerListForm = null;
        //public MstCustomer.MstCustomerDetailForm mstCustomerDetailForm = null;
        //public MstDiscounting.MstDiscountingListForm mstDiscountingListForm = null;
        //public MstDiscounting.MstDiscountingDetailForm mstDiscountingDetailForm = null;
        //public MstUser.MstUserListForm mstUserListForm = null;
        //public MstUser.MstUserDetailForm mstUserDetailForm = null;

        //public TrnPOS.TrnSalesListForm trnSalesListForm = null;
        //public TrnPOS.TrnSalesDetailForm trnSalesDetailForm = null;
        //public TrnStockIn.TrnStockInListForm trnStockInListForm = null;
        //public TrnStockIn.TrnStockInDetailForm trnStockInDetailForm = null;
        //public TrnStockOut.TrnStockOutListForm trnStockOutListForm = null;
        //public TrnStockOut.TrnStockOutDetailForm trnStockOutDetailForm = null;
        //public TrnStockCount.TrnStockCountListForm trnStockCountListForm = null;
        //public TrnStockCount.TrnStockCountDetailForm trnStockCountDetailForm = null;
        //public TrnDisbursement.TrnDisbursementListForm trnDisbursementListForm = null;
        //public TrnDisbursement.TrnDisbursementDetailForm trnDisbursementDetailForm = null;

        //public RepPOSReport.RepPOSReportForm repPOSReportForm = null;
        //public RepSalesReport.RepSalesReportForm repSalesReportForm = null;
        //public RepInventoryReport.RepInventoryReportForm repInventoryReportForm = null;
        //public RepRemittanceReport.RepRemittanceReportForm repRemittanceReportForm = null;

        //public SysSystemTables.SysSystemTablesForm sysSystemTablesForm = null;

        //public SysSettings.SysSettingsForm sysSettingsForm = null;

        public void InitializeDefaultForm()
        {
            //SysMenu.SysMenuForm sysMenuForm = new SysMenu.SysMenuForm(this)
            //{
            //    TopLevel = false,
            //    Visible = true,
            //    Dock = DockStyle.Fill
            //};

            //tabPageSysMenu.Controls.Add(sysMenuForm);
        }

        public void AddTabPageRemittanceReports()
        {
            //tabPageRemittanceReports.Controls.Remove(repRemittanceReportForm);

            //repRemittanceReportForm = new RepRemittanceReport.RepRemittanceReportForm(this)
            //{
            //    TopLevel = false,
            //    Visible = true,
            //    Dock = DockStyle.Fill
            //};

            //tabPageRemittanceReports.Controls.Add(repRemittanceReportForm);

            //if (tabControlSoftware.TabPages.Contains(tabPageRemittanceReports) == true)
            //{
            //    tabControlSoftware.SelectTab(tabPageRemittanceReports);
            //}
            //else
            //{
            //    tabControlSoftware.TabPages.Add(tabPageRemittanceReports);
            //    tabControlSoftware.SelectTab(tabPageRemittanceReports);
            //}
        }

        // =============
        // Tab Functions
        // =============
        //public void AddTabPageItemList()
        //{
        //    //tabPageItemList.Controls.Remove(mstItemListForm);

        //    //mstItemListForm = new MstItem.MstItemListForm(this)
        //    //{
        //    //    TopLevel = false,
        //    //    Visible = true,
        //    //    Dock = DockStyle.Fill
        //    //};

        //    //tabPageItemList.Controls.Add(mstItemListForm);

        //    //if (tabControlSoftware.TabPages.Contains(tabPageItemList) == true)
        //    //{
        //    //    tabControlSoftware.SelectTab(tabPageItemList);
        //    //}
        //    //else
        //    //{
        //    //    tabControlSoftware.TabPages.Add(tabPageItemList);
        //    //    tabControlSoftware.SelectTab(tabPageItemList);
        //    //}
        //}

        //public void AddTabPageItemDetail(MstItem.MstItemListForm itemListForm, Entities.MstItemEntity itemEntity)
        //{
        //    //tabPageItemDetail.Controls.Remove(mstItemDetailForm);

        //    //mstItemDetailForm = new MstItem.MstItemDetailForm(this, itemListForm, itemEntity)
        //    //{
        //    //    TopLevel = false,
        //    //    Visible = true,
        //    //    Dock = DockStyle.Fill
        //    //};

        //    //tabPageItemDetail.Controls.Add(mstItemDetailForm);

        //    //if (tabControlSoftware.TabPages.Contains(tabPageItemDetail) == true)
        //    //{
        //    //    tabControlSoftware.SelectTab(tabPageItemDetail);
        //    //}
        //    //else
        //    //{
        //    //    tabControlSoftware.TabPages.Add(tabPageItemDetail);
        //    //    tabControlSoftware.SelectTab(tabPageItemDetail);
        //    //}
        //}

        //public void AddTabPageCustomerList()
        //{
        //    tabPageCustomerList.Controls.Remove(mstCustomerListForm);

        //    mstCustomerListForm = new MstCustomer.MstCustomerListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageCustomerList.Controls.Add(mstCustomerListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageCustomerList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageCustomerList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageCustomerList);
        //        tabControlSoftware.SelectTab(tabPageCustomerList);
        //    }
        //}

        //public void AddTabPageCustomerDetail(MstCustomer.MstCustomerListForm itemListForm, Entities.MstCustomerEntity itemEntity)
        //{
        //    tabPageCustomerDetail.Controls.Remove(mstCustomerDetailForm);

        //    mstCustomerDetailForm = new MstCustomer.MstCustomerDetailForm(this, itemListForm, itemEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageCustomerDetail.Controls.Add(mstCustomerDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageCustomerDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageCustomerDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageCustomerDetail);
        //        tabControlSoftware.SelectTab(tabPageCustomerDetail);
        //    }
        //}

        //public void AddTabPageDiscountingList()
        //{
        //    tabPageDiscountingList.Controls.Remove(mstDiscountingListForm);

        //    mstDiscountingListForm = new MstDiscounting.MstDiscountingListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageDiscountingList.Controls.Add(mstDiscountingListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageDiscountingList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageDiscountingList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageDiscountingList);
        //        tabControlSoftware.SelectTab(tabPageDiscountingList);
        //    }
        //}

        //public void AddTabPageDiscountingDetail(MstDiscounting.MstDiscountingListForm discountingListForm, Entities.MstDiscountEntity discountingEntity)
        //{
        //    tabPageDiscountingDetail.Controls.Remove(mstDiscountingDetailForm);

        //    mstDiscountingDetailForm = new MstDiscounting.MstDiscountingDetailForm(this, discountingListForm, discountingEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageDiscountingDetail.Controls.Add(mstDiscountingDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageDiscountingDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageDiscountingDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageDiscountingDetail);
        //        tabControlSoftware.SelectTab(tabPageDiscountingDetail);
        //    }
        //}

        //public void AddTabPageUserList()
        //{
        //    tabPageUserList.Controls.Remove(mstUserListForm);

        //    mstUserListForm = new MstUser.MstUserListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageUserList.Controls.Add(mstUserListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageUserList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageUserList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageUserList);
        //        tabControlSoftware.SelectTab(tabPageUserList);
        //    }
        //}

        //public void AddTabPageUserDetail(MstUser.MstUserListForm userListForm, Entities.MstUserEntity userEntity)
        //{
        //    tabPageUserDetail.Controls.Remove(mstUserDetailForm);

        //    mstUserDetailForm = new MstUser.MstUserDetailForm(this, userListForm, userEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageUserDetail.Controls.Add(mstUserDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageUserDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageUserDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageUserDetail);
        //        tabControlSoftware.SelectTab(tabPageUserDetail);
        //    }
        //}

        //public void AddTabPagePOSSalesList()
        //{
        //    tabPagePOSSalesList.Controls.Remove(trnSalesListForm);

        //    trnSalesListForm = new TrnPOS.TrnSalesListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPagePOSSalesList.Controls.Add(trnSalesListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPagePOSSalesList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPagePOSSalesList);
        //        tabControlSoftware.SelectTab(tabPagePOSSalesList);
        //    }
        //}

        //public void AddTabPagePOSSalesDetail(TrnPOS.TrnSalesListForm salesListForm, Entities.TrnSalesEntity salesEntity)
        //{
        //    tabPagePOSSalesDetail.Controls.Remove(trnSalesDetailForm);

        //    trnSalesDetailForm = new TrnPOS.TrnSalesDetailForm(this, salesListForm, salesEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPagePOSSalesDetail.Controls.Add(trnSalesDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPagePOSSalesDetail);
        //        tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
        //    }
        //}

        //public void AddTabPageStockInList()
        //{
        //    tabPageStockInList.Controls.Remove(trnStockInListForm);

        //    trnStockInListForm = new TrnStockIn.TrnStockInListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockInList.Controls.Add(trnStockInListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockInList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockInList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockInList);
        //        tabControlSoftware.SelectTab(tabPageStockInList);
        //    }
        //}

        //public void AddTabPageStockInDetail(TrnStockIn.TrnStockInListForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        //{
        //    tabPageStockInDetail.Controls.Remove(trnStockInDetailForm);

        //    trnStockInDetailForm = new TrnStockIn.TrnStockInDetailForm(this, stockInListForm, stockInEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockInDetail.Controls.Add(trnStockInDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockInDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockInDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockInDetail);
        //        tabControlSoftware.SelectTab(tabPageStockInDetail);
        //    }
        //}

        //public void AddTabPageStockOutList()
        //{
        //    tabPageStockOutList.Controls.Remove(trnStockOutListForm);

        //    trnStockOutListForm = new TrnStockOut.TrnStockOutListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockOutList.Controls.Add(trnStockOutListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockOutList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockOutList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockOutList);
        //        tabControlSoftware.SelectTab(tabPageStockOutList);
        //    }
        //}

        //public void AddTabPageStockOutDetail(TrnStockOut.TrnStockOutListForm stockOutListForm, Entities.TrnStockOutEntity stockOutEntity)
        //{
        //    tabPageStockOutDetail.Controls.Remove(trnStockOutDetailForm);

        //    trnStockOutDetailForm = new TrnStockOut.TrnStockOutDetailForm(this, stockOutListForm, stockOutEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockOutDetail.Controls.Add(trnStockOutDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockOutDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockOutDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockOutDetail);
        //        tabControlSoftware.SelectTab(tabPageStockOutDetail);
        //    }
        //}

        //public void AddTabPageStockCountList()
        //{
        //    tabPageStockCountList.Controls.Remove(trnStockCountListForm);

        //    trnStockCountListForm = new TrnStockCount.TrnStockCountListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockCountList.Controls.Add(trnStockCountListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockCountList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockCountList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockCountList);
        //        tabControlSoftware.SelectTab(tabPageStockCountList);
        //    }
        //}

        //public void AddTabPageStockCountDetail(TrnStockCount.TrnStockCountListForm stockCountListForm, Entities.TrnStockCountEntity stockCountEntity)
        //{
        //    tabPageStockCountDetail.Controls.Remove(trnStockCountDetailForm);

        //    trnStockCountDetailForm = new TrnStockCount.TrnStockCountDetailForm(this, stockCountListForm, stockCountEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageStockCountDetail.Controls.Add(trnStockCountDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageStockCountDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageStockCountDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageStockCountDetail);
        //        tabControlSoftware.SelectTab(tabPageStockCountDetail);
        //    }
        //}

        //public void AddTabPageDisbursementList()
        //{
        //    tabPageDisbursementList.Controls.Remove(trnDisbursementListForm);

        //    trnDisbursementListForm = new TrnDisbursement.TrnDisbursementListForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageDisbursementList.Controls.Add(trnDisbursementListForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageDisbursementList) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageDisbursementList);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageDisbursementList);
        //        tabControlSoftware.SelectTab(tabPageDisbursementList);
        //    }
        //}

        //public void AddTabPageDisbursementDetail(TrnDisbursement.TrnDisbursementListForm disbursementListForm, Entities.TrnDisbursementEntity disbursementEntity)
        //{
        //    tabPageDisbursementDetail.Controls.Remove(trnDisbursementDetailForm);

        //    trnDisbursementDetailForm = new TrnDisbursement.TrnDisbursementDetailForm(this, disbursementListForm, disbursementEntity)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageDisbursementDetail.Controls.Add(trnDisbursementDetailForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageDisbursementDetail) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageDisbursementDetail);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageDisbursementDetail);
        //        tabControlSoftware.SelectTab(tabPageDisbursementDetail);
        //    }
        //}

        //public void AddTabPagePOSReport()
        //{
        //    tabPagePOSReport.Controls.Remove(repPOSReportForm);

        //    repPOSReportForm = new RepPOSReport.RepPOSReportForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPagePOSReport.Controls.Add(repPOSReportForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPagePOSReport) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPagePOSReport);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPagePOSReport);
        //        tabControlSoftware.SelectTab(tabPagePOSReport);
        //    }
        //}

        //public void AddTabPageInventoryReports()
        //{
        //    tabPageInventoryReports.Controls.Remove(repInventoryReportForm);

        //    repInventoryReportForm = new RepInventoryReport.RepInventoryReportForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageInventoryReports.Controls.Add(repInventoryReportForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageInventoryReports) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageInventoryReports);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageInventoryReports);
        //        tabControlSoftware.SelectTab(tabPageInventoryReports);
        //    }
        //}

        //public void AddTabPageSystemTables()
        //{
        //    tabPageSystemTables.Controls.Remove(sysSystemTablesForm);

        //    sysSystemTablesForm = new SysSystemTables.SysSystemTablesForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageSystemTables.Controls.Add(sysSystemTablesForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageSystemTables) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageSystemTables);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageSystemTables);
        //        tabControlSoftware.SelectTab(tabPageSystemTables);
        //    }
        //}

        //public void AddTabPageSettings()
        //{
        //    tabPageSettings.Controls.Remove(sysSettingsForm);

        //    if (sysSettingsForm == null)
        //    {
        //        sysSettingsForm = new SysSettings.SysSettingsForm(this)
        //        {
        //            TopLevel = false,
        //            Visible = true,
        //            Dock = DockStyle.Fill
        //        };
        //    }

        //    tabPageSettings.Controls.Add(sysSettingsForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageSettings) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageSettings);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageSettings);
        //        tabControlSoftware.SelectTab(tabPageSettings);
        //    }
        //}

        //public void AddTabPageSalesReport()
        //{
        //    tabPageSalesReports.Controls.Remove(repSalesReportForm);

        //    repSalesReportForm = new RepSalesReport.RepSalesReportForm(this)
        //    {
        //        TopLevel = false,
        //        Visible = true,
        //        Dock = DockStyle.Fill
        //    };

        //    tabPageSalesReports.Controls.Add(repSalesReportForm);

        //    if (tabControlSoftware.TabPages.Contains(tabPageSalesReports) == true)
        //    {
        //        tabControlSoftware.SelectTab(tabPageSalesReports);
        //    }
        //    else
        //    {
        //        tabControlSoftware.TabPages.Add(tabPageSalesReports);
        //        tabControlSoftware.SelectTab(tabPageSalesReports);
        //    }
        //}

        //public void RemoveTabPage()
        //{
        //    tabControlSoftware.TabPages.Remove(tabControlSoftware.SelectedTab);
        //    tabControlSoftware.SelectTab(tabControlSoftware.TabPages.Count - 1);
        //}

        private void SysSoftwareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Account.SysLogin.SysLoginForm sysLogin = new Account.SysLogin.SysLoginForm();
            sysLogin.Show();
        }

        private void tabControlSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControlSoftware.SelectedTab == tabPagePOSSalesList || tabControlSoftware.SelectedTab == tabPagePOSSalesDetail)
            //{
            //    labelLastChange.Visible = true;
            //    textBoxLastChange.Visible = true;
            //}
            //else
            //{
            //    labelLastChange.Visible = false;
            //    textBoxLastChange.Visible = false;
            //}
        }

        private void buttonOpenSidebarMenu_Click(object sender, EventArgs e)
        {
            if (panelSidebarMenu.Visible == false)
            {
                panelSidebarMenu.Visible = true;
            }
            else
            {
                panelSidebarMenu.Visible = false;
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tabControlSoftware.SelectTab(tabPageSysMenu);
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageItemList();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageCustomerList();
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageDiscountingList();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageUserList();
        }

        private void pOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //AddTabPagePOSSalesList();
        }

        private void pOSTouchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void remittanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageDisbursementList();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageStockInList();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageStockOutList();
        }

        private void stockCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageStockCountList();
        }

        private void systemTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageSystemTables();
        }

        private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pOSReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPagePOSReport();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageSalesReport();
        }

        private void remittanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageRemittanceReports();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageInventoryReports();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageSettings();
        }
    }
}
