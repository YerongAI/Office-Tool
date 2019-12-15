using OfficeTool.Export;
using System;
using System.Management;

namespace OfficeTool.Functions
{
    class AutoOperation
    {
        string operation;
        System.Timers.Timer ADIItemsAuto;

        public AutoOperation(OperationType operationType, bool ActivateNow)
        {
            if (operationType == OperationType.Logout)
                operation = "0";
            else if (operationType == OperationType.Shutdown)
                operation = "1";
            else
                operation = "2";
            if (ActivateNow)
                Activate();
        }

        /// <summary>
        /// 立即激活操作
        /// </summary>
        public void Activate()
        {
            if (!string.IsNullOrEmpty(operation))
            {
                PowerControl(operation);
                operation = string.Empty;
            }
        }

        /// <summary>
        /// 开始倒计时
        /// </summary>
        /// <param name="interval">倒计时间隔，涉及到进度条更新间隔</param>
        /// <param name="seconds">倒计时秒数</param>
        public void StartCountdown(int interval, int seconds)
        {
            CustomTimer timer = new CustomTimer(true);
            ADIItemsAuto = new System.Timers.Timer(interval);
            ADIItemsAuto.Elapsed += (obj, args) =>
            {
                int time = (int)timer.GetTimePassed();
                OnProgress(0, time, seconds);
                if (time >= seconds)
                {
                    Activate();
                    CancelCountdown();
                }
            };
            ADIItemsAuto.Start();
        }

        /// <summary>
        /// 取消倒计时
        /// </summary>
        public void CancelCountdown()
        {
            ADIItemsAuto.Stop();
            ADIItemsAuto.Dispose();
        }

        public enum OperationType
        {
            Logout = 0,
            Shutdown = 1,
            Reboot = 2
        }

        private void PowerControl(string flag)
        {
#pragma warning disable IDE0067 // 丢失范围之前释放对象
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
#pragma warning restore IDE0067 // 丢失范围之前释放对象
            try
            {
                mcWin32.Get();

                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

                //"0" 注销 "1" 关机, "2" 重启 "8" 关闭计算机电源
                mboShutdownParams["Flags"] = flag;
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    ManagementBaseObject mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mcWin32.Dispose();
            }
        }

        #region Events

        public event UpgradeProgressChanged ProgressChanged;

        private void OnProgress(int percentage, int current, int total)
        {
            ProgressChanged?.Invoke(this, new UpgradeProgressDelegate(percentage, current, total));
        }
        #endregion
    }
}
