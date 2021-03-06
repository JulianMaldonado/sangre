﻿Imports Ext.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmVenta
    Inherits System.Web.UI.Page

    Dim _producto As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsComunes


        If Not Page.IsPostBack And Not Ext.Net.X.IsAjaxRequest Then
            btnAgregar.Enable(False)
            txtCant.Value = 1

            fllenarGrid()
        End If
    End Sub

#Region "Metodos Directo"
    <DirectMethod>
    Public Sub fQuitar()
        txtFactor.ReadOnly = False
        txtFactor.Text = ""
        txtIdFactor.Text = ""
    End Sub
    <DirectMethod>
    Public Function fGuardar() As Integer
        Dim retorno As Integer
        Dim acceso As New clsControladorProcedimientos
        Try
            If clsComunes.Respuesta_Operacion.Guardado = acceso.fInsertarVenta(Session("idusuario"),Date.Now, txtNombre.Text, txtNit.Text,"ACTIVO",  txtTotal.Text ) Then
                retorno = clsComunes.Respuesta_Operacion.Guardado
                txtCant.Value = 0
                txtDireccion.Text = ""
                txtNit.Text = ""
                txtNombre.Text = 0
                Ext.Net.X.MessageBox.Alert("Operacion", "Transaccion Realizada").Show()
            End If
        Catch ex As Exception
            retorno = clsComunes.Respuesta_Operacion.Erronea
            Ext.Net.X.MessageBox.Notify("Operacion", ex.Message).Show()
        End Try
        Return retorno
    End Function

    <DirectMethod>
    Public Sub BuscarInventario()
        Dim titulo As String = "Buscar Inventarios"
        Dim queryString As String = ""
        queryString &= "&buscar=0"

        Dim win = New Window With {.ID = "Win_BuscarInvetario",
                                    .Width = Unit.Pixel(830),
                                    .Height = Unit.Pixel(450),
                                    .Title = titulo,
                                    .Modal = True,
                                    .AutoRender = False,
                                    .Collapsible = False,
                                    .Maximizable = False}
        win.Loader = New ComponentLoader
        win.Loader.Url = "frmInventario.aspx?" & queryString
        win.Loader.Mode = LoadMode.Frame
        win.Loader.LoadMask.ShowMask = True
        win.Loader.LoadMask.Msg = "Espere un momento..."
        win.Render(True)
        win.Show()
    End Sub
    <DirectMethod>
    Public Sub fSeleccionar(ByVal fila As String)
        Dim p As New JObject
        If _producto.Count > 0 Then
            _producto.Clear()
        End If
        Try
            p = JsonConvert.DeserializeObject(Of Object)(fila)
            ' Dim dt As New DataTable
            txtIdFactor.Text = p.Item("ID_FACTOR").ToString
            txtFactor.Text = p.Item("FACTOR").ToString
            txtCant.MaxValue = CInt(p.Item("STOCK").ToString)
            TXTFACTOR.ReadOnly = True
            txtCant.Enabled = TrUE
            btnAgregar.Enable(True)
            Ext.Net.X.MessageBox.Notify("Operacion", "Producto Agregado").Show()
        Catch ex As Exception
            Ext.Net.X.MessageBox.Notify("Error", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Sub fllenarGrid()
        Dim acceso As New clsControladorProcedimientos
        Try
            Dim dt As New DataTable
            Dim SUBT As Decimal = 0
            dt = acceso.fListarDetalleVenta(Session("id_empleado"))
            stDG.DataSource = dt
            stDG.DataBind()
            For Each f As DataRow In dt.Rows
                SUBT += CDec(f("SUBTOTAL"))
            Next
            txtTotal.Value = SUBT
        Catch ex As Exception
            Ext.Net.X.MessageBox.Notify("Error", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Function fInsertar() As Integer
        Dim acceso As New clsControladorProcedimientos
        Try
            acceso.fInsertarDetVenta(Session("id_empleado"), txtIdFactor.Text, CDbl(txtCant.Value), "")
            Ext.Net.X.MessageBox.Notify("Operacion", "Producto Insertado").Show()
            fQuitar()
        Catch ex As Exception
            Ext.Net.X.MessageBox.Notify("Error", ex.Message).Show()
        End Try
        Return 1
    End Function
    <DirectMethod>
    Public Function fEliminar(ByVal modelo As String) As Integer
        Dim acceso As New clsDetallesTemporales
        Try
            acceso.fElimina("ventas", Session("idempleado"), modelo)
            Ext.Net.X.MessageBox.Notify("Operacion", "Producto Eliminado").Show()
            fQuitar()
        Catch ex As Exception
            Ext.Net.X.MessageBox.Notify("Error", ex.Message).Show()
        End Try
        Return 1
    End Function

#End Region
End Class