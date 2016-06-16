<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="BancoSangre.Login" %>

<%@ Import Namespace="System.Security.Cryptography" %>

<%@ Import Namespace="Oracle.ManagedDataAccess.Client" %>

<html>
<head id="Head1" runat="server">
    <link rel="stylesheet" href="Style.css">
    <title>Iniciar Sesion</title>
    <script runat="server">
        Sub Logon_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim query, estado As String

            Dim hash As String

            Using Banco1 As MD5 = MD5.Create()
                hash = BancoSangre._ObtieneMd5Hash(Banco1, txtPass.Text)
                Session("pass") = hash
                query = "SELECT id_empleado, nombre, apellido, sexo, direccion, telefono, fecha_nacimiento, fecha_alta, usuario, pass,id_nivel from empleado where usuario = '" & txtUsuario.Text.ToLower & "' AND  pass= '" & hash & "'"
            End Using
            Dim r As OracleDataReader
            Try
                r = BancoSangre._CONSULTAR_SQL(query, "q1")
                If r.HasRows Then
                    Session("usuario") = txtUsuario.Text
                    While r.Read()
                        Session("id_empleado") = r(0)
                        Session("nombre") = r(1)
                        Session("apellido") = r(2)
                        Session("sexo") = r(3)
                        Session("direccion") = r(4)
                        Session("telefono") = r(5)
                        Session("fecha_nacimiento") = r(6)
                        Session("fecha_alta") = r(7)
                        Session("usuario") = r(8)
                        Session("pass") = r(9)
                        Session("id_nivel") = r(10)
                    End While

                    r.Close()
                    FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, True)
                End If
            Catch ex As Exception
                lblmsg.Text = "Error " + ex.Message.ToString
            End Try


        End Sub

    </script>
</head>
<body>
        <form id="form1" runat="server">
            <ext:ResourceManager runat="server"></ext:ResourceManager>
        <section class="container">
            <img alt="" src="../../img/logo.jpg" height="128" class="logo" />
            <p></p>
            <div class="login">
                <h1>Iniciar Sesion</h1>
                <p>
                    <asp:TextBox ID="txtUsuario" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="txtUsuario"
                        Display="Dynamic"
                        ErrorMessage="No puede estar vacio."
                        runat="server" />
                </p>
                <p>
                    <asp:TextBox ID="txtPass" TextMode="Password"
                        runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="txtPass"
                        ErrorMessage="No puede estar vacio."
                        runat="server" />
                </p>
               
                <p class="submit">
                   <asp:Button ID="Logon" Text="Iniciar Sesion"
                        runat="server" OnClick="Logon_Click" />
                   
                </p>
                <p class="submit">
                 <asp:Label ID="lblmsg" ForeColor="red" runat="server" />

                </p>
               
             
            </div>
            <br />
            </section>

    </form>
</body>
</html>
