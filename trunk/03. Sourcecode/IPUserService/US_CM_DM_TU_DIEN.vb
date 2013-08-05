'************************************************
'* Generated by: IPC
'* Date: 18/11/2003
'* Goal: Create User Service Class for CM_DM_TU_DIEN
'************************************************

option Explicit On
option Strict On

Imports IP.Core.IPData
Imports IP.Core.IPBusinessService
Imports IP.Core.IPCommon

Public Class US_CM_DM_TU_DIEN
	Inherits US_Object

	Private Const c_TableName as String = "CM_DM_TU_DIEN"

#Region "Public Property"

	Public Property dcID() As Decimal
		Get
            Return CNull.RowNVLDecimal(pm_objdr, "ID")
        End Get
        Set(ByVal Value As Decimal)
            pm_objDR.Item("ID") = Value
        End Set
    End Property

	Public Property strMA_TU_DIEN() As String
		Get
            Return CNull.RowNVLString(pm_objDR, "MA_TU_DIEN")
		End Get
		Set(ByVal Value As String)
			pm_objDR.Item("MA_TU_DIEN") = Value
		End Set
	End Property

	Public Property dcID_LOAI_TU_DIEN() As Decimal
		Get
            Return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_TU_DIEN")
		End Get
		Set(ByVal Value As Decimal)
			pm_objDR.Item("ID_LOAI_TU_DIEN") = Value
		End Set
	End Property

	Public Property strTEN_NGAN() As String
		Get
            Return CNull.RowNVLString(pm_objDR, "TEN_NGAN")
		End Get
		Set(ByVal Value As String)
			pm_objDR.Item("TEN_NGAN") = Value
		End Set
	End Property

	Public Property strTEN() As String
		Get
            Return CNull.RowNVLString(pm_objDR, "TEN")
		End Get
		Set(ByVal Value As String)
			pm_objDR.Item("TEN") = Value
		End Set
    End Property

    Public Property strGHI_CHU As String
        Get
            Return CNull.RowNVLString(pm_objDR, "GHI_CHU")
        End Get
        Set(ByVal Value As String)
            pm_objDR.Item("GHI_CHU") = Value
        End Set
    End Property

#End Region

    Public Sub New()
        pm_objDS = New DS_CM_DM_TU_DIEN()
        pm_strTableName = c_TableName
        pm_objDR = pm_objDS.Tables(pm_strTableName).NewRow()
    End Sub

    Public Sub New(ByVal i_objDR As DataRow)
        Me.New()
        Me.DataRow2Me(i_objDR)
    End Sub

    Public Sub New(ByVal i_dbID As Decimal)
        pm_objDS = New DS_CM_DM_TU_DIEN()
        pm_strTableName = c_TableName
        Me.FillDataset(pm_objDS, "Where ID = " & Str(i_dbID))
        pm_objDR = getRowClone(pm_objds.Tables(pm_strTableName).Rows(0))
    End Sub

    Public Sub New(ByVal i_strMaLoaiTD As String, ByVal i_strMaTuDien As String)
        'Tim ID loai tu dien
        Dim v_objLoaiTD As New US_CM_DM_LOAI_TD(i_strMaLoaiTD)
        pm_objds = New DS_CM_DM_TU_DIEN()
        pm_strTableName = c_TableName
        Me.FillDataset(pm_objds, "Where ID_LOAI_TU_DIEN = " & v_objLoaiTD.dcID _
                        & " and MA_TU_DIEN = N'" & i_strMaTuDien & "'")
        pm_objDR = getRowClone(pm_objds.Tables(pm_strTableName).Rows(0))
    End Sub

    Public Function getLoaiTuDienDS(ByVal i_strMaLoaiTD As String) As DS_CM_DM_TU_DIEN
        Dim v_dsTuDien As New DS_CM_DM_TU_DIEN()
        Dim v_usLoaiTD As New US_CM_DM_LOAI_TD(i_strMaLoaiTD)
        Dim v_cmd As SqlClient.SqlCommand
        Dim v_MakeSelCommand As IMakeSelectCmd
        v_MakeSelCommand = New CMakeAndSelectCmd(pm_objDS, c_TableName)
        v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang)
        v_cmd = v_MakeSelCommand.getSelectCmd
        Me.FillDatasetByCommand(v_dsTuDien, v_cmd)
        Return v_dsTuDien
    End Function

    Public Sub fill_tu_dien_cung_loai_ds(ByVal i_strMaLoaiTD As String, _
                                 ByVal i_ds_tu_dien As DS_CM_DM_TU_DIEN)
        Dim v_usLoaiTD As New US_CM_DM_LOAI_TD(i_strMaLoaiTD)
        Dim v_cmd As SqlClient.SqlCommand
        Dim v_MakeSelCommand As IMakeSelectCmd
        v_MakeSelCommand = New CMakeAndSelectCmd(pm_objDS, c_TableName)
        v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang)
        v_cmd = v_MakeSelCommand.getSelectCmd()
        Me.FillDatasetByCommand(i_ds_tu_dien, v_cmd)
    End Sub

    Public Sub fill_tu_dien_cung_loai_ds(ByVal i_strMaLoaiTD As String, _
                                         ByVal i_strSortField As String, _
                                 ByVal i_ds_tu_dien As DS_CM_DM_TU_DIEN)
        Dim v_usLoaiTD As New US_CM_DM_LOAI_TD(i_strMaLoaiTD)
        Dim v_cmd As SqlClient.SqlCommand
        Dim v_MakeSelCommand As IMakeSelectCmd
        v_MakeSelCommand = New CMakeAndSelectCmd(pm_objDS, c_TableName)
        v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang)
        v_cmd = v_MakeSelCommand.getSelectCmd()
        v_cmd.CommandText += " ORDER BY " + i_strSortField
        Me.FillDatasetByCommand(i_ds_tu_dien, v_cmd)
    End Sub
    Public Function check_exist_ma_tu_dien(ByVal i_strMaTuDien As String) As Boolean
        Dim i_ds_tu_dien As New DS_CM_DM_TU_DIEN()
        Dim v_cmd As SqlClient.SqlCommand
        Dim v_MakeSelCommand As IMakeSelectCmd
        v_MakeSelCommand = New CMakeAndSelectCmd(pm_objDS, c_TableName)
        v_MakeSelCommand.AddCondition("MA_TU_DIEN", i_strMaTuDien, eKieuDuLieu.KieuString, eKieuSoSanh.Bang)
        v_cmd = v_MakeSelCommand.getSelectCmd()
        Me.FillDatasetByCommand(i_ds_tu_dien, v_cmd)
        If i_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    '' Created by LinhDH 2012.05.17
    Public Sub Load_data_loai_hop_dong(ByVal op_ds_tu_dien As DS_CM_DM_TU_DIEN, ByVal ip_dc_id_loai_tu_dien As Decimal, ByVal ip_str_username As String)
        Dim v_cstore As New CStoredProc("pr_CM_DM_TU_DIEN_Load_Tu_Dien_By_Loai_Tu_Dien")
        v_cstore.addDecimalInputParam("@ID_LOAI_TU_DIEN", ip_dc_id_loai_tu_dien)
        v_cstore.addNVarcharInputParam("@USERNAME", ip_str_username)
        v_cstore.fillDataSetByCommand(Me, op_ds_tu_dien)
    End Sub
    Public Sub Load_Dv_quan_ly(ByVal op_ds_tu_dien As DS_CM_DM_TU_DIEN, ByVal ip_str_username As String)
        Dim v_cstore As New CStoredProc("pr_CM_DM_TU_DIEN_Load_DV_Quan_Ly")
        v_cstore.addNVarcharInputParam("@USERNAME", ip_str_username)
        v_cstore.fillDataSetByCommand(Me, op_ds_tu_dien)
    End Sub
    Public Sub Load_loai_hop_dong(ByVal op_ds_tu_dien As DS_CM_DM_TU_DIEN, ByVal ip_dc_id_dv_quan_ly As Decimal, ByVal ip_str_username As String)
        Dim v_cstore As New CStoredProc("pr_CM_DM_TU_DIEN_Load_Loai_HD")
        v_cstore.addDecimalInputParam("@ID_DV_QUAN_LY", ip_dc_id_dv_quan_ly)
        v_cstore.addNVarcharInputParam("@USERNAME", ip_str_username)
        v_cstore.fillDataSetByCommand(Me, op_ds_tu_dien)
    End Sub
End Class
