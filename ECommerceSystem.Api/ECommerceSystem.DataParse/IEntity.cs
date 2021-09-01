using System;

namespace ECommerceSystem.DataParse
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
