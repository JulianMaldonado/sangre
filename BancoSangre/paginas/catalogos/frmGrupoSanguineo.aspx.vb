Imports Ext.Net

Public Class frmGrupoSanguineo
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
            stgrupoSanguineo.DataSource = acceso.fListarGrupoSanguineo
            stgrupoSanguineo.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Function fNuevoGS() As Integer
        Dim r As Integer
        Try
            Dim acceso As New clsControladorProcedimientos
            If txtGrupoSanguineo.Text <> "" Then
                If acceso.fInsertarGrupoSanguineo(txtGrupoSanguineo.Text) = clsComunes.Respuesta_Operacion.Guardado Then
                    txtGrupoSanguineo.Text = ""
                    r = clsComunes.Respuesta_Operacion.Guardado
                End If
            End If
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
            r = clsComunes.Respuesta_Operacion.Erronea
        End Try
        Return r
    End Function
    <DirectMethod>
    Public Function fModificarGS(ByVal id As Long, ByVal nombre As String) As String
        Dim r As Integer
        Try
            Dim acceso As New clsControladorProcedimientos
            If acceso.fActualizaGuproSanguineo(id, nombre) = clsComunes.Respuesta_Operacion.Modificado Then
                r = clsComunes.Respuesta_Operacion.Modificado
                fLlenarGrid()
            End If

        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()

        End Try
        Return r
    End Function

End Class