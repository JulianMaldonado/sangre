
Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        Try
            Session.Add("id_empleado", 0)
            Session.Add("nombre", 0)
            Session.Add("apellido", 0)
            Session.Add("sexo", 0)
            Session.Add("direccion", 0)
            Session.Add("telefono", 0)
            Session.Add("fecha_nacimiento", 0)
            Session.Add("fecha_alta", 0)
            Session.Add("usuario", 0)
            Session.Add("id_nivel", 0)
        Catch ex As Exception

        End Try

        ' Se desencadena al iniciar la aplicación
    End Sub
End Class