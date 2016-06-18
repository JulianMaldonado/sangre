Imports Oracle.ManagedDataAccess.Client
Public Class clsControladorProcedimientos
#Region "Anulaciones"
    Public Function fAnularNotaSalida(ByVal p_lugar As String,
                                      ByVal p_id_nota As Int64,
                                      ByVal p_version As Int16,
                                     ByVal p_id_usuario As Int64) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "[dbo].[SP_AnularNotaSalida]"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("p_lugar", OracleDbType.Varchar2).Value = p_lugar

            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
#End Region
#Region "Insertar"
    Public Function fInsertarDetDonacion(ByVal p_donacion As Integer,
                                         ByVal p_factor As Int16,
                                         ByVal p_cantidad As Integer,
                                         ByVal p_descripcion As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARDETDONACION"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_DONACION", OracleDbType.Int32).Value = p_donacion
                .Parameters.Add("V_FACTOR", OracleDbType.Int16).Value = p_factor
                .Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = p_cantidad
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion


            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarDetVenta(ByVal p_empleado As Integer,
                                      ByVal p_factor As Int16,
                                      ByVal p_cantidad As Integer,
                                      ByVal p_descripcion As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARTEMPDETALLE"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_IDEMPLEADO", OracleDbType.Int32).Value = p_empleado
                .Parameters.Add("V_FACTOR", OracleDbType.Int16).Value = p_factor
                .Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = p_cantidad
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                



            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarDonacion(ByVal p_id_factor As Int16,
                                       ByVal p_id_empleado As Int32,
                                       ByVal p_fecha As Date,
                                       ByVal p_descripcion As String,
                                       ByVal p_estado As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARDONACION"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_ESTADO", OracleDbType.Int32).Value = p_estado


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarDonante(ByVal p_id_factor As Int16,
                                       ByVal p_dpi As String,
                                       ByVal p_nombre As String,
                                       ByVal p_apellido As String,
                                       ByVal p_sexo As String,
                                       ByVal p_direccion As String,
                                       ByVal p_fecha_nacimiento As Date,
                                       ByVal p_fecha_registro As Date,
                                       ByVal p_telefono1 As String,
                                       ByVal p_telefono2 As String,
                                       ByVal p_email As String,
                                       ByVal p_estado As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARDONANTE"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_DPI", OracleDbType.Varchar2).Value = p_dpi
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_APELLIDO", OracleDbType.Varchar2).Value = p_apellido
                .Parameters.Add("V_SEXO", OracleDbType.Varchar2).Value = p_sexo
                .Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = p_direccion
                .Parameters.Add("V_FECHA_NACIMIENTO", OracleDbType.Date).Value = p_fecha_nacimiento
                .Parameters.Add("V_FECHA_REGISTRO", OracleDbType.Date).Value = p_fecha_registro
                .Parameters.Add("V_TELEFONO1", OracleDbType.Varchar2).Value = p_telefono1
                .Parameters.Add("V_TELEFONO2", OracleDbType.Varchar2).Value = p_telefono2
                .Parameters.Add("V_EMAIL", OracleDbType.Varchar2).Value = p_email
                .Parameters.Add("V_ESTADO", OracleDbType.Varchar2).Value = p_estado


            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarEmparejamiento(ByVal p_id_factor As Int16) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTAREMPAREJAMIENTO"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarEmpleado(ByVal p_nombre As String,
                                       ByVal p_apellido As String,
                                       ByVal p_sexo As String,
                                       ByVal p_direccion As String,
                                       ByVal p_telefono As String,
                                       ByVal p_fecha_nacimiento As Date,
                                       ByVal p_fecha_alta As Date,
                                       ByVal p_usuario As String,
                                       ByVal p_pass As String) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTAREMPLEADO"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_APELLIDO", OracleDbType.Varchar2).Value = p_apellido
                .Parameters.Add("V_SEXO", OracleDbType.Varchar2).Value = p_sexo
                .Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = p_direccion
                .Parameters.Add("V_TELEFONO", OracleDbType.Varchar2).Value = p_telefono
                .Parameters.Add("V_FECHA_NACIMIENTO", OracleDbType.Date).Value = p_fecha_nacimiento
                .Parameters.Add("V_FECHA_ALTA", OracleDbType.Date).Value = p_fecha_alta
                .Parameters.Add("V_USUARIO", OracleDbType.Varchar2).Value = p_usuario
                .Parameters.Add("V_PASS", OracleDbType.Varchar2).Value = p_pass


            End With
            bd._Cmd.ExecuteNonQuery()
            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarNewAlmacen(ByVal p_descripcion As String) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARGRUPOSANGUINEO"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion



                '   .Parameters.Add("", varchar22, 32000, "").Direction = ParameterDirection.Output
            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarHistorial(ByVal p_id_almacen As Int32,
                                       ByVal p_id_factor As Int16,
                                       ByVal p_id_empleado As Int32,
                                       ByVal p_fecha As Date,
                                       ByVal p_descripcion As String,
                                       ByVal p_movimiento As Int32,
                                       ByVal p_stock As Int32) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARHISTORIAL"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_ID_ALMACEN", OracleDbType.Int32).Value = p_id_almacen
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_MOVIMIENTO", OracleDbType.Int32).Value = p_movimiento
                .Parameters.Add("V_STOCK", OracleDbType.Int32).Value = p_stock




            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarInventario(ByVal p_id_almacen As Int32,
                                         ByVal p_id_factor As Int16,
                                         ByVal p_id_empleado As Int32,
                                         ByVal p_descripcion As String,
                                         ByVal p_stock As Int32) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARINVENTARIO"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_ID_ALMACEN", OracleDbType.Int32).Value = p_id_almacen
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_STOCK", OracleDbType.Int32).Value = p_stock




            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fInsertarMuestra(ByVal p_id_donante As Int32,
                                     ByVal p_id_factor As Int16,
                                     ByVal p_id_empleado As Int32,
                                     ByVal p_fecha As Date,
                                     ByVal p_estado As String,
                                     ByVal p_fecha_fin As Date,
                                     ByVal p_aprobado As String,
                                     ByVal p_pagado As String,
                                     ByVal p_costo As Double) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARMUESTRA"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_ID_DONANTE", OracleDbType.Int32).Value = p_id_donante
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_ESTADO", OracleDbType.Varchar2).Value = p_estado
                .Parameters.Add("V_FECHA_FIN", OracleDbType.Date).Value = p_fecha_fin
                .Parameters.Add("V_APROBADO", OracleDbType.Varchar2).Value = p_aprobado
                .Parameters.Add("V_PAGADO", OracleDbType.Varchar2).Value = p_pagado
                .Parameters.Add("V_COSTO", OracleDbType.Int32).Value = p_costo




            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fInsertarNewAlmacen(ByVal p_nombre As String,
                                        ByVal p_direccion As String) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARNEWALMACEN"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = p_direccion



            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fInsertarVenta(ByVal p_id_empleado As Int32,
                                    ByVal p_fecha As Date,
                                    ByVal p_nombre As String,
                                    ByVal p_nit As String,
                                    ByVal p_estado As String,
                                    ByVal p_total As Decimal) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPINSERTARVENTA"
                .CommandType = CommandType.StoredProcedure

                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_NIT", OracleDbType.Varchar2).Value = p_nit
                .Parameters.Add("V_ESTADO", OracleDbType.Int32).Value = p_estado
                .Parameters.Add("V_TOTAL", OracleDbType.Decimal).Value = p_total

            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
#End Region
#Region "Actualizar"
    Public Function fActualizarDetalleDonacion(ByVal p_id_detalle As Integer,
                                               ByVal p_id_donacion As Integer,
                                               ByVal p_idfactor As Int16,
                                               ByVal p_cantidad As Integer,
                                               ByVal p_descripcion As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZARDETALLEDONACION"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_DETALLE", OracleDbType.Int32).Value = p_id_detalle
                .Parameters.Add("V_ID_DONACION", OracleDbType.Int32).Value = p_id_donacion
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_idfactor
                .Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = p_cantidad
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion

            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaDetalleVenta(ByVal p_id_detalle As Integer,
                                           ByVal p_id_venta As Integer,
                                           ByVal p_id_factor As Int16,
                                           ByVal p_cantidad As Integer,
                                           ByVal p_descripcion As String,
                                           ByVal p_total As Decimal) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZADETALLEVENTA"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_DETALLE", OracleDbType.Int32).Value = p_id_detalle
                .Parameters.Add("V_ID_VENTA", OracleDbType.Int32).Value = p_id_venta
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = p_cantidad
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_TOTAL", OracleDbType.Decimal).Value = p_descripcion

            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaDonacion(ByVal p_id_donacion As Int32,
                                       ByVal p_id_factor As Int16,
                                       ByVal p_id_empleado As Int32,
                                       ByVal p_fecha As Date,
                                       ByVal p_descripcion As String,
                                       ByVal p_estado As String) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZADONACION"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_DONACION", OracleDbType.Int32).Value = p_id_donacion
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_ESTADO", OracleDbType.Int32).Value = p_estado


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fActualizaDonante(ByVal p_id_donante As Int32,
                                       ByVal p_id_factor As Int16,
                                       ByVal p_dpi As String,
                                       ByVal p_nombre As String,
                                       ByVal p_apellido As String,
                                       ByVal p_sexo As String,
                                       ByVal p_direccion As String,
                                       ByVal p_fecha_nacimiento As Date,
                                       ByVal p_fecha_regristro As Date,
                                       ByVal p_telefono1 As String,
                                       ByVal p_telefono2 As String,
                                       ByVal p_email As String,
                                       ByVal p_estado As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZADONANTE"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_DONANTE", OracleDbType.Int32).Value = p_id_donante
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_DPI", OracleDbType.Varchar2).Value = p_dpi
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_APELLIDO", OracleDbType.Varchar2).Value = p_apellido
                .Parameters.Add("V_SEXO", OracleDbType.Varchar2).Value = p_sexo
                .Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = p_direccion
                .Parameters.Add("V_FECHA_NACIMIENTO", OracleDbType.Date).Value = p_fecha_nacimiento
                .Parameters.Add("V_FECHA_REGRISTO", OracleDbType.Date).Value = p_fecha_regristro
                .Parameters.Add("V_TELEFONO1", OracleDbType.Varchar2).Value = p_telefono1
                .Parameters.Add("V_TELEFONO2", OracleDbType.Varchar2).Value = p_telefono2
                .Parameters.Add("V_EMAIL", OracleDbType.Varchar2).Value = p_email
                .Parameters.Add("V_ESTADO", OracleDbType.Int32).Value = p_estado


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fActualizaEmparejamiento(ByVal p_id_emparejamiento As Int16,
                                             ByVal p_id_factor As Int16) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAEMPAREJAMIENTO"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_EMPAREJAMIENTO", OracleDbType.Int16).Value = p_id_emparejamiento
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fActualizaEmpleado(ByVal p_id_empleado As Int32,
                                       ByVal p_nombre As String,
                                       ByVal p_apellido As String,
                                       ByVal p_sexo As String,
                                       ByVal p_direccion As String,
                                       ByVal p_telefono As String,
                                       ByVal p_fecha_nacimiento As Date,
                                       ByVal p_fecha_alta As Date,
                                       ByVal p_usuario As String,
                                       ByVal p_pass As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZADONANTE"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_APELLIDO", OracleDbType.Varchar2).Value = p_apellido
                .Parameters.Add("V_SEXO", OracleDbType.Varchar2).Value = p_sexo
                .Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = p_direccion
                .Parameters.Add("V_TELEFONO", OracleDbType.Varchar2).Value = p_telefono
                .Parameters.Add("V_FECHA_NACIMIENTO", OracleDbType.Date).Value = p_fecha_nacimiento
                .Parameters.Add("V_FECHA_ALTA", OracleDbType.Date).Value = p_fecha_alta
                .Parameters.Add("V_USUARIO", OracleDbType.Varchar2).Value = p_usuario
                .Parameters.Add("V_PASS", OracleDbType.Int32).Value = p_pass


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function
    Public Function fActualizaGuproSanguineo(ByVal p_id_factor As Int16,
                                             ByVal p_descripcion As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAGRUPOSANGUINEO"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion


            End With
            bd._Cmd.ExecuteNonQuery()

            v_respuesta = clsComunes.Respuesta_Operacion.Guardado

        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaHistorial(ByVal p_id_historial As Integer,
                                       ByVal p_id_almacen As Int32,
                                       ByVal p_id_factor As Int16,
                                       ByVal p_id_empleado As Int32,
                                       ByVal p_fecha As Date,
                                       ByVal p_descripcion As String,
                                       ByVal p_movimiento As Int32,
                                       ByVal p_stock As Int32) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAHISTORIAL"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_HISTORIAL", OracleDbType.Int32).Value = p_id_historial
                .Parameters.Add("V_ID_ALMACEN", OracleDbType.Int32).Value = p_id_almacen
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_MOVIMIENTO", OracleDbType.Int32).Value = p_movimiento
                .Parameters.Add("V_STOCK", OracleDbType.Int32).Value = p_stock


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaInventario(ByVal p_id_almacen As Int32,
                                         ByVal p_id_factor As Int16,
                                         ByVal p_id_empleado As Int32,
                                         ByVal p_descripcion As String,
                                         ByVal p_stock As Int32) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAINVENTARIO"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_ALMACEN", OracleDbType.Int32).Value = p_id_almacen
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = p_descripcion
                .Parameters.Add("V_STOCK", OracleDbType.Int32).Value = p_stock



            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaMuestra(ByVal p_id_muestra As Int32,
                                       ByVal p_id_donante As Int32,
                                       ByVal p_id_factor As Int16,
                                       ByVal p_id_empleado As Int32,
                                       ByVal p_fecha As Date,
                                       ByVal p_estado As String,
                                       ByVal p_fecha_fin As Date,
                                       ByVal p_aprobado As String,
                                       ByVal p_pagado As String,
                                       ByVal p_costo As Double) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAMUESTRA"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_MUESTRA", OracleDbType.Int32).Value = p_id_muestra
                .Parameters.Add("V_ID_DONANTE", OracleDbType.Int32).Value = p_id_donante
                .Parameters.Add("V_ID_FACTOR", OracleDbType.Int16).Value = p_id_factor
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_ESTADO", OracleDbType.Varchar2).Value = p_estado
                .Parameters.Add("V_FECHA_FIN", OracleDbType.Date).Value = p_fecha_fin
                .Parameters.Add("V_APROBADO", OracleDbType.Varchar2).Value = p_aprobado
                .Parameters.Add("V_PAGADO", OracleDbType.Varchar2).Value = p_pagado
                .Parameters.Add("V_COSTO", OracleDbType.Int32).Value = p_costo



            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaNewAlmacen(ByVal p_id_almacen As Int32,
                                         ByVal p_nombre As String,
                                         ByVal p_direccion As String) As Integer
        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZANEWALMACEN"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_ALMACEN", OracleDbType.Int32).Value = p_id_almacen
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_DIRECCION", OracleDbType.Int32).Value = p_direccion



            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function

    Public Function fActualizaVenta(ByVal p_id_venta As Int32,
                                    ByVal p_id_empleado As Int32,
                                    ByVal p_fecha As Date,
                                    ByVal p_nombre As String,
                                    ByVal p_nit As String,
                                    ByVal p_estado As String,
                                    ByVal p_total As Decimal) As Integer

        Dim v_respuesta As Integer = 0
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "SPACTUALIZAVENTA"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("V_ID_VENTA", OracleDbType.Int32).Value = p_id_venta
                .Parameters.Add("V_ID_EMPLEADO", OracleDbType.Int32).Value = p_id_empleado
                .Parameters.Add("V_FECHA", OracleDbType.Date).Value = p_fecha
                .Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = p_nombre
                .Parameters.Add("V_NIT", OracleDbType.Varchar2).Value = p_nit
                .Parameters.Add("V_ESTADO", OracleDbType.Int32).Value = p_estado
                .Parameters.Add("V_TOTAL", OracleDbType.Decimal).Value = p_total


            End With
            bd._Cmd.ExecuteNonQuery()
            If bd._Cmd.Parameters("v_estado").Value > 0 Then
                v_respuesta = clsComunes.Respuesta_Operacion.Guardado
            End If
        Catch ex As Exception
            v_respuesta = clsComunes.Respuesta_Operacion.Erronea
        Finally
            bd.fCerrar()
        End Try
        Return v_respuesta
    End Function






#End Region
#Region "Listar"
    Public Function fLogin(ByVal USUARIO As String, ByVal PASS As String) As DataTable

        Dim DT As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "splogin"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = USUARIO
                .Parameters.Add("v_pass", OracleDbType.Varchar2).Value = PASS
                .Parameters.Add("v_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output
            End With
            DT.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return DT
    End Function
    Public Function fListarHistorialProducto(ByVal lugar As String, ByVal idpr_modelo As String) As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "[dbo].[spListarHistorialProducto]"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("idlugar", OracleDbType.Varchar2).Value = lugar
                .Parameters.Add("idpr_modelo", OracleDbType.Varchar2).Value = idpr_modelo
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarGrupoSanguineo() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select id_factor, descripcion from GRUPO_SANGUINEO"
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarInventarios() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select i.id_almacen, i.id_factor, a.nombre as almacen, f.descripcion as factor, i.stock
                                   from inventario i
                                   inner join grupo_sanguineo f
                                    on f.id_factor = i.id_factor
                                   inner join almacen a
                                    on a.id_almacen = i.id_almacen"
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarHistorial() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select h.id_almacen, h.id_factor, a.nombre as almacen, f.descripcion as factor, h.fecha, h.descripcion, h.movimiento, h.stock, e.usuario,
                                   from historial h
                                   inner join grupo_sanguineo f
                                    on f.id_factor = h.id_factor
                                   inner join almacen a
                                    on a.id_almacen = h.id_almacen
                                   inner join empleado e
                                    on e.id_empleado = h.id_empleado"
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarDetalleVenta(byval id As Integer) As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "SELECT
                                GS.ID_FACTOR,
                                F.CANTIDAD,
                                GS.DESCRIPCION AS FACTOR,
                                F.DESCRIPCION,
                                F.TOTAL,
                                F.CANTIDAD * F.TOTAL AS SUBTOTAL
                                FROM
                                SANGRE.TEMP_DETALLE_VENTA F
                                INNER JOIN SANGRE.GRUPO_SANGUINEO GS ON GS.ID_FACTOR = F.ID_FACTOR AND F.ID_FACTOR = GS.ID_FACTOR
                                WHERE F.ID_EMPLEADO = "+id.ToString
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarDetalleDonacion(byval id As Integer) As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "SELECT
                                GS.ID_FACTOR,
                                F.CANTIDAD,
                                GS.DESCRIPCION AS FACTOR,
                                F.DESCRIPCION,
                                F.TOTAL,
                                F.CANTIDAD * F.TOTAL AS SUBTOTAL
                                FROM
                                SANGRE.TEMP_DETALLE_DONACION F
                                INNER JOIN SANGRE.GRUPO_SANGUINEO GS ON GS.ID_FACTOR = F.ID_FACTOR AND F.ID_FACTOR = GS.ID_FACTOR
                                WHERE F.ID_EMPLEADO = "+id.ToString
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarDonantes() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select d.id_donante, d.id_factor, f.descripcion as FACTOR, d.dpi, d.nombre, 
                                        d.apellido, d.sexo, d.direccion, d.fecha_nacimiento, d.telefono1, d.telefono2,
                                        d.email, d.estado 
                                from DONANTE d inner join GRUPO_SANGUINEO f on f.id_factor = d.id_factor"
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarEmpleado() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select  e.id_empleado, 
                                        e.nombre, 
                                        e.apellido, 
                                        e.sexo, 
                                        e.direccion,
                                        e.telefono,        
                                        e.fecha_nacimiento,
                                        e.fecha_alta,
                                        e.usuario,
                                        e.pass, 
                                        e.id_nivel 
                                from EMPLEADO e "
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarMuestra() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "Select  m.id_muestra,
                                        m.id_donante,
                                           d.nombre as DONANTE,
                                        m.id_factor,
                                           f.descripcion as FACTOR, 
                                        m.id_empleado, 
                                            e.nombre as EMPLEADO, 
                                        m.fecha,
                                        m.estado,        
                                        m.fecha_fin,
                                        m.aprobado,
                                        m.pagado, 
                                        m.costo 
                                from MUESTRA m inner join DONANTE d on d.id_donante = m.id_donante
                                                inner join GRUPO_SANGUINEO f on f.id_factor = m.id_factor
                                                inner join EMPLEADO e on e.id_empleado = m.id_empleado"



                '"select  m.id_muestra,
                '                        d.nombre as DONANTE,
                '                        f.descripcion As FACTOR, 
                '                        e.nombre as EMPLEADO,
                '                        m.fecha,
                '                        m.estado,
                '                        m.fecha_fin,
                '                        m.aprobado,
                '                        m.pagado,
                '                        m.costo 

                '           From MUESTRA m inner Join DONANTE d on d.id_donante = m.id_donante
                '                          inner Join GRUPO_SANGUINEO f on f.id_factor = m.id_factor
                '                            inner Join EMPLEADO e On e.id_empleado = m.id_empleado"



            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function
    Public Function fListarAlmacen() As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .Connection = bd.ObtenerConexion
                .CommandType = CommandType.Text
                .CommandText = "select  a.id_almacen, 
                                        a.nombre, 
                                        a.direccion 
                                 from ALMACEN a "
            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function











#End Region
#Region "Obtener"
    Public Function fObtenerTipoCuenta(ByVal p_id As Long) As DataTable
        Dim dt As New DataTable
        Dim bd As New clsGestorBaseDatos
        Try
            bd.fAbrir()
            With bd._Cmd
                .CommandText = "[dbo].[spObtenerTipoCuenta]"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("p_TipoCuenta", OracleDbType.Int32).Value = p_id

            End With
            dt.Load(bd._Cmd.ExecuteReader())
        Catch ex As Exception
        Finally
            bd.fCerrar()
        End Try
        Return dt
    End Function

#End Region
End Class
