Imports Ext.Net

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Session.Count = 0 Then
            FormsAuthentication.RedirectToLoginPage()
        End If

        If Not Page.IsPostBack And Not Ext.Net.X.IsAjaxRequest Then
            fMostrarValoresInicales()
        End If

    End Sub
    Private Sub fMostrarValoresInicales()
        BtnSesionCnfg.Text = "Bienvenido " + Session("nombre")
        mostrarMenu()
    End Sub
    Private Sub ocultarMenu()

        miGruposanguineo.Visible = False
        miAlmacen.Visible = False
        miDonante.Visible = False
        miEmpleado.Visible = False
        miMuesta.Visible = False
        miVenta.Visible = False
        miDonacion.Visible = False
        miInventario.Visible = False
        mpReporteria.Visible = False

    End Sub
    Protected Sub mostrarMenu()

        Select Case CInt(Session("id_nivel"))
            Case 1   ''administrador

                miGruposanguineo.Visible = True
                miAlmacen.Visible = True
                miDonante.Visible = True
                miEmpleado.Visible = True
                miMuesta.Visible = True
                miVenta.Visible = True
                miDonacion.Visible = True
                miInventario.Visible = True
                mpReporteria.Visible = True


            Case 2  ''secretario

                miGruposanguineo.Visible = True
                miAlmacen.Visible = True
                miDonante.Visible = True
                miEmpleado.Visible = True
                miMuesta.Visible = True
                miVenta.Visible = True
                miDonacion.Visible = True
                miInventario.Visible = True
                mpReporteria.Visible = False


            Case 3  ''vendedor

                miGruposanguineo.Visible = False
                miAlmacen.Visible = False
                miDonante.Visible = False
                miEmpleado.Visible = False
                miMuesta.Visible = True
                miVenta.Visible = True
                miDonacion.Visible = True
                miInventario.Visible = True
                mpReporteria.Visible = False
                mpCatalogos1.Visible = False




        End Select




    End Sub
    <DirectMethod>
    Public Sub Salir()
        Session.Abandon()
        Session.Remove("nombre")
        FormsAuthentication.SignOut()

        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub


End Class