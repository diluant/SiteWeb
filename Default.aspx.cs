using System;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Web;

public partial class _Default:System.Web.UI.Page
{
    BaseDonnées m_db = BaseDonnées.Instance;
    Album m_album;

    protected void Page_Load(object sender, EventArgs e)
    {
        //InitialiserChamps();
        List<Album> albums = new List<Album>(m_db.TousLesAlbums(grChoixTri.SelectedIndex));
        Lister();
        
    }

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
        string titre = txtTitre.Text;

        if (titre.Length > 50)
        {
            Response.Write("Le titre est trop long : 50 caractères maximum.");
            return false;
        }

        int parution = Convert.ToInt32(txtParution.Text);

        if (1961 > parution || parution > DateTime.Now.Year)
        {
            Response.Write("L'année doit être comprise entre 2 et 100 et doit être paire.");
            return false;
        }

        int nbPages = Convert.ToInt32(txtNbPages.Text);

        if (2 > nbPages || nbPages > 100 || nbPages % 2 != 0)
        {
            Response.Write("Le nombre de pages doit être compris entre 2 et 100 et doit être paire.");
            return false;
        }

        double cote = Convert.ToDouble(txtCote.Text);

        if (0 > cote || cote > 10)
        {
            Response.Write("La cote doit être comprise entre 0 et 10.");
            return false;
        }

        Auteur auteur = (Auteur)grChoixAuteur.SelectedIndex;

        m_album = new Album(m_db.GénérerProchainNuméro(), titre, parution, nbPages, cote, auteur);
        return true;
    }

    public void InitialiserChamps()
    {
        txtTitre.Text = "";
        grChoixAuteur.SelectedIndex = 0;
        txtParution.Text = "";
        txtNbPages.Text = "";
        txtCote.Text = "";
    }

    public void Lister()
    {
        DataList1.DataSource = m_db.TousLesAlbums(grChoixTri.SelectedIndex);
        DataList1.DataBind();
        DataList1.Visible = true;
        foreach (Album album in m_db.TousLesAlbums(grChoixTri.SelectedIndex))
        {
            string txt = String.Format("{0}\t{1, 50} {2, 30} {3, 15} {4} {5}",
                album.Numéro, album.Titre, UtilAuteur.EnTexte(album.Auteur), album.AnnéeParution, album.NombrePages, album.Cote);
        }
    }

    public string Espaces()
    {
        return "";
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

    }

    protected void grChoixTri_SelectedIndexChanged(object sender, EventArgs e)
    {

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