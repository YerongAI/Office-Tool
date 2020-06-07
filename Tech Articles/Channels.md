# Office Update Channels Information

For information of update channels for Microsoft 365 Apps, please visit [the article](https://docs.microsoft.com/en-us/deployoffice/overview-update-channels).

For information of update channel for Office 2019, please visit [the article](https://docs.microsoft.com/en-us/deployoffice/office2019/update#update-channel-for-office-2019).

For information about Office Click-To-Run, please [visit the website](https://mrodevicemgr.officeapps.live.com/mrodevicemgrsvc/api/v2/C2RReleaseData).

## Update Channels List

| Branch | FFN | Channel Name | Verified | Last Verification |
| :---- | :---- | :---- | :---: | :---: |
Production::LTSC | f2e724c1-748f-4b47-8fb8-8e0d210e9208 | Office 2019 Perpetual Enterprise Channel | ✔ | 05/28/2020 |
Production::DC | 7ffbc6bf-bc32-4f92-8982-f9dd17fd3114 | Semi-annual Channel | ✔ | 05/28/2020 |
Production::MEC | 55336b82-a18d-4dd6-b5f6-9e5095c314a6 | Monthly Enterprise Channel | ✔ | 05/28/2020 |
Production::CC | 492350f6-3a01-4f97-b9c0-c7c6ddf67d60 | Monthly Channel | ✔ | 05/28/2020 |
Insiders::LTSC | 2e148de9-61c8-4051-b103-4af54baffbb4 | Office 2019 Perpetual Enterprise Channel (Insiders) | ✔ | 05/28/2020 |
Insiders::FRDC | b8f9b850-328d-4355-9145-c59439a0c4cf | Semi-annual Channel (Targeted) | ✔ | 05/28/2020 |
Insiders::CC | 64256afe-f5d9-4f86-8936-8840a6a4f5be | Monthly Channel (Targeted) | ✔ | 05/28/2020 |
Insiders::DevMain | 5440fd1f-7ecb-4221-8110-145efaa6372f | Beta Channel | ✔ | 05/28/2020 |
Microsoft::LTSC | 1d2d2ea6-1680-4c56-ac58-a441c8c24ff | Office 2019 Perpetual Enterprise Channel (Microsoft) | ✔ | 05/28/2020 |
Microsoft::DC | f4f024c8-d611-4748-a7e0-02b6e754c0fe | Semi-annual Channel (Microsoft) | ✔ | 05/28/2020 |
Microsoft::FRDC | 9a3b7ff2-58ed-40fd-add5-1e5158059d1c | Semi-annual Channel (Targeted) (Microsoft) | ✔ | 05/28/2020 |
Microsoft::CC | 5462eee5-1e97-495b-9370-853cd873bb07 | Beta Channel | ✔ | 05/28/2020 |
Microsoft::DevMain | b61285dd-d9f7-41f2-9757-8f61cba4e9c | Microsoft Elite (Microsoft) | ✔ | 05/28/2020 |
Dogfood::DCEXT | c4a7726f-06ea-48e2-a13a-9d78849eb706 | Semi-annual Channel (Dogfood) | ✔ | 05/28/2020 |
Dogfood::FRDC | 834504cc-dc55-4c6d-9e71-e024d0253f6d | Semi-annual Channel (Targeted) (Dogfood) | ✔ | 05/28/2020 |
Dogfood::CC | f3260cf1-a92c-4c75-b02e-d64c0a86a968 | Beta Channel | ✔ | 05/28/2020 |
Dogfood::DevMain | ea4a4090-de26-49d7-93c1-91bff9e53fc3 | Beta Channel | ✔ | 05/28/2020 |

## How to verify information?

Please make sure you have already upgrade Office to selected channel.

### For branch

Open Registry Editor, go to `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun\Configuration`, check the value of `AudienceData`.

### For channel name

Open Office application, go to `Account` page and you can see the channel name.