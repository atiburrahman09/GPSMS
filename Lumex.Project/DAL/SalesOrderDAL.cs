﻿using System;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class SalesOrderDAL
    {
        public string SaveSalesOrder(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string salesOrderId = "";

            try
            {
                db.AddParameters("@CustomerId", salesOrder.CustomerId.Trim());
                db.AddParameters("@CustomerName", salesOrder.CustomerName.Trim());
                db.AddParameters("@CustomerContactNumber", salesOrder.CustomerContactNumber.Trim());
                db.AddParameters("@CustomerAddress", salesOrder.CustomerAddress.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@SalesPersonId", salesOrder.SalesPersonId.Trim());
                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@VAT", salesOrder.VAT.Trim());
                db.AddParameters("@DiscountAmount", salesOrder.DiscountAmount.Trim());
                db.AddParameters("@TotalVATAmount", salesOrder.TotalVATAmount.Trim());
                db.AddParameters("@TotalReceivable", salesOrder.TotalReceivable.Trim());
                db.AddParameters("@ReceivedAmount", salesOrder.ReceivedAmount.Trim());
                db.AddParameters("@ChangeAmount", salesOrder.ChangeAmount);
                db.AddParameters("@DeliveryDate", salesOrder.DeliveryDate.Trim());
                db.AddParameters("@Narration", salesOrder.Narration.Trim());
                db.AddParameters("@TransportType", salesOrder.TransportType.Trim());
                db.AddParameters("@AccountId", salesOrder.AccountId);
                db.AddParameters("@PaymentMode", salesOrder.PaymentMode.Trim());
                db.AddParameters("@Bank", salesOrder.Bank.Trim());
                db.AddParameters("@BankBranch", salesOrder.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", salesOrder.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", salesOrder.ChequeDate.Trim());
                db.AddParameters("@LCNumber", salesOrder.LCNumber.Trim());
                db.AddParameters("@ShippingAddress", salesOrder.ShippingAddress.Trim());
                db.AddParameters("@BillingAddress", salesOrder.BillingAddress.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_SALES_ORDER", true);

                if (dt.Rows.Count > 0)
                {
                    salesOrderId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    if (dtPrdList.Rows[i]["Quantity"].ToString() == "" || dtPrdList.Rows[i]["Amount"].ToString() == "" || dtPrdList.Rows[i]["Available"].ToString() == "" || dtPrdList.Rows[i]["RatePerUnit"].ToString() == "")
                    {
                        if (dtPrdList.Rows[i]["Quantity"].ToString() == "")
                        {
                            dtPrdList.Rows[i]["Quantity"] = 0;
                        }
                        if (dtPrdList.Rows[i]["Amount"].ToString() == "")
                        {
                            dtPrdList.Rows[i]["Amount"] = 0;
                        }
                        if (dtPrdList.Rows[i]["Available"].ToString() == "")
                        {
                            dtPrdList.Rows[i]["Available"] = 0;
                        }
                        if (dtPrdList.Rows[i]["RatePerUnit"].ToString() == "")
                        {
                            dtPrdList.Rows[i]["RatePerUnit"] = 0;
                        }
                        if (dtPrdList.Rows[i]["VATPercentage"].ToString() == "")
                        {
                            dtPrdList.Rows[i]["VATPercentage"] = 0;
                        }
                    }
                    db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@ProductVat", dtPrdList.Rows[i]["VATPercentage"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());
                    db.AddParameters("@FreeQuantityWas", dtPrdList.Rows[i]["Available"].ToString());
                    db.AddParameters("@Narration", "");

                    db.ExecuteNonQuery("INSERT_SALES_ORDER_PRODUCT", true);
                }

                //db.ClearParameters();
                //db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                //db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                //db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                //db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                //db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_TO_CREATE_SALES_ORDER", true);

                return salesOrderId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }
        // Insert Sales
        public string SaveRetailSales(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string salesRecordId = "";

            try
            {
                db.AddParameters("@CustomerId", salesOrder.CustomerId.Trim());
                db.AddParameters("@CustomerName", salesOrder.CustomerName.Trim());
                db.AddParameters("@CustomerContactNumber", salesOrder.CustomerContactNumber.Trim());
                db.AddParameters("@CustomerAddress", salesOrder.CustomerAddress.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@DiscountAmount", salesOrder.DiscountAmount.Trim());
                db.AddParameters("@VAT", salesOrder.VAT.Trim());
                db.AddParameters("@TotalReceivable", salesOrder.TotalReceivable.Trim());
                db.AddParameters("@ReceivedAmount", salesOrder.ReceivedAmount.Trim());
                db.AddParameters("@ChangeAmount", salesOrder.ChangeAmount.Trim());
                db.AddParameters("@TotalVATAmount", salesOrder.TotalVATAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@SalesOrderId", salesOrder.SalesOrderId.Trim());

                //New Add

                db.AddParameters("@PaymentMode", salesOrder.PaymentMode.Trim());
                db.AddParameters("@AccountId", salesOrder.AccountId.Trim());
                db.AddParameters("@Bank", salesOrder.Bank.Trim());
                db.AddParameters("@BankBranch", salesOrder.BankBranch.Trim());
                db.AddParameters("@ChequeNumber", salesOrder.ChequeNumber.Trim());
                db.AddParameters("@ChequeDate", salesOrder.ChequeDate.Trim());
                db.AddParameters("@OthersDes", salesOrder.OthersDes.Trim());
                db.AddParameters("@OthersAmount", salesOrder.OthersAmount.Trim());
                db.AddParameters("@Narration", salesOrder.Narration.Trim());

                //
                DataTable dt = db.ExecuteDataTable("INSERT_RETAIL_SALES_RECORD", true);

                if (dt.Rows.Count > 0)
                {
                    salesRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());
                    db.AddParameters("@VATPercentage", dtPrdList.Rows[i]["VATPercentage"].ToString());
                    db.AddParameters("@Height", dtPrdList.Rows[i]["Height"].ToString());
                    db.AddParameters("@Width", dtPrdList.Rows[i]["Width"].ToString());
                    db.AddParameters("@OnSale", "Yes");
                    db.AddParameters("@OrderUnit", dtPrdList.Rows[i]["OrderUnit"].ToString());
                    db.AddParameters("@TotalUit", dtPrdList.Rows[i]["TotalUnit"].ToString());
                    db.AddParameters("@Description", "");
                    db.ExecuteNonQuery("INSERT_RETAIL_SALES_RECORD_PRODUCT", true);

                }
                if (salesOrder.SalesCenterId == "WH-002")
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());
                    db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_FOR_RETAIL_SALES", true);

                    db.ClearParameters();
                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteNonQuery("INSERT_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION", true);
                }
                else
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                    db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                    db.ExecuteNonQuery("[INSERT_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION_FOR_SUB_PRODUCT_APPROVE]", true);

                }
                return salesRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        public string SaveDamageProduct(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string damageRecordId = "";

            try
            {
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT_DAMAGE_RECORD", true);

                if (dt.Rows.Count > 0)
                {
                    damageRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());

                    db.ExecuteNonQuery("INSERT_PRODUCT_DAMAGE_RECORD_PRODUCT", true);
                }

                db.ClearParameters();
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_FOR_DAMAGE_RECORD", true);

                db.ClearParameters();
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("INSERT_PRODUCT_DAMAGE_LEDGER_TRANSACTION", true);

                return damageRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        public string SaveWarehouseDamageProduct(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string damageRecordId = "";

            try
            {
                db.AddParameters("@WarehouseId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_WAREHOUSE_PRODUCT_DAMAGE_RECORD", true);

                if (dt.Rows.Count > 0)
                {
                    damageRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@WarehouseId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());

                    db.ExecuteNonQuery("INSERT_WAREHOUSE_PRODUCT_DAMAGE_RECORD_PRODUCT", true);
                }

                db.ClearParameters();
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                db.AddParameters("@WarehouseId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_WAREHOUSE_PRODUCT_STOCK_FOR_DAMAGE_RECORD", true);

                db.ClearParameters();
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                db.AddParameters("@WarehouseId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("INSERT_WAREHOUSE_PRODUCT_DAMAGE_LEDGER_TRANSACTION", true);

                return damageRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        public DataTable GetSalesOrdersListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_SALES_ORDERS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPendingSalesOrdersListBySalesCenter(string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_PENDING_SALES_ORDERS_BY_SALES_CENTER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesOrdersListBySalesCenterAndStatus(string salesCenterId, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@Status", status.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_ORDERS_BY_SALES_CENTER_AND_STATUS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesOrderById(string salesOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_ORDER_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesOrderProductListById(string salesOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_ORDER_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelSalesOrderById(string salesOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                db.AddParameters("@CanceledBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CanceledFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("CANCEL_SALES_ORDER_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSalesOrderOnTransport(string salesOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                db.ExecuteNonQuery("UPDATE_SALES_ORDER_ON_TRANSPORT", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSalesOrderOnDelivered(string salesOrderId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                db.ExecuteNonQuery("UPDATE_SALES_ORDER_ON_DELIVERED", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesRecordsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_SALES_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDamageRecordsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DAMAGE_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDamageRecordsListByWarehouseDateRangeAndStatus(string warehouseId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DAMAGE_RECORDS_BY_WAREHOUSE_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesReturnsListBySalesCenterDateRangeAndStatus(string salesCenterId, string fromDate, string toDate, string status, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Status", status.Trim());

                DataTable dt = db.ExecuteDataTable("GET_SALES_RETURN_RECORDS_BY_SALES_CENTER_DATE_RANGE_AND_STATUS", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesRecordById(string salesRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_RECORD_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDamageRecordById(string damageRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_DAMAGE_RECORD_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesReturnById(string salesReturnId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesReturnId", salesReturnId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_RETURN_RECORD_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesRecordProductListById(string salesRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_RECORD_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesRecordProductListByIdForReturn(string salesRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_RECORD_PRODUCT_LIST_BY_ID_FOR_RETURN", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDamageRecordProductListById(string damageRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@DamageRecordId", damageRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_DAMAGE_RECORD_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetSalesReturnProductListById(string salesReturnId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesReturnId", salesReturnId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_SALES_RETURN_RECORD_PRODUCT_LIST_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetPaymentListBySales(string salesRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_CUSTOMER_PAYMENTS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SaveCustomerPaymentBySales(SalesOrderBLL salesOrder, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@CustomerId", salesOrder.CustomerId.Trim());
                db.AddParameters("@Amount", salesOrder.Amount.Trim());
                db.AddParameters("@Due", salesOrder.Due.Trim());
                db.AddParameters("@ApprovedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ApprovedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_CUSTOMER_PAYMENT_SALES_WISE", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SaveSalesReturn(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string salesReturnId = "";

            try
            {
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@ReturnAmount", salesOrder.ReturnAmount.Trim());
                db.AddParameters("@ReturnVATAmount", salesOrder.ReturnVATAmount.Trim());
                db.AddParameters("@SalesDueAmount", salesOrder.SalesDueAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                DataTable dt = db.ExecuteDataTable("INSERT_SALES_RETURN_RECORD", true);

                if (dt.Rows.Count > 0)
                {
                    salesReturnId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@PurchaseRecordId", dtPrdList.Rows[i]["PurchaseRecordId"].ToString());
                    db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                    db.AddParameters("@SalesReturnId", salesReturnId);
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    if (dtPrdList.Rows[i]["PurchaseRate"].ToString() == "")
                    {
                        db.AddParameters("@PurchaseRate", "0");

                    }
                    else
                    {
                        db.AddParameters("@PurchaseRate", dtPrdList.Rows[i]["PurchaseRate"].ToString());
                    }
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@ReturnQuantity", dtPrdList.Rows[i]["ReturnQuantity"].ToString());
                    db.AddParameters("@ReturnAmount", dtPrdList.Rows[i]["ReturnAmount"].ToString());
                    db.AddParameters("@VATPercentage", dtPrdList.Rows[i]["VATPercentage"].ToString());

                    db.ExecuteNonQuery("INSERT_SALES_RETURN_RECORD_PRODUCT", true);
                }

                db.ClearParameters();
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@SalesReturnId", salesReturnId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_FOR_SALES_RETURN", true);

                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@SalesReturnId", salesReturnId.Trim());
                db.AddParameters("@SalesDueAmount", salesOrder.SalesDueAmount.Trim());
                db.AddParameters("@ReturnAmount", salesOrder.ReturnAmount.Trim());
                db.AddParameters("@CustomerId", salesOrder.CustomerId.Trim());
                db.AddParameters("@IsDueAdjust", salesOrder.IsDuesAdjustforSalesReturn);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                dt = db.ExecuteDataTable("INSERT_SALES_RETURN_RECEIVE_PAYMENT_LEDGER_TRANSACTION", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        public void SaveUncollectableAmountBySalesRecordId(string salesRecordId, string uncollectableAmount, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                db.AddParameters("@UncollectableAmount", uncollectableAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("INSERT_UNCOLLECTABLE_AMOUNT_BY_SALES_RECORD_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool rejectProduction(LumexDBPlayer db, string SOID)
        {
            bool status = false;
            try
            {
                string QueryCommand_Update = "update SalesOrder set Status='R' where SalesOrderId=@SOID";
                db.AddParameters("@SOID", SOID.Trim());

                db.ExecuteNonQuery(QueryCommand_Update);
                status = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        internal bool UpdateSalesOrderOnApproved(LumexDBPlayer db, string salesRecordId, string salesOrderId)
        {
            bool status = false;
            try
            {

                db.AddParameters("@SalesOrderId", salesOrderId.Trim());
                db.AddParameters("@Status", "A");
                db.AddParameters("@SalesRecordId", salesRecordId);
                db.ExecuteNonQuery("[UPDATE_SALES_ORDER_ON_APPROVED]", true);
                status = true;
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }

        internal string ApproveSalesOrder(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string salesRecordId = "";

            try
            {

                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@DiscountAmount", salesOrder.DiscountAmount.Trim());
                db.AddParameters("@VAT", salesOrder.VAT.Trim());
                db.AddParameters("@TotalReceivable", salesOrder.TotalReceivable.Trim());
                db.AddParameters("@ReceivedAmount", salesOrder.ReceivedAmount.Trim());
                db.AddParameters("@ChangeAmount", salesOrder.ChangeAmount.Trim());
                db.AddParameters("@PaymentMode", salesOrder.PaymentMode.Trim());
                db.AddParameters("@TotalVATAmount", salesOrder.TotalVATAmount.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@SalesOrderId", salesOrder.SalesOrderId.Trim());


                DataTable dt = db.ExecuteDataTable("INSERT_SALES_RECORD_BY_APPROVE_SALES_ORDER", true);

                if (dt.Rows.Count > 0)
                {
                    salesRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());
                    db.AddParameters("@VATPercentage", dtPrdList.Rows[i]["VATPercentage"].ToString());
                    //need to add this 3 paremeters
                    db.AddParameters("@Height", dtPrdList.Rows[i]["Height"].ToString());
                    db.AddParameters("@Running", dtPrdList.Rows[i]["Running"].ToString());
                    db.AddParameters("@OnSale", dtPrdList.Rows[i]["OnSale"].ToString());
                    db.ExecuteNonQuery("INSERT_RETAIL_SALES_RECORD_PRODUCT", true);
                }

                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_FOR_RETAIL_SALES", true);

                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("INSERT_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION", true);

                return salesRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        internal DataTable GetSalesRecordMainProductListById(string salesRecordId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@RecordId", salesRecordId);


                DataTable dt = db.ExecuteDataTable("[GET_MAIN_PRODUCTS__BY_SALESRECORD_ID]", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string ApproveSalesRecordRetailSubproducs(SalesOrderBLL salesOrder, DataTable dt, LumexDBPlayer db)
        {
            string salesRecordId = "";

            try
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                    db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                    db.AddParameters("@ProductId", dt.Rows[i]["MainProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dt.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dt.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", (Convert.ToDecimal(dt.Rows[i]["RatePerUnit"].ToString()) * Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString())).ToString());
                    db.AddParameters("@VATPercentage", "0");
                    db.AddParameters("@Height", "0");
                    db.AddParameters("@Width", "0");
                    db.AddParameters("@OnSale", "No");
                    db.AddParameters("@OrderUnit", "0");
                    db.AddParameters("@TotalUit", "0");
                    db.AddParameters("@Description", "");
                    db.ExecuteNonQuery("INSERT_RETAIL_SALES_RECORD_PRODUCT", true);

                }

                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_STOCK_FOR_RETAIL_SALES", true);

                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@JournalNumber", salesOrder.JournalNumber.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[INSERT_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION_FOR_APPROVE_RETAIL_CGS_SUBP]", true);

                return salesRecordId = salesOrder.SalesRecordId.Trim();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dt = null;
            }
        }

        internal string UpdateRetailSales(SalesOrderBLL salesOrder, DataTable dtPrdList, LumexDBPlayer db)
        {
            string salesRecordId = "";

            try
            {

                db.AddParameters("@TotalAmount", salesOrder.TotalAmount.Trim());
                db.AddParameters("@DiscountAmount", salesOrder.DiscountAmount.Trim());
                db.AddParameters("@VAT", salesOrder.VAT.Trim());
                db.AddParameters("@TotalReceivable", salesOrder.TotalReceivable.Trim());
                db.AddParameters("@ReceivedAmount", salesOrder.ReceivedAmount.Trim());
                db.AddParameters("@ChangeAmount", salesOrder.ChangeAmount.Trim());
                db.AddParameters("@SalesRecordId", salesOrder.SalesRecordId.Trim());
                db.AddParameters("@OthersAmount", salesOrder.OthersAmount.Trim());
                db.AddParameters("@OthersDes", salesOrder.OthersDes.Trim());
                db.AddParameters("@Narration", salesOrder.Narration.Trim());

                DataTable dt = db.ExecuteDataTable("[UPDATE_RETAIL_SALES_RECORD_BY_RECORD_ID]", true);

                if (dt.Rows.Count > 0)
                {
                    salesRecordId = dt.Rows[0][0].ToString();
                }

                for (int i = 0; i < dtPrdList.Rows.Count; i++)
                {
                    db.ClearParameters();

                    db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                    db.AddParameters("@ProductId", dtPrdList.Rows[i]["ProductId"].ToString());
                    db.AddParameters("@RatePerUnit", dtPrdList.Rows[i]["RatePerUnit"].ToString());
                    db.AddParameters("@Quantity", dtPrdList.Rows[i]["Quantity"].ToString());
                    db.AddParameters("@Amount", dtPrdList.Rows[i]["Amount"].ToString());
                    db.AddParameters("@VATPercentage", dtPrdList.Rows[i]["VATPercentage"].ToString());
                    db.AddParameters("@Height", dtPrdList.Rows[i]["Height"].ToString());
                    db.AddParameters("@Width", dtPrdList.Rows[i]["Width"].ToString());
                    db.AddParameters("@OnSale", "Yes");
                    db.AddParameters("@OrderUnit", dtPrdList.Rows[i]["OrderUnit"].ToString());
                    db.AddParameters("@TotalUit", dtPrdList.Rows[i]["TotalUnit"].ToString());
                    db.AddParameters("@Serial", dtPrdList.Rows[i]["Serial"].ToString());
                    db.AddParameters("@Description", "");
                    db.ExecuteNonQuery("UPDATE_RETAIL_SALES_RECORD_PRODUCT", true);

                }


                db.ClearParameters();
                db.AddParameters("@SalesRecordId", salesRecordId.Trim());
                db.AddParameters("@SalesCenterId", salesOrder.SalesCenterId.Trim());
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[UPDATE_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION_FOR_SUB_PRODUCT_APPROVE_BY_JV_RECORD]", true);


                return salesRecordId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                salesOrder = null;
                dtPrdList = null;
            }
        }

        internal bool RejectRetailSales(SalesOrderBLL salesOrderBLL, LumexDBPlayer db)
        {
            try
            {
                bool status = false;
                db.AddParameters("@SalesRecordId", salesOrderBLL.SalesRecordId);
                db.AddParameters("@SalesCenterId", salesOrderBLL.SalesCenterId);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("[INSERT_RETAIL_SALES_RECEIVE_PAYMENT_LEDGER_TRANSACTION_FOR_SUB_PRODUCT_REJECT]", true);
                status = true;
                return status;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
