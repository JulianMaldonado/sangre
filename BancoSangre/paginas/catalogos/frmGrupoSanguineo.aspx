﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmGrupoSanguineo.aspx.vb" Inherits="BancoSangre.frmGrupoSanguineo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/Javascript">
        var fEditar = function (editor, e) {
            if (!(e.value === e.originalValue)) {
                App.direct.fModificarGS(e.record.data.id_factor, e.value,
                   {
                       success: function (result) {
                           if (result == 2) {
                               Ext.net.Notification.show({
                                   pinEvent: 'click',
                                   html: '<h3>Cambio Guardado</h3>'
                               });
                               App.direct.fLlenarGrid();
                           };
                       }
                   }); 
            }
        },
        guardarNuevo = function () {
            App.direct.fNuevaFamilia(
                  {
                      success: function (result) {
                          if (result == 1) {
                              Ext.net.Notification.show({
                                  pinEvent: 'click',
                                  html: '<h3>Registro Ingresado</h3>'
                              });
                              App.direct.fLlenarGrid();
                          };
                      }
                  });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
            <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" ID="vpCatalogoFamilia" Layout="AbsoluteLayout">
            <Items>
                <ext:GridPanel runat="server" ID="dg" AnchorHorizontal="100%" AnchorVertical="100%" Scroll="Both" AutoScroll="true">
                    <Store>
                        <ext:Store ID="stgrupoSanguineo" runat="server">
                            <Model>
                                <ext:Model ID="ModeloGrupoSanguineo" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="id_factor" />
                                        <ext:ModelField Name="descripcion" />
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
                                <ext:TextField runat="server" ID="txtFamilia" Regex="[a-zA-Z]" AllowBlank="false"></ext:TextField>
                                <ext:Button ID="btnGuardarFamilia" runat="server" Width="160" Text="Guardar Nueva" Icon="Add">
                                    <Listeners>
                                        <Click Handler="guardarNuevo()"></Click>
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
                            <ext:Column ID="Column1" runat="server" DataIndex="id_factor" Text="Codigo" Visible="true" Width="150" />
                            <ext:Column ID="Column2" runat="server" DataIndex="descripcion" Text="Nombre" Flex="1">
                                <Editor>
                                    <ext:TextField runat="server"></ext:TextField>
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                 
                    <Plugins>
                        <ext:FilterHeader runat="server" Remote="false" />
                        <ext:CellEditing runat="server">
                            <Listeners>
                                <Edit Fn="fEditar" />
                            </Listeners>
                        </ext:CellEditing>
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" RefreshHandler="fLlenarGrid()" />
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
