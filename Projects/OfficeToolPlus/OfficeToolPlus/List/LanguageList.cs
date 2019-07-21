using System.Collections.Generic;

namespace OTP.List
{
    //Copyright © 2019 Landiannews |By Yerong | https://otp.landian.vip/
    class LanguageList
    {
        // For more information please visit: https://docs.microsoft.com/en-us/DeployOffice/overview-of-deploying-languages-in-office-365-proplus#languages-culture-codes-and-companion-proofing-languages
        private readonly List<List> LangList = new List<List>(100);
        public LanguageList()
        {
            List lang1 = new List("العربية (المملكة العربية السعودية)", "ar-sa", 1025, "Full");
            List lang2 = new List("български (България)", "bg-bg", 1026, "Full");
            List lang3 = new List("简体中文 (中国)", "zh-cn", 2052, "Full");
            List lang4 = new List("繁體中文 (台灣)", "zh-tw", 1028, "Full");
            List lang5 = new List("hrvatski (Hrvatska)", "hr-hr", 1050, "Full");
            List lang6 = new List("čeština (Česká republika)", "cs-cz", 1029, "Full");
            List lang7 = new List("dansk (Danmark)", "da-dk", 1030, "Full");
            List lang8 = new List("Nederlands (Nederland)", "nl-nl", 1043, "Full");
            List lang9 = new List("English (United States)", "en-us", 1033, "Full");
            List lang10 = new List("eesti (Eesti)", "et-ee", 1061, "Full");
            List lang11 = new List("suomi (Suomi)", "fi-fi", 1035, "Full");
            List lang12 = new List("français (France)", "fr-fr", 1036, "Full");
            List lang13 = new List("Deutsch (Deutschland)", "de-de", 1031, "Full");
            List lang14 = new List("Ελληνικά (Ελλάδα)", "el-gr", 1032, "Full");
            List lang15 = new List("עברית (ישראל)", "he-il", 1037, "Full");
            List lang16 = new List("हिंदी (भारत)", "hi-in", 1081, "Full");
            List lang17 = new List("magyar (Magyarország)", "hu-hu", 1038, "Full");
            List lang18 = new List("Bahasa Indonesia (Indonesia)", "id-id", 1057, "Full");
            List lang19 = new List("italiano (Italia)", "it-it", 1040, "Full");
            List lang20 = new List("日本語 (日本)", "ja-jp", 1041, "Full");
            List lang21 = new List("Қазақ (Қазақстан)", "kk-kz", 1087, "Full");
            List lang22 = new List("한국어(대한민국)", "ko-kr", 1042, "Full");
            List lang23 = new List("latviešu (Latvija)", "lv-lv", 1062, "Full");
            List lang24 = new List("lietuvių (Lietuva)", "lt-lt", 1063, "Full");
            List lang25 = new List("Bahasa Melayu (Malaysia)", "ms-my", 1086, "Full");
            List lang26 = new List("norsk, bokmål (Norge)", "nb-no", 1044, "Full");
            List lang27 = new List("polski (Polska)", "pl-pl", 1045, "Full");
            List lang28 = new List("português (Brasil)", "pt-br", 1046, "Full");
            List lang29 = new List("português (Portugal)", "pt-pt", 2070, "Full");
            List lang30 = new List("română (România)", "ro-ro", 1048, "Full");
            List lang31 = new List("русский (Россия)", "ru-ru", 1049, "Full");
            List lang32 = new List("srpski (Srbija)", "sr-latn-rs", 9242, "Full");
            List lang33 = new List("slovenčina (Slovenská republika)", "sk-sk", 1051, "Full");
            List lang34 = new List("slovenščina (Slovenija)", "sl-si", 1060, "Full");
            List lang35 = new List("español (España, alfabetización internacional)", "es-es", 3082, "Full");
            List lang36 = new List("svenska (Sverige)", "sv-se", 1053, "Full");
            List lang37 = new List("ไทย (ไทย)", "th-th", 1054, "Full");
            List lang38 = new List("Türkçe (Türkiye)", "tr-tr", 1055, "Full");
            List lang39 = new List("українська (Україна)", "uk-ua", 1058, "Full");
            List lang40 = new List("Tiếng Việt (Việt Nam)", "vi-vn", 1066, "Full");
            List lang41 = new List("Afrikaans (Suid-Afrika)", "af-za", 1078, "Partial");
            List lang42 = new List("Shqip (Shqipëria)", "sq-al", 1052, "Partial");
            List lang43 = new List("Հայերեն (Հայաստան)", "hy-am", 1067, "Partial");
            List lang44 = new List("অসমীয়া (ভাৰত)", "as-in", 1101, "Partial");
            List lang45 = new List("Azərbaycan dili (Azərbaycan)", "az-Latn-az", 1068, "Partial");
            List lang46 = new List("বাংলা (বাংলাদেশ)", "bn-bd", 2117, "Partial");
            List lang47 = new List("বাংলা (ভারত)", "bn-in", 1093, "Partial");
            List lang48 = new List("euskara (euskara)", "eu-es", 1069, "Partial");
            List lang49 = new List("bosanski (Bosna i Hercegovina)", "bs-latn-ba", 5146, "Partial");
            List lang50 = new List("Català (Català)", "ca-es", 1027, "Partial");
            List lang51 = new List("Valencià (Espanya)", "ca-es-valencia", 2051, "Partial");
            List lang52 = new List("galego (galego)", "gl-es", 1110, "Partial");
            List lang53 = new List("ქართული (საქართველო)", "ka-ge", 1079, "Partial");
            List lang54 = new List("ગુજરાતી (ભારત)", "gu-in", 1095, "Partial");
            List lang55 = new List("íslenska (Ísland)", "is-is", 1039, "Partial");
            List lang56 = new List("Gaeilge (Éire)", "ga-ie", 2108, "Partial");
            List lang57 = new List("ಕನ್ನಡ (ಭಾರತ)", "kn-in", 1099, "Partial");
            List lang58 = new List("Kiswahili (Kenya)", "sw-ke", 1089, "Partial");
            List lang59 = new List("कोंकणी (भारत)", "kok-in", 1111, "Partial");
            List lang60 = new List("Кыргыз (Кыргызстан)", "ky-kg", 1088, "Partial");
            List lang61 = new List("Lëtzebuergesch (Lëtzebuerg)", "lb-lu", 1134, "Partial");
            List lang62 = new List("македонски јазик (Македонија)", "mk-mk", 1071, "Partial");
            List lang63 = new List("മലയാളം (ഭാരതം)", "ml-in", 1100, "Partial");
            List lang64 = new List("Malti (Malta)", "mt-mt", 1082, "Partial");
            List lang65 = new List("Reo Māori (Aotearoa)", "mi-nz", 1153, "Partial");
            List lang66 = new List("मराठी (भारत)", "mr-in", 1102, "Partial");
            List lang67 = new List("नेपाली (नेपाल)", "ne-np", 1121, "Partial");
            List lang68 = new List("norsk, nynorsk (Noreg)", "nn-no", 2068, "Partial");
            List lang69 = new List("ଓଡ଼ିଆ (ଭାରତ)", "or-in", 1096, "Partial");
            List lang70 = new List("فارسى (ایران)", "fa-ir", 1065, "Partial");
            List lang71 = new List("ਪੰਜਾਬੀ (ਭਾਰਤ)", "pa-in", 1094, "Partial");
            List lang72 = new List("Gàidhlig (An Rìoghachd Aonaichte)", "gd-gb", 1169, "Partial");
            List lang73 = new List("српски (Босна и Херцеговина)", "sr-cyrl-ba", 7194, "Partial");
            List lang74 = new List("српски (Србија)", "sr-cyrl-rs", 10266, "Partial");
            List lang75 = new List("සිංහල (ශ්‍රී ලං", "si-lk", 1115, "Partial");
            List lang76 = new List("தமிழ் (இந்தியா)", "ta-in", 1097, "Partial");
            List lang77 = new List("Татар (Россия)", "tt-ru", 1092, "Partial");
            List lang78 = new List("తెలుగు (భారత దే", "te-in", 1098, "Partial");
            List lang79 = new List("اُردو (پاکستان", "ur-pk", 1056, "Partial");
            List lang80 = new List("O'zbekcha (O'zbekiston Respublikasi)", "uz-Latn-uz", 1091, "Partial");
            List lang81 = new List("Cymraeg (Y Deyrnas Unedig)", "cy-gb", 1106, "Partial");
            List lang82 = new List("Hausa (Nijeriya)", "ha-Latn-ng", 1128, "Proofing");
            List lang83 = new List("Sesotho sa Leboa (Afrika Borwa)", "ig-ng", 1132, "Proofing");
            List lang84 = new List("isiXhosa (uMzantsi Afrika)", "xh-za", 1076, "Proofing");
            List lang85 = new List("isiZulu (iNingizimu Afrika)", "zu-za", 1077, "Proofing");
            List lang86 = new List("Kinyarwanda (Rwanda)", "rw-rw", 1159, "Proofing");
            List lang87 = new List("پښتو (افغانستان)", "ps-af", 1123, "Proofing");
            List lang88 = new List("Rumantsch (Svizra)", "rm-ch", 1047, "Proofing");
            List lang89 = new List("Sesotho sa Leboa (Afrika Borwa)", "nso-za", 1132, "Proofing");
            List lang90 = new List("Setswana (Aforika Borwa)", "tn-za", 1074, "Proofing");
            List lang91 = new List("Wolof (Senegaal)", "wo-sn", 1160, "Proofing");
            List lang92 = new List("Yoruba (Nigeria)", "yo-ng", 1130, "Proofing");
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
        }

        /// <summary>
        /// 根据语言标识符获取其他信息
        /// </summary>
        /// <param name="id">语言标识符</param>
        /// <param name="language">要获取的信息，以 object 类型返回</param>
        /// <returns></returns>
        public object GetInfByID(string id, LanguageType language)
        {
            for (int i = 0; i < LangList.Count; i++)
            {
                if (LangList[i].ID == id)
                {
                    switch (language)
                    {
                        case LanguageType.Name:
                            return LangList[i].Name;
                        case LanguageType.Num:
                            return LangList[i].Num;
                        case LanguageType.Type:
                            return LangList[i].Type;
                    }
                }
            }
            return null;
        }

        public List<string> GetIDs()
        {
            List<string> vs = new List<string>(100);
            for (int i = 0; i < LangList.Count; i++)
            {
                vs.Add(LangList[i].ID);
            }
            return vs;
        }
    }

    class List
    {
        /// <summary>
        /// 语言信息列表
        /// </summary>
        /// <param name="Name">语言名称</param>
        /// <param name="ID">语言标识符</param>
        /// <param name="Num">语言标识码</param>
        /// <param name="Type">语言类型</param>
        public List(string Name, string ID, int Num, string Type)
        {
            this.Name = Name;
            this.ID = ID;
            this.Num = Num;
            this.Type = Type;
        }

        public string Name { get; }
        public string ID { get; }
        public int Num { get; }
        public string Type { get; }
    }

    /// <summary>
    /// 语言列表数据类型
    /// </summary>
    public enum LanguageType
    {
        Name = 0,
        Num = 1,
        Type = 2
    }
}