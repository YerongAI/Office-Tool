## Office 배포 가이드

---

이미 설치된 Office 제품과 언어 패키지를 관리 할 수 있습니다. Office 미 설치하면 새로 설치 진행할겁니다. **마이크로소프트사의 제한에 따라 Office가 시스템 파티션에서만 설치할 수 있습니다.** 

응용프로그램들 중에서 ***Lync*** 는 ***Skype for Business***, ***Groove*** 는 ***OneDrive for Business*** 입니다.

다운로드 모드에서 사용자 정의한 Office 설치 파일 저장 경로를 시정하려면 ***설치 설정*** 에서 ***소스 경로*** 를 수정하면됩니다.

### 목록

---

1. 배포 모드 가이드
2. 채널 가이드
3. 설치 모듈 가이드
4. 더 많은 정보

### 배포 모드 가이드

---

새로 설치는 Office 미 설치된 PC에서 Office를 배포하는 의미입니다. 수정 설치는 Office 설치된 PC에서 Office를 배포하는 의미입니다.

수정 설치는 제품과 언어 패키지를 추가/제거하는 것 뿐만 아니라 응용프로그램 추가/제거도 할 수 있습니다. 배포 시작을 누르고 변경된 사항을 기존된 Office에서 적용할겁니다.\

#### 다운로드하는 동시에 설치 진행하기

이 모드가 새로 설치와 수정 설치 두 가지 방식을 지원됩니다. 필요한 파일만 다운로드하고 네트워크 상태가 좋지 않으면 예상 시간이 길어질 수 도 있고 설치 실패도 가능합니다. `수정 설치 시 이 모드가 권장합니다.`

#### 다운로드 완료 후 설치 진행하기

이 모드가 새로 설치와 수정 설치 두 가지 방식을 지원됩니다. 지정된 경로에서 Office 설치 파일을 전체 다운로드하고 선택된 설치 모듈 수량이 적으면 부 필요한 네트워크를 사용할겁니다. `새로 설치 시 이 모드가 권장합니다.`

#### 기존 설치 소스 사용하기

이 모드가 새로 설치와 수정 설치 두 가지 방식을 지원됩니다. 기존 설치 소스 사용할 때 Office 설치 파일 중에서 임의 CAB 파일을 반드시 시정해야합니다. 그리고 Office ISO파일을 먼저 탑재해야 CAB파일을 볼 수 있습니다. 사용자가 설치 파일을 선택하지 않으면 설치 시작할 때는 자동으로 다운로드하는 동시에 설치 진행하는 모드로 전환할겁니다.

#### ISO 파일 생성하기

Office 설치 파일이 다운로드 완료된 상태하고 Office 설치 파일과 Office Tool Plus가 동일 경로에 있어야 ISO 파일을 생성할 수 있습니다.

`ISO 파일 생성하기 전에 Office 설치 환경설정 진행했으면 ISO 파일 생성하는 동시에 Configuration.xml 파일을 같이 생성됩니다. ISO 모든에서 Office Tool Plus를 시작할 때 사용자한테 Office 설치를 즉시 시작하냐고 확인할겁니다.`

#### 다운로드만 

이 모드에서는 Office 설치 파일 다운로드하기만 하고 Office 배포하지 않을겁니다.
`이 모드에서 최소 한개의 언어 패키지를 선택해야합니다. 않으면 일부 파일이 다운로드되지 않을겁니다.`

#### 환경설정만 진행하기

이 모도가 환경설정만 하고 XML 파일을 생성하며 해당 PC에서 기존된 Office를 수정하지 않습니다.

### 채널 가이드

---

`Office 2019 언터프라이즈 장기 버전:`

Office 2019 볼륨 버전 전용 채널입니다.

**기능 업데이트:** 없음
 
**보안 업데이트:** 한 달에 한번씩, 매월 2번째 화요일

`현재 채널(기본값):`

**기능 업데이트:** 새 기능 준비되면 바로 업데이트 가능(약 한달에 한번씩), 특정 플랜 없음

**보안 업데이트:** 한 달에 한번씩, 매월 2번째 화요일

`반기단위 채널:`

**기능 업데이트:** 매년 두번씩(1월과 7월), 매월 2번째 화요일

**보안 업데이트:** 한 달에 한번씩, 매월 2번째 

주의: 저희는 모든 사용자가 미리보기 채널을 사용하지 않을 것을 권장합니다. 상세한 정보를 알아보려면 마지막의 린크에 따라 마이크로소프트사의 공식 설명서를 참고하세요.

### 모듈 설치 가이드

---

Office 배포 툴은 마으크로소프트사 개발된 Office 배포용 도구입니다.

Office Tool Plus 모듈은 저희 개발된 설치 모듈입니다. 기능상에는 Office 배포 툴과 보다 부족해지만 Office 설치 기능도 지원합니다.

#### Office Tool Plus 모듈에서 지원되지 않는 기능

- 기록 옵션 설정 지원되지 않음
- 환경설정 관리기 설정 지원되지 않음
- 엡데이트 마감 시간 설정 지원되지 않음
- 체제 구조 이동 지원되지 않음
- 강제 업데이트 지원되지 않음
- 기존 MSI 버전의 Office 제거 지원되지 않음
- 기존 MSI 버전의 Office와 동일한 언어 설치 지원되지 않음

주의: **전체 설치 기능을 원하면 Office 배포 툴을 사용하세요.***

### 더 많은 정보를 찾고 싶다면 아래 사이트에 참고하세요

---

[Office 배포 툴 공식 사이트](https://aka.ms/ODT)

[Office 배포 툴 환경설정 옵션](https://docs.microsoft.com/ko-kr/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office 배포 툴 지원되는 제품 ID](https://docs.microsoft.com/ko-kr/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Microsoft 365 앱의 업데이트 채널 가이드](https://docs.microsoft.com/ko-kr/deployoffice/overview-update-channels)

[Microsoft 365 앱의 업데이트 기로](https://docs.microsoft.com/ko-kr/officeupdates/update-history-microsoft365-apps-by-date)

[Office 2019 업데이트 채널 가이드](https://docs.microsoft.com/ko-kr/DeployOffice/office2019/update#update-channel-for-office-2019)
