/*
 * This file is only kept in this project for didactical purposes. All of the classes and enums present here
 * can also be found in namespaces Enums and PrimitiveTypes.
 */

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Runtime.InteropServices;
//using System.IO;
//using IsoCreator;

//namespace ISO9660 {

//    #region Enums

//    public enum Endian {
//        LittleEndian,
//        BigEndian
//    };

//    /// <summary>
//    /// Describes the volume descriptor type; the numbers are set according to the ISO 9660 standard.
//    /// </summary>
//    public enum VolumeType {
//        BootRecord=0,		// Number 0: shall mean that the Volume Descriptor is a Boot Record 
//        // (never used in this program... maybe in future distributions).

//        Primary=1,			// Number 1: shall mean that the Volume Descriptor is a Primary Volume Descriptor

//        Suplementary=2,		// Number 2: shall mean that the Volume Descriptor is a Supplementary Volume Descriptor

//        Partition=3,		// Number 3: shall mean that the Volume Descriptor is a Volume Partition Descriptor

//        SetTerminator=255	// Number 255: shall mean that the Volume Descriptor is a Volume Descriptor Set Terminator.
//    };

//    #endregion

//    #region Structs

//    public class BinaryDateRecord {
//        public byte Year;					// number of years since 1900

//        public byte Month;				// month, where 1=January, 2=February, etc.

//        public byte DayOfMonth;				// day of month, in the range from 1 to 31

//        public byte Hour;					// hour, in the range from 0 to 23

//        public byte Minute;					// minute, in the range from 0 to 59

//        public byte Second;					/* second, in the range from 0 to 59
//                                             * (for DOS this is always an even number)
//                                             */
//    }

//    public class AsciiDateRecord {
//        // field													contents
//        // --------													---------------------------------------------------------
//        public byte[] Year = new byte[4] { 48, 48, 48, 48 };		// year, as four ASCII digits

//        public byte[] Month = new byte[2] { 48, 48 };				/* month, as two ASCII digits, where
//                                                                     * 01=January, 02=February, etc.
//                                                                     */

//        public byte[] DayOfMonth = new byte[2] { 48, 48 };			/* day of month, as two ASCII digits, in the range
//                                                                     * from 01 to 31
//                                                                     */

//        public byte[] Hour = new byte[2] { 48, 48 };				// hour, as two ASCII digits, in the range from 00 to 23

//        public byte[] Minute = new byte[2] { 48, 48 };				// minute, as two ASCII digits, in the range from 00 to 59

//        public byte[] Second = new byte[2] { 48, 48 };				// second, as two ASCII digits, in the range from 00 to 59

//        public byte[] HundredthsOfSecond = new byte[2] { 48, 48 };	/* hundredths of a second, as two ASCII digits, in the range
//                                                                     * from 00 to 99
//                                                                     */

//        public sbyte TimeZone;										/* offset from Greenwich Mean Time, in 15-minute intervals,
//                                                                     * as a twos complement signed number, positive for time
//                                                                     * zones east of Greenwich, and negative for time zones
//                                                                     * west of Greenwich
//                                                                     */
//    }

//    public class DirectoryRecord {
//        // field									contents
//        // ------------------------------			---------------------------------------------------------
//        // [1]
//        public byte Length = IsoAlgorithm.DefaultDirectoryRecordLength;
//                                                    // 34, the number of bytes in the record (which must be even)

//        // [2]
//        public byte ExtendedAttributeLength = 0;	// always 0 in DOS [number of sectors in extended attribute record]

//        // [3-10]
//        public UInt64 ExtentLocation;				/* number of the first sector of file data or directory
//                                                     * (zero for an empty file), as a both endian double word
//                                                     */

//        // [11-18]
//        public UInt64 DataLength;					/* number of bytes of file data or length of directory,
//                                                     * excluding the extended attribute record,
//                                                     * as a both endian double word
//                                                     */

//        // [19-24]
//        public BinaryDateRecord Date = new BinaryDateRecord();
//                                                    // Details in struct DateRecord			

//        // [25]
//        public sbyte TimeZone;						/* offset from Greenwich Mean Time, in 15-minute intervals,
//                                                     * as a twos complement signed number, positive for time
//                                                     * zones east of Greenwich, and negative for time zones
//                                                     * west of Greenwich (DOS ignores this field)
//                                                     */

//        // [26]
//        public byte FileFlags;						/* flags, with bits as follows:
//                                                     * bit     value
//                                                     * ------  ------------------------------------------
//                                                     * 0 (LS)  0 for a norma1 file, 1 for a hidden file
//                                                     * 1       0 for a file, 1 for a directory
//                                                     * 2       0 [1 for an associated file]
//                                                     * 3       0 [1 for record format specified]
//                                                     * 4       0 [1 for permissions specified]
//                                                     * 5       0
//                                                     * 6       0
//                                                     * 7 (MS)  0 [1 if not the final record for the file]
//                                                     */

//        // [27]
//        public byte FileUnitSize = 0;				// 0 [file unit size for an interleaved file]

//        // [28]
//        public byte InterleaveGapSize = 0;			// 0 [interleave gap size for an interleaved file]

//        // [29-32]
//        public UInt32 VolumeSequnceNumber = 0x01000001;
//                                                    // 1, as a both endian word [volume sequence number]

//        // [33]
//        public byte LengthOfFileIdentifier;			// the identifier length

//        // [34-...]
//        public byte[] FileIdentifier;				// identifier

//        // A directory record must have even number of bytes. (!!)
//    }

//    public class VolumeDescriptor {
//        // field													contents
//        // ------------------------------							---------------------------------------------------------
//        // [1]
//        public byte VolumeDescType;									// 1, 2, 255

//        // [2-7]
//        public byte[] StandardIdentifier = new byte[6] { 67, 68, 48, 48, 49, 1 };
//        /* 67, 68, 48, 48, 49 ( that is CD001 ) and 1, respectively (same as Volume
//         * Descriptor Set Terminator)
//         */

//        // [8]
//        public byte Reserved1 = 0;									// 0

//        // [9-40]
//        public byte[] SystemId = IsoAlgorithm.MemSet( IsoAlgorithm.SystemIdLength, IsoAlgorithm.AsciiBlank );// system identifier

//        // [41-72]
//        public byte[] VolumeId = IsoAlgorithm.MemSet( IsoAlgorithm.VolumeIdLength, IsoAlgorithm.AsciiBlank );// volume identifier

//        // [73-80]
//        public UInt64 Reserved2 = 0;								// 0

//        // [81-88]
//        public UInt64 VolumeSpaceSize;								// total number of sectors, as a both endian double word

//        public byte[] Reserved3_1 = new byte[3] { 37, 47, 69 };		// [89-91]
//        // [92-120]
//        public byte[] Reserved3_2 = new byte[29];						// zeros

//        // [121-124]
//        public UInt32 VolumeSetSize = 0x01000001;					// 1, as a both endian word [volume set size]

//        // [125-128]
//        public UInt32 VolumeSequenceNumber = 0x01000001;			// 1, as a both endian word [volume sequence number]

//        // [129-132]
//        public UInt32 SectorkSize = 0x00080800;						// 2048 (the sector size), as a both endian word

//        // [133-140]
//        public UInt64 PathTableSize;								// path table length in bytes, as a both endian double word

//        // [141-144]
//        public UInt32 TypeLPathTable;								/* number of first sector in first little endian path table,
//                                                                         * as a little endian double word
//                                                                         */

//        // [145-148]
//        public UInt32 OptionalTypeLPathTable = 0;					/* number of first sector in second little endian path table,
//                                                                         * as a little endian double word, or zero if there is no
//                                                                         * second little endian path table
//                                                                         */

//        // [149-152]
//        public UInt32 TypeMPathTable; /* a inverser */				/* number of first sector in first big endian path table,
//                                                                         * as a big endian double word
//                                                                         */

//        // [153-156]
//        public UInt32 OptionalTypeMPathTable = 0; /* a inverser */	/* number of first sector in second big endian path table,
//                                                                         * as a big endian double word, or zero if there is no
//                                                                         * second big endian path table
//                                                                         */

//        // [157-190]
//        public DirectoryRecord RootDirRecord = new DirectoryRecord();							// root directory record

//        // [191-318]
//        public byte[] VolumeSetId = IsoAlgorithm.MemSet( IsoAlgorithm.VolumeSetIdLength, IsoAlgorithm.AsciiBlank );					// volume set identifier

//        // [319-446]
//        public byte[] PublisherId = IsoAlgorithm.MemSet( IsoAlgorithm.PublisherIdLength, IsoAlgorithm.AsciiBlank );					// publisher identifier

//        // [447-574]
//        public byte[] PreparerId = IsoAlgorithm.MemSet( IsoAlgorithm.PreparerIdLength, IsoAlgorithm.AsciiBlank );						// data preparer identifier

//        // [575-702]
//        public byte[] ApplicationId = IsoAlgorithm.MemSet( IsoAlgorithm.ApplicationIdLength, IsoAlgorithm.AsciiBlank );				// application identifier

//        // [703-739]
//        public byte[] CopyrightFileId = IsoAlgorithm.MemSet( IsoAlgorithm.CopyrightFileIdLength, IsoAlgorithm.AsciiBlank );			// copyright file identifier

//        // [740-776]
//        public byte[] AbstractFileId = IsoAlgorithm.MemSet( IsoAlgorithm.AbstractFileIdLength, IsoAlgorithm.AsciiBlank );				// abstract file identifier

//        // [777-813]
//        public byte[] BibliographicFileId = IsoAlgorithm.MemSet( IsoAlgorithm.BibliographicFileIdLength, IsoAlgorithm.AsciiBlank );	// bibliographical file identifier

//        // [814-830]
//        public AsciiDateRecord CreationDate = new AsciiDateRecord();		// date and time of volume creation

//        // [831-847]
//        public AsciiDateRecord ModificationDate = new AsciiDateRecord();	// date and time of most recent modification

//        // [848-864]
//        public AsciiDateRecord ExpirationDate = new AsciiDateRecord();		// date and time when volume expires

//        // [865-881]
//        public AsciiDateRecord EffectiveDate = new AsciiDateRecord();		// date and time when volume is effective

//        // [882]
//        public byte FileStructureVersion = 1;						// 1

//        // [883]
//        public byte Reserved4 = 0;									// 0

//        // [884-1395]
//        public byte[] ApplicationData = new byte[512];				// reserved for application use (usually zeros)

//        // [1396-2048]
//        public byte[] Reserved5 = new byte[653];					// zeros
//        // TOTAL 2048 bytes
//    }

//    public class PathTableRecord {
//        public byte Length;					// N, the identifier length (or 1 for the root directory)

//        public byte ExtendedLength = 0;		// 0 [number of sectors in extended attribute record]

//        public UInt32 ExtentLocation;		/* number of the first sector in the directory, as a
//                                                 * double word
//                                                 */

//        public UInt16 ParentNumber;			/* number of record for parent directory (or 1 for the root
//                                                 * directory), as a word; the first record is number 1,
//                                                 * the second record is number 2, etc.
//                                                 */

//        public byte[] Identifier;			// identifier (or 0 for the root directory)

//        // One record must have even number of bytes.
//    }

//    #endregion
//}
