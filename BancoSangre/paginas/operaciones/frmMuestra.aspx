<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmMuestra.aspx.vb" Inherits="BancoSangre.frmMuestra" %>

<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" ID="vpCatalogoMuestra" Layout="AbsoluteLayout">
            <Items>
                <ext:GridPanel runat="server" ID="dg" AnchorHorizontal="100%" AnchorVertical="100%" Scroll="Both" AutoScroll="true">
                    <Store>
                        <ext:Store ID="sthistorial" runat="server">
                            <Model>
                                <ext:Model ID="ModeloMuestra" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="ID_MUESTRA" />
                                        <ext:ModelField Name="DONANTE" />
                                        <ext:ModelField Name="FACTOR" />
                                        <ext:ModelField Name="EMPLEADO" />
                                        <ext:ModelField Name="FECHA" Type="Date" />
                                        <ext:ModelField Name="ESTADO" />
                                        <ext:ModelField Name="FECHA_FIN" Type="Date" />  <%--CADUCIDAD DE UNIDAD--%>
                                        <ext:ModelField Name="APROBADO" />
                                        <ext:ModelField Name="PAGADO" />
                                        <ext:ModelField Name="COSTO" />
                                        
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
                            <ext:Column ID="Column1" runat="server" DataIndex="ID_MUESTRA" Text="COD. MUESTRA" Visible="true" Flex="1"/>
                            <ext:Column ID="Column2" runat="server" DataIndex="DONANTE" Text="DONANTE" Visible="true" Flex="1"/>
                            <ext:Column ID="Column3" runat="server" DataIndex="FACTOR" Text="FACTOR" Visible="true" Flex="1" />
                            <ext:Column ID="Column4" runat="server" DataIndex="EMPLEADO" Text="EMPLEADO" Visible="true" Flex="1" />
                            <ext:DateColumn runat="server" Format="dd/MM/yyyy" DataIndex="FECHA" Text="FECHA" Visible="true" Flex="1"  />
                             
                            <ext:Column ID="Column6" runat="server" DataIndex="ESTADO" Text="ESTADO" Visible="true" Flex="1" />
                            <ext:DateColumn runat="server" Format="dd/MM/yyyy" DataIndex="FECHA_FIN" Text="CADUCIDAD" Visible="true" Flex="1"  />
                            
                            <ext:Column ID="Column8" runat="server" DataIndex="APROBADO" Text="APROBADO" Visible="true" Flex="1" />
                            <ext:Column ID="Column9" runat="server" DataIndex="PAGADO" Text="PAGADO" Visible="true" Flex="1" />
                            <ext:Column ID="Column10" runat="server" DataIndex="COSTO" Text="COSTO" Visible="true" Flex="1" />


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
