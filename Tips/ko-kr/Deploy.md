# 배포에 관한 정보

이 페이지에서 설치됨 오피스 제품과 언어 패키지를 관리하고 새로운 설치하기도 진행할 수 있습니다.

채널 버전 정보에서 각각 채널의 버전과 배포 날짜를 조회가능합니다. 그리고 다운로드와 설치 할 때 버전을 지정할 수 있습니다. 지정하지 않으면 최신 버전을 선택합니다.

**주의: 시스템 파티션에서만 오피스를 설치될 수 있는 제약은 마이크로소프트가 규정합니다.**

## 내용

---

1. 설치 모듈
2. 채널 설정
3. 프레시 설치
4. 제품/언어 피키지 추가/제거
5. Office 365 제품 아이디
6. 설치 파일
7. 설치 파일 다운로드
8. 오피스 완경설정

## 설치 모듈

---

Office Deployment Tool는 마이크로소프트 공식 오피스 배포 툴이고 Office Tool Plus는 그의 파라미터들을 거의 다 지원합니다.
Office Tool Plus 모듈은 오피스 설치하기에 도음을 제공합니다. Office Deployment Tool보다 기능이 간단하지만 더 간단한 방법으로 오피스를 설치하는 기능을 제공합니다.

[Office Deployment Tool 공식 사이트](https://aka.ms/ODT)

[Office Deployment Tool 환경설정 옵션](https://docs.microsoft.com/ko-kr/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office Customization Tool](https://config.office.com/deploymentsettings)

**왼도우7에서 오피스2019를 설치하려면 모듈을 Office Tool Plus로 바꿔주세요!**

`주의: Office Deployment Tool로 설치할 때 문제가 발생하면 모듈을 Office Tool Plus로 바꿔주세요!`

## 채널 설정

---

`Office, Visio, Project 2019 [Volume]가 Office 2019 Perpetual Enterprise 채널만 지원하고 다른 제품(Office 365 등)과 동시 설치할 수 없습니다.`
Office 365 이미 설치된 환경에서 Visio를 설치하려면 Visio 2016 Retail/Volume나 Visio 2019 Retail를 선택하세요. (Project는 같습니다)

Office 2016/2019 [Retail]/365는 다른 채널을 선택할 수 있습니다(Office 2019 Perpetual Enterprise 채널 제외). Monthly채널 추천하고 새로나온 기능에 관심없는 사용자가 Semi-Annual 채널을 선택하는 것이 좋습니다. **Targeted/Insider/Dogfood채널을 사용시 문제가 발생하면 사용자가 스스로 해결하야합니다.**

## 프레시 설치

---

시작하기 전에 채널 설정 절을 보는 것이 좋습니다.

[+제품추가] 버튼을 누르고 제품을 선택합니다. Office/Visio일 경우 원하지 않는 앱을 선택취소도 가능합니다. ***(Groove는 OneDrive for Business, Lync는 Skype for Business)*

[+언어추가] 버튼을 누르고 설치하려 언어를 선택합니다. 언어를 지정하지 않으면 해당 시시템 언어와 동일하게 자동으로 설정합니다. 자동설정 실패하면 [en-us]- 영어(미국)을 설정합니다.

그 다음에 [Office배포]버튼을 누르고 시작합시다.

`주의: 수동적으로 언어 패키지를 선택했으면 최소 한 개의 [Full]형 언어 패키지를 선택하야합니다.`

## 제품/언어 피키지 추가/제거

---

Office Tool Plus가 이미 설치된 Office의 제품과 언어도 추가하고 제거할 수 있습니다.

### 제품/언어 추가

[+제품추가]/[+언어추가] 버튼을 누르고 선택하면 됩니다.

`주의: 문제 발생하지 않도록 이미 설치된 제품과 언어를 선택하지 마세요`

### 제품 변경

어떤 제품의 및 개의 앱들 중의 하나를 제거하려면 그 제품을 먼저 선택한 다음에 그 앱을 선택취소하고 [Office배포] 버튼을 누르면 됩니다. 예를 들어, 설치된 제품 Office 365의 Word, Excel, Outlook 등 중의 Word를 제거하기

### 제품/언어 제거

제거하려는 제품이나 언어 패키지를 선택하고 [Office배포] 버튼의 자 메뉴 "선택된 제품이나 언어 패키지 제거"를 클릭해서 시작합니다.

## Office 365 제품 아이디

---

```txt
Office 365 ProPlus		O365ProPlusRetail
Office 365 Enterprise E3		O365ProPlusRetail
Office 365 Enterprise E4		O365ProPlusRetail
Office 365 Enterprise E5		O365ProPlusRetail
Office 365 Midsize		O365ProPlusRetail
Office 365 Business		O365BusinessRetail
Office 365 Business Premium	O365BusinessRetail
Office Small Business Premium	O365SmallBusPremRetail
Office 365 Home			O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

상에정본는 마이크로소프트 공식 사이트에 참조하세요. [Office Deployment Tool for Click-to-Run 지원하는 제품 아이디](https://docs.microsoft.com/ko-kr/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## 설치 파일

---

설치 파일은 Office의 설피 패키지입니다. Office Tool Plus가 마이크로소프트 서버에서 Office설치 파일을 다운로드해서 ISO이미지를 생성할 수 있습니다. 다운로드 완료후 오프라인 설치도 진행할 수 있고 다른 사용자들에게 공유해서 시간과 네크워크 절약도 할 수 있습니다.

채널이 어떤 버전을 설치할 수 있는지 결정합니다. 그래서 채널 설정 절을 보는 것이 좋습니다.

설치 파일 관리 페이지에서 자메뉴 "설치 파일 다운로드"를 클릭해서 시작합니다. 사용자 정의 설정이나 Office Tool Plus 기본 설정으로 시작할 수 있으며 시작 버튼을 누르고 다운로드 시작합니다.

![설치 파일 다운로드(중국어 캡쳐 이미지)](https://server.coolhub.top/OfficeTool/images/en-us/DownloadPanel.png)

### 더 많는 정보

[Office 365 ProPlus의 업데이트 채널 개요](https://docs.microsoft.com/ko-kr/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Office 365 ProPlus에 대한 업데이트 기록](https://docs.microsoft.com/en-us/officeupdates/update-history-office365-proplus-by-date)

[Office 2019 업데이트 채널](https://docs.microsoft.com/ko-kr/DeployOffice/office2019/update#update-channel-for-office-2019)

## 설치 파일 다운로드

---

더 빨은 다운로드 속도 제공하기 위해 Office Deployment Tool의 기본 다운로드 기능에 Thuner(중국에 유행하는 다운로드 도구)추가됩니다. 기본 기능상 참이점이 없지만 `Thuner만 다운로드 진적, 속도 제한과 프록시 등 기능을 지원합니다.` Thunder 사용시 문제가 발생하면 Office Deployment Tool으로 바꿔주세요.

### Thunder 속도 제한 설정

Thunder로 다운로드할 때 속도 제한하려면 다운로드 속드를 클릭해서 열린 창에서 제한 속드를 설정하면 됩니다. 속드 제한을 해제하려면 0으로 설정하면 됩니다.

## 오피스 완경설정

---

`배포 페이지 우측에서 Office 환경 설정 패널을 호출할 수 있습니다.`
Office Tool Plus가 Office 업데이트 채널과 소유자 이름을 수정 기능을 지원합니다. 수정 완료 후 [저장] 버튼을 누르고 발로 적용됩니다.

Office사용시 문제 발생하면 여기서 복원도 할 수 있습니다.

**주의: [새로고침]을 클릭하면 제품과 언어 패키지 리스크가 새로고침하고 일부 설정내용가 초기화될 겁니다.**
