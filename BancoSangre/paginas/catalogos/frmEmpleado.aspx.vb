Imports Ext.Net

Public Class frmEmpleado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsComunes
        If CInt(Session("id_nivel")) > 1 Then
            Response.Redirect(cls.Pagina_Acceso_Denegado)
        End If
        fLlenarGrid()
    End Sub
    <DirectMethod>
    Public Sub fLlenarGrid()
        Dim vacceso As New clsControladorProcedimientos
        Try
            stEMPLEADO.DataSource = vacceso.fListarEmpleado()
            stEMPLEADO.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Sub fcrearVentanaEmpleado(ByVal p_id As Long,
                                     ByVal p_nombre As String,
                                     ByVal p_apellido As String,
                                     ByVal p_sexo As String,
                                     ByVal p_direccion As String,
                                     ByVal p_tel As String,
                                     ByVal p_fechan As String,
                                     ByVal p_fechaalta As String,
                                     ByVal p_usuario As String,
                                     ByVal p_pass As String,
                                     ByVal p_id_nivel As String)
        Dim titulo As String = ""
        Dim queryString As String = ""
        If p_id = clsComunes.Operacion_Registro.Nuevo Then

            titulo = "Crear Empleado"
            queryString = ""
            queryString &= ("&id=" & p_id)
        Else

            titulo = "Modificar Empleado " & p_nombre
            queryString = ""
            queryString &= ("&id=" & p_id)
            queryString &= ("&nombre=" & p_nombre)
            queryString &= ("&apellido=" & p_apellido)
            queryString &= ("&sexo=" & p_sexo)
            queryString &= ("&direccion=" & p_direccion)
            queryString &= ("&tel1=" & p_tel)
            queryString &= ("&fechan=" & p_fechan)
            queryString &= ("&fechan=" & p_fechaalta)
            queryString &= ("&user=" & p_usuario)
            queryString &= ("&pass=" & p_pass)
            queryString &= ("&nivel=" & p_id_nivel)

        End If
        Dim win = New Window With {.ID = "Win_EditarEmpleado",
                                    .Width = Unit.Pixel(700),
                                    .Height = Unit.Pixel(600),
                                    .Title = titulo,
                                    .Modal = True,
                                    .AutoRender = False,
                                    .Collapsible = False,
                                    .Maximizable = False}
        win.Loader = New ComponentLoader
        win.Loader.Url = "frmItemEmpleado.aspx?" & queryString
        win.Loader.Mode = LoadMode.Frame
        win.Loader.LoadMask.ShowMask = True
        win.Loader.LoadMask.Msg = "Espere un momento..."
        win.Render(True)
        win.Show()
    End Sub

End Class