using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for BaseDonnées
/// </summary>
public class BaseDonnées
{
    OleDbConnection m_db;
    private BaseDonnées()
    {
        //string connection = "Provider=Microsoft.ACE.OLEDB.12.0;" +
           // @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb";

        //try
        //{
        //    m_db = new OleDbConnection(connection);
        //}
        //catch
        //{
        //    Environment.Exit(0);
        //}
    }

    

    static BaseDonnées m_base = new BaseDonnées();

    public static BaseDonnées Instance
    {
        get { return m_base; }
    }

    public void AjouterAlbum(Album p_album)
    {
        using (m_db = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb"))
        {
            try
            {
                using (OleDbCommand commande = new OleDbCommand(
                    "INSERT INTO albums (numéro, titre, auteur, année_parution, nb_pages, cote) " +
                    "VALUE(?,?,?,?,?,?)", m_db))
                {
                    commande.CommandType = CommandType.Text;
                    commande.Parameters.AddWithValue("numéro", GénérerProchainNuméro());
                    commande.Parameters.AddWithValue("titre", p_album.Titre);
                    commande.Parameters.AddWithValue("auteur", p_album.Auteur);
                    commande.Parameters.AddWithValue("année_parution", p_album.AnnéeParution);
                    commande.Parameters.AddWithValue("nb_pages", p_album.NombrePages);
                    commande.Parameters.AddWithValue("cote", p_album.Cote);
                    m_db.Open();
                    commande.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                // Message d'erreur
            }
        }  
    }

    public void ModifierAlbum(Album p_album)
    {
        using (OleDbConnection connexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb"))
        {
            try
            {
                using (OleDbCommand commande = new OleDbCommand(String.Format(
                    "UPDATE albums " +
                    "SET numéro=?, titre=?, année_parution=?,  nb_pages=?, " +
                    "    cote=?, auteur=? " +
                    "WHERE numéro=?", p_album.Numéro), m_db))
                {
                    commande.CommandType = CommandType.Text;
                    commande.Parameters.AddWithValue("numéro", p_album.Numéro);
                    commande.Parameters.AddWithValue("titre", p_album.Titre);
                    commande.Parameters.AddWithValue("année_parution", p_album.AnnéeParution);
                    commande.Parameters.AddWithValue("nb_pages", p_album.NombrePages);
                    commande.Parameters.AddWithValue("cote", p_album.Cote);
                    commande.Parameters.AddWithValue("auteur", p_album.Auteur);
                    m_db.Open();
                    commande.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                // Message d'erreur
            }
        }  
    }

    public void RetirerAlbum(int p_numéro)
    {
        using (m_db = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb"))
        {
            using (OleDbCommand commande = new OleDbCommand(String.Format(
                "DELETE FROM albums " +
                "WHERE numéro=?", p_numéro), m_db))
            {
                commande.CommandType = CommandType.Text;
                m_db.Open();
                commande.ExecuteNonQuery();
            }
        }  
    }

    public IEnumerable<Album> TousLesAlbums(int p_indice)
    {
        // ListeAlbums.Items.Clear();
        string ordre = "";
        switch (p_indice)
        {
            case 0: ordre += "ORDER BY numéro"; break;
            case 1: ordre += "ORDER BY année_parution, titre"; break;
        }

        using (m_db = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb"))
        {
            using (OleDbCommand commande = new OleDbCommand(
                "SELECT numéro, titre, année_parution, nb_pages, cote, auteur " +
                "FROM albums " + ordre, m_db))
            {
                commande.CommandType = CommandType.Text;
                m_db.Open();
                using (OleDbDataReader bdr = commande.ExecuteReader())
                {
                    while (bdr.Read())
                    {
                        Album album = new Album((int)bdr["numéro"], bdr["titre"].ToString(),
                                                (int)bdr["année_parution"], (int)bdr["nb_pages"],
                                                (double)bdr["cote"], (Auteur)bdr["auteur"]);
                        yield return album;
                    }
                }
            }
        } 
    }

    public int GénérerProchainNuméro()
    {
        m_db = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=M:\Programmation 2\SiteWeb\Astérix.accdb");
           
        OleDbCommand commande = new OleDbCommand(
            "SELECT valeurCompteur " +
            "FROM Compteurs " +
            "WHERE nomCompteur = 'numéroProchainAlbum'", m_db);

        commande.CommandType = CommandType.Text;
        m_db.Open();
        OleDbDataReader reader = commande.ExecuteReader();
        int cpt = (int)reader["valeurCompteur"];

        commande = new OleDbCommand(String.Format(
            "UPDATE Compteur (valeurCompteur)" +
            "SET valeurCompteur=? " +
            "WHERE nomCompteur = numéroProchainAlbum", ++cpt), m_db);

        commande.ExecuteNonQuery();

        return --cpt;
    }

    //public void Fermer()
    //{
    //    m_bd.Close(); 
    //}
}