<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="BancoSangre.index" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Banco de Sangre</title>

    <style type="text/css">
       

        img.displayed {
            display: block;
            margin: 0 auto;
            clear: right;
        }
    </style>
     
    <link rel="shortcut icon" type="image/ico" href="Images/icono.png" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="ScriptFiles" />
</head>
<body>
    <form id="frmPanelPrincipal" runat="server">
        <script src="../scripts/panel_administracion.js" type="text/javascript"></script>
        <ext:ResourceManager ID="ResourceManager1" runat="server" InitScriptMode="Linked"
            DirectEventUrl="panel_principal.aspx" IDMode="Explicit" />
        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
            <Items>
                <ext:Panel ID="pnlToolbar" runat="server" Region="North" Height="95">
                    <Items>
                        <ext:Toolbar ID="Toolbar1" runat="server" Height="95">
                            <Items>
                                <ext:Panel ID="DisplayField12" runat="server">
                                    <Content>
                                        <div>
                                            <asp:Image runat="server" ImageUrl="~/img/logo.png" ID="Image1" ImageAlign="AbsMiddle" Height ="80px" />
                                        </div>
                                    </Content>
                                </ext:Panel>
                                <ext:ToolbarFill />
                                <ext:Button ID="BtnSesionCnfg" runat="server" Icon="UserGray" Text="Sesión">
                                    <Menu>
                                        <ext:Menu ID="Menu1" runat="server">
                                            <Items>
                                                <ext:MenuItem runat="server" ID="mnuPerfil" Text="Perfil" Icon="User" />
                                                <ext:MenuItem runat="server" ID="mnuchangePass" Text="Cambiar Contraseña" Icon="UserKey">
                                                </ext:MenuItem>
                                                <ext:MenuItem runat="server" ID="mnulogOut" Text="Salir del Sistema" Icon="UserGo">
                                                    <Listeners>
                                                        <Click Handler="App.direct.Salir()"></Click>
                                                    </Listeners>
                                                </ext:MenuItem>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                       </Items>
                </ext:Panel>
                <ext:TabPanel ID="tabPanelPrincipal"
                    runat="server"
                    Region="Center"
                    MarginSpec="5 5 5 0">
                    <Items>
                        <ext:Panel ID="PanelInfo" runat="server" Title="Dashboard" AutoRender="false">
                            <Loader ID="Loader1" runat="server" Url="paginas/inicio.aspx" DisableCaching="true" Mode="Frame" AutoLoad="false">
                                <LoadMask ShowMask="true" Msg="Espere un momento..." />
                            </Loader>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel> 
                <ext:Panel ID="pnlOeste" runat="server" Region="West"
                    Width="210" Collapsible="true" Split="true"
                    MinWidth="175" MaxWidth="400" MarginSpec="5 0 5 5"
                    Layout="AccordionLayout">
                    <Items>
                        <ext:MenuPanel ID="mpCatalogos1" runat="server"
                            Title="Catalogos" Collapsed="true"
                            Icon="ApplicationDouble" AutoScroll="true" BodyPadding="5" Border="false">
                            <Menu ID="Menu2" runat="server">
                                <Items>
                                    <ext:MenuItem ID="miGruposanguineo" runat="server" Text="Grupo Sanguineo" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id11', 'catalogos/frmGrupoSanguineo.aspx','Catálogo Grupo Sanguineo',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem ID="miDonante" runat="server" Text="Donantes" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id12', 'catalogos/frmDonante.aspx','Catálogo Donantes',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem ID="miAlmacen" runat="server" Text="Almacen" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id13', 'catalogos/frmAlmacen.aspx','Catálogo Almacenes',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem ID="miEmpleado" runat="server" Text="Empleado" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id14', 'catalogos/frmEmpleado.aspx','Catálogo Empleados',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>
                                   
                                  
                                </Items>
                            </Menu>
                        </ext:MenuPanel>
                        <ext:MenuPanel ID="mpOperaciones2" runat="server"
                            Title="Operaciones" Collapsed="true"
                            Icon="ApplicationDouble" AutoScroll="true" BodyPadding="5" Border="false">
                            <Menu ID="Menu3" runat="server">
                                <Items>
                                 
                                    <ext:MenuItem ID="miMuesta" runat="server" Text="Ingreso de Muestras" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id22', 'operaciones/frmMuestra.aspx','Ingreso De Muestras',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>

                                    <ext:MenuItem ID="miVenta" runat="server" Text="Ingreso de Ventas" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id23', 'operaciones/frmVenta.aspx','Ingreso De Venta',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>
                                 
                                    <ext:MenuItem ID="miDonacion" runat="server" Text="Ingreso de Donaciones" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id24', 'operaciones/frmDonacion.aspx','Ingreso De Donaciones',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>

                                     <ext:MenuItem ID="miInventario" runat="server" Text="Inventario" Icon="BookEdit">
                                        <Listeners>
                                            <Click Handler="addTab(#{tabPanelPrincipal}, 'id25', 'operaciones/frmInventario.aspx','Inventario ',  this);" />
                                        </Listeners>
                                    </ext:MenuItem>

                                    
                                </Items>
                            </Menu>
                        </ext:MenuPanel>
                        <ext:MenuPanel ID="mpReporteria" runat="server"
                            Title="Reporteria" Collapsed="true"
                            Icon="ApplicationDouble" AutoScroll="true" BodyPadding="5" Border="false">
                            <Menu ID="Menu4" runat="server">
                                
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>