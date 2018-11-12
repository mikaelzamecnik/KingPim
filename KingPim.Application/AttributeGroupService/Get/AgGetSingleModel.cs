using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeGroupService.Get
{
    public class AgGetSingleModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SingleAttribute> SingleAttribute { get; set; }
    }

}