<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonante.aspx.vb" Inherits="BancoSangre.frmDonante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" ID="vpCatalogoDonante" Layout="AbsoluteLayout">
            <Items>
                <ext:GridPanel runat="server" ID="dg" AnchorHorizontal="100%" AnchorVertical="100%" Scroll="Both" AutoScroll="true">
                    <Store>
                        <ext:Store ID="stDONANTE" runat="server">
                            <Model>
                                <ext:Model ID="mdDONANTE" runat="server">
                                    <Fields>

                                        <ext:ModelField Name="ID_DONANTE" />
                                        <ext:ModelField Name="ID_FACTOR" />
                                        <ext:ModelField Name="FACTOR" />
                                        <ext:ModelField Name="DPI" />
                                        <ext:ModelField Name="NOMBRE" />
                                        <ext:ModelField Name="APELLIDO" />
                                        <ext:ModelField Name="SEXO" />
                                        <ext:ModelField Name="DIRECCION" />
                                        <ext:ModelField Name="FECHA_NACIMIENTO" />
                                        <ext:ModelField Name="TELEFONO1" />
                                        <ext:ModelField Name="TELEFONO2" />
                                        <ext:ModelField Name="EMAIL" />
                                        <ext:ModelField Name="ESTADO" />
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
                  
                                <ext:Button ID="btnNuevoModelo" runat="server" Width="160" Text="Agregar Modelo" Icon="Add">
                                    <Listeners>
                                        <Click Handler="App.direct.fcrearVentanaDonante(1, 0,0,0,'','','','','')"></Click>
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
                            <ext:Column ID="Column1" runat="server" DataIndex="ID_DONANTE" Text="Codigo" Visible="true" Width="80" />
                            <ext:Column ID="Column3" runat="server" DataIndex="FACTOR" Text="Proveedor" Flex="1" />
                            <ext:Column ID="Column4" runat="server" DataIndex="DPI" Text="Familia" Flex="1" />
                            <ext:Column ID="Column5" runat="server" DataIndex="NOMBRE" Text="Material" Flex="1" />
                            <ext:Column ID="Column6" runat="server" DataIndex="APELLIDO" Text="Descripcion" Flex="1" />
                            <ext:Column ID="Column2" runat="server" DataIndex="SEXO" Text="Precio Compra" Flex="1" />
                            <ext:Column ID="Column7" runat="server" DataIndex="DIRECCION" Text="Precio Venta" Flex="1" />
                            <ext:Column ID="Column9" runat="server" DataIndex="FECHA_NACIMIENTO" Text="Precio Venta" Flex="1" />
                            <ext:Column ID="Column10" runat="server" DataIndex="TELEFONO1" Text="Precio Venta" Flex="1" />
                            <ext:Column ID="Column11" runat="server" DataIndex="TELEFONO2" Text="Precio Venta" Flex="1" />
                            <ext:Column ID="Column12" runat="server" DataIndex="EMAIL" Text="Precio Venta" Flex="1" />
                            <ext:Column ID="Column8" runat="server" DataIndex="ESTADO" Text="Estado" Flex="1" />
                            <ext:CommandColumn runat="server" Width="30">
                                <Commands>
                                    <ext:GridCommand Icon="Pencil" CommandName="btnEditar" ToolTip-Text="Editar Producto" />
                                </Commands>
                                <Listeners>
                                    <Command Handler="App.direct.fcrearVentanaDonante(2, record.data.ID_DONANTE, record.data.ID_FACTOR, record.data.DPI, record.data.NOMBRE, record.data.APELLIDO, record.data.SEXO, record.data.DIRECCION, record.data.FECHA_NACIMIENTO, record.data.TELEFONO1, record.data.TELEFONO2, record.data.EMAIL, record.data.ESTADO);" />
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
