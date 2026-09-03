using System;
using System.Collections.Generic;


namespace gnaDataClasses
{
    #region Captured DBTrackGeometry models

    public sealed class TrackPointEpochData
    {
        #region Identity and time

        public string SensorID { get; init; } = string.Empty;

        public string PointName { get; init; } = string.Empty;

        public string ReplacementName { get; init; } = string.Empty;

        public DateTime ReportUtc { get; init; }

        public bool IsMissing { get; init; }

        #endregion

        #region Reference coordinates

        public double? ReferenceE { get; init; }

        public double? ReferenceN { get; init; }

        public double? ReferenceH { get; init; }

        #endregion

        #region Current coordinates and rail level

        public double? CurrentE { get; init; }

        public double? CurrentN { get; init; }

        public double? CurrentH { get; init; }

        public double? CurrentToR { get; init; }

        #endregion

        #region Point geometry

        public double? Top { get; init; }

        public double? Slew { get; init; }

        public double? Versine { get; init; }

        #endregion
    }


    public sealed class TrackPairEpochData
    {
        #region Identity and time

        public int PrismPairNumber { get; init; }

        public int RailSectionNumber { get; init; }

        public int PairOrder { get; init; }

        public string TrackName { get; init; } = string.Empty;

        public string LeftSensorID { get; init; } = string.Empty;

        public string RightSensorID { get; init; } = string.Empty;

        public DateTime ReportUtc { get; init; }

        #endregion

        #region Database geometry values

        public double? Cant { get; init; }

        public double? ShortTwist { get; init; }

        public double? LongTwist { get; init; }

        #endregion

        #region Workbook ratios

        public double? WorkbookTwistRatio { get; init; }

        public double? WorkbookLongTwistRatio { get; init; }

        #endregion
    }


    public sealed class DBTrackGeometryCaptureResult
    {
        #region Constructor

        public DBTrackGeometryCaptureResult(
            DateTime reportUtc,
            List<TrackPointEpochData> pointEpochs,
            List<TrackPairEpochData> pairEpochs)
        {
            if (reportUtc.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException(
                    message: "The report timestamp must have DateTimeKind.Utc.",
                    paramName: nameof(reportUtc));
            }

            ReportUtc = reportUtc;

            PointEpochs = pointEpochs
                ?? throw new ArgumentNullException(
                    paramName: nameof(pointEpochs));

            PairEpochs = pairEpochs
                ?? throw new ArgumentNullException(
                    paramName: nameof(pairEpochs));
        }

        #endregion

        #region Properties

        public DateTime ReportUtc { get; }

        public List<TrackPointEpochData> PointEpochs { get; }

        public List<TrackPairEpochData> PairEpochs { get; }

        #endregion
    }

    #endregion


    #region Export context and configuration identities

    public sealed class DBTrackGeometryExportContext
    {
        public DBTrackGeometryExportContext(
            string databaseConnectionString,
            int projectId,
            string registryProjectName)
        {
            DatabaseConnectionString =
                string.IsNullOrWhiteSpace(databaseConnectionString)
                    ? throw new ArgumentException(
                        message: "The DBTrackGeometry connection string is required.",
                        paramName: nameof(databaseConnectionString))
                    : databaseConnectionString.Trim();

            if (projectId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(projectId),
                    message: "The Project_ID must be greater than zero.");
            }

            ProjectId = projectId;

            RegistryProjectName =
                string.IsNullOrWhiteSpace(registryProjectName)
                    ? throw new ArgumentException(
                        message: "The Registry project name is required.",
                        paramName: nameof(registryProjectName))
                    : registryProjectName.Trim();
        }

        public string DatabaseConnectionString { get; }

        public int ProjectId { get; }

        public string RegistryProjectName { get; }
    }


    public sealed class DBTrackGeometryProjectIdentity
    {
        public int ProjectId { get; init; }

        public string ProjectName { get; init; } = string.Empty;
    }


    public sealed class DBTrackGeometryPointIdentity
    {
        public int PointNameId { get; init; }

        public string PointName { get; init; } = string.Empty;

        public string ReplacementName { get; init; } = string.Empty;

        public bool IsDeleted { get; init; }
    }


    public sealed class DBTrackGeometryPairIdentity
    {
        public int PrismPairId { get; init; }

        public int TrackId { get; init; }

        public string TrackName { get; init; } = string.Empty;

        public int PairOrder { get; init; }

        public int LeftPointNameId { get; init; }

        public int RightPointNameId { get; init; }
    }


    public sealed class DBTrackGeometryArrayPointIdentity
    {
        public char PointRole { get; init; }

        public int PointNameId { get; init; }

        public string PointName { get; init; } = string.Empty;

        public string ReplacementName { get; init; } = string.Empty;

        public bool MembershipIsDeleted { get; init; }

        public bool PointIsDeleted { get; init; }
    }


    public sealed class DBTrackGeometryArrayIdentity
    {
        public int ArrayId { get; init; }

        public string ArrayName { get; init; } = string.Empty;

        public int ArrayTypeId { get; init; }

        public string ArrayTypeName { get; init; } = string.Empty;

        public List<DBTrackGeometryArrayPointIdentity> Points { get; init; } =
            new();
    }

    #endregion


    #region Resolved direct Epoch models

    public sealed class ResolvedTrackPointEpochData
    {
        public int PointNameId { get; init; }

        public string PointName { get; init; } = string.Empty;

        public string ReplacementName { get; init; } = string.Empty;

        public string SensorId { get; init; } = string.Empty;

        public DateTime ReportUtc { get; init; }

        public bool IsMissing { get; init; }

        public bool IsConfigurationDeleted { get; init; }

        public double? ReferenceE { get; init; }

        public double? ReferenceN { get; init; }

        public double? ReferenceH { get; init; }

        public double? CurrentE { get; init; }

        public double? CurrentN { get; init; }

        public double? CurrentH { get; init; }

        public double? CurrentToR { get; init; }

        public double? Top { get; init; }

        public double? Slew { get; init; }

        public double? Versine { get; init; }
    }


    public sealed class ResolvedTrackPairEpochData
    {
        public int PrismPairId { get; init; }

        public int TrackId { get; init; }

        public string TrackName { get; init; } = string.Empty;

        public int PairOrder { get; init; }

        public int LeftPointNameId { get; init; }

        public int RightPointNameId { get; init; }

        public DateTime ReportUtc { get; init; }

        public double? Cant { get; init; }

        public double? ShortTwist { get; init; }

        public double? LongTwist { get; init; }

        public int? ShortTwistRatio { get; init; }

        public int? LongTwistRatio { get; init; }
    }

    #endregion


    #region Derived Epoch models

    public sealed class DhEpochData
    {
        public int PointNameId { get; init; }

        public DateTime ReportUtc { get; init; }

        public double? Dh { get; init; }
    }


    public sealed class StructuralArrayEpochData
    {
        public int ArrayId { get; init; }

        public int PointNameId { get; init; }

        public DateTime ReportUtc { get; init; }

        public double? DE { get; init; }

        public double? DN { get; init; }

        public double? DH { get; init; }
    }


    public sealed class TunnelConvergenceEpochData
    {
        public int ArrayId { get; init; }

        public DateTime ReportUtc { get; init; }

        public double? DAB { get; init; }

        public double? DAC { get; init; }

        public double? DAD { get; init; }

        public double? DAE { get; init; }

        public double? DBC { get; init; }

        public double? DBD { get; init; }

        public double? DBE { get; init; }

        public double? DCD { get; init; }

        public double? DCE { get; init; }

        public double? DDE { get; init; }
    }


    public sealed class PrismCrackGaugeEpochData
    {
        public int ArrayId { get; init; }

        public DateTime ReportUtc { get; init; }

        public double? D2D { get; init; }

        public double? D3D { get; init; }

        public double? DH { get; init; }
    }

    #endregion


    #region Validation and complete Epoch batch

    public enum DBTrackGeometryIssueSeverity
    {
        Warning = 1,
        Error = 2
    }


    public sealed class DBTrackGeometryValidationIssue
    {
        public DBTrackGeometryIssueSeverity Severity { get; init; }

        public string Category { get; init; } = string.Empty;

        public string Identity { get; init; } = string.Empty;

        public string Message { get; init; } = string.Empty;
    }


    public sealed class DBTrackGeometryValidationSummary
    {
        public List<DBTrackGeometryValidationIssue> Issues { get; init; } =
            new();

        public bool DirectPointCategoryReady { get; init; }

        public bool DirectPairCategoryReady { get; init; }

        public bool DhCategoryReady { get; init; }

        public bool StructuralArrayCategoryReady { get; init; }

        public bool TunnelConvergenceCategoryReady { get; init; }

        public bool PrismCrackGaugeCategoryReady { get; init; }

        public int ResolvedPointCount { get; init; }

        public int ResolvedPairCount { get; init; }

        public int DhRowCount { get; init; }

        public int StructuralArrayRowCount { get; init; }

        public int TunnelConvergenceRowCount { get; init; }

        public int PrismCrackGaugeRowCount { get; init; }
    }


    public sealed class DBTrackGeometryEpochBatch
    {
        public DBTrackGeometryProjectIdentity Project { get; init; } =
            new();

        public DateTime ReportUtc { get; init; }

        public List<ResolvedTrackPointEpochData> PointEpochs { get; init; } =
            new();

        public List<ResolvedTrackPairEpochData> PairEpochs { get; init; } =
            new();

        public List<DhEpochData> DhEpochs { get; init; } =
            new();

        public List<StructuralArrayEpochData> StructuralArrayEpochs { get; init; } =
            new();

        public List<TunnelConvergenceEpochData> TunnelConvergenceEpochs { get; init; } =
            new();

        public List<PrismCrackGaugeEpochData> PrismCrackGaugeEpochs { get; init; } =
            new();

        public DBTrackGeometryValidationSummary Validation { get; init; } =
            new();
    }


    public sealed class DBTrackGeometryCategoryWriteResult
    {
        public string Category { get; init; } = string.Empty;

        public int AttemptedCount { get; set; }

        public int InsertedCount { get; set; }

        public int UpdatedCount { get; set; }

        public int UnchangedCount { get; set; }

        public int FailedCount { get; set; }

        public List<string> Errors { get; init; } =
            new();
    }


    public sealed class DBTrackGeometryEpochWriteResult
    {
        public int ProjectId { get; init; }

        public string ProjectName { get; init; } = string.Empty;

        public DateTime ReportUtc { get; init; }

        public DateTime WriteUtc { get; set; }

        public string Outcome { get; set; } = string.Empty;

        public bool HistoryWriteSucceeded { get; set; }

        public string HistoryWriteError { get; set; } = string.Empty;

        public List<DBTrackGeometryCategoryWriteResult> Categories { get; init; } =
            new();
    }

    #endregion
}
