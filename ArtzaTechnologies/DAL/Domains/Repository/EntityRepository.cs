using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.DAL.Domains.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtzaTechnologies.DAL.Domains.Repository
{
    /// <summary>
    /// Définition de la repository abstraite de entityframework.
    /// </summary>
    /// <typeparam name="T"> le type du domaine bd.</typeparam>
    public class EntityRepository<T> where T : DomainObject
    {
        /// <summary>
        /// Le context bd de l'application.
        /// </summary>
        protected AppDomainContext AppDomainContext { get; private set; }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="appDomainContext"> le context entity framework de l'application. </param>
        public EntityRepository(AppDomainContext appDomainContext)
        {
            AppDomainContext = appDomainContext;
        }

        /// <summary>
        /// Permet de récupérer l'ensemble des entités.
        /// </summary>
        /// <returns> Une collection d'objets du domain db.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            var enumerable = AppDomainContext.GetDbSetFor<T>().AsEnumerable();

            return enumerable;
        }

        /// <summary>
        /// Permet de récupérer un objet du domain par son id en bd.
        /// </summary>
        /// <param name="id"> L'identifiant de l'objet.</param>
        /// <returns> La valeur du domain.</returns>
        public virtual T GetById(int id)
        {
            var dbSet = AppDomainContext.GetDbSetFor<T>();

            return dbSet.SingleOrDefault(n => n.Id == id);

        }

        /// <summary>
        /// Permet de créer un nouveau objet en bd.
        /// </summary>
        /// <param name="domain"> L'objet créé depuis le context.</param>
        /// <returns> Le nouveau objet <see cref="{T}"/> </returns>
        public virtual T Create(T domain)
        {
            var dbSet = AppDomainContext.GetDbSetFor<T>();

            if (!dbSet.All(x => x.Id == domain.Id))
            {
                var entry = dbSet.Add(domain);

                entry.Context.SaveChanges();

                return entry.Entity;
            }

            return null;
        }

        /// <summary>
        /// Met à jour une donnée en bd.
        /// </summary>
        /// <param name="domain"> L'objet à mettre à jour.</param>
        /// <returns> L'objet <see cref="{T}"/> mis à jour.</returns>
        public virtual T Update(T domain)
        {
            var dbSet = AppDomainContext.GetDbSetFor<T>();

            if (dbSet != null)
            {
                var entry = dbSet.Update(domain);

                entry.Context.SaveChanges();

                return entry.Entity;
            }

            return null;
        }

        /// <summary>
        /// Supprime un élement domain de la base de données.
        /// </summary>
        /// <param name="domain"> L'objet à mettre à supprimer.</param>
        /// <returns> True si la suppression à réussie, false sinon.</returns>
        public virtual bool Delete(T domain)
        {
            var dbSet = AppDomainContext.GetDbSetFor<T>();

            if (dbSet != null && dbSet.Any(x => x.Id == domain.Id))
            {
                var entry = dbSet.Remove(domain);

                return entry.Context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
