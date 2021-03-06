﻿using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KingPim.Application.Repositories.Models
{
    public class AttributeOptionListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }

    }
}
