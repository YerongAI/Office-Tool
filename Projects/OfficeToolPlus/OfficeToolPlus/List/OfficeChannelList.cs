using System.Collections.Generic;

namespace OfficeTool.List
{
    // Channel Information List
    // Copyright © 2020 蓝点网 | By Yerong | https://otp.landian.vip/
    // For more information please visit:   https://docs.microsoft.com/en-us/DeployOffice/overview-of-update-channels-for-office-365-proplus
    //                                      https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019
    class OfficeChannelList
    {
        static private readonly List<ChannelInf> ChannelLists = new List<ChannelInf>(4);
        public OfficeChannelList()
        {
            if (ChannelLists.Count == 0)
                BuildLists();
        }

        public OfficeChannelList(bool rebuild)
        {
            if (rebuild)
            {
                ChannelLists.Clear();
                BuildLists();
            }
        }

        /// <summary>
        /// Build Channel List
        /// </summary>
        private void BuildLists()
        {
            ChannelInf p0 = new ChannelInf("f2e724c1-748f-4b47-8fb8-8e0d210e9208", "Office 2019 Perpetual Enterprise", "PerpetualVL2019", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p0);
            ChannelInf p1 = new ChannelInf("7ffbc6bf-bc32-4f92-8982-f9dd17fd3114", "Semi-Annual Channel", "Broad", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p1);
            ChannelInf p2 = new ChannelInf("b8f9b850-328d-4355-9145-c59439a0c4cf", "Semi-Annual Channel (Targeted)", "Targeted", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p2);
            ChannelInf p3 = new ChannelInf("492350f6-3a01-4f97-b9c0-c7c6ddf67d60", "Monthly Channel", "Monthly", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p3);
            ChannelInf p4 = new ChannelInf("64256afe-f5d9-4f86-8936-8840a6a4f5be", "Monthly Channel (Targeted)", "Insiders", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p4);
            ChannelInf p5 = new ChannelInf("5440fd1f-7ecb-4221-8110-145efaa6372f", "Beta Channel (Insider)", "InsiderFast", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p5);
            ChannelInf p6 = new ChannelInf("ea4a4090-de26-49d7-93c1-91bff9e53fc3", "DevMain Channel (Dogfood)", "Dogfood", string.Empty, string.Empty, new List<string>());
            ChannelLists.Add(p6);
        }

        /// <summary>
        /// Set the version of Channel
        /// </summary>
        /// <param name="ffn">Channel FFN</param>
        /// <param name="version">Version of Office</param>
        /// <param name="createdTimeUTC">Create Time (UTC)</param>
        public void SetVersion(string ffn, string version, string createdTimeUTC)
        {
            foreach (ChannelInf channel in ChannelLists)
            {
                if (channel.FFN == ffn)
                {
                    channel.Version = version;
                    channel.CreatedTimeUTC = createdTimeUTC;
                }
            }
        }

        /// <summary>
        /// Get Office version by Channel FFN
        /// </summary>
        /// <param name="ffn">Channel FFN</param>
        /// <returns>Return Office version, or string.empty if no information.</returns>
        public string GetVersion(string ffn)
        {
            foreach (ChannelInf channel in ChannelLists)
            {
                if (channel.FFN == ffn)
                    return channel.Version;
            }
            return string.Empty;
        }

        /// <summary>
        /// Set the create time of Channel
        /// </summary>
        /// <param name="name">Channel Name</param>
        /// <param name="version">Office Version</param>
        /// <param name="createdTimeUTC">Create Time</param>
        public void SetCreateTime(string name, string version, string createdTimeUTC)
        {
            foreach (ChannelInf channel in ChannelLists)
            {
                if (channel.ChannelName == name && channel.Version == version)
                {
                    channel.CreatedTimeUTC = createdTimeUTC;
                }
            }
        }

        /// <summary>
        /// Add old version to a Channel
        /// </summary>
        /// <param name="channelName">Channel Name</param>
        /// <param name="version">Office Version</param>
        public void AddOldVersion(string channelName, string version)
        {
            foreach (ChannelInf channel in ChannelLists)
            {
                if (channel.ChannelName == channelName)
                    channel.OldVersionList.Add(version);
            }
        }

        /// <summary>
        /// Get the old version of Office
        /// </summary>
        /// <param name="index">Index of Channel</param>
        /// <returns>Return the Office Version list</returns>
        public List<string> GetVersionList(int index)
        {
            if (index >= 0 && index < ChannelLists.Count)
                return ChannelLists[index].OldVersionList;
            else
                return new List<string>();
        }

        /// <summary>
        /// Get Channel FFN by Channel Name
        /// </summary>
        /// <param name="channelName">Channel Name</param>
        /// <returns>Return Channel FFN</returns>
        public string GetFFN(string channelName)
        {
            foreach (ChannelInf channel in ChannelLists)
            {
                if (channel.ChannelName == channelName)
                    return channel.FFN;
            }
            return null;
        }

        /// <summary>
        /// Get the information of all Channels
        /// </summary>
        /// <returns>Return Channel information list</returns>
        public List<ChannelInf> GetChannelsList()
        {
            return ChannelLists;
        }
    }

    class ChannelInf
    {
        public ChannelInf(string FFN, string DisplayName, string ChannelName, string Version, string CreatedTimeUTC, List<string> OldVersionList)
        {
            this.FFN = FFN;
            this.DisplayName = DisplayName;
            this.ChannelName = ChannelName;
            this.Version = Version;
            this.CreatedTimeUTC = CreatedTimeUTC;
            this.OldVersionList = OldVersionList;
        }
        public string FFN { get; set; }
        public string DisplayName { get; set; }
        public string ChannelName { get; }
        public string Version { get; set; }
        public string CreatedTimeUTC { get; set; }
        public List<string> OldVersionList { get; set; }
    }
}
