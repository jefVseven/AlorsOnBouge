﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MetiersPortable
{
    /// <summary>
    /// Subject défini par son ID, contenu, titre, date et auteur
    /// Subject fait partie d'une Rubric
    /// </summary>
    [DataContract]
    public class Subject
    {
        [DataMember]
        private int _Id;
        /// <summary>
        /// Identifiant du sujet
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        [DataMember]
        private string _Titre;
        /// <summary>
        /// Titre du sujet
        /// </summary>
        public string Titre
        {
            get { return _Titre; }
            set { _Titre = value; }
        }

        [DataMember]
        private string _Desc;
        /// <summary>
        /// Description du sujet
        /// </summary>
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        [DataMember]
        private DateTime _Date;
        /// <summary>
        /// Date de création du sujet
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        [DataMember]
        private List<Post> _Posts;
        /// <summary>
        /// La liste de reponse, concernant un sujet
        /// </summary>
        public List<Post> Posts
        {
            get { return _Posts; }
            set { _Posts = value; }
        }

        [DataMember]
        private Rubric _Rubric;
        /// <summary>
        /// Identifiant de la rubrique
        /// </summary>
        public Rubric Rubric
        {
            get { return _Rubric; }
            set { _Rubric = value; }
        }

        [DataMember]
        private Utilisateur _Utilisateur;
        /// <summary>
        /// L'utilisateur qui a créé et posté le post
        /// </summary>
        public Utilisateur Utilisateur
        {
            get { return _Utilisateur; }
            set { _Utilisateur = value; }
        }

        [DataMember]
        private string _Auteur;
        /// <summary>
        /// Auteur du Post
        /// </summary>
        public string Auteur
        {
            get { return _Auteur; }
            set { _Auteur = value; }
        }

        #region "Constructeurs"

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Subject() { }

        /// <summary>
        /// Constructeur d'un nouveau sujet
        /// </summary>
        /// <param name="id">Identifiant du sujet</param>
        /// <param name="title">Titre du sujet</param>
        /// <param name="description">Description du sujet</param>
        /// <param name="rubric">Identifiant de la rubrique</param>
        public Subject(int id, string title, string description, Rubric rubric)
        {
            this.Id = id;
            this.Titre = title;
            this.Desc = description;
            this.Rubric = rubric;
            this.Posts = new List<Post>();
            this.Date = DateTime.Now;
        }

        /// <summary>
        /// Constructeur d'un sujet, avec des posts en réponse, on fait appel au constructeur du sujet sans réponse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="description"></param>
        /// <param name="rubric"></param>
        /// <param name="Posts"></param>
        public Subject(int id, string titre, string description, Rubric rubric, List<Post> Posts) : this(id, titre, description, rubric)
        {
            this.Posts = Posts;
        }

        /// <summary>
        /// constructeur construit pour l'ajout de l'auteur et de la date du sujet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="utilisateur"></param>
        /// <param name="rubric"></param>
        public Subject(int id, string titre, string description, DateTime date, Utilisateur utilisateur, Rubric rubric) : this(id, titre, description, rubric)
        {
            this.Date = date;
            this.Utilisateur = utilisateur;
            this.Auteur = utilisateur.Username;
        }

        #endregion

        #region "Methodes"

        /// <summary>
        /// Méthode permettant de connaître l'username du redacteur du sujet
        /// </summary>
        /// <returns>Username</returns>
        public string GetUsername()
        {
            return Utilisateur.Username;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals (object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())

            {
                return false;
            }

            Subject suj = (Subject)obj;

            return Id == suj.Id;

        }

        #endregion
    }
}
