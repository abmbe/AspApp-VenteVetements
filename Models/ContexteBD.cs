﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AspApp_VenteVetements.Models
{
    public class ContexteBD : DbContext
    {
        public virtual DbSet<Statut> Statuts { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Vetement> Vetements { get; set; }
        public virtual DbSet<VetementCommande> VetementCommandes { get; set; }

        protected override void OnModelCreating(DbModelBuilder createurModeles)
        {
            createurModeles.Entity<Statut>()
            .HasKey(s => s.id)
            .Property(s => s.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            createurModeles.Entity<Statut>()
            .HasMany(s => s.Utilisateurs)
            .WithRequired(u => u.Statut)
            .HasForeignKey(c => c.statutId);


            createurModeles.Entity<Utilisateur>()
                .HasKey(u => u.id)
                .Property(u => u.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            createurModeles.Entity<Utilisateur>()
            .HasMany(u => u.Commandes)
            .WithRequired(c => c.Utilisateur)
            .HasForeignKey(c => c.utilisateurId);

            createurModeles.Entity<Utilisateur>()
                .Property(u => u.nom)
                .IsRequired()
                .HasMaxLength(150);

            createurModeles.Entity<Utilisateur>()
              .Property(u => u.motDePasse)
              .IsRequired()
              .HasMaxLength(150);

            createurModeles.Entity<Utilisateur>()
              .Property(u => u.adresseMail)
              .IsRequired()
              .HasMaxLength(100);

            createurModeles.Entity<Commande>()
                .HasKey(c => c.id)
                .Property(c => c.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            createurModeles.Entity<Commande>()
            .HasMany(c => c.VetementCommandes)
            .WithRequired(vc => vc.Commande)
            .HasForeignKey(vc => vc.commandeId);

            createurModeles.Entity<Vetement>()
                .HasKey(v => v.id)
                .Property(v => v.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            createurModeles.Entity<Vetement>()
             .HasMany(v => v.VetementCommandes)
             .WithRequired(vc => vc.Vetement)
             .HasForeignKey(vc => vc.vetementId);

            createurModeles.Entity<VetementCommande>()
                .HasKey(vc => vc.id)
                .Property(vc => vc.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(createurModeles);
        }
    }
}