namespace EFDataLayer.Migrations
{
    using MinistrySuite.Entities;
    using MinistrySuite.Enums;
    using MinistrySuite.SecondaryEntities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDataLayer.ChurchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
           
        }

        protected override void Seed(EFDataLayer.ChurchContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            List<string> churches = new List<string>{
                "St. Gabriel",
                "St. Sabina",
                "Our Lady of the Presentation",
                "St. Dominic"
            };
            churches.ForEach(s => context.Churches.AddOrUpdate(Church.Create(s)));
            context.SaveChanges();



            List<Ministry> ministries = new List<Ministry>
            {
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        name: "Lector",
                        description: "Proclaiming the Word of God at Mass."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        name: "Psalmist",
                        description: "Proclaiming the responsorial Psalm at Mass."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        name: "Sacristan",
                        description: "Making all preparations before the weekend Masses."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        name: "Lector",
                        description: "Proclaiming the Word of God at Mass."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        name: "Usher",
                        description: "Welcoming people into the church every Sunday and helping them find a seat."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        name: "Altar Society",
                        description: "Preparing the altar linens."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        name: "Knights of Columbus",
                        description: "Raising money for needy children, provided dounuts and coffee and fish frys."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        name: "Lector",
                        description: "Proclaiming the Word of God at Mass."
                    ),
                 Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        name: "Cantor",
                        description: "Leading the Assmebly in song."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        name: "Cantor",
                        description: "Leading the Assmebly in song."
                    ),
                Ministry.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        name: "Cantor",
                        description: "Leading the Assmebly in song."
                    ),
            };
            ministries.ForEach(m => context.Ministries.AddOrUpdate(m));
            context.SaveChanges();

            List<ChurchMember> members = new List<ChurchMember>
            {
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        firstName: "Jefferson",
                        lastName: "Williams",
                        dob: new DateTimeOffset(new DateTime(1986, 6, 12)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "St. Dominic").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        firstName: "Sally",
                        lastName: "Franklin",
                        dob: new DateTimeOffset(new DateTime(1980, 2, 12)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "St. Gabriel").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        firstName: "Harry",
                        lastName: "Jones",
                        dob: new DateTimeOffset(new DateTime(1970, 5, 19)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        firstName: "Lillian",
                        lastName: "Reardeb",
                        dob: new DateTimeOffset(new DateTime(1960, 11, 29)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        firstName: "Doug",
                        lastName: "Wilson",
                        dob: new DateTimeOffset(new DateTime(1980, 2, 12)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "St. Gabriel").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        firstName: "Balanca",
                        lastName: "Fredrickson",
                        dob: new DateTimeOffset(new DateTime(1970, 5, 19)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                ChurchMember.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        firstName: "Jane",
                        lastName: "Gillmore",
                        dob: new DateTimeOffset(new DateTime(1960, 11, 29)),
                        ministries: ministries.Where(m=> m.ChurchId == context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id).ToList()
                    )
            };
            members.ForEach(m => m.Addresses = new List<ChurchMemberAddress>
            {
               ChurchMemberAddress.Create(m.Id, true, AddressType.Business, "123 Main", "KC", "MO", "64555"),
               ChurchMemberAddress.Create(m.Id, false, AddressType.Work, "123 Fillmore", "Leawood", "KS", "66226")
            });
            members.ForEach(m => m.EmailAddresses = new List<ChurchMemberEmailAddress> {
                ChurchMemberEmailAddress.Create(m.Id, false, EmailAddressType.Personal, m.FirstName + m.LastName +"@gmail.com"),
                ChurchMemberEmailAddress.Create(m.Id, true, EmailAddressType.Work, m.FirstName + m.LastName +"_work@gmail.com")
            });
            members.ForEach(m => m.PhoneNumbers = new List<ChurchMemberPhoneNumber> { 
                ChurchMemberPhoneNumber.Create(m.Id, false, "9134568779"),
                ChurchMemberPhoneNumber.Create(m.Id, true, "9132256556")
            });
            members.ForEach(m => context.ChurchMemebrs.AddOrUpdate(m));
            context.SaveChanges();

            List<PrayerRequest> prayerRequests = new List<PrayerRequest>
            {
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        title: "Fransico D'Anconia's cataract surgery.",
                        request: "Fransico's cataracts will be removed Sunday.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 29)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 2)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Dominic").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        title: "Bob Jenkins' back spasms.",
                        request: "Bob's been immobile due to severely painful back spasms.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 23)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 2)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Dominic").First().Id && m.Name == "Sacristan").ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        title: "FELECITY'S cat's gall stones.",
                        request: "Pray the FELECITY'S cat's gall stones will go away.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 24)),
                        endDate: new DateTimeOffset(new DateTime(2016, 4, 25)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Dominic").First().Id && m.Name == "Sacristan").ToList()
                    ),
                 PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Dominic").First().Id,
                        title: "Zelma's big job interview.",
                        request: "Bob's been immobile due to severely painful back spasms.",
                        startDate: new DateTimeOffset(new DateTime(2016, 5, 12)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 12)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Dominic").First().Id && m.Name == "Sacristan").ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        title: "Mary's Heart Surgery",
                        request: "Mary's having open heart surgery on Monday. Will be in North KC Hospital.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 23)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 2)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id,
                        title: "Judy's hip replacement.",
                        request: "Judy's having her hip replaced on Sunday at KU Med.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 27)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 1)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "Our Lady of the Presentation").First().Id).ToList()
                    ),

                    PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Gary's child's asthma",
                        request: "John, Gary's youngest child, has had asthma attacks with increased frequency.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 23)),
                        endDate: new DateTimeOffset(new DateTime(2016, 7, 2)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Mary Johnson's burglary",
                        request: "Mary Johnson's house was broken into 4/22/2016. Pray that the burglar will be caught and her belongings returned.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 22)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 1)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Cathy broke her leg.",
                        request: "Cathy slipped on the ice and broke her leg.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 25)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 1)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                 PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Jack's interview.",
                        request: "Jack has a very important interview.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        endDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id).ToList()
                    ),
                 PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Katie Franks trip.",
                        request: "Pray for safe travels for Katie Frank She'll be going to the middle east.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 12)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id && m.Name == "Usher").ToList()
                    ),
                 PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Judy gets food poisoning.",
                        request: "Judy has been in the hospital with food poisoning.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        endDate: new DateTimeOffset(new DateTime(2016, 4, 30)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id && m.Name == "Usher").ToList()
                    ),

                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        title: "Churck's gall stones",
                        request: "Chuck has been having gall stones.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 21)),
                        endDate: new DateTimeOffset(new DateTime(2016, 5, 2)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Gabriel").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        title: "Nancy's sister's dementia",
                        request: "Betty, Nancy's sister, her dementia has been worsening. She may have to be checked into a nursing home if Nancy can no longer take care of her.",
                        startDate: new DateTimeOffset(new DateTime(2016, 1, 22)),
                        endDate: new DateTimeOffset(new DateTime(2016, 7, 1)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Gabriel").First().Id).ToList()
                    ),
                PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Gabriel").First().Id,
                        title: "Margaret Jones was stung by a scorpion.",
                        request: "Margaret has been in a coma. Pray that she comes to.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        endDate: new DateTimeOffset(new DateTime(2016, 4, 29)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Gabriel").First().Id && m.Name == "Usher").ToList()
                    ),
                    PrayerRequest.Create(
                        churchId: context.Churches.Where(c => c.Name == "St. Sabina").First().Id,
                        title: "Sady Franklin fell in the bathtub.",
                        request: "Sady possible busted up her hip. Had an MRI at KU med, awaiting results.",
                        startDate: new DateTimeOffset(new DateTime(2016, 4, 28)),
                        endDate: new DateTimeOffset(new DateTime(2016, 4, 29)),
                        ministries: ministries.Where(m => m.ChurchId == context.Churches.Where(c => c.Name == "St. Sabina").First().Id && m.Name == "Usher").ToList()
                    )
            };
            prayerRequests.ForEach(pr => context.PrayerRequests.AddOrUpdate(pr));
            context.SaveChanges();
        }
    }
}
