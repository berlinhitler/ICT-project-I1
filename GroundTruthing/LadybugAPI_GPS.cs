//=============================================================================
// Copyright © 2008 Point Grey Research, Inc. All Rights Reserved.
//
// This software is the confidential and proprietary information of Point
// Grey Research, Inc. ("Confidential Information").  You shall not
// disclose such Confidential Information and shall use it only in
// accordance with the terms of the license agreement you entered into
// with Point Grey Research, Inc. (PGR).
//
// PGR MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF THE
// SOFTWARE, EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE, OR NON-INFRINGEMENT. PGR SHALL NOT BE LIABLE FOR ANY DAMAGES
// SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING
// THIS SOFTWARE OR ITS DERIVATIVES.
//=============================================================================
//
// This file defines the interface of Ladybug SDK's GPS-related functions.
// If your C# project uses Ladybug SDK's GPS functions, this file must also be
// added to your project along with LadybugAPI.cs.
//
//=============================================================================

using System;
using System.Runtime.InteropServices;

namespace LadybugAPI
{
    unsafe public partial class Ladybug
    {
        // ladybugGPS.h functions
        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugCreateGPSContext")]
        public static extern LadybugError CreateGPSContext(out int context);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugDestroyGPSContext")]
        public static extern LadybugError DestroyGPSContext(ref int context);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugRegisterGPS")]
        public static extern LadybugError RegisterGPS(int ladybug_context, ref int gps_context);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugUnregisterGPS")]
        public static extern LadybugError UnregisterGPS(int ladybug_context, ref int gps_context);


        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugInitializeGPS")]
        public static extern LadybugError InitializeGPS(
            int context,
            uint uiPort,
            uint uiBaud,
            uint uiUpdateTimeInterval);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugStartGPS")]
        public static extern LadybugError StartGPS(int context);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugStopGPS")]
        public static extern LadybugError StopGPS(int context);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugGetGPSNMEADataFromImage")]
        public static extern LadybugError GetGPSNMEADataFromImage(
            ref LadybugImage pImage,
            string pszNMEASentenceId,
            void* pNMEADataBuffer);

        [DllImport(LADYBUG_DLL, EntryPoint = "ladybugGetAllGPSNMEADataFromImage")]
        public static extern LadybugError GetAllGPSNMEADataFromImage(
            ref LadybugImage pImage,
            out LadybugNMEAGPSData pNMEAData);

    }

    // Description:
    //   Ladybug2 GPS NMEA GPGGA data - Fix information.
    //
    // Remarks:
    //   Essential fix data which provides a 3D location and accuracy data.
    [StructLayout(LayoutKind.Explicit, Size = 120)]
    unsafe public struct LadybugNMEAGPGGA
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Hour, Coordinated Universal Time.
        [FieldOffset(1)]
        public byte ucGGAHour;

        // Minute, Coordinated Universal Time.
        [FieldOffset(2)]
        public byte ucGGAMinute;

        // Second, Coordinated Universal Time.
        [FieldOffset(3)]
        public byte ucGGASecond;

        // Sub-second.
        [FieldOffset(4)]
        public ushort wGGASubSecond;

        // Latitude.
        // < 0 = South of Equator, > 0 = North of Equator.
        [FieldOffset(8)]
        public double dGGALatitude;

        // Longitude.
        // < 0 = West of Prime Meridian, > 0 = East of Prime Meridian.
        [FieldOffset(16)]
        public double dGGALongitude;

        // GPS Quality Indicator.
        // 0 = Fix not available.
        // 1 = GPS SPS mode.
        // 2 = Differential GPS, SPS mode, fix valid.
        // 3 = GPS PPS mode, fix valid.
        [FieldOffset(24)]
        public byte ucGGAGPSQuality;

        // Number of satellites in view.
        [FieldOffset(25)]
        public byte ucGGANumOfSatsInUse;

        // Horizontal Dilution of precision (HDOP) (in meters).
        [FieldOffset(32)]
        public double dGGAHDOP;

        // Antenna Altitude above/below mean-sea-level (geoid) (in meters).
        [FieldOffset(40)]
        public double dGGAAltitude;

        // Geoidal separation.
        // This is the difference between the WGS-84 earth ellipsoid and the
        // and mean sea level (geoid). A negative value means the mean-sea-level
        // below ellipsoid.
        [FieldOffset(48)]
        public double dGGAHeightOfGeoid;

        // A counter containing the number of GPGGA sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(56)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(60)]
        public fixed uint ulReserved[14];

    }

    // Description:
    //   Ladybug2 GPS NMEA GPGSA data - Overall Satellite data.
    //
    // Remarks:
    //   Details on the nature of the fix. It includes the numbers of the
    //   satellites being used in the current solution and the DOP
    //   (dilution of precision).
    [StructLayout(LayoutKind.Explicit, Size = 176)]
    unsafe public struct LadybugNMEAGPGSA
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Selection mode.
        // M = manual, A = automatic 2D/3D.
        [FieldOffset(1)]
        public byte ucGSAMode;

        // Fix Mode.
        // 1 = No fix.
        // 2 = 2D fix.
        // 3 = 3D fix.
        [FieldOffset(2)]
        public byte ucGSAFixMode;

        // ID of 1st satellite used for fix.
        [FieldOffset(4)]
        public fixed ushort wGSASatsInSolution[36 /*NP_MAX_CHAN*/];

        // Dilution of precision (PDOP).
        [FieldOffset(80)]
        public double dGSAPDOP;

        // Horizontal dilution of precision (HDOP).
        [FieldOffset(88)]
        public double dGSAHDOP;

        // Vertical dilution of precision (VDOP).
        [FieldOffset(96)]
        public double dGSAVDOP;

        // A counter containing the number of GPGSA sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(104)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(108)]
        public fixed uint ulReserved[16];

    }

    // Description:
    //   Ladybug2 GPS NMEA GPGSV data - Satellites in view.
    //
    // Remarks:
    //   Data about the satellites that the unit might be able to find based on
    //   its viewing mask and almanac data. It also shows current ability to
    //   track this data.
    [StructLayout(LayoutKind.Explicit, Size = 432)]
    unsafe public struct LadybugNMEAGPGSV
    {
        //
        // Description:
        //   Satellite information structure
        //
        // Remarks:
        //   This structure contains information about a single satellite.
        //
        public struct CNPSatInfo
        {
            // Satellite ID.
            public ushort wPRN;

            // Signal strength (Signal to Noise Ratio).
            public ushort wSignalQuality;

            // Boolean indicating if this satellite is being used in the solution.
            public bool bUsedInSolution;

            // Azimuth (in degrees).
            public ushort wAzimuth;

            // Elevation (in degrees).
            public ushort wElevation;

        }

        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Total number of messages.
        [FieldOffset(1)]
        public byte ucGSVTotalNumOfMsg;

        // Total satellites in view.
        [FieldOffset(2)]
        public ushort wGSVTotalNumSatsInView;

        // Array of satellite information structures.
        //public fixed CNPSatInfo             GSVSatInfo[ 36 /*NP_MAX_CHAN*/]; // can't have an array of struct as a member of a struct in C# so...
        [FieldOffset(4)]
        public fixed byte CNPSatInfo_bytes[10 * 36]; // this will allocate the sizeof(CNPSatInfo) * NP_MAX_CHAN

        // A counter containing the number of GPGSV sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(364)]
        public uint ulCount;

        // Reserved Space
        [FieldOffset(368)]
        public fixed uint ulReserved[16];

    }

    // Description:
    //   Ladybug2 GPS NMEA GPRMC data - Recommended minimum data for GPS.
    [StructLayout(LayoutKind.Explicit, Size = 120)]
    unsafe public struct LadybugNMEAGPRMC
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Hour (Coordinated Universal Time).
        [FieldOffset(1)]
        public byte ucRMCHour;

        // Minute (Coordinated Universal Time).
        [FieldOffset(2)]
        public byte ucRMCMinute;

        // Second (Coordinated Universal Time).
        [FieldOffset(3)]
        public byte ucRMCSecond;

        // Sub-second.
        [FieldOffset(4)]
        public ushort wRMCSubSecond;

        // Data valid character.
        // A - Data valid, V - Navigation rx warning.
        [FieldOffset(6)]
        public byte ucRMCDataValid;

        // Latitude.
        // < 0 = South of Equator, > 0 = North of Equator.
        [FieldOffset(8)]
        public double dRMCLatitude;

        // Longitude.
        // < 0 = West of Prime Meridian, > 0 = East of Prime Meridian.
        [FieldOffset(16)]
        public double dRMCLongitude;

        // Ground speed (in knots).
        [FieldOffset(24)]
        public double dRMCGroundSpeed;

        // Course over ground, degrees true.
        [FieldOffset(32)]
        public double dRMCCourse;

        // Day.
        [FieldOffset(40)]
        public byte ucRMCDay;

        // Month.
        [FieldOffset(41)]
        public byte ucRMCMonth;

        // Year.
        [FieldOffset(42)]
        public ushort wRMCYear;

        // Magnetic variation.
        // Positive values indicate degrees east, while negative values indicate
        // west.
        [FieldOffset(48)]
        public double dRMCMagVar;

        // A counter containing the number of GPRMC sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(56)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(60)]
        public fixed uint ulReserved[14];

    }

    // Description:
    //   Ladybug2 GPS NMEA GPZDA data - Date and time.
    [StructLayout(LayoutKind.Explicit, Size = 72)]
    unsafe public struct LadybugNMEAGPZDA
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Hour (Coordinated Universal Time).
        [FieldOffset(1)]
        public byte ucZDAHour;

        // Minute (Coordinated Universal Time).
        [FieldOffset(2)]
        public byte ucZDAMinute;

        // Second (Coordinated Universal Time).
        [FieldOffset(3)]
        public byte ucZDASecond;

        // Sub-second.
        [FieldOffset(4)]
        public ushort wZDASubSecond;

        // Day.
        [FieldOffset(6)]
        public byte ucZDADay;

        // Month.
        [FieldOffset(7)]
        public byte ucZDAMonth;

        // Year.
        [FieldOffset(8)]
        public ushort wZDAYear;

        // Local zone description, -13 to +13 hours.
        [FieldOffset(19)]
        public byte ucZDALocalZoneHour;

        // Local zone minutes description, 00 to 59 minutes.
        [FieldOffset(11)]
        public byte ucZDALocalZoneMinute;

        // A counter containing the number of GPZDA sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(12)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(16)]
        public fixed uint ulReserved[14];

    }

    // Description:
    //   Ladybug2 GPS NMEA GPVTG data - Vector track and Speed over the Ground.
    //
    // Remarks:
    //   This structure contains the current track and speed as recorded by the
    //   GPS device.
    [StructLayout(LayoutKind.Explicit, Size = 112)]
    unsafe public struct LadybugNMEAGPVTG
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Track Made Good.
        [FieldOffset(8)]
        public double dVTGTrackMadeGood;

        // Magnetic Track Made Good.
        [FieldOffset(16)]
        public double dVTGMagneticTrackMadeGood;

        // Ground Speed (in knots).
        [FieldOffset(24)]
        public double dVTGGroundSpeedKnots;

        // Ground Speed (in kilometers per hour).
        [FieldOffset(32)]
        public double dVTGGroundSpeedKilometersPerHour;

        // A counter containing the number of GPVTG sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(40)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(44)]
        public fixed uint ulReserved[16];

    }


    // Description:
    //   Ladybug2 GPS NMEA GPGLL data - Geographic Position Latitude/Longitude.
    [StructLayout(LayoutKind.Explicit, Size = 96)]
    unsafe public struct LadybugNMEAGPGLL
    {
        // Flag indicating whether all the data in this structure is valid.
        // True - Valid, False - Invalid.
        [FieldOffset(0)]
        public bool bValidData;

        // Latitude, < 0 = South of Equator, > 0 = North of Equator.
        [FieldOffset(8)]
        public double dGLLLatitude;

        // Longitude, < 0 = West of Prime Meridian, > 0 = East of Prime Meridian.
        [FieldOffset(16)]
        public double dGLLLongitude;

        // Hour (Coordinated Universal Time).
        [FieldOffset(24)]
        public byte ucGLLHour;

        // Minute (Coordinated Universal Time).
        [FieldOffset(25)]
        public byte ucGLLMinute;

        // Second (Coordinated Universal Time).
        [FieldOffset(26)]
        public byte ucGLLSecond;

        // Sub-second.
        [FieldOffset(28)]
        public ushort wGLLSubSecond;

        // Data valid character.
        // A - Data Valid, V - Data Invalid.
        [FieldOffset(30)]
        public byte ucGLLDataValid;

        // A counter containing the number of GPGLL sentences parsed since
        // the GPS device was started (or restarted).
        // If the GPS data is from a Ladybug image, it is always 1.
        [FieldOffset(32)]
        public uint ulCount;

        // Reserved.
        [FieldOffset(36)]
        public fixed uint ulReserved[14];

    }


    // Description:
    //   Ladybug2 GPS NMEA data.
    //
    // Remarks:
    //   This structure is a holder for all of the above structures.
    [StructLayout(LayoutKind.Explicit, Size = 2152)]
    unsafe public struct LadybugNMEAGPSData
    {
        // GPGGA data structure
        [FieldOffset(0)]
        public LadybugNMEAGPGGA dataGPGGA;

        // GPGSA data structure
        [FieldOffset(120)]
        public LadybugNMEAGPGSA dataGPGSA;

        // GPGSV data structure
        [FieldOffset(296)]
        public LadybugNMEAGPGSV dataGPGSV;

        // GPRMC data structure
        [FieldOffset(728)]
        public LadybugNMEAGPRMC dataGPRMC;

        // GPZDA data structure
        [FieldOffset(848)]
        public LadybugNMEAGPZDA dataGPZDA;

        // GPVTG data structure
        [FieldOffset(920)]
        public LadybugNMEAGPVTG dataGPVTG;

        // GPGLL data structure
        [FieldOffset(1032)]
        public LadybugNMEAGPGLL dataGPGLL;

        // Reserved space
        [FieldOffset(1128)]
        public fixed uint ulReserved[256];
    }
}
