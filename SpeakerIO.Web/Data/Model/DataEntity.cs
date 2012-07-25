using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects;

namespace SpeakerIO.Web.Data.Model
{
    public abstract class DataEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as DataEntity<TKey>;

            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            bool typesMatch = GetUnproxiedType() == other.GetUnproxiedType();

            bool idsMatch = PersistentAndSame(other);

            return typesMatch && idsMatch;
        }

        public override int GetHashCode()
        {
            // ReSharper disable BaseObjectGetHashCodeCallInGetHashCode
            // http://msdn.microsoft.com/en-us/library/system.object.gethashcode(v=VS.110).aspx
            if (IsTransient()) return base.GetHashCode();
            // ReSharper restore BaseObjectGetHashCodeCallInGetHashCode
            unchecked
            {
                return (GetUnproxiedType().GetHashCode()*31) ^ Id.GetHashCode();
            }
        }

        public static bool operator ==(DataEntity<TKey> left, DataEntity<TKey> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DataEntity<TKey> left, DataEntity<TKey> right)
        {
            return !Equals(left, right);
        }

        bool PersistentAndSame(DataEntity<TKey> compareTo)
        {
            return (!Id.Equals(default(TKey))) &&
                   (!compareTo.Id.Equals(default(TKey))) && Id.Equals(compareTo.Id);
        }

        bool IsTransient()
        {
            return Equals(Id, default(TKey));
        }

        public Type GetUnproxiedType()
        {
            return ObjectContext.GetObjectType(GetType());
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", GetUnproxiedType().Name, Id);
        }
    }
}