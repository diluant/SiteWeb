<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html>

<link href="Styles.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css"> #form { width: 1470px; height: 867px; } </style>
</head>
<body>
    <form id="form" runat="server">

        <div class="blended_grid">

            <div class="header">
            </div> <!-- Header -->

            <div class="aside">
                <div>
                    <div>
                        <ul>
                            <li>
                                    <asp:Label ID="lblTitre" runat="server" Text="Titre : "></asp:Label><br />
                                    <asp:TextBox ID="txtTitre" runat="server"></asp:TextBox>
                            </li>
                            <li>
                                    <asp:Label ID="lblAuteur" runat="server" Text="Auteur : "></asp:Label><br />
                                    <asp:RadioButtonList ID="grChoixAuteur" runat="server">
                                        <asp:ListItem>Goscinny et Uderzo</asp:ListItem>
                                        <asp:ListItem>Uderzo</asp:ListItem>
                                        <asp:ListItem>Autre</asp:ListItem>
                                    </asp:RadioButtonList>
                            </li>
                            <li>
                                    <asp:Label ID="lblParution" runat="server" Text="Parution : "></asp:Label><br />
                                    <asp:TextBox ID="txtParution" runat="server"></asp:TextBox>
                            </li>
                            <li>
                                    <asp:Label ID="lblNbPages" runat="server" Text="Nombre de pages : "></asp:Label><br />
                                    <asp:TextBox ID="txtNbPages" runat="server"></asp:TextBox>
                            </li>
                            <li>
                                    <asp:Label ID="lblCote" runat="server" Text="Cote : "></asp:Label><br />
                                    <asp:TextBox ID="txtCote" runat="server"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                </div>

                <div>
                    <ul style="width: 129px">
                        <li>
                            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" Width="127px" OnClick="btnAjouter_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnModifier" runat="server" Text="Modifier" Width="127px" />
                        </li>
                        <li>
                            <asp:Button ID="btnRetirer" runat="server" Text="Retirer" Width="127px" OnClick="btnRetirer_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" Width="127px" OnClick="btnRechercher_Click" />
                        </li>
                    </ul>
                </div>
            </div> <!-- Aside -->

            <div class="main">

                <asp:ListBox ID="ListeAlbums" runat="server" Height="308px" Width="575px"></asp:ListBox>
                <asp:RadioButtonList ID="grChoixTri" runat="server">
                    <asp:ListItem>Lister par numéro d&#39;album</asp:ListItem>
                    <asp:ListItem>Lister par date de parution</asp:ListItem>
                </asp:RadioButtonList>
            </div> <!-- Main -->

            <div class="footer">

            </div> <!-- Footer -->
        </div>
    </form>
</body>
</html>
