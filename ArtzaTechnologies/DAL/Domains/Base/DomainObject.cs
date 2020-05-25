namespace ArtzaTechnologies.DAL.Domains.Base
{
    /// <summary>
    /// Class de base de domaines.
    /// </summary>
    public abstract class DomainObject
    {
        /// <summary>
        /// Identifiant BD de l'objet.
        /// </summary>
        public virtual int Id { get; set; }
    }
}
