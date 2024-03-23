//path: src\SchemaGen\ModelBuilderExtensions.cs

using Microsoft.EntityFrameworkCore;

namespace SouthSeas.SchemaGen
{
    public static class ModelBuilderExtensions
    {
        public static void GenFloat<T>(this ModelBuilder builder, string prop, float val) where T : class
            => builder.Entity<T>()
                .Property(prop)
                .HasDefaultValue(val);

        public static void GenFloat3<T>(this ModelBuilder builder, string prop, float[] val) where T : class
            => builder.Entity<T>()
                .Property(prop)
                .HasDefaultValue(val);

        public static void GenString<T>(this ModelBuilder builder, string prop, string val) where T : class
            => builder.Entity<T>()
                .Property(prop)
                .HasDefaultValue(val);
    }
}
