﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspApp_VenteVetements.Models
{
    public class Utilisateur
    {
        public int id { get; set; }
        public int statutId { get; set; }

        [DisplayName("Nom complet")]
        
        public string nom { get; set; }

        [DisplayName("Adresse Email")]
        [DataType(DataType.EmailAddress)]
        public string adresseMail { get; set; }

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string motDePasse { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual Statut Statut { get; set; }

    }
}