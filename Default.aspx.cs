using System;
using System.Data.OleDb;
using System.Data;

public partial class _Default:System.Web.UI.Page
{
    /*static private void CreateOleDbCommand(string queryString, string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand(queryString, connection);
            command.ExecuteNonQuery();
        }
    }*/

    BaseDonnées m_db = BaseDonnées.Instance;
    Album m_album;
    int m_indiceTri = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //InitialiserChamps();
        Lister(SqlLister);
    }

    const string chaîneConnexion = "Provider=Microsoft.ACE.OLEDB.12.0;" + 
                                  @"Data Source=E:\Documents\Dev\Programmation II\WebSite\Astérix.accdb";
    const string SqlLister = "SELECT * " +
                             "FROM albums ";

    public string AuteurEnTexte(int p_indice)
    {
        switch (p_indice)
        {
            case 0: return "Goscinny et Uderzo";
            case 1: return "Uderzo";
            default: return "Autre";
        }
    }

    public bool ChampsValides()
    {


        return true;
    }

    

    public void Lister(string p_requête)
    {
        // ListeAlbums.Items.Clear();

        switch (grChoixTri.SelectedIndex)
        {
            case 0: p_requête += "ORDER BY numéro"; break;
            case 1: p_requête += "ORDER BY année_parution, titre"; break;
        }

        using (OleDbConnection connexion = new OleDbConnection(chaîneConnexion))
        {
            try
            {
                DataTable table;
                using (OleDbCommand commande = new OleDbCommand(
                    "SELECT * " +
                    "FROM albums ", connexion))
                {
                    commande.CommandType = CommandType.Text;
                    connexion.Open();
                    using (OleDbDataReader reader = commande.ExecuteReader())
                    {
                        
                        //while (reader.Read())
                        //{

                        //    ListeAlbums.Items.Add(String.Format("{0, 7} {1, 50} {2, 30} {3, 8} {4} {5}",
                        //        reader["numéro"].ToString(), reader["titre"].ToString(),
                        //        AuteurEnTexte((int)reader["auteur"]), reader["année_parution"].ToString(),
                        //        reader["nb_pages"].ToString(), reader["cote"].ToString()));
                        //}
                        OleDbDataAdapter adapter = new OleDbDataAdapter(commande);
                        table = new DataTable();
                        adapter.Fill(table);

                        ListeAlbums.DataSource = reader;
                        ListeAlbums.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                // Message d'erreur
            }

        } 
    }

    public void InitialiserChamps()
    {
        txtTitre.Text = "";
        grChoixAuteur.SelectedIndex = 0;
        grChoixTri.SelectedIndex = m_indiceTri;
        txtParution.Text = "";
        txtNbPages.Text = "";
        txtCote.Text = "";
    }

    protected void btnAjouter_Click(object sender, EventArgs e)
    {
        // OleDbCommand http://www.mikesdotnetting.com/article/26/parameter-queries-in-asp-net-with-ms-access
        if (ChampsValides())
            m_db.AjouterAlbum(m_album);
        // implémenter msg erreur
    }

    protected void btnRechercher_Click(object sender, EventArgs e)
    {
        Lister(SqlLister);
    }

    protected void grChoixTri_SelectedIndexChanged(object sender, EventArgs e)
    {
        m_indiceTri = grChoixTri.SelectedIndex;
    }

    public Album Extraire()
    {
        return m_album;
    }

    protected void btnRetirer_Click(object sender, EventArgs e)
    {
        m_db.RetirerAlbum(1);
    }
}