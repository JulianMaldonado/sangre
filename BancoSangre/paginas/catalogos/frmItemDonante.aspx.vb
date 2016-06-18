Imports Ext.Net

Public Class frmItemDonante
    Inherits System.Web.UI.Page
#Region "Variables Globales"
    Private _id As Long
    Private _idfactor As Long
    Private _dpi As String
    Private _nombre As String
    Private _apellido As String
    Private _sexo As String
    Private _direccion As String
    Private _fechan As String
    Private _tel1 As String
    Private _tel2 As String
    Private _email As String
    Private _estado As String

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
        If Request.QueryString.AllKeys.Contains("idf") Then
            _idfactor = Long.Parse(Request.QueryString("idf").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("dpi") Then
            _dpi = (Request.QueryString("dpi").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("nombre") Then
            _nombre = CStr(Request.QueryString("nombre").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("apellido") Then
            _apellido = CStr(Request.QueryString("apellido").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("sexo") Then
            _sexo = (Request.QueryString("sexo").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("direccion") Then
            _direccion = (Request.QueryString("direccion").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("fechan") Then
            _fechan = CStr(Request.QueryString("fechan").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("tel1") Then
            _tel1 = (Request.QueryString("tel1").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("tel2") Then
            _tel2 = (Request.QueryString("tel2").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("email") Then
            _email = (Request.QueryString("email").ToString)
        End If
        If Request.QueryString.AllKeys.Contains("estado") Then
            _estado = (Request.QueryString("estado").ToString)
        End If



    End Sub
    Private Sub fEstablecerValoresIniciales()
        fllenarGS()
        cmbfactor.SelectedItem.Value = _idfactor
        txtCodigo.Text = _id
        txtDPI.Text = _dpi
        txtDireccion.Text = _direccion
        txtEmail.Text = _email
        txtEstado.Text = _estado
        txtFechan.Text = _fechan
        txtNombre.Text = _nombre
        txtApellido.Text = _apellido
        txtSexo.Text = _sexo
        txtTelefono1.Text = _tel1
        txtTelefono2.Text = _tel2

    End Sub
    Private Sub fllenarGS()
        Try
            Dim v_datos As New clsControladorProcedimientos
            stFactor.DataSource = v_datos.fListarGrupoSanguineo
            stFactor.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Alert("ERROR", ex.Message).Show()
        End Try

    End Sub


    <DirectMethod>
    Public Function fGuardar() As Integer
        Dim v_respuesta As Integer
        Dim v_acceso As New clsControladorProcedimientos
        If _id = clsComunes.Operacion_Registro.Nuevo Then
            v_respuesta = v_acceso.fInsertarDonante(cmbfactor.SelectedItem.Value, txtDPI.Text, txtNombre.Text, txtApellido.Text, txtSexo.Text, txtDireccion.Text, txtFechan.Value, Date.Now, txtTelefono1.Text, txtTelefono2.Text, txtEmail.Text, txtEstado.Text)
        Else
            v_respuesta = v_acceso.fActualizaDonante(txtCodigo.Text, cmbfactor.SelectedItem.Value, txtDPI.Text, txtNombre.Text, txtApellido.Text, txtSexo.Text, txtDireccion.Text, txtFechan.Value, Date.Now, txtTelefono1.Text, txtTelefono2.Text, txtEmail.Text, txtEstado.Text)
        End If
        Return v_respuesta
    End Function
End Class