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
        string connection = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=E:\Documents\Dev\Programmation II\WebSite\Astérix.accdb";

        try
        {
            m_db = new OleDbConnection(connection);
            m_db.Open();
        }
        catch
        {
            // implementer popup d'erreur
        }

    }

    

    static BaseDonnées m_base = new BaseDonnées();

    public static BaseDonnées Instance
    {
        get { return m_base; }
    }

    public void AjouterAlbum(Album p_album)
    {
        using (m_db)
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
        using (m_db)
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
        using (m_db)
        {
            try
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
            catch (Exception)
            {
                // Message d'erreur
            }
        }  
    }

    public int GénérerProchainNuméro()
    {
        OleDbCommand commande = new OleDbCommand(
            "SELECT valeurCompteur" +
            "FROM Compteurs " +
            "WHERE nomCompteur = numéroProchainAlbum", m_db);

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
}