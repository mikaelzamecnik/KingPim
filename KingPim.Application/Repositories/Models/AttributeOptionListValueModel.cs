using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KingPim.Application.Repositories.Models
{
    public class AttributeOptionListValueModel
    {
        public int Id { get; set; }
        public string ListValue { get; set; }
        public int? AttributeOptionListId { get; set; }
        public virtual AttributeOptionList AttributeOptionList { get; set; }
    }
}
