Imports Ext.Net

Public Class frmInventario
    Inherits System.Web.UI.Page
    Dim _buscar As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       Dim cls As New clsComunes
       If CInt(Session("id_nivel")) > 1 Then
            Response.Redirect(cls.Pagina_Acceso_Denegado)

        End If
       If Request.QueryString.AllKeys.Contains("buscar") Then
           ColumnaAccion.Visible = True
        Else
            ColumnaAccion.Visible = False
       End If
        fLlenarGrid()
 End Sub
    <DirectMethod>
    Public Sub fLlenarGrid()
        Try
            Dim acceso As New clsControladorProcedimientos
            stinventario.DataSource = acceso.fListarInventarios

            stinventario.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
End Class