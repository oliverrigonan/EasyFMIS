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

            GetUserDetail();
            panelSidebarMenu.Visible = false;
        }

        public void GetUserDetail()
        {
            var current = Modules.SysCurrentModule.GetCurrentSettings();

            Controllers.MstUserController userController = new Controllers.MstUserController();
            var currentUserDetail = userController.DetailUser(Convert.ToInt32(current.CurrentUserId));
            if (currentUserDetail != null)
            {
                labelCurrentUserCompanyBranch.Text = "  User: " + currentUserDetail.UserName + "   Company: " + currentUserDetail.Company + "   Branch: " + currentUserDetail.Branch;
            }
        }

        public void ClearTabPages()
        {
            tabControlSoftware.TabPages.Clear();

            tabControlSoftware.TabPages.Add(tabPageSysMenu);
            tabControlSoftware.SelectTab(tabPageSysMenu);
        }

        // =========
        // Tab Pages
        // =========
        public TabPage tabPageItemList = new TabPage { Name = "tabPageItemList", Text = "Setup - Item List" };
        public TabPage tabPageItemDetail = new TabPage { Name = "tabPageItemDetail", Text = "Setup - Item Detail" };
        public TabPage tabPageCustomerList = new TabPage { Name = "tabPageCustomerList", Text = "Setup - Customer List" };
        public TabPage tabPageCustomerDetail = new TabPage { Name = "tabPageCustomerDetail", Text = "Setup - Customer Detail" };

        public TabPage tabPageSupplierList = new TabPage { Name = "tabPageSupplierList", Text = "Setup - Supplier List" };
        public TabPage tabPageSupplierDetail = new TabPage { Name = "tabPageSupplierDetail", Text = "Setup - Supplier Detail" };

        public TabPage tabPageDiscountingList = new TabPage { Name = "tabPageDiscountingList", Text = "Setup - Discounting List" };
        public TabPage tabPageDiscountingDetail = new TabPage { Name = "tabPageDiscountingDetail", Text = "Setup - Discounting Detail" };
        public TabPage tabPageUserList = new TabPage { Name = "tabPageUserList", Text = "Setup - User List" };
        public TabPage tabPageUserDetail = new TabPage { Name = "tabPageUserDetail", Text = "Setup - User Detail" };

        public TabPage tabPageCompanyList = new TabPage { Name = "tabPageCompanyList", Text = "Setup - Company List" };
        public TabPage tabPageCompanyDetail = new TabPage { Name = "tabPageCompanyDetail", Text = "Setup - Company Detail" };

        public TabPage tabPagePOSSalesList = new TabPage { Name = "tabPagePOSSalesList", Text = "Activity - POS Barcode - Sales List" };
        public TabPage tabPagePOSSalesDetail = new TabPage { Name = "tabPagePOSSalesDetail", Text = "Activity - POS Barcode - Sales Detail" };
        public TabPage tabPageStockInList = new TabPage { Name = "tabPageStockInList", Text = "Activity - Stock-In List" };
        public TabPage tabPageStockInDetail = new TabPage { Name = "tabPageStockInDetail", Text = "Activity - Stock-In Detail" };
        public TabPage tabPageStockOut = new TabPage { Name = "tabPageStockOut", Text = "Activity - Stock-Out List" };
        public TabPage tabPageStockOutDetail = new TabPage { Name = "tabPageStockOutDetail", Text = "Activity - Stock-Out Detail" };
        public TabPage tabPageStockTransfer = new TabPage { Name = "tabPageStockTransfer", Text = "Activity - Stock Transfer List" };
        public TabPage tabPageStockTransferDetail = new TabPage { Name = "tabPageStockTransferDetail", Text = "Activity - Stock Transfer Detail" };

        public TabPage tabPageDisbursementList = new TabPage { Name = "tabPageDisbursementList", Text = "Activity - Disbursement List" };
        public TabPage tabPageDisbursementDetail = new TabPage { Name = "tabPageDisbursementDetail", Text = "Activity - Disbursement Detail" };

        public TabPage tabPageMemoList = new TabPage { Name = "tabPageMemoList", Text = "Activity - Memo List" };
        public TabPage tabPageMemoDetail = new TabPage { Name = "tabPageMemoDetail", Text = "Activity - Memo Detail" };

        public TabPage tabPageSalesOrder = new TabPage { Name = "tabPageSalesOrder", Text = "Activity - Sales Order List" };
        public TabPage tabPageSalesOrderDetail = new TabPage { Name = "tabPageSalesOrderDetail", Text = "Activity - Sales Order Detail" };
        public TabPage tabPageSalesInvoice = new TabPage { Name = "tabPageSalesInvoice", Text = "Activity - Sales Invoice List" };
        public TabPage tabPageSalesInvoiceDetail = new TabPage { Name = "tabPageSalesInvoiceDetail", Text = "Activity - Sales Invoice Detail" };
        public TabPage tabPagePurchaseOrder = new TabPage { Name = "tabPagePurchaseOrder", Text = "Activity - Purchase Order List" };
        public TabPage tabPagePurchaseOrderDetail = new TabPage { Name = "tabPagePurchaseOrderDetail", Text = "Activity - Purchase Order Detail" };
        public TabPage tabPageReceivingReceipt = new TabPage { Name = "tabPageReceivingReceipt", Text = "Activity - Receiving Receipt List" };
        public TabPage tabPageReceivingReceiptDetail = new TabPage { Name = "tabPageReceivingReceiptDetail", Text = "Activity - Receiving Receipt Detail" };

        public TabPage tabPageCollection = new TabPage { Name = "tabPageCollection", Text = "Activity - Collection List" };
        public TabPage tabPageCollectionDetail = new TabPage { Name = "tabPageCollectionDetail", Text = "Activity - Collection Detail" };

        public TabPage tabPageInventoryReports = new TabPage { Name = "tabPageInventoryReports ", Text = "Report - Inventory Report" };
        public TabPage tabPageRemittanceReports = new TabPage { Name = "tabPageRemittanceReports ", Text = "Report - Remittance Report" };

        public TabPage tabPageSystemTables = new TabPage { Name = "tabPageSystemTables", Text = "System - System Tables" };

        public TabPage tabPageSettings = new TabPage { Name = "tabPageSettings", Text = "Settings" };

        public TabPage tabPageStockCountList = new TabPage { Name = "tabPageStockCountList", Text = "Activity - Stock-Count List" };
        public TabPage tabPageStockCountDetail = new TabPage { Name = "tabPageStockCountDetail", Text = "Activity - Stock-Count Detail" };

        public TabPage tabPageAccountsPayableReport = new TabPage { Name = "tabPageAccountsPayableReport", Text = "Report - Accounts Payable Report" };
        public TabPage tabPageAccountsReceivableReport = new TabPage { Name = "tabPageAccountsReceivableReport", Text = "Report - Accounts Receivable Report" };

        // =====
        // Forms
        // =====
        public MstItem.MstItemListForm mstItemListForm = null;
        public MstItem.MstItemDetailForm mstItemDetailForm = null;
        public MstCustomer.MstCustomerListForm mstCustomerListForm = null;
        public MstCustomer.MstCustomerDetailForm mstCustomerDetailForm = null;
        public MstSupplier.MstSupplierListForm mstSupplierListForm = null;
        public MstSupplier.MstSupplierDetailForm mstSupplierDetailForm = null;

        //public MstDiscounting.MstDiscountingListForm mstDiscountingListForm = null;
        //public MstDiscounting.MstDiscountingDetailForm mstDiscountingDetailForm = null;
        public MstUser.MstUserListForm mstUserListForm = null;
        public MstUser.MstUserDetailForm mstUserDetailForm = null;

        public MstCompany.MstCompanyListForm mstCompanyListForm = null;
        public MstCompany.MstCompanyDetailForm mstCompanyDetailForm = null;


        //public TrnPOS.TrnSalesListForm trnSalesListForm = null;
        //public TrnPOS.TrnSalesDetailForm trnSalesDetailForm = null;
        public TrnStockIn.TrnStockInForm trnStockInForm = null;
        public TrnStockIn.TrnStockInDetailForm trnStockInDetailForm = null;
        public TrnStockOut.TrnStockOutForm trnStockOutForm = null;
        public TrnStockOut.TrnStockOutDetailForm trnStockOutDetailForm = null;
        public TrnStockTransfer.TrnStockTransferForm trnStockTransferForm = null;
        public TrnStockTransfer.TrnStockTransferDetailForm trnStockTransferDetailForm = null;
        public TrnSalesOrder.TrnSalesOrderForm trnSalesOrderForm = null;
        public TrnSalesOrder.TrnSalesOrderDetailForm trnSalesOrderDetailForm = null;
        public TrnSalesInvoice.TrnSalesInvoiceForm trnSalesInvoiceForm = null;
        public TrnSalesInvoice.TrnSalesInvoiceDetailForm trnSalesInvoiceDetailForm = null;
        public TrnPurchaseOrder.TrnPurchaseOrderForm trnPurchaseOrderForm = null;
        public TrnPurchaseOrder.TrnPurchaseOrderDetailForm trnPurchaseOrderDetailForm = null;

        public TrnReceivingReceipt.TrnReceivingReceiptForm trnReceivingReceiptForm = null;
        public TrnReceivingReceipt.TrnReceivingReceiptDetailForm trnReceivingReceiptDetailForm = null;

        public TrnCollection.TrnCollectionForm trnCollectionForm = null;
        public TrnCollection.TrnCollectionDetailForm trnCollectionDetailForm = null;

        public TrnMemo.TrnMemoListForm trnMemoForm  = null;
        public TrnMemo.TrnMemoDetailForm trnMemoDetailForm = null;

        //public TrnStockCount.TrnStockCountListForm trnStockCountListForm = null;
        //public TrnStockCount.TrnStockCountDetailForm trnStockCountDetailForm = null;
        public TrnDisbursement.TrnDisbursementListForm trnDisbursementListForm = null;
        public TrnDisbursement.TrnDisbursementDetailForm trnDisbursementDetailForm = null;

        public RepAccountsPayableReport.RepAccountsPayableReportForm repAccountsPayableReportForm = null;
        public RepAccountsReceivableReport.RepAccountsReceivableReportForm repAccountsReceivableReportForm = null;
        public RepInventoryReport.RepInventoryReportForm repInventoryReportForm = null;
        //public RepRemittanceReport.RepRemittanceReportForm repRemittanceReportForm = null;

        public SysSystemTables.SysSystemTablesForm sysSystemTablesForm = null;

        //public SysSettings.SysSettingsForm sysSettingsForm = null;

        public void InitializeDefaultForm()
        {
            SysMenu.SysMenuForm sysMenuForm = new SysMenu.SysMenuForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSysMenu.Controls.Add(sysMenuForm);
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

        //=============
        //Tab Functions
        //=============
        public void AddTabPageItemList()
        {
            tabPageItemList.Controls.Remove(mstItemListForm);

            mstItemListForm = new MstItem.MstItemListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageItemList.Controls.Add(mstItemListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageItemList) == true)
            {
                tabControlSoftware.SelectTab(tabPageItemList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageItemList);
                tabControlSoftware.SelectTab(tabPageItemList);
            }
        }

        public void AddTabPageItemDetail(MstItem.MstItemListForm itemListForm, Entities.MstArticleEntity itemEntity)
        {
            tabPageItemDetail.Controls.Remove(mstItemDetailForm);

            mstItemDetailForm = new MstItem.MstItemDetailForm(this, itemListForm, itemEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageItemDetail.Controls.Add(mstItemDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageItemDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageItemDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageItemDetail);
                tabControlSoftware.SelectTab(tabPageItemDetail);
            }
        }

        public void AddTabPageCustomerList()
        {
            tabPageCustomerList.Controls.Remove(mstCustomerListForm);

            mstCustomerListForm = new MstCustomer.MstCustomerListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCustomerList.Controls.Add(mstCustomerListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCustomerList) == true)
            {
                tabControlSoftware.SelectTab(tabPageCustomerList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCustomerList);
                tabControlSoftware.SelectTab(tabPageCustomerList);
            }
        }

        public void AddTabPageCustomerDetail(MstCustomer.MstCustomerListForm itemListForm, Entities.MstArticleEntity itemEntity)
        {
            tabPageCustomerDetail.Controls.Remove(mstCustomerDetailForm);

            mstCustomerDetailForm = new MstCustomer.MstCustomerDetailForm(this, itemListForm, itemEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCustomerDetail.Controls.Add(mstCustomerDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCustomerDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageCustomerDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCustomerDetail);
                tabControlSoftware.SelectTab(tabPageCustomerDetail);
            }
        }

        public void AddTabPageSupplierList()
        {
            tabPageSupplierList.Controls.Remove(mstSupplierListForm);

            mstSupplierListForm = new MstSupplier.MstSupplierListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSupplierList.Controls.Add(mstSupplierListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSupplierList) == true)
            {
                tabControlSoftware.SelectTab(tabPageSupplierList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSupplierList);
                tabControlSoftware.SelectTab(tabPageSupplierList);
            }
        }

        public void AddTabPageSupplierDetail(MstSupplier.MstSupplierListForm itemListForm, Entities.MstArticleEntity itemEntity)
        {
            tabPageSupplierDetail.Controls.Remove(mstSupplierDetailForm);

            mstSupplierDetailForm = new MstSupplier.MstSupplierDetailForm(this, itemListForm, itemEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSupplierDetail.Controls.Add(mstSupplierDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSupplierDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageSupplierDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSupplierDetail);
                tabControlSoftware.SelectTab(tabPageSupplierDetail);
            }
        }

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

        public void AddTabPageUserList()
        {
            tabPageUserList.Controls.Remove(mstUserListForm);

            mstUserListForm = new MstUser.MstUserListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageUserList.Controls.Add(mstUserListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageUserList) == true)
            {
                tabControlSoftware.SelectTab(tabPageUserList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageUserList);
                tabControlSoftware.SelectTab(tabPageUserList);
            }
        }

        public void AddTabPageUserDetail(MstUser.MstUserListForm userListForm, Entities.MstUserEntity userEntity)
        {
            tabPageUserDetail.Controls.Remove(mstUserDetailForm);

            mstUserDetailForm = new MstUser.MstUserDetailForm(this, userListForm, userEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageUserDetail.Controls.Add(mstUserDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageUserDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageUserDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageUserDetail);
                tabControlSoftware.SelectTab(tabPageUserDetail);
            }
        }

        public void AddTabPageCompanyList()
        {
            tabPageCompanyList.Controls.Remove(mstCompanyListForm);

            mstCompanyListForm = new MstCompany.MstCompanyListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCompanyList.Controls.Add(mstCompanyListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCompanyList) == true)
            {
                tabControlSoftware.SelectTab(tabPageCompanyList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCompanyList);
                tabControlSoftware.SelectTab(tabPageCompanyList);
            }
        }

        public void AddTabPageCompanyDetail(MstCompany.MstCompanyListForm mstCompanyListForm, Entities.MstCompanyEntity mstCompanyEntity)
        {
            tabPageCompanyDetail.Controls.Remove(mstCompanyDetailForm);

            mstCompanyDetailForm = new MstCompany.MstCompanyDetailForm(this, mstCompanyListForm, mstCompanyEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCompanyDetail.Controls.Add(mstCompanyDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCompanyDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageCompanyDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCompanyDetail);
                tabControlSoftware.SelectTab(tabPageCompanyDetail);
            }
        }



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

        public void AddTabPageStockInList()
        {
            tabPageStockInList.Controls.Remove(trnStockInForm);

            trnStockInForm = new TrnStockIn.TrnStockInForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockInList.Controls.Add(trnStockInForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockInList) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockInList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockInList);
                tabControlSoftware.SelectTab(tabPageStockInList);
            }
        }

        public void AddTabPageStockInDetail(TrnStockIn.TrnStockInForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        {
            tabPageStockInDetail.Controls.Remove(trnStockInDetailForm);

            trnStockInDetailForm = new TrnStockIn.TrnStockInDetailForm(this, stockInListForm, stockInEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockInDetail.Controls.Add(trnStockInDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockInDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockInDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockInDetail);
                tabControlSoftware.SelectTab(tabPageStockInDetail);
            }
        }

        public void AddTabPageStockOutList()
        {
            tabPageStockOut.Controls.Remove(trnStockOutForm);

            trnStockOutForm = new TrnStockOut.TrnStockOutForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockOut.Controls.Add(trnStockOutForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockOut) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockOut);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockOut);
                tabControlSoftware.SelectTab(tabPageStockOut);
            }
        }

        public void AddTabPageStockOutDetail(TrnStockOut.TrnStockOutForm stockOutListForm, Entities.TrnStockOutEntity stockOutEntity)
        {
            tabPageStockOutDetail.Controls.Remove(trnStockOutDetailForm);

            trnStockOutDetailForm = new TrnStockOut.TrnStockOutDetailForm(this, stockOutListForm, stockOutEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockOutDetail.Controls.Add(trnStockOutDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockOutDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockOutDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockOutDetail);
                tabControlSoftware.SelectTab(tabPageStockOutDetail);
            }
        }

        public void AddTabPageStockTransferList()
        {
            tabPageStockTransfer.Controls.Remove(trnStockTransferForm);

            trnStockTransferForm = new TrnStockTransfer.TrnStockTransferForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockTransfer.Controls.Add(trnStockTransferForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockTransfer) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockTransfer);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockTransfer);
                tabControlSoftware.SelectTab(tabPageStockTransfer);
            }
        }

        public void AddTabPageStockTransferDetail(TrnStockTransfer.TrnStockTransferForm stockOutListForm, Entities.TrnStockTransferEntity stockOutEntity)
        {
            tabPageStockTransferDetail.Controls.Remove(trnStockTransferDetailForm);

            trnStockTransferDetailForm = new TrnStockTransfer.TrnStockTransferDetailForm(this, stockOutListForm, stockOutEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageStockTransferDetail.Controls.Add(trnStockTransferDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageStockTransferDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageStockTransferDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageStockTransferDetail);
                tabControlSoftware.SelectTab(tabPageStockTransferDetail);
            }
        }

        public void AddTabPageSalesOrderList()
        {
            tabPageSalesOrder.Controls.Remove(trnSalesOrderForm);

            trnSalesOrderForm = new TrnSalesOrder.TrnSalesOrderForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSalesOrder.Controls.Add(trnSalesOrderForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSalesOrder) == true)
            {
                tabControlSoftware.SelectTab(tabPageSalesOrder);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSalesOrder);
                tabControlSoftware.SelectTab(tabPageSalesOrder);
            }
        }

        public void AddTabPageSalesOrderDetail(TrnSalesOrder.TrnSalesOrderForm trnSalesOrderForm, Entities.TrnSalesOrderEntity trnSalesOrderEntity)
        {
            tabPageSalesOrderDetail.Controls.Remove(trnSalesOrderDetailForm);

            trnSalesOrderDetailForm = new TrnSalesOrder.TrnSalesOrderDetailForm(this, trnSalesOrderForm, trnSalesOrderEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSalesOrderDetail.Controls.Add(trnSalesOrderDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSalesOrderDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageSalesOrderDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSalesOrderDetail);
                tabControlSoftware.SelectTab(tabPageSalesOrderDetail);
            }
        }

        public void AddTabPagePurchaseOrderList()
        {
            tabPagePurchaseOrder.Controls.Remove(trnPurchaseOrderForm);

            trnPurchaseOrderForm = new TrnPurchaseOrder.TrnPurchaseOrderForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPagePurchaseOrder.Controls.Add(trnPurchaseOrderForm);

            if (tabControlSoftware.TabPages.Contains(tabPagePurchaseOrder) == true)
            {
                tabControlSoftware.SelectTab(tabPagePurchaseOrder);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPagePurchaseOrder);
                tabControlSoftware.SelectTab(tabPagePurchaseOrder);
            }
        }

        public void AddTabPagePurchaseOrderDetail(TrnPurchaseOrder.TrnPurchaseOrderForm trnPurchaseOrderForm, Entities.TrnPurchaseOrderEntity trnPurchaseOrderEntity)
        {
            tabPagePurchaseOrderDetail.Controls.Remove(trnPurchaseOrderDetailForm);

            trnPurchaseOrderDetailForm = new TrnPurchaseOrder.TrnPurchaseOrderDetailForm(this, trnPurchaseOrderForm, trnPurchaseOrderEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPagePurchaseOrderDetail.Controls.Add(trnPurchaseOrderDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPagePurchaseOrderDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPagePurchaseOrderDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPagePurchaseOrderDetail);
                tabControlSoftware.SelectTab(tabPagePurchaseOrderDetail);
            }
        }

        public void AddTabPageSalesInvoiceList()
        {
            tabPageSalesInvoice.Controls.Remove(trnSalesInvoiceForm);

            trnSalesInvoiceForm = new TrnSalesInvoice.TrnSalesInvoiceForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSalesInvoice.Controls.Add(trnSalesInvoiceForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSalesInvoice) == true)
            {
                tabControlSoftware.SelectTab(tabPageSalesInvoice);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSalesInvoice);
                tabControlSoftware.SelectTab(tabPageSalesInvoice);
            }
        }

        public void AddTabPageSalesInvoiceDetail(TrnSalesInvoice.TrnSalesInvoiceForm trnSalesInvoiceForm, Entities.TrnSalesInvoiceEntity trnSalesInvoiceEntity)
        {
            tabPageSalesInvoiceDetail.Controls.Remove(trnSalesInvoiceDetailForm);

            trnSalesInvoiceDetailForm = new TrnSalesInvoice.TrnSalesInvoiceDetailForm(this, trnSalesInvoiceForm, trnSalesInvoiceEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSalesInvoiceDetail.Controls.Add(trnSalesInvoiceDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSalesInvoiceDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageSalesInvoiceDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSalesInvoiceDetail);
                tabControlSoftware.SelectTab(tabPageSalesInvoiceDetail);
            }
        }

        public void AddTabPageReceivingReceiptList()
        {
            tabPageReceivingReceipt.Controls.Remove(trnReceivingReceiptForm);

            trnReceivingReceiptForm = new TrnReceivingReceipt.TrnReceivingReceiptForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageReceivingReceipt.Controls.Add(trnReceivingReceiptForm);

            if (tabControlSoftware.TabPages.Contains(tabPageReceivingReceipt) == true)
            {
                tabControlSoftware.SelectTab(tabPageReceivingReceipt);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageReceivingReceipt);
                tabControlSoftware.SelectTab(tabPageReceivingReceipt);
            }
        }

        public void AddTabPageReceivingReceiptDetail(TrnReceivingReceipt.TrnReceivingReceiptForm trnReceivingReceiptForm, Entities.TrnReceivingReceiptEntity trnReceivingReceiptEntity)
        {
            tabPageReceivingReceiptDetail.Controls.Remove(trnReceivingReceiptDetailForm);

            trnReceivingReceiptDetailForm = new TrnReceivingReceipt.TrnReceivingReceiptDetailForm(this, trnReceivingReceiptForm, trnReceivingReceiptEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageReceivingReceiptDetail.Controls.Add(trnReceivingReceiptDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageReceivingReceiptDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageReceivingReceiptDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageReceivingReceiptDetail);
                tabControlSoftware.SelectTab(tabPageReceivingReceiptDetail);
            }
        }

        public void AddTabPageCollectionList()
        {
            tabPageCollection.Controls.Remove(trnCollectionForm);

            trnCollectionForm = new TrnCollection.TrnCollectionForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCollection.Controls.Add(trnCollectionForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCollection) == true)
            {
                tabControlSoftware.SelectTab(tabPageCollection);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCollection);
                tabControlSoftware.SelectTab(tabPageCollection);
            }
        }

        public void AddTabPageCollectionDetail(TrnCollection.TrnCollectionForm trnCollectionForm, Entities.TrnCollectionEntity trnCollectionEntity)
        {
            tabPageCollectionDetail.Controls.Remove(trnCollectionDetailForm);

            trnCollectionDetailForm = new TrnCollection.TrnCollectionDetailForm(this, trnCollectionForm, trnCollectionEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageCollectionDetail.Controls.Add(trnCollectionDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageCollectionDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageCollectionDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageCollectionDetail);
                tabControlSoftware.SelectTab(tabPageCollectionDetail);
            }
        }

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

        public void AddTabPageDisbursementList()
        {
            tabPageDisbursementList.Controls.Remove(trnDisbursementListForm);

            trnDisbursementListForm = new TrnDisbursement.TrnDisbursementListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageDisbursementList.Controls.Add(trnDisbursementListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageDisbursementList) == true)
            {
                tabControlSoftware.SelectTab(tabPageDisbursementList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageDisbursementList);
                tabControlSoftware.SelectTab(tabPageDisbursementList);
            }
        }

        public void AddTabPageDisbursementDetail(TrnDisbursement.TrnDisbursementListForm disbursementListForm, Entities.TrnDisbursementEntity disbursementEntity)
        {
            tabPageDisbursementDetail.Controls.Remove(trnDisbursementDetailForm);

            trnDisbursementDetailForm = new TrnDisbursement.TrnDisbursementDetailForm(this, disbursementListForm, disbursementEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageDisbursementDetail.Controls.Add(trnDisbursementDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageDisbursementDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageDisbursementDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageDisbursementDetail);
                tabControlSoftware.SelectTab(tabPageDisbursementDetail);
            }
        }

        public void AddTabPageMemoList()
        {
            tabPageMemoList.Controls.Remove(trnMemoForm);

            trnMemoForm = new TrnMemo.TrnMemoListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageMemoList.Controls.Add(trnMemoForm);

            if (tabControlSoftware.TabPages.Contains(tabPageMemoList) == true)
            {
                tabControlSoftware.SelectTab(tabPageMemoList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageMemoList);
                tabControlSoftware.SelectTab(tabPageMemoList);
            }
        }

        public void AddTabPageMemoDetail(TrnMemo.TrnMemoListForm trnMemoForm, Entities.TrnMemoEntity trnMemoEntity)
        {
            tabPageMemoDetail.Controls.Remove(trnMemoDetailForm);

            trnMemoDetailForm = new TrnMemo.TrnMemoDetailForm(this, trnMemoForm, trnMemoEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageMemoDetail.Controls.Add(trnMemoDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageMemoDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageMemoDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageMemoDetail);
                tabControlSoftware.SelectTab(tabPageMemoDetail);
            }
        }

        public void AddTabPageAccountsPayableReport()
        {
            tabPageAccountsPayableReport.Controls.Remove(repAccountsPayableReportForm);

            repAccountsPayableReportForm = new RepAccountsPayableReport.RepAccountsPayableReportForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageAccountsPayableReport.Controls.Add(repAccountsPayableReportForm);

            if (tabControlSoftware.TabPages.Contains(tabPageAccountsPayableReport) == true)
            {
                tabControlSoftware.SelectTab(tabPageAccountsPayableReport);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageAccountsPayableReport);
                tabControlSoftware.SelectTab(tabPageAccountsPayableReport);
            }
        }

        public void AddTabPageAccountsReceivableReport()
        {
            tabPageAccountsReceivableReport.Controls.Remove(repAccountsReceivableReportForm);

            repAccountsReceivableReportForm = new RepAccountsReceivableReport.RepAccountsReceivableReportForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageAccountsReceivableReport.Controls.Add(repAccountsReceivableReportForm);

            if (tabControlSoftware.TabPages.Contains(tabPageAccountsReceivableReport) == true)
            {
                tabControlSoftware.SelectTab(tabPageAccountsReceivableReport);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageAccountsReceivableReport);
                tabControlSoftware.SelectTab(tabPageAccountsReceivableReport);
            }
        }

        public void AddTabPageInventoryReports()
        {
            tabPageInventoryReports.Controls.Remove(repInventoryReportForm);

            repInventoryReportForm = new RepInventoryReport.RepInventoryReportForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageInventoryReports.Controls.Add(repInventoryReportForm);

            if (tabControlSoftware.TabPages.Contains(tabPageInventoryReports) == true)
            {
                tabControlSoftware.SelectTab(tabPageInventoryReports);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageInventoryReports);
                tabControlSoftware.SelectTab(tabPageInventoryReports);
            }
        }

        public void AddTabPageSystemTables()
        {
            tabPageSystemTables.Controls.Remove(sysSystemTablesForm);

            sysSystemTablesForm = new SysSystemTables.SysSystemTablesForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSystemTables.Controls.Add(sysSystemTablesForm);

            if (tabControlSoftware.TabPages.Contains(tabPageSystemTables) == true)
            {
                tabControlSoftware.SelectTab(tabPageSystemTables);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageSystemTables);
                tabControlSoftware.SelectTab(tabPageSystemTables);
            }
        }

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

        public void RemoveTabPage()
        {
            tabControlSoftware.TabPages.Remove(tabControlSoftware.SelectedTab);
            tabControlSoftware.SelectTab(tabControlSoftware.TabPages.Count - 1);
        }

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
            AddTabPageStockInList();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddTabPageStockOut();
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

        private void activityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysSoftwareChangeBranchForm sysSoftwareChangeBranchForm = new SysSoftwareChangeBranchForm(this);
            sysSoftwareChangeBranchForm.ShowDialog();
        }
    }
}
