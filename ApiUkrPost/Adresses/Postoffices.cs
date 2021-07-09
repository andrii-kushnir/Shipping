using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class Postoffice
    {
        [JsonProperty("POLOCK_EN")]
        public string POLOCKEN { get; set; }

        [JsonProperty("TYPE_SHORT")]
        public string TYPESHORT { get; set; }

        [JsonProperty("CITY_RU")]
        public string CITYRU { get; set; }

        [JsonProperty("POREGION_ID")]
        public string POREGIONID { get; set; }

        [JsonProperty("SHORTPDCITYTYPE_RU")]
        public string SHORTPDCITYTYPERU { get; set; }

        [JsonProperty("DISTRICT_EN")]
        public string DISTRICTEN { get; set; }

        [JsonProperty("PDCITYTYPE_EN")]
        public string PDCITYTYPEEN { get; set; }

        [JsonProperty("POSTINDEX")]
        public string POSTINDEX { get; set; }

        [JsonProperty("SHORTCITYTYPE_EN")]
        public string SHORTCITYTYPEEN { get; set; }

        [JsonProperty("MEREZA_NUMBER")]
        public string MEREZANUMBER { get; set; }

        [JsonProperty("POLOCK_UA")]
        public string POLOCKUA { get; set; }

        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("STREETTYPE_RU")]
        public string STREETTYPERU { get; set; }

        [JsonProperty("CITYTYPE_UA")]
        public string CITYTYPEUA { get; set; }

        [JsonProperty("POSTREET_ID")]
        public string POSTREETID { get; set; }

        [JsonProperty("NEW_DISTRICT_UA")]
        public string NEWDISTRICTUA { get; set; }

        [JsonProperty("PO_LONG")]
        public string POLONG { get; set; }

        [JsonProperty("PDCITY_UA")]
        public string PDCITYUA { get; set; }

        [JsonProperty("POLOCK_RU")]
        public string POLOCKRU { get; set; }

        [JsonProperty("PO_SHORT")]
        public string POSHORT { get; set; }

        [JsonProperty("LOCK_RU")]
        public string LOCKRU { get; set; }

        [JsonProperty("TYPE_LONG")]
        public string TYPELONG { get; set; }

        [JsonProperty("TYPE_ACRONYM")]
        public string TYPEACRONYM { get; set; }

        [JsonProperty("PARENT_ID")]
        public string PARENTID { get; set; }

        [JsonProperty("TECHINDEX")]
        public string TECHINDEX { get; set; }

        [JsonProperty("REGION_UA")]
        public string REGIONUA { get; set; }

        [JsonProperty("PDCITY_ID")]
        public string PDCITYID { get; set; }

        [JsonProperty("PDCITYTYPE_RU")]
        public string PDCITYTYPERU { get; set; }

        [JsonProperty("IS_NODISTRICT")]
        public string ISNODISTRICT { get; set; }

        [JsonProperty("DISTRICT_UA")]
        public string DISTRICTUA { get; set; }

        [JsonProperty("PO_CODE")]
        public string POCODE { get; set; }

        [JsonProperty("ADDRESS")]
        public string ADDRESS { get; set; }

        [JsonProperty("SHORTCITYTYPE_UA")]
        public string SHORTCITYTYPEUA { get; set; }

        [JsonProperty("PODISTRICT_ID")]
        public string PODISTRICTID { get; set; }

        [JsonProperty("LOCK_EN")]
        public string LOCKEN { get; set; }

        [JsonProperty("PDOLDCITYNAME_EN")]
        public string PDOLDCITYNAMEEN { get; set; }

        [JsonProperty("POSTCODE")]
        public string POSTCODE { get; set; }

        [JsonProperty("PDCITY_EN")]
        public string PDCITYEN { get; set; }

        [JsonProperty("PHONE")]
        public string PHONE { get; set; }

        [JsonProperty("LONGITUDE")]
        public string LONGITUDE { get; set; }

        [JsonProperty("STREET_UA")]
        public string STREETUA { get; set; }

        [JsonProperty("REGION_EN")]
        public string REGIONEN { get; set; }

        [JsonProperty("PDREGION_ID")]
        public string PDREGIONID { get; set; }

        [JsonProperty("SHORTPDCITYTYPE_UA")]
        public string SHORTPDCITYTYPEUA { get; set; }

        [JsonProperty("STREETTYPE_UA")]
        public string STREETTYPEUA { get; set; }

        [JsonProperty("LOCK_UA")]
        public string LOCKUA { get; set; }

        [JsonProperty("ISVPZ")]
        public string ISVPZ { get; set; }

        [JsonProperty("PDOLDCITYNAME_UA")]
        public string PDOLDCITYNAMEUA { get; set; }

        [JsonProperty("CITY_EN")]
        public string CITYEN { get; set; }

        [JsonProperty("STREET_EN")]
        public string STREETEN { get; set; }

        [JsonProperty("LOCK_CODE")]
        public string LOCKCODE { get; set; }

        [JsonProperty("PDOLDCITYNAME_RU")]
        public string PDOLDCITYNAMERU { get; set; }

        [JsonProperty("CITYTYPE_RU")]
        public string CITYTYPERU { get; set; }

        [JsonProperty("REGION_RU")]
        public string REGIONRU { get; set; }

        [JsonProperty("POCITY_ID")]
        public string POCITYID { get; set; }

        [JsonProperty("PDCITY_RU")]
        public string PDCITYRU { get; set; }

        [JsonProperty("RESTRICTED_ACCESS")]
        public string RESTRICTEDACCESS { get; set; }

        [JsonProperty("PDCITYTYPE_UA")]
        public string PDCITYTYPEUA { get; set; }

        [JsonProperty("SHORTCITYTYPE_RU")]
        public string SHORTCITYTYPERU { get; set; }

        [JsonProperty("SHORTPDCITYTYPE_EN")]
        public string SHORTPDCITYTYPEEN { get; set; }

        [JsonProperty("STREETTYPE_EN")]
        public string STREETTYPEEN { get; set; }

        [JsonProperty("PDDISTRICT_ID")]
        public string PDDISTRICTID { get; set; }

        [JsonProperty("CITYTYPE_EN")]
        public string CITYTYPEEN { get; set; }

        [JsonProperty("HOUSENUMBER")]
        public string HOUSENUMBER { get; set; }

        [JsonProperty("LATTITUDE")]
        public string LATTITUDE { get; set; }

        [JsonProperty("STREET_RU")]
        public string STREETRU { get; set; }

        [JsonProperty("CITY_UA")]
        public string CITYUA { get; set; }

        [JsonProperty("DISTRICT_RU")]
        public string DISTRICTRU { get; set; }
    }

    public class Postoffices
    {
        [JsonProperty("Entry")]
        public List<Postoffice> Entry { get; set; }
    }

    public class PostofficesRoot
    {
        [JsonProperty("Entries")]
        public Postoffices Entries { get; set; }
    }
}
