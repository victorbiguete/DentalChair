using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Infrastructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_CHAIR, "Create table to save the Chair's information")]
    public class Version000001 : VersionBase
    {
        private const string CHAIRS_TABLE_NAME = "DentalChairs";
        public override void Up()
        {
            CreateTable(CHAIRS_TABLE_NAME)
                .WithColumn("ChairNumber").AsString(50).NotNullable()
                .WithColumn("Description").AsString(500).NotNullable()
                .WithColumn("Model").AsString(100).NotNullable()
                .WithColumn("PurchaseDate").AsDateTime().NotNullable()
                .WithColumn("LastMaintenance").AsDateTime().NotNullable()
                .WithColumn("UsageCount").AsInt32().NotNullable().WithDefaultValue(0); 
        }
    }
}
