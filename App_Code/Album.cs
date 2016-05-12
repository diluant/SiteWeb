using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Les différents auteurs disponible pour les albums.
/// </summary>
public enum Auteur
{
    GoscinnyEtUderzo, Uderzo, Autre
}

/// <summary>
/// Utilitaire pour mettre en texte les différents auteurs.
/// </summary>
public static class UtilAuteur
{
    public static string EnTexte(this Auteur p_catégorie)
    {
        string texte;

        switch (p_catégorie)
        {
            case Auteur.GoscinnyEtUderzo: texte = "Goscinny et Uderzo"; break;
            case Auteur.Uderzo: texte = "Uderzo"; break;
            default: texte = "Autre"; break;
        }

        return texte;
    }
}

/// <summary>
///
/// </summary>
public class Album
{
    /// <summary>
    /// Construit un objet de type album d'après les données qui le constitue.
    /// </summary>
    /// <param name="p_numéro">Le numéro de l'album.</param>
    /// <param name="p_titre">Le titre de l'album.</param>
    /// <param name="p_annéeParution">L'année de parution de l'album.</param>
    /// <param name="p_nombrePages">Le nombre de pages de l'album.</param>
    /// <param name="p_cote">Une cote d'apréciation ce l'album.</param>
    /// <param name="p_auteur">Le(s) auteur(s) de l'album.</param>
    public Album(int p_numéro, string p_titre, int p_annéeParution, int p_nombrePages, double? p_cote,
                    Auteur p_auteur, string p_autreAuteur)
    {
        if (p_numéro < 1)
            throw new ArgumentOutOfRangeException("p_numéro", "Doit être >= 1");

        if (String.IsNullOrEmpty(p_titre))
            throw new ArgumentException("Ne doit pas être null ni vide", "p_titre");

        Numéro = p_numéro;
        Titre = p_titre;
        AnnéeParution = p_annéeParution;
        NombrePages = p_nombrePages;
        Cote = p_cote;
        Auteur = p_auteur;
    }

    /// <summary>
    /// Le numéro de l'album; servira de clé.
    /// </summary>
    public int Numéro { get; private set; }

    /// <summary>
    /// Le titre de l'album; servira de clé ne pourra être dupliqué.
    /// </summary>
    public string Titre { get; private set; }

    /// <summary>
    /// L'année de parution de l'album; doit être supérieur ou égale à 1961.
    /// </summary>
    public int AnnéeParution { get; private set; }

    /// <summary>
    /// Le nombre de pages que contient l'album.
    /// </summary>
    public int NombrePages { get; private set; }

    /// <summary>
    /// La cote d'apréciation de l'album; n'est pas nécessaire mais une fois entrée elle ne peut pas être
    /// retirer, seulement modifiée.
    /// </summary>
    public double? Cote { get; private set; }

    /// <summary>
    /// Le ou les auteurs de l'album.
    /// </summary>
    public Auteur Auteur { get; private set; }

}