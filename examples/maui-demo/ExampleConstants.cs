using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Orbyss.Components.Json.Models;

namespace Syncfusion.DynamicGrid.Demo
{
    internal static class ExampleConstants
    {
        public const string Data = "[{\"firstName\":\"Kevin\",\"surname\":\"Jackson\",\"dateOfBirth\":\"1954-08-26\",\"status\":\"Accepted\"},{\"firstName\":\"Bob\",\"surname\":\"Martin\",\"dateOfBirth\":\"1990-06-10\",\"status\":\"Pending\"},{\"firstName\":\"Paula\",\"surname\":\"Martin\",\"dateOfBirth\":\"1999-03-06\",\"status\":\"Pending\"},{\"firstName\":\"Zach\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1950-05-11\",\"status\":\"Pending\"},{\"firstName\":\"Laura\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2006-12-09\",\"status\":\"Rejected\"},{\"firstName\":\"Charlie\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1972-01-13\",\"status\":\"Pending\"},{\"firstName\":\"Rachel\",\"surname\":\"Thomas\",\"dateOfBirth\":\"1963-07-19\",\"status\":\"Accepted\"},{\"firstName\":\"Michael\",\"surname\":\"Williams\",\"dateOfBirth\":\"1961-12-19\",\"status\":\"Rejected\"},{\"firstName\":\"Samuel\",\"surname\":\"Moore\",\"dateOfBirth\":\"1960-07-18\",\"status\":\"Pending\"},{\"firstName\":\"Tina\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1988-10-01\",\"status\":\"Rejected\"},{\"firstName\":\"Kevin\",\"surname\":\"White\",\"dateOfBirth\":\"1990-10-08\",\"status\":\"Rejected\"},{\"firstName\":\"Diana\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2003-06-24\",\"status\":\"Pending\"},{\"firstName\":\"Wendy\",\"surname\":\"Smith\",\"dateOfBirth\":\"2009-08-18\",\"status\":\"Rejected\"},{\"firstName\":\"Oliver\",\"surname\":\"Moore\",\"dateOfBirth\":\"1986-07-07\",\"status\":\"Accepted\"},{\"firstName\":\"Zach\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1980-11-15\",\"status\":\"Rejected\"},{\"firstName\":\"Julia\",\"surname\":\"Jones\",\"dateOfBirth\":\"1980-06-29\",\"status\":\"Pending\"},{\"firstName\":\"Ian\",\"surname\":\"Martin\",\"dateOfBirth\":\"1986-01-25\",\"status\":\"Accepted\"},{\"firstName\":\"Victor\",\"surname\":\"Thompson\",\"dateOfBirth\":\"1954-03-05\",\"status\":\"Accepted\"},{\"firstName\":\"Hannah\",\"surname\":\"Martin\",\"dateOfBirth\":\"2003-01-28\",\"status\":\"Rejected\"},{\"firstName\":\"Laura\",\"surname\":\"Williams\",\"dateOfBirth\":\"1981-09-14\",\"status\":\"Rejected\"},{\"firstName\":\"Charlie\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1965-01-17\",\"status\":\"Accepted\"},{\"firstName\":\"George\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1987-08-17\",\"status\":\"Accepted\"},{\"firstName\":\"Tina\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2000-08-29\",\"status\":\"Pending\"},{\"firstName\":\"Hannah\",\"surname\":\"Smith\",\"dateOfBirth\":\"1994-01-08\",\"status\":\"Pending\"},{\"firstName\":\"Paula\",\"surname\":\"Garcia\",\"dateOfBirth\":\"1956-06-19\",\"status\":\"Accepted\"},{\"firstName\":\"Ian\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1993-01-12\",\"status\":\"Rejected\"},{\"firstName\":\"Samuel\",\"surname\":\"Davis\",\"dateOfBirth\":\"1955-05-23\",\"status\":\"Rejected\"},{\"firstName\":\"Paula\",\"surname\":\"Martin\",\"dateOfBirth\":\"1960-09-20\",\"status\":\"Rejected\"},{\"firstName\":\"Charlie\",\"surname\":\"Moore\",\"dateOfBirth\":\"1966-12-27\",\"status\":\"Pending\"},{\"firstName\":\"Oliver\",\"surname\":\"Martin\",\"dateOfBirth\":\"1974-06-27\",\"status\":\"Accepted\"},{\"firstName\":\"Tina\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2010-09-30\",\"status\":\"Accepted\"},{\"firstName\":\"Tina\",\"surname\":\"Davis\",\"dateOfBirth\":\"1973-03-29\",\"status\":\"Pending\"},{\"firstName\":\"Xander\",\"surname\":\"Garcia\",\"dateOfBirth\":\"1987-05-12\",\"status\":\"Rejected\"},{\"firstName\":\"Nina\",\"surname\":\"Martinez\",\"dateOfBirth\":\"2003-03-12\",\"status\":\"Accepted\"},{\"firstName\":\"Ethan\",\"surname\":\"Brown\",\"dateOfBirth\":\"1975-12-12\",\"status\":\"Accepted\"},{\"firstName\":\"Diana\",\"surname\":\"Smith\",\"dateOfBirth\":\"1996-09-02\",\"status\":\"Rejected\"},{\"firstName\":\"Alice\",\"surname\":\"Taylor\",\"dateOfBirth\":\"1972-05-12\",\"status\":\"Accepted\"},{\"firstName\":\"Bob\",\"surname\":\"Anderson\",\"dateOfBirth\":\"1996-12-25\",\"status\":\"Rejected\"},{\"firstName\":\"Kevin\",\"surname\":\"Davis\",\"dateOfBirth\":\"1962-05-30\",\"status\":\"Rejected\"},{\"firstName\":\"Nina\",\"surname\":\"White\",\"dateOfBirth\":\"1952-12-10\",\"status\":\"Accepted\"},{\"firstName\":\"Ian\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1999-08-15\",\"status\":\"Rejected\"},{\"firstName\":\"George\",\"surname\":\"Thomas\",\"dateOfBirth\":\"1996-12-29\",\"status\":\"Pending\"},{\"firstName\":\"Yvonne\",\"surname\":\"Davis\",\"dateOfBirth\":\"1976-01-18\",\"status\":\"Rejected\"},{\"firstName\":\"Quentin\",\"surname\":\"Martin\",\"dateOfBirth\":\"1968-02-13\",\"status\":\"Rejected\"},{\"firstName\":\"Fiona\",\"surname\":\"Jackson\",\"dateOfBirth\":\"2006-07-17\",\"status\":\"Pending\"},{\"firstName\":\"Diana\",\"surname\":\"Hernandez\",\"dateOfBirth\":\"1979-12-11\",\"status\":\"Rejected\"},{\"firstName\":\"Alice\",\"surname\":\"Thompson\",\"dateOfBirth\":\"1960-11-30\",\"status\":\"Pending\"},{\"firstName\":\"Victor\",\"surname\":\"Jackson\",\"dateOfBirth\":\"1980-04-02\",\"status\":\"Accepted\"},{\"firstName\":\"Samuel\",\"surname\":\"Anderson\",\"dateOfBirth\":\"1992-01-26\",\"status\":\"Pending\"},{\"firstName\":\"Wendy\",\"surname\":\"Smith\",\"dateOfBirth\":\"1980-02-15\",\"status\":\"Rejected\"}]";

        public static readonly JSchema JsonSchema = JSchema.Parse(jsonSchema);

        public static readonly TableUiSchema TableUiSchema = DefaultJsonConverter.Deserialize<TableUiSchema>(uiSchema);

        public static readonly TranslationSchema TranslationSchema = DefaultJsonConverter.Deserialize<TranslationSchema>(translationSchema);

        private const string jsonSchema = @"
            {
                ""properties"":{
                    ""firstName"": {
                        ""type"": ""string""
                    },
                    ""surname"": {
                        ""type"": ""string""
                    },
                    ""dateOfBirth"": {
                        ""type"": ""string"",
                        ""format"": ""date""
                    },
                    ""status"": {
                        ""type"": ""string"",
                        ""enum"": [
                            ""Pending"",
                            ""Accepted"",
                            ""Rejected""
                        ]
                    }
                }
            }";

        private const string uiSchema = @"
        {
            ""initialOrdering"":{
                ""direction"": ""descending"",
                ""scope"": ""$.properties.dateOfBirth""
            },
             ""columns"":{        
                 ""globalLayout"":{
                     ""width"": ""120"",
                     ""alignment"":{
                         ""horizontal"": ""right""
                     }
                 },
                 ""items"":[
                     {
                         ""label"": ""CustomFirstNameLabel"",
                         ""scope"": ""$.properties.firstName"",
                         ""sortable"": true,
                         ""filter"":{
                             ""types"":[
                                 ""header""
                             ],
                             ""rule"": ""StartsWith""
                         }
                     },
                     {
                         ""scope"": ""$.properties.surname"",
                         ""sortable"": true,
                         ""filter"":{
                             ""types"":[
                                 ""header""
                             ],
                             ""rule"": ""EndsWith""
                         }
                     },
                      {
                         ""scope"": ""$.properties.dateOfBirth"",
                         ""sortable"": true
                     },
                     {
                         ""scope"": ""$.properties.status"",
                         ""sortable"": true,
                         ""layout"": {
                             ""width"": ""60"",
                             ""alignment"":{
                                 ""horizontal"": ""left""
                             }
                         }
                     }
                 ]
             }
         }";

        private const string translationSchema = @"
        {
            ""resources"":{
                ""en"":{
                    ""translation"":{
                        ""CustomFirstNameLabel"": ""First name!"",
                        ""surname"": ""Last name"",
                        ""dateOfBirth"":{
                            ""label"": ""Date of birth""
                        },
                        ""status"":{
                            ""label"": ""Status of person""                    
                        }
                    }
                },
                ""nl"":{
                    ""translation"":{
                        ""CustomFirstNameLabel"": ""Voornaam !"",
                        ""surname"": ""Achternaam"",
                        ""dateOfBirth"":{
                            ""label"": ""Geboorte datum""
                        },
                        ""status"":{
                            ""label"": ""Persoon status"",
                            ""Pending"": ""Afwachten"",
                            ""Accepted"": ""Goedgekeurd"",
                            ""Rejected"": ""Afgekeurd""
                        }
                    }
                }
            }
        }";
    }
}