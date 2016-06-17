Imports Ext.Net

Public Class frmDonante
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
            stDONANTE.DataSource = vacceso.fListarDonantes()
            stDONANTE.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Sub fcrearVentanaDonante(ByVal p_id As Long, ByVal p_idfactor As Long, ByVal p_dpi As String, ByVal p_nombre As String,
                                      ByVal p_apellido As String, ByVal p_sexo As String, ByVal p_direccion As String, ByVal p_fechan As String, ByVal p_tel1 As String,
                                      ByVal p_tel2 As String, ByVal p_mail As String, ByVal p_estado As String)
        Dim titulo As String = ""
        Dim queryString As String = ""
        If p_id = clsComunes.Operacion_Registro.Nuevo Then

            titulo = "Crear nuevo Donante"
            queryString = ""
            queryString &= ("&id=" & p_id)
        Else

            titulo = "Modificar Donante " & p_nombre
            queryString = ""
            queryString &= ("&id=" & p_id)
            queryString &= ("&idf=" & p_idfactor)
            queryString &= ("&dpi=" & p_dpi)
            queryString &= ("&nombre=" & p_nombre)
            queryString &= ("&apellido=" & p_apellido)
            queryString &= ("&sexo=" & p_sexo)
            queryString &= ("&direccion=" & p_direccion)
            queryString &= ("&fechan=" & p_fechan)
            queryString &= ("&tel1=" & p_tel1)
            queryString &= ("&tel2=" & p_tel2)
            queryString &= ("&email=" & p_mail)
            queryString &= ("&estado=" & p_estado)

        End If
        Dim win = New Window With {.ID = "Win_EditarDonante",
                                    .Width = Unit.Pixel(750),
                                    .Height = Unit.Pixel(700),
                                    .Title = titulo,
                                    .Modal = True,
                                    .AutoRender = False,
                                    .Collapsible = False,
                                    .Maximizable = False}
        win.Loader = New ComponentLoader
        win.Loader.Url = "frmItemDonante.aspx?" & queryString
        win.Loader.Mode = LoadMode.Frame
        win.Loader.LoadMask.ShowMask = True
        win.Loader.LoadMask.Msg = "Espere un momento..."
        win.Render(True)
        win.Show()
    End Sub

End Class