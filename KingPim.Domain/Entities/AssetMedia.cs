using System;
using System.Collections.Generic;


namespace KingPim.Domain.Entities
{
    public class AssetMedia
    {
        public int Id { get; set; }
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}
        public string AltTextName { get; set; }
        public bool SetPrimary { get; set; }
        public string FilePath { get; set; }
        public int MediaTypeId { get; set; }
        public virtual AssetType AssetType {get;set;}
    }
}