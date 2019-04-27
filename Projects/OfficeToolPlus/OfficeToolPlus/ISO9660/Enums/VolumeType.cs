namespace ISO9660.Enums {

	/// <summary>
	/// Describes the volume descriptor type; the numbers are set according to the ISO 9660 standard.
	/// </summary>
	internal enum VolumeType {
		BootRecord=0,		// Number 0: shall mean that the Volume Descriptor is a Boot Record 
		// (never used in this program... maybe in future distributions).

		Primary=1,			// Number 1: shall mean that the Volume Descriptor is a Primary Volume Descriptor

		Suplementary=2,		// Number 2: shall mean that the Volume Descriptor is a Supplementary Volume Descriptor

		Partition=3,		// Number 3: shall mean that the Volume Descriptor is a Volume Partition Descriptor

		SetTerminator=255	// Number 255: shall mean that the Volume Descriptor is a Volume Descriptor Set Terminator.
	};

}