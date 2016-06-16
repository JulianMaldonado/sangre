Imports Ext.Net

Public Class frmHistorial
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
        Try
            Dim acceso As New clsControladorProcedimientos
            sthistorial.DataSource = acceso.fListarHistorial

            sthistorial.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
End Class