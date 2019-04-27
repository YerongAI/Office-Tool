using System;
using System.Runtime.InteropServices;

static class XL
{
    [DllImport("files\\Thunder\\xldl.dll", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  bool XL_Init();

    [DllImport("files\\Thunder\\xldl.dll", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  bool XL_UnInit();

    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  IntPtr XL_CreateTask([In()]DownTaskParam stParam);

    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  bool XL_StartTask(IntPtr hTask);

    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  bool XL_StopTask(IntPtr hTask);

    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern IntPtr XL_SetSpeedLimit(int nKBps);//原平台类为object
 
    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern  bool XL_DeleteTask(IntPtr hTask);

    [DllImport("files\\Thunder\\xldl.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    public static extern bool XL_SetUserAgent(string pszUserAgent);

    [DllImport("files\\Thunder\\xldl.dll", EntryPoint = "XL_QueryTaskInfoEx", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern  bool XL_QueryTaskInfoEx(IntPtr hTask, [Out()]DownTaskInfo stTaskInfo);


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public class DownTaskParam
    {
        public int nReserved;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
        public string szTaskUrl;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
        public string szRefUrl;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
        public string szCookies;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilename;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szReserved0;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szSavePath;
        public IntPtr hReserved;
        public int bReserved = 0;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szReserved2;
        public int IsOnlyOriginal = 0;
        public uint nReserved1 = 5;
        public int DisableAutoRename = 1;
        public int IsResume = 1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048, ArraySubType = UnmanagedType.U4)]
        public uint[] reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class DownTaskInfo
    {
        public DOWN_TASK_STATUS stat;
        public TASK_ERROR_TYPE fail_code;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilename;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szReserved0;
        public long nTotalSize;
        public long nTotalDownload;
        public float fPercent;
        public int nReserved0;
        public int nSrcTotal;
        public int nSrcUsing;
        public int nReserved1;
        public int nReserved2;

        public int nReserved3;
       ///int

        public int nReserved4;
       ///__int64

        public long nReserved5;
       ///__int64

        public long nDonationP2P;
       ///__int64

        public long nReserved6;
       ///__int64

        public long nDonationOrgin;
       ///__int64

        public long nDonationP2S;
       ///__int64

        public long nReserved7;
       ///__int64

        public long nReserved8;
       ///int

        public int nSpeed;
       ///int

        public int nSpeedP2S;
       ///int

        public int nSpeedP2P;
       ///boolean

        public bool bIsOriginUsable;
       ///float

        public float fHashPercent;
       ///int

        public int IsCreatingFile;
       ///DWORD[64]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U4)]
        public uint[] reserved;
    }

    public enum DOWN_TASK_STATUS
    {

       ///NOITEM -> 0
        NOITEM = 0,

        TSC_ERROR,

        TSC_PAUSE,

        TSC_DOWNLOAD,

        TSC_COMPLETE,

        TSC_STARTPENDING,

        TSC_STOPPENDING
    }

    public enum TASK_ERROR_TYPE
    {

       ///TASK_ERROR_UNKNOWN -> 0x00
        TASK_ERROR_UNKNOWN = 0,

       ///TASK_ERROR_DISK_CREATE -> 0x01
        TASK_ERROR_DISK_CREATE = 1,

       ///TASK_ERROR_DISK_WRITE -> 0x02
        TASK_ERROR_DISK_WRITE = 2,

       ///TASK_ERROR_DISK_READ -> 0x03
        TASK_ERROR_DISK_READ = 3,

       ///TASK_ERROR_DISK_RENAME -> 0x04
        TASK_ERROR_DISK_RENAME = 4,

       ///TASK_ERROR_DISK_PIECEHASH -> 0x05
        TASK_ERROR_DISK_PIECEHASH = 5,

       ///TASK_ERROR_DISK_FILEHASH -> 0x06
        TASK_ERROR_DISK_FILEHASH = 6,

       ///TASK_ERROR_DISK_DELETE -> 0x07
        TASK_ERROR_DISK_DELETE = 7,

       ///TASK_ERROR_DOWN_INVALID -> 0x10
        TASK_ERROR_DOWN_INVALID = 16,

       ///TASK_ERROR_PROXY_AUTH_TYPE_UNKOWN -> 0x20
        TASK_ERROR_PROXY_AUTH_TYPE_UNKOWN = 32,

       ///TASK_ERROR_PROXY_AUTH_TYPE_FAILED -> 0x21
        TASK_ERROR_PROXY_AUTH_TYPE_FAILED = 33,

       ///TASK_ERROR_HTTPMGR_NOT_IP -> 0x30
        TASK_ERROR_HTTPMGR_NOT_IP = 48,

       ///TASK_ERROR_TIMEOUT -> 0x40
        TASK_ERROR_TIMEOUT = 64,

       ///TASK_ERROR_CANCEL -> 0x41
        TASK_ERROR_CANCEL = 65,

       ///TASK_ERROR_TP_CRASHED -> 0x42
        TASK_ERROR_TP_CRASHED = 66,

       ///TASK_ERROR_ID_INVALID -> 0x43
        TASK_ERROR_ID_INVALID = 67
    }
}

