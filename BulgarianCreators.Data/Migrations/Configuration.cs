namespace BulgarianCreators.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BulgarianCreators.Data.CreatorsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BulgarianCreators.Data.CreatorsDbContext context)
        {
            return;

            var countriesAsString =
                @"Andorra;United Arab Emirates;Afghanistan;Antigua and Barbuda;Anguilla;Albania;Armenia;Angola;Antarctica;Argentina;    
                    American Samoa;Austria;Australia;Aruba;Åland Islands;Azerbaijan;Bosnia and Herzegovina;Barbados;Bangladesh;Belgium;
                    Burkina Faso;Bulgaria;Bahrain;Burundi;Benin;Saint Barthélemy;Bermuda;Brunei Darussalam;Bolivia;Caribbean Netherlands;
                    Brazil;Bahamas;Bhutan;Bouvet Island;Botswana;Belarus;Belize;Canada;Cocos (Keeling) Islands;Congo, Democratic Republic of;
                    Central African Republic;Congo;Switzerland;Côte d'Ivoire;Cook Islands;Chile;Cameroon;China;Colombia;Costa Rica;Cuba;Cape Verde;
                    Curaçao;Christmas Island;Cyprus;Czech Republic;Germany;Djibouti;Denmark;Dominica;Dominican Republic;Algeria;Ecuador;Estonia;Egypt;
                    Western Sahara;Eritrea;Spain;Ethiopia;Finland;Fiji;Falkland Islands;Micronesia, Federated States of;Faroe Islands;France;Gabon;
                    United Kingdom;Grenada;Georgia;French Guiana;Guernsey;Ghana;Gibraltar;Greenland;Gambia;Guinea;Guadeloupe;Equatorial Guinea;Greece;
                    South Georgia and the South Sandwich Islands;Guatemala;Guam;Guinea-Bissau;Guyana;Hong Kong;Heard and McDonald Islands;Honduras;Croatia;
                    Haiti;Hungary;Indonesia;Ireland;Israel;Isle of Man;India;British Indian Ocean Territory;Iraq;Iran;Iceland;Italy;Jersey;Jamaica;Jordan;Japan;
                    Kenya;Kyrgyzstan;Cambodia;Kiribati;Comoros;Saint Kitts and Nevis;North Korea;South Korea;Kuwait;Cayman Islands;Kazakhstan;Lao People's Democratic Republic;
                    Lebanon;Saint Lucia;Liechtenstein;Sri Lanka;Liberia;Lesotho;Lithuania;Luxembourg;Latvia;Libya;Morocco;Monaco;Moldova;Montenegro;Saint-Martin (France);
                    Madagascar;Marshall Islands;Macedonia;Mali;Myanmar;Mongolia;Macau;Northern Mariana Islands;Martinique;Mauritania;Montserrat;Malta;Mauritius;Maldives;
                    Malawi;Mexico;Malaysia;Mozambique;Namibia;New Caledonia;Niger;Norfolk Island;Nigeria;Nicaragua;The Netherlands;Norway;Nepal;Nauru;Niue;New Zealand;Oman;
                    Panama;Peru;French Polynesia;Papua New Guinea;Philippines;Pakistan;Poland;St. Pierre and Miquelon;Pitcairn;Puerto Rico;Palestine, State of;Portugal;Palau;
                    Paraguay;Qatar;Réunion;Romania;Serbia;Russian Federation;Rwanda;Saudi Arabia;Solomon Islands;Seychelles;Sudan;Sweden;Singapore;Saint Helena;Slovenia;
                    Svalbard and Jan Mayen Islands;Slovakia;Sierra Leone;San Marino;Senegal;Somalia;Suriname;South Sudan;Sao Tome and Principe;El Salvador;Sint Maarten (Dutch part);
                    Syria;Swaziland;Turks and Caicos Islands;Chad;French Southern Territories;Togo;Thailand;Tajikistan;Tokelau;Timor-Leste;Turkmenistan;Tunisia;Tonga;Turkey;
                    Trinidad and Tobago;Tuvalu;Taiwan;Tanzania;Ukraine;Uganda;United States Minor Outlying Islands;United States;Uruguay;Uzbekistan;Vatican;Saint Vincent and the Grenadines;
                    Venezuela;Virgin Islands (British);Virgin Islands (U.S.);Vietnam;Vanuatu;Wallis and Futuna Islands;Samoa;Yemen;Mayotte;South Africa;Zambia;Zimbabwe"
                    .Split(new char[] { ';' });

            IList<Country> countries = new List<Country>();

            for (int i = 0; i < countriesAsString.Length; i++)
            {
                countries.Add(new Country() { Id = Guid.NewGuid(), CountryName = countriesAsString[i].Trim() });
            }
            context.Countries.AddOrUpdate(countries.ToArray());

            IList<Category> categories = new List<Category>()
            {
                new Category() { Id = Guid.NewGuid(), CategoryName = "Film and animation" },
                new Category() { Id = Guid.NewGuid(), CategoryName = "Music" },
                new Category() { Id = Guid.NewGuid(), CategoryName = "Travel" },
                new Category() { Id = Guid.NewGuid(), CategoryName = "People and Blogs" },
                new Category() { Id = Guid.NewGuid(), CategoryName = "Education" },
                new Category() { Id = Guid.NewGuid(), CategoryName = "Lifestyle" }
            };
            context.Categories.AddOrUpdate(categories.ToArray());

            IList<Comment> comments = new List<Comment>()
            {
                new Comment() {Id=Guid.NewGuid(), commentBody="Really nice, show us some more!!", PostedOn=DateTime.Now},
                new Comment() {Id=Guid.NewGuid(), commentBody="You suck man! trolololo", PostedOn=DateTime.Now}
            };

            IList<Post> posts = new List<Post>()
            {
                new Post() { Id = Guid.NewGuid(),
                    Title = "Check out my new video",
                    ImageUrl = "http://thevideoanalyst.com/wp-content/uploads/2016/05/video-conference.jpg",
                    Comments = new List<Comment>() { comments[0], comments[1] },
                    Category = categories[1],
                    PostedOn = DateTime.Now,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Post() { Id = Guid.NewGuid(),
                    Title = "Traveling to Zimbabwe",
                    ImageUrl = "http://www.heartofavagabond.com/wp-content/uploads/2014/03/10-Common-Travel-Mistakes-You-Can-Avoid.jpg?x11395",
                    Category = categories[2],
                    PostedOn = DateTime.Now,
                    Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                }
            };

            context.Posts.AddOrUpdate(posts.ToArray());
        }
    }
}
