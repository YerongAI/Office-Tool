# Office Tool Plus

[English](/README.md) | [简体中文](/README-zh_cn.md) | [繁體中文](/README-zh_tw.md) | 한국어 | [Italiano](/README-it_it.md) | [ไทย/Thai](/README-th_th.md) | [polski](/README-pl_pl.md) | [Brazilian Portuguese](/README-pt_br.md)

Office Tool Plus는 하나의 Office 관리, 다운로드와 설치 보조 툴입니다.

Office Tool Plus는 마이크로소프트 Office Deployment Tool를 기반으로 만들고 사용자에게 빠르고 편한 Office배포 기능을 제공합니다.

Office Tool Plus가 기 존재 Office( Click To Run방식만 한정)를 변경, 단독제품을 제거하거나 언어 패키지 추가도 가능합니다.

## Office Tool Plus 다운로드

[공식 사이트](https://otp.landian.vip/)

[다운로드 사이트](https://delivery.yuntu.dev/office-tool/) by [Yuntu](https://www.yuntu.dev/)

## 기술설명서

[설정 옵션 설명](https://docs.microsoft.com/ko-kr/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

## 간단설명서

먼저 Office 설치파일을 다운로드 완료후 설치 진행하는 것이 권장합니다.

Office Tool Plus열린후 다운로드 페이지에 이동하고 시작 버튼을 누르면 설치파일 다운로드하기가 바로 진행합니다.

다운로드 완료후 설치 페이지에 이동하고 설치할 제품을 선택해서 시작 버튼을 누러 설치 진행합니다. 기존설치제품은 Word, PowerPoint와 Excel입니다.

설치 완료후 유효한 라이선스가 있어야 Office정품인정을 받을 수 있습니다.

## 응용프로그램의 법률 관련사항

Office Tool Plus는 마이크로소프트의[Office Deployment Tool](https://docs.microsoft.com/zh-cn/DeployOffice/overview-of-the-office-customization-tool-for-click-to-run)를 기반으로 만들고 추가기능을 통해서 사용자에게 더 편한 Office배포 경험을 제공합니다.

**통역자 추가 주의사항: 중국 이외의 다른 국가 및 지역의 사용자 분들이 해당 국가 및 지역의 관련 법률을 준수하여 사용하십시오

### 정품인정 모듈에 관한 사항

정품인정 모듈이 마이크로소프트의 ospp.vbs (Office Software Protect Platform)를 기반으로 만들고 모든 정품인정 조치가 ospp.vbs로 진행합니다. 사용자들에게 더 확실하게 OSPP를 이해하도록 변역도(zh-ch, zh-tw) 진행합니다.

````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"````에서 OSPP조치 설명을 확인할 수 있습니다(Office를 먼저 설치 해야함).

## 협력자 감사합니다

### Thanks to the collaborators

- Portuguese (Brazil) / [Hélio de Souza](https://sway.office.com/RVue6qySNJ2DzYrs?ref=Link)
- Polish (Poland) / JakubDriver
- Korean (Korea) / [Jay Jang](https://github.com/yaeyaya)
- Traditional Chinese (Taiwan) / [Yi Chi](https://github.com/chiyi4488)
- English (United States) / [Moedog](https://prprpr.love)

## 현지화(로컬리제이션) 도움 요청

누구나도 응용프로그램의 현지화 참여 할 수 있도록 다음과 같은 설명을 드립니다.

1. 이 리포지토리 포크함(Fork this repository)

2. (예) 파일````zh-cn.xaml````를 변역해서 ````zh-tw.xaml````로 저장함

3. (예) 정확한 경로 ````OfficeToolPlus/Language/zh-tw.xaml````로 복사함

4. 풀 요청함(Make a Pull Request)

### 변역파일 테스트

1. 변역파일을 ````D:\Date\zh-cn.xaml```` 같은 경로에 저장함
2. Office Tool Plus를 실행함
3. 설정 페이지에 이동해서 ````Load localization file````을 클릭함
4. 저장한 변역파일을 선택함

문제 없으면 응용프로그램이 선택된 언어 리소스 파일을 로드할 겁니다. 새 변역을 추가하면 Office Tool Plus가 서버에 연결하지 못 하는 메시지 표시할 수 있지만 이 현상은 정상입니다. 변역을 확인후 저희는 서버 새설정할 겁니다.

### 더 많은 정보

저희는 변역자마다 Admin응용프로그램을 제공합니다. 번역자가 이 으용프로그램을 통해서 공지사항, 배경화면과 설명내용 등 정보를 간편하게 수정할 수 있습니다.
**[이메일](mailto:yerong@coolhub.top)로 신청하면 됩니다.

## 같이 코딩하자

코딩에 관심이 있으면 이 리포지토리를 포크하고 같이 코딩하세요. 코딩 완료되면 풀 요청(Pull Request)하고 변경내용, 사용방법과 변경원인 등 정보를 비고로 추가하면 됩니다.

모든 참여자에게 진심으로 감사 드리겠습니다.

주의:
힛허브에서 전제코드가 아닌 일부만 제공해서 VS Code등 코드 편집기민으로 코딩하고 CS테스트 완료후 제출할 수 있습니다. 저희는 받은 코드를 다시 테스트할 겁니다. 버그수정, 성능향상, 기능추가 등 개선을 제공해주셔서 감사합니다.

사용허락:
저희의 코드를 사용하려면 먼저 허락을 받아야합니당~
