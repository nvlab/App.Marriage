﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Marriage.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SOKNAEntities : DbContext
    {
        public SOKNAEntities()
            : base("name=SOKNAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ChatRoomMessage> ChatRoomMessage { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Enums> Enums { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Permissons> Permissons { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonHiddenFlds> PersonHiddenFlds { get; set; }
        public virtual DbSet<QuestionBank> QuestionBank { get; set; }
        public virtual DbSet<RegisterRequests> RegisterRequests { get; set; }
        public virtual DbSet<RelationRequest> RelationRequest { get; set; }
        public virtual DbSet<RequestQuestionSenario> RequestQuestionSenario { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
