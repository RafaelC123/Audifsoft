using Audisoft.Models;
using Audisoft.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Data.Context.Extension
{
    public static class ModelBuilderExtension
    {
        /// <summary>
        /// Configuración de entidades para EntitiFramework
        /// </summary>
        public static ModelBuilder ConfigureEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Notes", "Administration");
                BasicConfigurationEntity(entity);

                entity.HasOne(e => e.Student).WithMany(e => e.Notes)
                .HasPrincipalKey(x => x.Id).HasForeignKey(x => x.StudentId);

                entity.HasOne(e => e.Teacher).WithMany(e => e.Notes)
                .HasPrincipalKey(x => x.Id).HasForeignKey(x => x.TeacherId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students", "Administration");
                BasicConfigurationEntity(entity);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers", "Administration");
                BasicConfigurationEntity(entity);
            });

            
            return modelBuilder;
        }




        /// <summary>
        /// Configuracion basica para todas las entidades
        /// </summary>
        private static EntityTypeBuilder<T> BasicConfigurationEntity<T>(this EntityTypeBuilder<T> entity) where T : GenericModel
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnType("NUMERIC(20,0)");
            return entity;
        }
    }
}
