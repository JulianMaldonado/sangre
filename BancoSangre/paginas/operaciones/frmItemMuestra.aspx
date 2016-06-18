<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmItemMuestra.aspx.vb" Inherits="BancoSangre.frmItemMuestra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<script type="text/javascript">
        fGuardar = function () {
            App.direct.fGuardar(
                {
                    success: function (result) { 
                        if (result == 1) {
                            msgBox_A('EXITOSO!!!', 'El Registro fue Guardado!');
                        } else if (result == 2) {
                            msgBox_A('EXITOSO!!!', 'El Registro fue Modificado!');
                        } else if (result == 3) {
                            msgBox_A('EXITOSO!!!', 'El Registro fue Eliminado!');
                        } else {
                            msgBox_B('ERROR!!!', 'El Registro no fue procesado!');
                        };
                    }
                });
        },

msgBox_A = function (titulo, texto) {
    Ext.MessageBox.show({
        title: titulo,
        msg: texto,
        width: 300,
        buttons: Ext.MessageBox.OK,
        fn: fCerrarVentanaModelo,
        icon: Ext.MessageBox.OK
    });
},

msgBox_B = function (titulo, texto) {
    Ext.MessageBox.show({
        title: titulo,
        msg: texto,
        width: 300,
        buttons: Ext.MessageBox.OK,
        icon: Ext.MessageBox.OK
    });
},

fCerrarVentanaModelo = function () {
    parent.App.direct.fLlenarGrid();
    parent.App.Win_EditarMuestra.close();

};
    </script>
</head>
<%--<body>--%>

    <form id="form1" runat="server">
           <ext:ResourceManager runat="server" />
        <ext:FormPanel ID="frmeditarMuestra" runat="server">
            <FieldDefaults AllowBlank="false" />
            <Items>
                <ext:TextField ID="txtCodigo" FieldLabel="Codigo" runat="server" LabelAlign="Top" Flex="1"/>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    
                     <Items>
                         

                        <ext:ComboBox runat="server" ID="cmbfactor" MarginSpec="5 5 5 5" FieldLabel="Seleccione un Factor" DisplayField="DESCRIPCION" ValueField="ID_FACTOR" LabelAlign="Top" Editable="false" Flex="1">
                            <Store>
                                <ext:Store ID="stFactor" runat="server">
                                    <Model>
                                        <ext:Model ID="mdFactor" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID_FACTOR" />
                                                <ext:ModelField Name="DESCRIPCION" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                               



                         <ext:ComboBox runat="server" ID="ComboBox1" MarginSpec="5 5 5 5" FieldLabel="Seleccione un Factor" DisplayField="DESCRIPCION" ValueField="ID_FACTOR" LabelAlign="Top" Editable="false" Flex="1">
                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Model>
                                        <ext:Model ID="Model1" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID_FACTOR" />
                                                <ext:ModelField Name="DESCRIPCION" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>







                    </Items>
                </ext:FieldContainer>


                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:TextField MaxLength="15" FieldLabel="DPI" LabelAlign="Top" runat="server" ID="txtDPI" AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        </Items>
                    </ext:FieldContainer>

                <ext:FieldContainer runat="server" Layout="HBoxLayout">

                    <Items>
                
                        <ext:TextField MaxLength="200" FieldLabel="Nombre" LabelAlign="Top" runat="server" ID="txtNombre" AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        <ext:TextField MaxLength="200" FieldLabel="Apellido" LabelAlign="Top" runat="server" ID="txtApellido" AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                       </Items>
                    </ext:FieldContainer>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                
                        <ext:TextField MaxLength="1" FieldLabel="Sexo" ID="txtSexo" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        <ext:TextField MaxLength="200" FieldLabel="Direccion" ID="txtDireccion" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        <ext:DateField  runat="server" FieldLabel="Fecha Nacimiento" ID="txtFechan" LabelAlign ="Top" AllowBlank ="false" MarginSpec="5 5 5 5" Flex="1" />
                          </Items>
                    </ext:FieldContainer>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                          <ext:TextField MaxLength="10" FieldLabel="Telefono 1" ID="txtTelefono1" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        <ext:TextField MaxLength="10" FieldLabel="Telefono 2" ID="txtTelefono2" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                            </Items>
                    </ext:FieldContainer>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:TextField MaxLength="50" FieldLabel="Email" ID="txtEmail" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                        <ext:TextField MaxLength="50" FieldLabel="Estado" ID="txtEstado" LabelAlign="Top" runat="server"  AllowBlank="false" MarginSpec="5 5 5 5" Flex="1" />
                   </Items>
                </ext:FieldContainer>
            </Items>
            <Buttons>
                <ext:Button ID="btnGuardar" runat="server" Text="Guardar" FormBind="true" Icon="Disk" Width="110" AutoLoadingState="true">
                            <Listeners>
                                <Click Handler="fGuardar();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnCancelar" runat="server" Text="Cancelar" Icon="Cancel" Width="110">
                            <Listeners>
                                <Click Handler="fCerrarVentanaModelo();" />
                            </Listeners>
                        </ext:Button>
            </Buttons>
        </ext:FormPanel>
    </form>
</body>
</html>
