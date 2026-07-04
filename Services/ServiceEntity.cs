using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Services
{
    public class ServiceEntity : IEntity
    {
        public ServiceEntity()
        {
            Id = Guid.NewGuid();
        }

        // ID entero usado por SQL Server. Se mantiene separado del Guid de IEntity.
        public int ID { get; set; }

        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ServiceEntity)) return false;
            return Id.Equals(((ServiceEntity)obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
