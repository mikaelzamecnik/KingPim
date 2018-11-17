using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public class AgModifyPutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool publishedStatus {get;set;}
        public List<SingleAttribute> SingleAttribute { get; set; }
    }
}