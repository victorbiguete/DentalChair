using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Infrastructure.Migration.Versions
{
    [Migration(DatabaseVersions.TABLE_ALLOCATION,"Create table to save the Allocation information")]
    public class Version000002 : VersionBase
    {
        private const string ALLOCATION_TABLE_NAME = "Allocations";
        private const string CHAIRS_TABLE_NAME = "DentalChairs";

        public override void Up()
        {
            Create.Table(ALLOCATION_TABLE_NAME)
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("DentalChairId").AsInt64().NotNullable()
            .WithColumn("PatientName").AsString(200).NotNullable()
            .WithColumn("ProcedureType").AsString(100).Nullable()
            .WithColumn("StartDate").AsDateTime().NotNullable()
            .WithColumn("EndDate").AsDateTime().NotNullable()
            .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(1)
            .WithColumn("Notes").AsString(1000).Nullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("UpdatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);

            // Foreign Key
            Create.ForeignKey("FK_Allocations_Chairs")
                .FromTable(ALLOCATION_TABLE_NAME).ForeignColumn("DentalChairId")
                .ToTable(CHAIRS_TABLE_NAME).PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}
