using System;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;



namespace gnaDataClasses
{

#pragma warning disable IDE1006
#pragma warning disable NU1510

    public class BuildInfo
    {
        /// <summary>
        /// Returns a build/date stamp derived from the best available executable image timestamp.
        /// Falls back to UTC now if no valid file path can be resolved.
        /// </summary>
        public static string BuildDateString(string format = "yyyyMMdd")
        {
            try
            {
                // 1) Prefer the entry assembly (the EXE in normal runs)
                var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
                string? path = asm.Location;

                // 2) If empty or nonexistent, try the current process path (NET 6+)
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    path = Environment.ProcessPath;

                // 3) Try MainModule file name
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    path = Process.GetCurrentProcess().MainModule?.FileName;

                // 4) Last resort: look for an .exe in the base directory
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                {
                    var baseDir = AppContext.BaseDirectory;
                    path = Directory.EnumerateFiles(baseDir, "*.exe", SearchOption.TopDirectoryOnly)
                                    .FirstOrDefault();
                }

                // If all else fails, use current time (won't throw)
                if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                    return DateTime.Now.ToString(format);

                // Use the file's last write time as a proxy for build time
                var dtLocal = File.GetLastWriteTime(path);
                return dtLocal.ToString(format);
            }
            catch
            {
                // Absolute safety net
                return DateTime.Now.ToString(format);
            }
        }
    }


    public class Points
    {
        // Metadata
        public string? SensorID { get; set; }
        public string? Name { get; set; }
        public string? ReplacementName { get; set; }
        public string? Count { get; set; }
        public string? Type { get; set; }
        public string? UTCtime { get; set; }
        public string? isOutlier { get; set; }

        // Reference coordinates
        public double Nref { get; set; }
        public double Eref { get; set; }
        public double Href { get; set; }

        // Displacements
        public double dN { get; set; }
        public double dE { get; set; }
        public double dH { get; set; }

        // Corrections
        public double dNcor { get; set; }
        public double dEcor { get; set; }
        public double dHcor { get; set; }

        // Absolute coordinates
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }

        // Mean coordinates
        public double MeanN { get; set; }
        public double MeanE { get; set; }
        public double MeanH { get; set; }


        // Derived metrics
        public double dS { get; set; }
        public double dR { get; set; }
        public double dT { get; set; }

        // Time metrics
        public string? TimeBlockStartUTC { get; set; }
        public string? TimeBlockEndUTC { get; set; }
    }

    //============================================================

    public class EmailCredentials
    {
        public string? EmailLogin { get; set; }
        public string? EmailPassword { get; set; }
        public string? EmailFrom { get; set; }
        public string? EmailRecipients { get; set; }
    }



    public class SensorInfo
    {
        public int SensorID { get; set; }
        public string? SensorName { get; set; }
        public string? ATS { get; set; }
        public string? Read { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }

    }


    public class AlarmState
    {
        public string? ATSname { get; set; }
        public string? Settop { get; set; }
        public string? previousAlarmState { get; set; }
        public string? currentAlarmState { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }
        public string? StateChange { get; set; }
    }


    public class GKAmeanLimits
    {
        public double HA { get; set; }
        public double VA { get; set; }
        public double SD { get; set; }

    }







    public class SPN010
    {
        public double ShortTwistAmber { get; set; }
        public double ShortTwistRed { get; set; }
        public double LongTwistAmber { get; set; }
        public double LongTwistRed { get; set; }
        public double TopAmber { get; set; }
        public double TopRed { get; set; }

    }


    public class GKAdata
    {
        public string? ATSname { get; set; } //1
        public string? TargetName { get; set; } //1
        public string? UTCtime { get; set; }
        public Int16 Face { get; set; } //6
        public double Ha { get; set; } //10
        public double Va { get; set; } //12
        public double SD { get; set; } //7
        public double PsmOffset { get; set; } //15
        public Int16 ObservationCount { get; set; }

    }

    // public class FieldObservation
//    {
//        public string? TargetName { get; set; } //1
//        public string? UTCtime { get; set; }
//        public Int16 Face { get; set; } //6
//        public double Ha { get; set; } //10
//        public double Va { get; set; } //12
//        public double SD { get; set; } //7
//        public double PsmOffst { get; set; } //15

//        public Int16 Rounds{ get; set; }
//}


    public class Observation
    {
        public int? index { get; set; }
        public int? fixedDataIndex { get; set; }
        public string? Name { get; set; }       // this is a string as it could contain 'Missing'
        public string? UTCtime { get; set; }
        public double dE { get; set; }
        public double dN { get; set; }
        public double dH { get; set; }
        public double E { get; set; }
        public double N { get; set; }
        public double H { get; set; }
        public double dT { get; set; }
        public double PsmOffst { get; set; }
        public string? railBracket { get; set; }
    }

    public class ATSstats
    {
        public string? ATSname { get; set; }       // this is a string as it could contain 'Missing'
        public int MaxPossibleObs { get; set; }
        public int SuccessfulObs { get; set; }
        public int TotalPrismCount { get; set; }
        public int SuccessfulPrismCount { get; set; }
        public int FailedPrismCount { get; set; }
        public double PercentageSuccess { get; set; }
        public string? TimeBlockStart { get; set; }
        public string? TimeBlockEnd { get; set; }
        public string? Date { get; set; }

    }

    public class FixedData
    {
        public int? index { get; set; }
        public string? shortName { get; set; }
        public string? longName { get; set; }
        public double? Esurvey { get; set; }
        public double? Nsurvey { get; set; }
        public double? Hsurvey { get; set; }
        public string? railBracket { get; set; }
        public double? dTtrigger { get; set; }
        public double? dHtrigger { get; set; }

        public double? Chainage { get; set; }

    }

    public class PrismStats
    {
        public string? SensorID { get; set; }
        public string? Name { get; set; }
        public string? ReplacementName { get; set; }
        public string? ATS { get; set; }       // this is a string as it could contain 'Missing'
        public int ObservationCount { get; set; }
        public int MaxObservationCount { get; set; }
        public double PercentageSuccess { get; set; }
        public string? TimeBlockStart { get; set; }
        public string? TimeBlockEnd { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }

    }

    public class ColumnData
    {
        public string? Name { get; set; }

        public string? data { get; set; }
    }

    public class Coordinates
    {
        public string? SensorID { get; set; }       // this is a string as it could contain 'Missing'
        public string? Name { get; set; }
        public double Nref { get; set; }
        public double Eref { get; set; }
        public double Href { get; set; }
        public double dN { get; set; }
        public double dE { get; set; }
        public double dH { get; set; }
        public double dNcorr { get; set; }
        public double dEcorr { get; set; }
        public double dHcorr { get; set; }
        public double Ncurrent { get; set; }
        public double Ecurrent { get; set; }
        public double Hcurrent { get; set; }
        public double ToRoffset { get; set; }
        public double ToR { get; set; }
        public string? Timestamp { get; set; }
        public string? Count { get; set; }
        public string? Type { get; set; }
        public string? ReplacementName { get; set; }
        public string? ATS { get; set; }
        public string? RailBracket { get; set; }
        public double Hfault { get; set; }
        public double Vfault { get; set; }

    }



    public class ATSDetails
    {
        public string ATSName { get; init; } = string.Empty;
        public string GKAFilePath { get; init; } = string.Empty;
        public double E { get; set; }
        public double N { get; set; }
        public double H { get; set; }
    }

    public class ATS
    {
        public string? Name { get; set; }
        public double E { get; set; }
        public double N { get; set; }
        public double H { get; set; }
        public string? Settop { get; set; }
        public string? ROlist { get; set; }
        public string? Note1 { get; set; }
    }


    public class ATSCoords
    {
        public string? Name { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }
        public double OrientationGons { get; set; }


    }


    public class Prism
    {
        public string? SensorID { get; set; }       // this is a string as it could contain 'Missing'
        public string? Name { get; set; }
        public double Nref { get; set; }
        public double Eref { get; set; }
        public double Href { get; set; }

        public double dN { get; set; }
        public double dE { get; set; }
        public double dH { get; set; }
        public double dS { get; set; }
        public double dR { get; set; }
        public double dT { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }
        public double dHalign { get; set; }
        public double dValign { get; set; }
        public double ToRoffset { get; set; }
        public double ToR { get; set; }
        public string? Count { get; set; }
        public string? Track { get; set; }
        public string? ReplacementName { get; set; }
        public string? ATS { get; set; }
        public double Bearing { get; set; }
        public double Distance { get; set; }
        public string? Note1 { get; set; }
        public double? dTtrigger { get; set; }
        public double? dHtrigger { get; set; }
        public double? Chainage { get; set; }
        public int? ExcelRow { get; set; }
        public string? dS_Trigger_color { get; set; }
        public string? dH_Trigger_color { get; set; }
        public string? dR_Trigger_color { get; set; }
        public string? dT_Trigger_color { get; set; }


    }

    public class Deltas
    {
        public string? Name { get; set; }
        public double dN { get; set; }
        public double dE { get; set; }
        public double dH { get; set; }
        public double ToR { get; set; }
        public string? Count { get; set; }
        public string? Track { get; set; }
    }

    public class TrackGeometry
    {
        public string? TargetName_Arail { get; set; }
        public string? TargetName_Brail { get; set; }
        public double Reference_cant { get; set; }
        public double Current_Cant { get; set; }
        public double Reference_Twist { get; set; }
        public double Current_Twist { get; set; }
        public double Reference_HA_Arail { get; set; }
        public double Current_HA_Arail { get; set; }
        public double Reference_HA_Brail { get; set; }
        public double Current_HA_Brail { get; set; }
        public double Reference_VA_Arail { get; set; }
        public double Current_VA_Arail { get; set; }
        public double Reference_VA_Brail { get; set; }
        public double Current_VA_Brail { get; set; }
        public double Current_SlewChange { get; set; }
        public double Current_GaugeChange { get; set; }
        public double Reference_RCant { get; set; }
        public double Current_RCant { get; set; }
        public string? TrackName { get; set; }
        public string? TargetAreadingCount { get; set; }
        public string? TargetBreadingCount { get; set; }
        public int Trigger_H_A { get; set; }
        public int Trigger_H_B { get; set; }
        public int Trigger_V_A { get; set; }
        public int Trigger_V_B { get; set; }

    }

    public class Car
    {
        public string? Model { get; set; }
        public string? Color { get; set; }
    }

    public class PrismStatsTable
    {
        public string? SensorID { get; set; }
        public string? Name { get; set; }
        public string? ReplacementName { get; set; }
        public string? ATS { get; set; } 
        public int ObservationCount { get; set; }
        public int MaxObservationCount { get; set; }
        public double PercentageSuccess { get; set; }
        public string? TimeBlockStart { get; set; }
        public string? TimeBlockEnd { get; set; }
        public string? TimeBlockColumnHeader { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public int Index { get; set; }

    }

    public class TransCoords
    {
        public string? Name { get; set; }
        public double Nlocal { get; set; }
        public double Elocal { get; set; }
        public double Hlocal { get; set; }
        public double Nmain { get; set; }
        public double Emain { get; set; }
        public double Hmain { get; set; }
        public double dS { get; set; }
        public double dH { get; set; }
        public double OrrCorr { get; set; }

        public double ObservedHA { get; set; }

        public double ObservedVA { get; set; }

        public double ObservedSD { get; set; }
    }

    public class ControlPrisms
    {
        public string? SensorID { get; set; }
        public string? Name { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }
        public double slopeDist { get; set; }
        public double prismConst { get; set; }
    }




    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


    public class PrismCoords
    {
        public string? SensorID { get; set; }
        public string? ATSname { get; set; }
        public string? Name { get; set; }
        public string? ReplacementName { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }

        public double settopHa { get; set; }
        public double settopVa { get; set; }
        public double settopSD { get; set; }

        public double joinHa { get; set; }
        public double joinVa { get; set; }
        public double joinSD { get; set; }

        public double dR { get; set; }
        public double dT { get; set; }

        public double prismConst { get; set; }

        public int readingCount { get; set; }

    }

    public class OrientationObservations
    {
        public bool IsUsed { get; set; }
        public string? Name { get; set; }
        public double HA { get; set; }
        public double VA { get; set; }
        public double SD { get; set; }
        public double prismConst { get; set; }
    }

    public class RailTags
    {
        public string? LeftRailTag { get; set; }
        public string? RightRailTag { get; set; }

    }

    public class ToR
    {
        public string? Name { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }
    }

    public class Combined
    {
        public string? PrismName { get; set; }
        public double PrismE { get; set; }
        public double PrismN { get; set; }
        public double PrismH { get; set; }
        public string? TORName { get; set; }
        public double TORE { get; set; }
        public double TORN { get; set; }
        public double TORH { get; set; }

    }




    public class JWG_Prisms
    {
        public string? Count { get; set; }
        public string? Code { get; set; }
        public string? SensorID { get; set; }
        public string? Name { get; set; }
        public string? ReplacementName { get; set; }
        public string? TimeLocalref { get; set; }
        public double Nref { get; set; }
        public double Eref { get; set; }
        public double Href { get; set; }    
        public double TORref { get; set; }
        public string? TimeLocalprevious { get; set; }
        public double Nprevious { get; set; }
        public double Eprevious { get; set; }

        public double Hprevious { get; set; }   
        public double TORprevious { get; set; }

        public string? TimeLocalcurrent { get; set; }
        public double Ncurrent { get; set; }
        public double Ecurrent { get; set; }

        public double Hcurrent { get; set; }

        public double TORcurrent { get; set; }

        public double dRref { get; set; }
        public double dTref { get; set; }
        public double dHref { get; set; }

        public double dRprevious { get; set; }
        public double dTprevious { get; set; }
        public double dHprevious { get; set; }

        public double dRcurrent { get; set; }
        public double dTcurrent { get; set; }
        public double dHcurrent { get; set; }

    }


    public class JWG_TrackGeometry
    {
        public string? Code { get; set; }
        public string? ReplacementName { get; set; }
        public string? Name { get; set; }
        public int Row { get; set; }
        public string? Point { get; set; }
        public string? Rail { get; set; }
        public double SlewReferenceCurrent { get; set; }
        public double SlewPreviousCurrent { get; set; }
        public double ReferenceCurrentHeave { get; set; }
        public double PreviousCurrentHeave { get; set; }

        public double CantReference { get; set; }
        public double CantPrevious { get; set; }
        public double CantCurrent { get; set; }

        public double TwistReference { get; set; }
        public double TwistPrevious { get; set; }
        public double TwistCurrent { get; set; }

        public double dH { get; set; }

        public double dHreference { get; set; }
        public double dHprevious { get; set; }
        public double dHcurrent { get; set; }


        public double RadDispl_RefToCur { get; set; }
        public double RadDispl_PrevToCur { get; set; }
        public double TanDispl_RefToCur { get; set; }
        public double TanDispl_PrevToCur { get; set; }
        public double RadTilt_RefToCur { get; set; }
        public double TanTilt_RefToCur { get; set; }
        public double RadTilt_PrevToCur { get; set; }
        public double TanTilt_PrevToCur { get; set; }

        public double Heave_RefToCur { get; set; }
        public double Heave_PrevToCur { get; set; }

        public double RadAng_RefToCur { get; set; }
        public double RadAng_PrevToCur { get; set; }

        public double TanAng_RefToCur { get; set; }
        public double TanAng_PrevToCur { get; set; }




    }


    //==================[Specific limited use classes]===================================

    public class Join3DResult
    {
        public double Ha { get; init; }
        public double Va { get; init; }
        public double SD { get; init; }
    }



}