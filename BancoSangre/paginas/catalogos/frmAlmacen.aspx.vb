Imports Ext.Net

Public Class frmAlmacen
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
            stAlmacen.DataSource = acceso.fListarAlmacen
            stAlmacen.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub
    <DirectMethod>
    Public Function fNuevoAlmacen() As Integer
        Dim r As Integer
        Try
            Dim acceso As New clsControladorProcedimientos
            If txtnombre.Text <> "" And txtdireccion.Text <> "" Then
                If acceso.fInsertarNewAlmacen(txtnombre.Text.ToUpper, txtdireccion.Text.ToUpper) = clsComunes.Respuesta_Operacion.Guardado Then
                    txtnombre.Text = ""
                    txtdireccion.Text = ""
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
    Public Function fModificarAlmacen(ByVal id As Long, ByVal nombre As String, ByVal direccion As String) As String
        Dim r As Integer
        Try
            Dim acceso As New clsControladorProcedimientos
            If acceso.fActualizaNewAlmacen(id, nombre, direccion) = clsComunes.Respuesta_Operacion.Modificado Then
                r = clsComunes.Respuesta_Operacion.Modificado
                fLlenarGrid()
            End If

        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()

        End Try
        Return r
    End Function

End Class