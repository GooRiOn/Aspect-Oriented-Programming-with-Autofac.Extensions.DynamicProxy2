using System.ComponentModel.DataAnnotations;

namespace AOP.Database
{
    public class ItemEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quiantity { get; set; }

        public bool IsDeleted { get; set; }

        public ItemEntity()
        {
            IsDeleted = false;
        }
    }
}