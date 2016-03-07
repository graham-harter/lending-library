namespace LendingLibrary.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LendingLibrary.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<LendingLibrary.Data.LendingLibraryContext>
    {
        private readonly IList<MediumValue> MediumValues = new List<MediumValue>();
        private readonly IDictionary<MediumValue, int> MediumId = new Dictionary<MediumValue, int>();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            // Generate lookup data.
            this.GenerateMediumLookupData();
        }

        protected override void Seed(LendingLibrary.Data.LendingLibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Create media
            context.MediumSet.AddOrUpdate(m => m.ID, GenerateMedia());

            // Create titles
            context.TitleSet.AddOrUpdate(t => t.Name, GenerateTitles());
        }

        private void GenerateMediumLookupData()
        {
            var mediumValues = Enum.GetValues(typeof(MediumValue)).Cast<MediumValue>().ToList();

            // Make this ordered list available to the object.
            this.MediumValues.Clear();
            mediumValues.ForEach(m => this.MediumValues.Add(m));

            // Generate the reverse lookup.
            this.MediumId.Clear();
            int i = 1;
            mediumValues.ForEach(m => this.MediumId.Add(m, i++));
        }

        private Medium[] GenerateMedia()
        {
            var media = new List<Medium>();
            this.MediumValues.ToList().ForEach(m => media.Add(
                new Medium() { Name = m.ToString() }
                ));

            return media.ToArray();
        }

        private Title[] GenerateTitles()
        {
            var titles = new Title[]
            {
                new Title()
                {
                    MediumId = this.MediumId[MediumValue.Hardback],
                    Name = "Ante-Nicene Fathers Vol. 1",
                    Subtitle = "The Apostolic Fathers with Justin Martyr and Irenaeus v. 1: The Writings of the Fathers Down to A.D.325 (Early Church Fathers)",
                    Author = "A. Cleveland Coxe (editor)",
                    Publisher = "William B Eerdmans Publishing Co.",
                    Year = 1980,
                    ImageURL = @"http://ecx.images-amazon.com/images/I/41J23C8M5HL._SX316_BO1,204,203,200_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.Hardback],
                    Name = "Against the Heresies, Book 1",
                    Subtitle = "Ancient Christian Writers No. 55",
                    Author = "St. Irenaeus of Lyons; Dominic J. Unger",
                    Publisher = "Paulist Press",
                    Year = 1991,
                    ImageURL = @"http://ecx.images-amazon.com/images/I/41g13mH-6AL._SX294_BO1,204,203,200_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.Paperback],
                    Name = "Anna Karenina",
                    Author = "Leo Tolstoy; Richard Pevear",
                    Publisher = "Penguin Classics",
                    Year = 2003,
                    ImageURL = @"http://ecx.images-amazon.com/images/I/41IwGXSRMSL._SX324_BO1,204,203,200_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.Paperback],
                    Name = "St. Antony of the Desert",
                    Author = "St. Athanasius",
                    Publisher = "TAN Books",
                    ImageURL = @"http://ecx.images-amazon.com/images/I/513nizoaU7L._SX302_BO1,204,203,200_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.Hardback],
                    Name = "Proof of the Apostolic Preaching",
                    Subtitle = "Ancient Christian Writers No. 16",
                    Author = "St. Irenaeus of Lyons; Joseph P. Smith, SJ",
                    Publisher = "Paulist Press",
                    Year = 1978,
                    ImageURL = @"http://ecx.images-amazon.com/images/I/41W8Q1ZXA0L._SX299_BO1,204,203,200_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.DVD],
                    Name = "Skyfall",
                    Author = "Sam Mendes",
                    Publisher = "Metro-Goldwyn-Mayer",
                    Year = 2013,
                    ImageURL = @"http://ecx.images-amazon.com/images/I/71kVLSKFghL._SY550_.jpg"
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.DVD],
                    Name = "Goldeneye",
                    Author = "Martin Campbell",
                    Publisher = "Metro-Goldwyn-Mayer",
                    Year = 1995
                },

                new Title()
                {
                    MediumId = this.MediumId[MediumValue.CD],
                    Name = "Trout Mask Replica",
                    Author = "Captain Beefheart & His Magic Band",
                    Publisher = "Reprise",
                    ImageURL = @"http://ecx.images-amazon.com/images/I/51sBFJYnq6L._SX425_.jpg"
                }
            };

            return titles;
        }

        #region Private enum MediumValue
        private enum MediumValue
        {
            Hardback,
            Paperback,
            eBook,
            DVD,
            BluRay,
            CD
        }
        #endregion
    }
}
