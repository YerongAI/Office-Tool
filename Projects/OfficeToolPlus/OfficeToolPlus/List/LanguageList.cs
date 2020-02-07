using System.Collections.Generic;

namespace OfficeTool.List
{
    // Language Information List
    // Copyright © 2020 蓝点网 | By Yerong | https://otp.landian.vip/
    // For more information please visit: https://docs.microsoft.com/en-us/DeployOffice/overview-of-deploying-languages-in-office-365-proplus#languages-culture-codes-and-companion-proofing-languages
    class LanguageList
    {
        private static readonly List<LangInfo> LangList = new List<LangInfo>(110);

        public LanguageList()
        {
            if (LangList.Count == 0)
            {
                LangInfo lang1 = new LangInfo("العربية (المملكة العربية السعودية)", "ar-sa", 1025, LanguageType.Full);
                LangInfo lang2 = new LangInfo("български (България)", "bg-bg", 1026, LanguageType.Full);
                LangInfo lang3 = new LangInfo("čeština (Česká republika)", "cs-cz", 1029, LanguageType.Full);
                LangInfo lang4 = new LangInfo("Dansk (Danmark)", "da-dk", 1030, LanguageType.Full);
                LangInfo lang5 = new LangInfo("Deutsch (Deutschland)", "de-de", 1031, LanguageType.Full);
                LangInfo lang6 = new LangInfo("Ελληνικά (Ελλάδα)", "el-gr", 1032, LanguageType.Full);
                LangInfo lang7 = new LangInfo("English (United States)", "en-us", 1033, LanguageType.Full);
                LangInfo lang8 = new LangInfo("Español (España, alfabetización internacional)", "es-es", 3082, LanguageType.Full);
                LangInfo lang9 = new LangInfo("Eesti (Eesti)", "et-ee", 1061, LanguageType.Full);
                LangInfo lang10 = new LangInfo("Suomi (Suomi)", "fi-fi", 1035, LanguageType.Full);
                LangInfo lang11 = new LangInfo("Français (France)", "fr-fr", 1036, LanguageType.Full);
                LangInfo lang12 = new LangInfo("עברית (ישראל)", "he-il", 1037, LanguageType.Full);
                LangInfo lang13 = new LangInfo("हिंदी (भारत)", "hi-in", 1081, LanguageType.Full);
                LangInfo lang14 = new LangInfo("Hrvatski (Hrvatska)", "hr-hr", 1050, LanguageType.Full);
                LangInfo lang15 = new LangInfo("Magyar (Magyarország)", "hu-hu", 1038, LanguageType.Full);
                LangInfo lang16 = new LangInfo("Bahasa Indonesia (Indonesia)", "id-id", 1057, LanguageType.Full);
                LangInfo lang17 = new LangInfo("Italiano (Italia)", "it-it", 1040, LanguageType.Full);
                LangInfo lang18 = new LangInfo("日本語 (日本)", "ja-jp", 1041, LanguageType.Full);
                LangInfo lang19 = new LangInfo("Қазақ (Қазақстан)", "kk-kz", 1087, LanguageType.Full);
                LangInfo lang20 = new LangInfo("한국어(대한민국)", "ko-kr", 1042, LanguageType.Full);
                LangInfo lang21 = new LangInfo("Lietuvių (Lietuva)", "lt-lt", 1063, LanguageType.Full);
                LangInfo lang22 = new LangInfo("Latviešu (Latvija)", "lv-lv", 1062, LanguageType.Full);
                LangInfo lang23 = new LangInfo("Bahasa Melayu (Malaysia)", "ms-my", 1086, LanguageType.Full);
                LangInfo lang24 = new LangInfo("Norsk, bokmål (Norge)", "nb-no", 1044, LanguageType.Full);
                LangInfo lang25 = new LangInfo("Nederlands (Nederland)", "nl-nl", 1043, LanguageType.Full);
                LangInfo lang26 = new LangInfo("Polski (Polska)", "pl-pl", 1045, LanguageType.Full);
                LangInfo lang27 = new LangInfo("Português (Brasil)", "pt-br", 1046, LanguageType.Full);
                LangInfo lang28 = new LangInfo("Português (Portugal)", "pt-pt", 2070, LanguageType.Full);
                LangInfo lang29 = new LangInfo("Română (România)", "ro-ro", 1048, LanguageType.Full);
                LangInfo lang30 = new LangInfo("русский (Россия)", "ru-ru", 1049, LanguageType.Full);
                LangInfo lang31 = new LangInfo("Slovenčina (Slovenská republika)", "sk-sk", 1051, LanguageType.Full);
                LangInfo lang32 = new LangInfo("Slovenščina (Slovenija)", "sl-si", 1060, LanguageType.Full);
                LangInfo lang33 = new LangInfo("Srpski (Srbija)", "sr-Latn-rs", 9242, LanguageType.Full);
                LangInfo lang34 = new LangInfo("Svenska (Sverige)", "sv-se", 1053, LanguageType.Full);
                LangInfo lang35 = new LangInfo("ไทย (ไทย)", "th-th", 1054, LanguageType.Full);
                LangInfo lang36 = new LangInfo("Türkçe (Türkiye)", "tr-tr", 1055, LanguageType.Full);
                LangInfo lang37 = new LangInfo("українська (Україна)", "uk-ua", 1058, LanguageType.Full);
                LangInfo lang38 = new LangInfo("Tiêng Việt (Việt Nam)", "vi-vn", 1066, LanguageType.Full);
                LangInfo lang39 = new LangInfo("简体中文 (中国)", "zh-cn", 2052, LanguageType.Full);
                LangInfo lang40 = new LangInfo("繁體中文 (台灣)", "zh-tw", 1028, LanguageType.Full);
                LangInfo lang41 = new LangInfo("Afrikaans", "af-za", 1078, LanguageType.Partial);
                LangInfo lang42 = new LangInfo("অসমীয়া", "as-in", 1101, LanguageType.Partial);
                LangInfo lang43 = new LangInfo("azərbaycan dili", "az-Latn-az", 1068, LanguageType.Partial);
                LangInfo lang44 = new LangInfo("বাংলা (বাংলাদেশ)", "bn-bd", 2117, LanguageType.Partial);
                LangInfo lang45 = new LangInfo("বাংলা", "bn-in", 1093, LanguageType.Partial);
                LangInfo lang46 = new LangInfo("bosanski", "bs-latn-ba", 5146, LanguageType.Partial);
                LangInfo lang47 = new LangInfo("Català", "ca-es", 1027, LanguageType.Partial);
                LangInfo lang48 = new LangInfo("Valencià", "ca-es-valencia", 2051, LanguageType.Partial);
                LangInfo lang49 = new LangInfo("Cymraeg", "cy-gb", 1106, LanguageType.Partial);
                LangInfo lang50 = new LangInfo("Euskara", "eu-es", 1069, LanguageType.Partial);
                LangInfo lang51 = new LangInfo("فارسی", "fa-ir", 1065, LanguageType.Partial);
                LangInfo lang52 = new LangInfo("Gaeilge", "ga-ie", 2108, LanguageType.Partial);
                LangInfo lang53 = new LangInfo("Gàidhlig", "gd-gb", 1169, LanguageType.Partial);
                LangInfo lang54 = new LangInfo("Galego", "gl-es", 1110, LanguageType.Partial);
                LangInfo lang55 = new LangInfo("ગુજરાતી", "gu-in", 1095, LanguageType.Partial);
                LangInfo lang56 = new LangInfo("Հայերեն", "hy-am", 1067, LanguageType.Partial);
                LangInfo lang57 = new LangInfo("íslenska", "is-is", 1039, LanguageType.Partial);
                LangInfo lang58 = new LangInfo("ქართული", "ka-ge", 1079, LanguageType.Partial);
                LangInfo lang59 = new LangInfo("ಕನ್ನಡ", "kn-in", 1099, LanguageType.Partial);
                LangInfo lang60 = new LangInfo("कोंकणी", "kok-in", 1111, LanguageType.Partial);
                LangInfo lang61 = new LangInfo("Кыргыз", "ky-kg", 1088, LanguageType.Partial);
                LangInfo lang62 = new LangInfo("Lëtzebuergesch", "lb-lu", 1134, LanguageType.Partial);
                LangInfo lang63 = new LangInfo("Reo Māori", "mi-nz", 1153, LanguageType.Partial);
                LangInfo lang64 = new LangInfo("Македонски", "mk-mk", 1071, LanguageType.Partial);
                LangInfo lang65 = new LangInfo("മലയാളം", "ml-in", 1100, LanguageType.Partial);
                LangInfo lang66 = new LangInfo("[मराठी]", "mr-in", 1102, LanguageType.Partial);
                LangInfo lang67 = new LangInfo("Malti", "mt-mt", 1082, LanguageType.Partial);
                LangInfo lang68 = new LangInfo("नेपाली", "ne-np", 1121, LanguageType.Partial);
                LangInfo lang69 = new LangInfo("nynorsk", "nn-no", 2068, LanguageType.Partial);
                LangInfo lang70 = new LangInfo("ଓଡିଆ", "or-in", 1096, LanguageType.Partial);
                LangInfo lang71 = new LangInfo("ਪੰਜਾਬੀ", "pa-in", 1094, LanguageType.Partial);
                LangInfo lang72 = new LangInfo("සිංහල", "si-lk", 1115, LanguageType.Partial);
                LangInfo lang73 = new LangInfo("Shqip", "sq-al", 1052, LanguageType.Partial);
                LangInfo lang74 = new LangInfo("српски", "sr-cyrl-ba", 7194, LanguageType.Partial);
                LangInfo lang75 = new LangInfo("српски", "sr-cyrl-rs", 10266, LanguageType.Partial);
                LangInfo lang76 = new LangInfo("Kiswahili", "sw-ke", 1089, LanguageType.Partial);
                LangInfo lang77 = new LangInfo("தமிழ்", "ta-in", 1097, LanguageType.Partial);
                LangInfo lang78 = new LangInfo("తెలుగు", "te-in", 1098, LanguageType.Partial);
                LangInfo lang79 = new LangInfo("Татар", "tt-ru", 1092, LanguageType.Partial);
                LangInfo lang80 = new LangInfo("اردو", "ur-pk", 1056, LanguageType.Partial);
                LangInfo lang81 = new LangInfo("o'zbekcha", "uz-Latn-uz", 1091, LanguageType.Partial);
                LangInfo lang82 = new LangInfo("አማርኛ", "am-et", 1118, LanguageType.PartialWithoutProofingTools);
                LangInfo lang83 = new LangInfo("Беларуская", "be-by", 1059, LanguageType.PartialWithoutProofingTools);
                LangInfo lang84 = new LangInfo("Filipino", "fil-ph", 1124, LanguageType.PartialWithoutProofingTools);
                LangInfo lang85 = new LangInfo("ភាសាខ្មែរ", "km-kh", 1107, LanguageType.PartialWithoutProofingTools);
                LangInfo lang86 = new LangInfo("Монгол хэл", "mn-mn", 1104, LanguageType.PartialWithoutProofingTools);
                LangInfo lang87 = new LangInfo("درى", "prs-af", 1164, LanguageType.PartialWithoutProofingTools);
                LangInfo lang88 = new LangInfo("Runasimi", "quz-pe", 3179, LanguageType.PartialWithoutProofingTools);
                LangInfo lang89 = new LangInfo("سنڌي", "sd-arab-pk", 2137, LanguageType.PartialWithoutProofingTools);
                LangInfo lang90 = new LangInfo("türkmen dili", "tk-tm", 1090, LanguageType.PartialWithoutProofingTools);
                LangInfo lang91 = new LangInfo("ئۇيغۇرچە", "ug-cn", 1152, LanguageType.PartialWithoutProofingTools);
                LangInfo lang92 = new LangInfo("Hausa", "ha-Latn-ng", 1128, LanguageType.ProofingTools);
                LangInfo lang93 = new LangInfo("Igbo", "ig-ng", 1136, LanguageType.ProofingTools);
                LangInfo lang94 = new LangInfo("Sesotho sa Leboa", "nso-za", 1132, LanguageType.ProofingTools);
                LangInfo lang95 = new LangInfo("پښتو", "ps-af", 1123, LanguageType.ProofingTools);
                LangInfo lang96 = new LangInfo("Rumantsch", "rm-ch", 1047, LanguageType.ProofingTools);
                LangInfo lang97 = new LangInfo("Kinyarwanda", "rw-rw", 1159, LanguageType.ProofingTools);
                LangInfo lang98 = new LangInfo("Setswana", "tn-za", 1074, LanguageType.ProofingTools);
                LangInfo lang99 = new LangInfo("Wolof", "wo-sn", 1160, LanguageType.ProofingTools);
                LangInfo lang100 = new LangInfo("isiXhosa", "xh-za", 1076, LanguageType.ProofingTools);
                LangInfo lang101 = new LangInfo("ede Yorùbá", "yo-ng", 1130, LanguageType.ProofingTools);
                LangInfo lang102 = new LangInfo("isiZulu", "zu-za", 1077, LanguageType.ProofingTools);
                LangList.Add(lang1);
                LangList.Add(lang2);
                LangList.Add(lang3);
                LangList.Add(lang4);
                LangList.Add(lang5);
                LangList.Add(lang6);
                LangList.Add(lang7);
                LangList.Add(lang8);
                LangList.Add(lang9);
                LangList.Add(lang10);
                LangList.Add(lang11);
                LangList.Add(lang12);
                LangList.Add(lang13);
                LangList.Add(lang14);
                LangList.Add(lang15);
                LangList.Add(lang16);
                LangList.Add(lang17);
                LangList.Add(lang18);
                LangList.Add(lang19);
                LangList.Add(lang20);
                LangList.Add(lang21);
                LangList.Add(lang22);
                LangList.Add(lang23);
                LangList.Add(lang24);
                LangList.Add(lang25);
                LangList.Add(lang26);
                LangList.Add(lang27);
                LangList.Add(lang28);
                LangList.Add(lang29);
                LangList.Add(lang30);
                LangList.Add(lang31);
                LangList.Add(lang32);
                LangList.Add(lang33);
                LangList.Add(lang34);
                LangList.Add(lang35);
                LangList.Add(lang36);
                LangList.Add(lang37);
                LangList.Add(lang38);
                LangList.Add(lang39);
                LangList.Add(lang40);
                LangList.Add(lang41);
                LangList.Add(lang42);
                LangList.Add(lang43);
                LangList.Add(lang44);
                LangList.Add(lang45);
                LangList.Add(lang46);
                LangList.Add(lang47);
                LangList.Add(lang48);
                LangList.Add(lang49);
                LangList.Add(lang50);
                LangList.Add(lang51);
                LangList.Add(lang52);
                LangList.Add(lang53);
                LangList.Add(lang54);
                LangList.Add(lang55);
                LangList.Add(lang56);
                LangList.Add(lang57);
                LangList.Add(lang58);
                LangList.Add(lang59);
                LangList.Add(lang60);
                LangList.Add(lang61);
                LangList.Add(lang62);
                LangList.Add(lang63);
                LangList.Add(lang64);
                LangList.Add(lang65);
                LangList.Add(lang66);
                LangList.Add(lang67);
                LangList.Add(lang68);
                LangList.Add(lang69);
                LangList.Add(lang70);
                LangList.Add(lang71);
                LangList.Add(lang72);
                LangList.Add(lang73);
                LangList.Add(lang74);
                LangList.Add(lang75);
                LangList.Add(lang76);
                LangList.Add(lang77);
                LangList.Add(lang78);
                LangList.Add(lang79);
                LangList.Add(lang80);
                LangList.Add(lang81);
                LangList.Add(lang82);
                LangList.Add(lang83);
                LangList.Add(lang84);
                LangList.Add(lang85);
                LangList.Add(lang86);
                LangList.Add(lang87);
                LangList.Add(lang88);
                LangList.Add(lang89);
                LangList.Add(lang90);
                LangList.Add(lang91);
                LangList.Add(lang92);
                LangList.Add(lang93);
                LangList.Add(lang94);
                LangList.Add(lang95);
                LangList.Add(lang96);
                LangList.Add(lang97);
                LangList.Add(lang98);
                LangList.Add(lang99);
                LangList.Add(lang100);
                LangList.Add(lang101);
                LangList.Add(lang102);
            }
        }

        /// <summary>
        /// Get other information by Language ID
        /// </summary>
        /// <param name="id">Language ID</param>
        /// <param name="language">Type of information</param>
        /// <returns></returns>
        public object GetInfByID(string id, LanguageInfo language)
        {
            foreach (LangInfo lang in LangList)
            {
                if (lang.ID.ToLower() == id.ToLower())
                    switch (language)
                    {
                        case LanguageInfo.Name:
                            return lang.Name;
                        case LanguageInfo.Num:
                            return lang.Num;
                        case LanguageInfo.Type:
                            return lang.Type;
                    }
            }
            return null;
        }

        /// <summary>
        /// Return the list of Language information
        /// </summary>
        /// <returns></returns>
        public List<LangInfo> GetList()
        {
            return LangList;
        }
    }

    class LangInfo
    {
        /// <summary>
        /// Language Info Record
        /// </summary>
        /// <param name="Name">Language name</param>
        /// <param name="ID">Language ID</param>
        /// <param name="Num">Language number</param>
        /// <param name="Type">Language type</param>
        public LangInfo(string Name, string ID, int Num, LanguageType Type)
        {
            this.Name = Name;
            this.ID = ID;
            this.Num = Num;
            this.Type = Type;
        }

        public string Name { get; }
        public string ID { get; }
        public int Num { get; }
        public LanguageType Type { get; }
    }

    /// <summary>
    /// Language Info Type
    /// </summary>
    public enum LanguageInfo
    {
        Name = 0,
        Num = 1,
        Type = 2
    }

    /// <summary>
    /// Language Type
    /// </summary>
    enum LanguageType
    {
        Full = 0,
        Partial = 1,
        PartialWithoutProofingTools = 2,
        ProofingTools = 3,
    }
}