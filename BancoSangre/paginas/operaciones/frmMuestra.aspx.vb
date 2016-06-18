Imports Ext.Net

Public Class frmMuestra
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
            stMuestra.DataSource = acceso.fListarMuestra
            stMuestra.DataBind()
        Catch ex As Exception
            Ext.Net.X.Msg.Notify("Error Inesperado", ex.Message).Show()
        End Try
    End Sub


    <DirectMethod>
    Public Sub fcrearVentaMuestra(ByVal p_id As Long,
                                     ByVal p_id_donante As Long,
                                     ByVal p_id_factor As Long,
                                     ByVal p_id_empleado As Long,
                                     ByVal p_fecha As String,
                                     ByVal p_estado As String,
                                     ByVal p_fechafin As String,
                                     ByVal p_aprobado As String,
                                     ByVal p_pagado As String,
                                     ByVal p_costo As String)
        Dim titulo As String = ""
        Dim queryString As String = ""
        If p_id = clsComunes.Operacion_Registro.Nuevo Then

            titulo = "Nueva Muestra"
            queryString = ""
            queryString &= ("&id=" & p_id)
        Else


            queryString = ""
            queryString &= ("&id=" & p_id)
            queryString &= ("&id_donante=" & p_id_donante)
            queryString &= ("&p_id_factor=" & p_id_factor)
            queryString &= ("&p_id_empleado=" & p_id_empleado)
            queryString &= ("&fechanac=" & p_fecha)
            queryString &= ("&p_estado=" & p_estado)
            queryString &= ("&fechafin=" & p_fechafin)
            queryString &= ("aprobado=" & p_aprobado)
            queryString &= ("&pagado=" & p_pagado)
            queryString &= ("&costo=" & p_costo)

        End If
        Dim win = New Window With {.ID = "Win_EditarMuestra",
                                    .Width = Unit.Pixel(700),
                                    .Height = Unit.Pixel(600),
                                    .Title = titulo,
                                    .Modal = True,
                                    .AutoRender = False,
                                    .Collapsible = False,
                                    .Maximizable = False}
        win.Loader = New ComponentLoader
        win.Loader.Url = "frmItemMuestra.aspx?" & queryString
        win.Loader.Mode = LoadMode.Frame
        win.Loader.LoadMask.ShowMask = True
        win.Loader.LoadMask.Msg = "Espere un momento..."
        win.Render(True)
        win.Show()
    End Sub


End Class