﻿using System;

namespace WarehouseApp
{
    public class Entity
    {
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
