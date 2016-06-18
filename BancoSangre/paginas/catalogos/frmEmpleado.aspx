<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmEmpleado.aspx.vb" Inherits="BancoSangre.frmEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" ID="vpCatalogoEmpleado" Layout="AbsoluteLayout">
            <Items>
                <ext:GridPanel runat="server" ID="dg" AnchorHorizontal="100%" AnchorVertical="100%" Scroll="Both" AutoScroll="true">
                    <Store>
                        <ext:Store ID="stEMPLEADO" runat="server">
                            <Model>
                                <ext:Model ID="mdEMPLEADO" runat="server">
                                    <Fields>

                                        <ext:ModelField Name="ID_EMPLEADO" />
                                        <ext:ModelField Name="NOMBRE" />
                                        <ext:ModelField Name="APELLIDO" />
                                        <ext:ModelField Name="SEXO" />
                                        <ext:ModelField Name="DIRECCION" />
                                        <ext:ModelField Name="TELEFONO" />
                                        <ext:ModelField Name="FECHA_NACIMIENTO" />
                                        <ext:ModelField Name="FECHA_ALTA" />
                                        <ext:ModelField Name="USUARIO" />
                                        <ext:ModelField Name="PASS" />
                                        <ext:ModelField Name="ID_NIVEL" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill2" runat="server" />
                                <ext:ToolbarSeparator />
                  
                                <ext:Button ID="btnNuevoModelo" runat="server" Width="160" Text="Nuevo Empleado" Icon="Add">
                                    <Listeners>
                                        <Click Handler="App.direct.fcrearVentanaEmpleado(0,'','','','','','','','','','')"></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:ToolbarSeparator />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="rowSelectionModel1" runat="server" />
                    </SelectionModel>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" DataIndex="ID_EMPLEADO" Text="Codigo" Visible="true" Width="80" />
                            <ext:Column ID="Column2" runat="server" DataIndex="NOMBRE" Text="Nombre" Flex="1" />
                            <ext:Column ID="Column3" runat="server" DataIndex="APELLIDO" Text="Apellido" Flex="1" />
                            <ext:Column ID="Column4" runat="server" DataIndex="SEXO" Text="Sexo" Flex="1" />
                            <ext:Column ID="Column5" runat="server" DataIndex="DIRECCION" Text="Direccion" Flex="1" />
                            <ext:Column ID="Column6" runat="server" DataIndex="TELEFONO" Text="Celular" Flex="1" />
                            <ext:Column ID="Column7" runat="server" DataIndex="FECHA_NACIMIENTO" Text="Fecha Nac." Flex="1" />
                            <ext:Column ID="Column8" runat="server" DataIndex="FECHA_ALTA" Text="Fecha Alta" Flex="1" />
                            <ext:Column ID="Column9" runat="server" DataIndex="USUARIO" Text="Usuario" Flex="1" />
                          <%--<ext:Column ID="Column10" runat="server" DataIndex="PASS" Type="Pasword" Text="Clave" Flex="1" />--%>
                            <ext:Column ID="Column11" runat="server" DataIndex="ID_NIVEL" Text="Nivel" Flex="1" />
                            <ext:CommandColumn runat="server" Width="30" Text="">
                                <Commands>
                                    <ext:GridCommand Icon="Pencil" CommandName="btnEditar" ToolTip-Text="Editar" />
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.fcrearVentanaEmpleado( record.data.ID_EMPLEADO, record.data.NOMBRE, record.data.APELLIDO, record.data.SEXO, record.data.DIRECCION, record.data.TELEFONO,
                                                                                        record.data.FECHA_NACIMIENTO, record.data.FECHA_ALTA, record.data.USUARIO, record.data.PASS, record.data.ID_NIVEL);" />
                                </Listeners>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:FilterHeader runat="server" Remote="false" />
                    </Plugins>

                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" RefreshHandler="App.direct.fLlenarGrid()" />
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
