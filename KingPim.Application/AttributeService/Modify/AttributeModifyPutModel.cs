using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeService.Modify
{
    public class AttributeModifyPutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public bool publishedStatus {get;set;}
    }
}