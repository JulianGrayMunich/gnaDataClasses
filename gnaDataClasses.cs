using System;
using System.Data.Common;



namespace gnaDataClasses
{
    public class SPN010
    {
        public double ShortTwistAmber { get; set; }
        public double ShortTwistRed { get; set; }
        public double LongTwistAmber { get; set; }
        public double LongTwistRed { get; set; }
        public double TopAmber { get; set; }
        public double TopRed { get; set; }

    }

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

    public class ATS
    {
        public string? Name { get; set; }
        public double N { get; set; }
        public double E { get; set; }
        public double H { get; set; }
        public string? Settop { get; set; }
        public string? ROlist { get; set; }
        public string? Note1 { get; set; }
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


    public class gnaDataClasses
    {


        public void helloWorld() {
            Console.WriteLine("hello world");  
        }

    }
}
