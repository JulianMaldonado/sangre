Imports System.Security.Cryptography
Imports Ext.Net

Public Class frmItemEmpleado
    Inherits System.Web.UI.Page

#Region "Variables Globales"
    Private _id As Long
    Private _nombre As String
    Private _apellido As String
    Private _sexo As String
    Private _direccion As String
    Private _tel As String
    Private _fechan As String
    Private _fechaalta As String
    Private _usuario As String
    Private _pass As String
    Private _id_nivel As Int32
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsComunes
        If CInt(Session("id_nivel")) > 2 Then
            Response.Redirect(cls.Pagina_Acceso_Denegado)

        End If
        fobtenerValoresQuerystring()

        If Not Page.IsPostBack And Not Ext.Net.X.IsAjaxRequest Then
            fEstablecerValoresIniciales()
        End If
    End Sub
    Private Sub fobtenerValoresQuerystring()
        If Request.QueryString.AllKeys.Contains("id") Then
            _id = Long.Parse(Request.QueryString("id").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("nombre") Then
            _nombre = CStr(Request.QueryString("nombre").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("apellido") Then
            _apellido = CStr(Request.QueryString("apellido").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("sexo") Then
            _sexo = CStr(Request.QueryString("sexo").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("direccion") Then
            _direccion = CStr(Request.QueryString("direccion").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("tel") Then
            _tel = (Request.QueryString("tel").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("fechan") Then
            _fechan = (Request.QueryString("fechan").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("fechaalta") Then
            _fechaalta = CStr(Request.QueryString("fechaalta").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("user") Then
            _usuario = (Request.QueryString("user").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("pass") Then
            _pass = (Request.QueryString("pass").ToString)
        End If

        If Request.QueryString.AllKeys.Contains("nivel") Then
            _id_nivel = (Request.QueryString("nivel").ToString)
        End If

    End Sub
    Private Sub fEstablecerValoresIniciales()
        fllenarGS()

        txtCodigo.Text = _id
        txtNombre.Text = _nombre
        txtApellido.Text = _apellido
        txtSexo.Text = _sexo
        txtDireccion.Text = _direccion
        txtTelefono.Text = _tel
        txtFechan.Text = _fechan
        txtFechaAlta.Text = _fechaalta
        txtUser.Text = _usuario
        txtPass.Text = _pass
        txtnivel.Text = _id_nivel


    End Sub
    Private Sub fllenarGS()
        Try
            Dim v_datos As New clsControladorProcedimientos
            'stEMPLEADO.DataSource = v_datos.fListarEmpleado
            'stEMPLEADO.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Alert("ERROR", ex.Message).Show()
        End Try

    End Sub


    <DirectMethod>
    Public Function fGuardar() As Integer

        Dim hash As String

        Using Banco1 As MD5 = MD5.Create()
            hash = _ObtieneMd5Hash(Banco1, txtPass.Text)

        End Using

        Dim v_respuesta As Integer
        Dim v_acceso As New clsControladorProcedimientos
        If _id = clsComunes.Operacion_Registro.Nuevo Then
            v_respuesta = v_acceso.fInsertarEmpleado(txtNombre.Text, txtApellido.Text, txtSexo.Text, txtDireccion.Text, txtTelefono.Text, txtFechan.Value, txtFechaAlta.Value, txtUser.Text, hash, txtnivel.Text)
        Else
            v_respuesta = v_acceso.fActualizaEmpleado(txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtSexo.Text, txtDireccion.Text, txtTelefono.Text, txtFechan.Value, txtFechaAlta.Value, txtUser.Text, hash, txtnivel.Text)
        End If
        Return v_respuesta
    End Function
End Class