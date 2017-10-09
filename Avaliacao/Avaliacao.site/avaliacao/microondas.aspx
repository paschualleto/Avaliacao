<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="microondas.aspx.cs" Inherits="Avaliacao.site.avaliacao.microondas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Microondas</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="panel-group" style="padding: 10px">
                <div class="panel panel-info" style="width: 500px">
                    <div class="panel-heading">Microondas</div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <label>Alimento:</label>
                            <asp:TextBox runat="server" ID="txtAlimento" CssClass="form-control" />
                            
                            <asp:Button ID="btnBuscar" runat="server" Text="buscar" OnClick="btnBuscar_Click" />

                            <asp:Panel runat="server" ID="pnInstrucoes" Visible="false"> 
                                <label>Nome:</label>
                                <asp:Label runat="server" ID="lbNome"></asp:Label>
                                <label>Intrução:</label>
                                <asp:Label runat="server" ID="lbInstru"></asp:Label>
                                <label>Tempo:</label>
                                <asp:Label runat="server" ID="lbTempo"></asp:Label>
                                <label>Potência:</label>
                                <asp:Label runat="server" ID="lbPotencia"></asp:Label>
                            </asp:Panel>

                            <div>
                                <asp:Panel runat="server" ID="pnAddProg" Visible="false">
                                    <label>Nome:</label>
                                    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" MaxLength="10"/>
                                    <label>Instrução:</label>
                                    <asp:TextBox runat="server" ID="txtIntru" CssClass="form-control" MaxLength="20" />
                                    <label>Tempo:</label>
                                    <asp:TextBox runat="server" ID="txtTempoA" CssClass="form-control" MaxLength="3"/>
                                    <label>Potência:</label>
                                    <asp:TextBox runat="server" ID="txtPotenciaA" CssClass="form-control" MaxLength="3"/>
                                    <label>Símbolo:</label>
                                    <asp:TextBox runat="server" ID="txtCaracter" CssClass="form-control" MaxLength="2"/>

                                    <asp:Button runat="server" ID="btnAddProg" Text="ADD" OnClick="btnAddProg_Click"/>
                                </asp:Panel>
                            </div>
                            
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Tempo:</label>
                                <asp:TextBox runat="server" ID="txtTempo" MaxLength="3" Width="60px" CssClass="form-control"></asp:TextBox>
                                <%--<label style="margin-left: 70px; margin-top: 1px">Segundos</label>--%>
                            </div>

                            <div class="form-group">
                                <label>Potência:</label>
                                <asp:TextBox runat="server" ID="txtPotencia" MaxLength="2" Width="50px" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <asp:Timer runat="server" ID="Timer1" Interval="1000" Enabled="false" OnTick="Timer1_Tick" />
                        <br />
                                               

                    </div>
                </div>
            </div>
            <asp:Button ID="btnLigar" Text="Ligar" runat="server" CssClass="btn btn-success" OnClick="btnLigar_Click"/>

            <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CssClass="btn btn-success" OnClick="btnCancelar_Click"/>

            <asp:Button ID="btnAquecer" Text="30seg" runat="server" CssClass="btn btn-success" OnClick="btnAquecer_Click"/>

            <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="btn btn-success" OnClick="btnReset_Click"/>

            <div>
                <asp:Label ID="lbAquecendo" runat="server" Font-Bold="true" Font-Size="30px" ClientIDMode="Static"></asp:Label>
            </div>

            <asp:Panel runat="server" ID="pnFinal" Visible="false">
                <div class="alert alert-success">
                    <asp:Label ID="lbFim" runat="server"></asp:Label>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnMessage" runat="server" Visible="false">
                <div class="alert alert-warning">
                    <asp:Label ID="message" runat="server"></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

