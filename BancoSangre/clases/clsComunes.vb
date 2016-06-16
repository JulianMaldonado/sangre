Public Class clsComunes
    Public Property CarpetaImagenes As String = "\Resources\Images\"
    Public Property rutaLecturaImagenes As String = "~/Resources/Images/"
    Public Property SinImagen As String = "sin_foto_predeterminada.jpg"
    Public Property Pagina_Acceso_Denegado As String = "~/Paginas/administracion/notificacion/frmDenegado.aspx"
    Enum Operacion_Registro As Int16
        Nuevo = 0
        Editar = 1
        Eliminar = 2
    End Enum
    Enum Respuesta_Operacion As Int16
        Guardado = 1
        Modificado = 2
        Eliminado = 3
        Erronea = 4
    End Enum




End Class
