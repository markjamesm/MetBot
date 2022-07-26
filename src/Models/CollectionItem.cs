namespace MetBot.Models
{
    public class Constituent
    {
        public int constituentID { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string constituentULAN_URL { get; set; }
        public string constituentWikidata_URL { get; set; }
        public string gender { get; set; }
    }

    public class ElementMeasurements
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }

    public class Measurement
    {
        public string elementName { get; set; }
        public object elementDescription { get; set; }
        public ElementMeasurements elementMeasurements { get; set; }
    }

    // The root class
    public class CollectionItem
    {
        public int objectID { get; set; }
        public bool isHighlight { get; set; }
        public string accessionNumber { get; set; }
        public string accessionYear { get; set; }
        public bool isPublicDomain { get; set; }
        public string primaryImage { get; set; }
        public string primaryImageSmall { get; set; }
        public List<string> additionalImages { get; set; }
        public List<Constituent> constituents { get; set; }
        public string department { get; set; }
        public string objectName { get; set; }
        public string title { get; set; }
        public string culture { get; set; }
        public string period { get; set; }
        public string dynasty { get; set; }
        public string reign { get; set; }
        public string portfolio { get; set; }
        public string artistRole { get; set; }
        public string artistPrefix { get; set; }
        public string artistDisplayName { get; set; }
        public string artistDisplayBio { get; set; }
        public string artistSuffix { get; set; }
        public string artistAlphaSort { get; set; }
        public string artistNationality { get; set; }
        public string artistBeginDate { get; set; }
        public string artistEndDate { get; set; }
        public string artistGender { get; set; }
        public string artistWikidata_URL { get; set; }
        public string artistULAN_URL { get; set; }
        public string objectDate { get; set; }
        public int objectBeginDate { get; set; }
        public int objectEndDate { get; set; }
        public string medium { get; set; }
        public string dimensions { get; set; }
        public List<Measurement> measurements { get; set; }
        public string creditLine { get; set; }
        public string geographyType { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public string locale { get; set; }
        public string locus { get; set; }
        public string excavation { get; set; }
        public string river { get; set; }
        public string classification { get; set; }
        public string rightsAndReproduction { get; set; }
        public string linkResource { get; set; }
        public DateTime metadataDate { get; set; }
        public string repository { get; set; }
        public string objectURL { get; set; }
        public List<Tag> tags { get; set; }
        public string objectWikidata_URL { get; set; }
        public bool isTimelineWork { get; set; }
        public string GalleryNumber { get; set; }
    }

    public class Tag
    {
        public string term { get; set; }
        public string AAT_URL { get; set; }
        public string Wikidata_URL { get; set; }
    }
}
