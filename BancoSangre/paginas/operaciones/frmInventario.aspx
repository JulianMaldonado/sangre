<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmInventario.aspx.vb" Inherits="BancoSangre.frmInventario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" ID="vpCatalogoGrupoSanguineo" Layout="AbsoluteLayout">
            <Items>
                <ext:GridPanel runat="server" ID="dg" AnchorHorizontal="100%" AnchorVertical="100%" Scroll="Both" AutoScroll="true">
                    <Store>
                        <ext:Store ID="stinventario" runat="server">
                            <Model>
                                <ext:Model ID="ModeloGrupoSanguineo" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="ID_ALMACEN" />
                                        <ext:ModelField Name="ID_FACTOR" />
                                        <ext:ModelField Name="ALMACEN" />
                                        <ext:ModelField Name="FACTOR" />
                                        <ext:ModelField Name="STOCK" />
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
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="rowSelectionModel1" runat="server" />
                    </SelectionModel>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column ID="Column1" runat="server" DataIndex="ALMACEN" Text="ALMACEN" Visible="true" Flex="1" />
                            <ext:Column ID="Column2" runat="server" DataIndex="FACTOR" Text="FACTOR" Visible="true" Flex="1" />
                            <ext:Column ID="Column3" runat="server" DataIndex="STOCK" Text="STOCK" Visible="true" Flex="1" />
                              <ext:CommandColumn runat="server" Width="30" ID="ColumnaAccion">
                                <Commands>
                                    <ext:GridCommand Icon="Accept" CommandName="btnAceptar" ToolTip-Text="Seleccionar" />
                                </Commands>
                                <Listeners>
                                    <Command Handler="parent.App.direct.fSeleccionar(record.data); 
                                                      parent.App.Win_BuscarInvetario.close();
                                                      "/>
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
