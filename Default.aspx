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
                            <asp:Button ID="btnRetirer" runat="server" Text="Retirer" Width="127px" OnClick="btnSupprimer_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" Width="127px" OnClick="btnRechercher_Click" />
                        </li>
                    </ul>
                </div>
            </div> <!-- Aside -->

            <div class="main">
                <asp:DataList ID="ListeAlbums" runat="server" BorderStyle="Groove" GridLines="Both" RepeatColumns="6" BackColor="White" DataKeyField="numéro" DataSourceID="SqlDataSource" Height="300px" Width="600px" RepeatDirection="Horizontal" >
                    <ItemTemplate>
                        numéro:
                        <asp:Label ID="numéroLabel" runat="server" Text='<%# Eval("numéro") %>' />
                        <br />
                        titre:
                        <asp:Label ID="titreLabel" runat="server" Text='<%# Eval("titre") %>' />
                        <br />
                        auteur:
                        <asp:Label ID="auteurLabel" runat="server" Text='<%# Eval("auteur") %>' />
                        <br />
                        année_parution:
                        <asp:Label ID="année_parutionLabel" runat="server" Text='<%# Eval("année_parution") %>' />
                        <br />
                        nb_pages:
                        <asp:Label ID="nb_pagesLabel" runat="server" Text='<%# Eval("nb_pages") %>' />
                        <br />
                        cote:
                        <asp:Label ID="coteLabel" runat="server" Text='<%# Eval("cote") %>' />
                        <br />
<br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:RadioButtonList ID="grChoixTri" runat="server" AutoPostBack="True" OnSelectedIndexChanged="grChoixTri_SelectedIndexChanged">
                    <asp:ListItem>Tri par numéro d&#39;album</asp:ListItem>
                    <asp:ListItem>Tri par date de parution</asp:ListItem>
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [numéro], [titre], [auteur], [année_parution], [nb_pages], [cote] FROM [albums]"></asp:SqlDataSource>
            </div> <!-- Main -->

            <div class="footer">

            </div> <!-- Footer -->
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
