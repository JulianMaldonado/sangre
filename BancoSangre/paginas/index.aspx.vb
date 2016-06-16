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

    End Sub
    Protected Sub mostrarMenu()

        Select Case CInt(Session("idpuesto"))
                    Case 1


                    Case 2



                    Case 3





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