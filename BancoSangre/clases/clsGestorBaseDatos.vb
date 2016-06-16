Imports Oracle.ManagedDataAccess.Client
Public Class clsGestorBaseDatos
    Private _CadenaConexion As String = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.27)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE))); User Id=Sangre; Password=33463346;"
    '  Private _CadenaConexion As String = "Data Source=hazel.arvixe.com;Initial Catalog=seminario_joyeria;Persist Security Info=True;User ID=seminario_umg;Password=umg123"
    Private _Cnn As OracleConnection

    Public _Cmd As OracleCommand
    Public Function ObtenerConexion() As OracleConnection
        Return _Cnn
    End Function

    Public Sub fAbrir()
        _Cnn = New OracleConnection(_CadenaConexion)
        _Cnn.Open()
        _Cmd = New OracleCommand
        _Cmd.Connection = _Cnn
    End Sub
    Public Sub fCerrar()
        _Cnn.Close()
    End Sub

End Class
